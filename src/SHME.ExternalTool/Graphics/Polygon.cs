using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace SHME.ExternalTool
{
	public class Polygon
	{
		public IList<Vertex> Vertices { get; } = new List<Vertex>(4);

		public IList<(int, int, bool)> Edges { get; } = new List<(int, int, bool)>(4);

		/// <summary>
		/// The name of the texture meant to be applied to this polygon; if said
		/// texture isn't loaded, a placeholder will be used for CurrentTexture.
		/// </summary>
		public string IntendedTextureName { get; set; } = String.Empty;

		public Vector3 TextureBasisS;
		public Vector3 TextureBasisT;
		public Vector2 TextureOffset;
		public float TextureRotation;
		public Vector2 TextureScale;

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
			TextureBasisS = p.TextureBasisS;
			TextureBasisT = p.TextureBasisT;
			TextureOffset = p.TextureOffset;
			TextureRotation = p.TextureRotation;
			TextureScale = p.TextureScale;
			Normal = p.Normal;

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

		private void MakeEdges()
		{
			Edges.Clear();
			for (int i = 0; i < Vertices.Count; i++)
			{
				Edges.Add((i, (i + 1) % Vertices.Count, true));
			}
		}

		public Polygon ClipAgainstPlane(Plane plane)
		{
			var points = new List<Vertex>();

			for (int i = 0; i < Vertices.Count; i++)
			{
				int idxA = i;
				int idxB = (i + 1) % Vertices.Count;

				Vertex a = Vertices[idxA];
				Vertex b = Vertices[idxB];

				(a, b, bool visible) = (a, b).ClipPairAgainstPlane(plane);

				if (!visible)
				{
					continue;
				}

				points.Add(a);
				points.Add(b);
			}

			Vertices.Clear();
			for (int i = 0; i < points.Count; i++)
			{
				Vertex point = points[i];
				if (!Vertices.Contains(point))
				{
					Vertices.Add(point);
				}
			}

			MakeEdges();

			return this;
		}

		public Polygon Rotate(Vector3 rotation, Vector3 origin)
		{
			if (rotation.Z < 0.0f)
			{
				rotation.Z = Math.Abs(rotation.Z);
			}
			else
			{
				rotation.Z = 360.0f - rotation.Z;
			}

			Matrix4x4 rotZ = Matrix4x4.CreateRotationZ(MathUtilities.DegreesToRadians(rotation.Z), origin);
			Matrix4x4 rotY = Matrix4x4.CreateRotationY(MathUtilities.DegreesToRadians(rotation.Y), origin);
			Matrix4x4 rotX = Matrix4x4.CreateRotationX(MathUtilities.DegreesToRadians(rotation.X), origin);

			Matrix4x4 matrix = rotZ * rotY * rotX;

			TextureBasisS = Vector3.Transform(TextureBasisS, matrix);
			TextureBasisT = Vector3.Transform(TextureBasisT, matrix);
			Normal = Vector3.Transform(Normal, matrix);

			for (int i = 0; i < Vertices.Count; i++)
			{
				Vertex v = Vertices[i].ModelToWorld(Renderable.ModelMatrix);
				v.Rotate(rotation, origin);
				Vertices[i] = v.WorldToModel(Renderable.ModelMatrix);
			}

			return this;
		}

		public Polygon Scale(Vector3 scale)
		{
			for (int i = 0; i < Vertices.Count; i++)
			{
				Vertex v = Vertices[i];

				v.Position *= scale;

				Vertices[i] = v;
			}

			// TODO: Understand, and explain in a comment, why the basis
			// vectors need to be divided by the scale instead of multiplied
			// like the vertex positions. I figured this out by observation,
			// and honestly have no idea why it works.

			TextureBasisS /= scale;
			TextureBasisT /= scale;

			return this;
		}

		public Polygon TranslateRelative(Vector3 diff)
		{
			for (int i = 0; i < Vertices.Count; i++)
			{
				Vertex v = Vertices[i];
				Vertices[i] = v.TranslateRelative(diff);
			}

			// The dot product projects one vector onto another, in essence
			// describing how far along one of them the other is. That gives the
			// relative offset on the respective basis vector, though v.
			TextureOffset.X -= Vector3.Dot(diff, TextureBasisS) / TextureScale.X;
			TextureOffset.Y -= Vector3.Dot(diff, TextureBasisT) / TextureScale.Y;

			return this;
		}
	}
}
