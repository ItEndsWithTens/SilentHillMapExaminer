using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

// NOTE: Converted to Y-up, right-handed coordinates only! Convenience functions
// will be added later to work with the Z-up, left-handed coordinates I find more
// personally comfortable.

namespace SHME.ExternalTool
{
	public class Polygon
	{
		/// <summary>
		/// The vertex indices of this polygon, relative to the Vertices list of
		/// the Renderable containing it.
		/// </summary>
		public List<int> Indices;
		public List<int> LineLoopIndices { get; } = new List<int>();

		/// <summary>
		/// The name of the texture meant to be applied to this polygon; if said
		/// texture isn't loaded, a placeholder will be used for CurrentTexture.
		/// </summary>
		public string IntendedTextureName { get; set; } = "";

		public Vector3 BasisS;
		public Vector3 BasisT;
		public Vector2 Offset;
		public float Rotation;
		public Vector2 Scale;

		public Vector3 Normal;

		public IntPtr IndexOffset;
		public IntPtr LineLoopIndexOffset { get; set; } = IntPtr.Zero;

		private Color _color = Color.White;
		public Color Color
		{
			get {  return _color; }
			set
			{
				_color = value;

				foreach (int i in Indices)
				{
					Vertex v = Renderable.Vertices[i];

					v.Color = _color;

					Renderable.Vertices.RemoveAt(i);
					Renderable.Vertices.Insert(i, v);
				}
			}
		}

		public Renderable Renderable { get; set; }

		public Polygon(Renderable r)
		{
			Renderable = r;
			Indices = new List<int>();
		}
		public Polygon(Polygon p)
		{
			Renderable = p.Renderable;
			Indices = new List<int>(p.Indices);
			LineLoopIndices = new List<int>(p.LineLoopIndices);
			IntendedTextureName = p.IntendedTextureName;
			BasisS = new Vector3(p.BasisS.X, p.BasisS.Y, p.BasisS.Z);
			BasisT = new Vector3(p.BasisT.X, p.BasisT.Y, p.BasisT.Z);
			Offset = new Vector2(p.Offset.X, p.Offset.Y);
			Rotation = p.Rotation;
			Scale = new Vector2(p.Scale.X, p.Scale.Y);
			Normal = new Vector3(p.Normal.X, p.Normal.Y, p.Normal.Z);

			// Avoid replacing any existing vertex colors, as otherwise happens
			// in the Color set method.
			_color = p.Color;
		}

		public static Polygon Rotate(Polygon polygon, float pitch, float yaw, float roll, Vector3 origin)
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

			return p;
		}

		public static Polygon TranslateRelative(Polygon polygon, Vector3 diff)
		{
			var p = new Polygon(polygon);

			// The dot product projects one vector onto another, in essence
			// describing how far along one of them the other is. That gives the
			// relative offset on the respective basis vector, though scaled.
			p.Offset.X -= Vector3.Dot(diff, p.BasisS) / p.Scale.X;
			p.Offset.Y -= Vector3.Dot(diff, p.BasisT) / p.Scale.Y;

			return p;
		}
		public static Polygon TranslateRelative(Polygon polygon, float diffX, float diffY, float diffZ)
		{
			return TranslateRelative(polygon, new Vector3(diffX, diffY, diffZ));
		}
	}
}
