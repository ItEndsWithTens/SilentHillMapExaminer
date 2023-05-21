using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace SHME.ExternalTool
{
	public static class PolygonExtensions
	{
		public static Polygon ClipAgainstPlane(this Polygon p, Plane plane)
		{
			if (p.Vertices.Count == 0)
			{
				return p;
			}

			var clipped = new Polygon(p);
			clipped.Vertices.Clear();
			clipped.Edges.Clear();

			var points = new List<Vertex>();

			for (int i = 0; i < p.Vertices.Count; i++)
			{
				int idxA = i;
				int idxB = (i + 1) % p.Vertices.Count;

				Vertex a = p.Vertices[idxA];
				Vertex b = p.Vertices[idxB];

				(a, b, bool visible) = (a, b).ClipVertexPairAgainstPlane(plane);

				if (!visible)
				{
					continue;
				}

				points.Add(a);
				points.Add(b);
			}

			for (int i = 0; i < points.Count; i++)
			{
				Vertex point = points[i];
				if (!clipped.Vertices.Contains(point))
				{
					clipped.Vertices.Add(point);
				}
			}

			for (int i = 0; i < clipped.Vertices.Count; i++)
			{
				clipped.Edges.Add((
					i,
					(i + 1) % clipped.Vertices.Count,
					true));
			}

			return clipped;
		}

		public static (Vertex, Vertex, bool) ClipVertexPairAgainstPlane(this (Vertex a, Vertex b) pair, Plane plane)
		{
			Vector3 p = plane.A;
			Vector3 n = plane.Normal;

			float distanceA = Vector3.Dot(pair.a.Position - p, n);
			float distanceB = Vector3.Dot(pair.b.Position - p, n);

			bool aBehind = distanceA <= 0.0f;
			bool bBehind = distanceB <= 0.0f;

			if (aBehind && bBehind)
			{
				return (pair.a, pair.b, false);
			}

			if (!aBehind && !bBehind)
			{
				return (pair.a, pair.b, true);
			}

			float factor = distanceA / (distanceA - distanceB);

			Vector3 intersection = pair.a.Position + (pair.b.Position - pair.a.Position) * factor;

			if (aBehind)
			{
				var clipped = new Vertex(pair.a) { Position = intersection };
				return (clipped, pair.b, true);
			}
			else
			{
				var clipped = new Vertex(pair.b) { Position = intersection };
				return (pair.a, clipped, true);
			}
		}

		public static Polygon Rotate(this Polygon polygon, float pitch, float yaw, float roll, Vector3 origin)
		{
			if (pitch < 0.0f)
			{
				pitch = Math.Abs(pitch);
			}
			else
			{
				pitch = 360.0f - pitch;
			}

			Matrix4x4 rotZ = Matrix4x4.CreateRotationZ(MathUtilities.DegreesToRadians(pitch), origin);
			Matrix4x4 rotY = Matrix4x4.CreateRotationY(MathUtilities.DegreesToRadians(yaw), origin);
			Matrix4x4 rotX = Matrix4x4.CreateRotationX(MathUtilities.DegreesToRadians(roll), origin);

			Matrix4x4 rotation = rotZ * rotY * rotX;

			var p = new Polygon(polygon);
			p.BasisS = Vector3.Transform(p.BasisS, rotation);
			p.BasisT = Vector3.Transform(p.BasisT, rotation);
			p.Normal = Vector3.Transform(p.Normal, rotation);

			for (int i = 0; i < p.Vertices.Count; i++)
			{
				Vertex world = p.Vertices[i].ModelToWorld(p.Renderable.ModelMatrix);
				var rotated = Vertex.Rotate(world, pitch, yaw, roll, origin);
				p.Vertices[i] = rotated.WorldToModel(p.Renderable.ModelMatrix);
			}

			return p;
		}

		public static Polygon Scale(this Polygon polygon, float x, float y, float z)
		{
			var scaled = new Polygon(polygon);

			for (int i = 0; i < scaled.Vertices.Count; i++)
			{
				Vertex v = scaled.Vertices[i];

				v.Position = new Vector3
				{
					X = v.Position.X * x,
					Y = v.Position.Y * y,
					Z = v.Position.Z * z
				};

				scaled.Vertices[i] = v;
			}

			// TODO: Understand, and explain in a comment, why the basis
			// vectors need to be divided by the scale instead of multiplied
			// like the vertex positions. I figured this out by observation,
			// and honestly have no idea why it works.

			scaled.BasisS = new Vector3
			{
				X = scaled.BasisS.X / x,
				Y = scaled.BasisS.Y / y,
				Z = scaled.BasisS.Z / z
			};

			scaled.BasisT = new Vector3
			{
				X = scaled.BasisT.X / x,
				Y = scaled.BasisT.Y / y,
				Z = scaled.BasisT.Z / z
			};

			return scaled;
		}

		public static Polygon TranslateRelative(this Polygon polygon, Vector3 diff)
		{
			var p = new Polygon(polygon);

			for (int i = 0; i < p.Vertices.Count; i++)
			{
				p.Vertices[i] = Vertex.TranslateRelative(p.Vertices[i], diff);
			}

			// The dot product projects one vector onto another, in essence
			// describing how far along one of them the other is. That gives the
			// relative offset on the respective basis vector, though v.
			p.Offset.X -= Vector3.Dot(diff, p.BasisS) / p.Scale.X;
			p.Offset.Y -= Vector3.Dot(diff, p.BasisT) / p.Scale.Y;

			return p;
		}
		public static Polygon TranslateRelative(this Polygon polygon, float diffX, float diffY, float diffZ)
		{
			return TranslateRelative(polygon, new Vector3(diffX, diffY, diffZ));
		}
	}

	public class Polygon
	{
		public IList<Vertex> Vertices { get; } = new List<Vertex>();

		public IList<(int, int, bool)> Edges { get; } = new List<(int, int, bool)>();

		/// <summary>
		/// The name of the texture meant to be applied to this polygon; if said
		/// texture isn't loaded, a placeholder will be used for CurrentTexture.
		/// </summary>
		public string IntendedTextureName { get; set; } = String.Empty;

		public Vector3 BasisS;
		public Vector3 BasisT;
		public Vector2 Offset;
		public float Rotation;
		public Vector2 Scale;

		public Vector3 Normal;

		private Color _color = Color.White;
		public Color Color
		{
			get => _color;
			set
			{
				_color = value;

				for (int i = 0; i < Vertices.Count; i++)
				{
					Vertex v = Vertices[i];
					v.Color = _color;

					Vertices[i] = v;
				}
			}
		}

		public Renderable Renderable { get; set; }

		public Polygon(Renderable r)
		{
			Renderable = r;
		}
		public Polygon(Polygon p)
		{
			Renderable = p.Renderable;
			IntendedTextureName = p.IntendedTextureName;
			BasisS = new Vector3(p.BasisS.X, p.BasisS.Y, p.BasisS.Z);
			BasisT = new Vector3(p.BasisT.X, p.BasisT.Y, p.BasisT.Z);
			Offset = new Vector2(p.Offset.X, p.Offset.Y);
			Rotation = p.Rotation;
			Scale = new Vector2(p.Scale.X, p.Scale.Y);
			Normal = new Vector3(p.Normal.X, p.Normal.Y, p.Normal.Z);

			Vertices.Clear();
			for (int i = 0; i < p.Vertices.Count; i++)
			{
				Vertices.Add(p.Vertices[i]);
			}

			// Avoid replacing any existing vertex colors, as otherwise happens
			// in the Color set method.
			_color = p.Color;

			Edges.Clear();
			for (int i = 0; i < p.Edges.Count; i++)
			{
				Edges.Add(p.Edges[i]);
			}
		}
	}
}
