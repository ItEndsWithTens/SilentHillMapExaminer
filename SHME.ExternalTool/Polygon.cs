using OpenTK;
using System;
using System.Collections.Generic;

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
		public string IntendedTextureName { get; set; }

		/// <summary>
		/// The texture currently applied to this polygon. If the texture named
		/// by IntendedTexture isn't available, a placeholder will be used.
		/// </summary>
		public Vector3 BasisS;
		public Vector3 BasisT;
		public Vector2 Offset;
		public float Rotation;
		public Vector2 Scale;

		public Vector3 Normal;

		public IntPtr IndexOffset;
		public IntPtr LineLoopIndexOffset { get; set; } = IntPtr.Zero;

		public Polygon()
		{
			Indices = new List<int>();
		}
		public Polygon(Polygon p)
		{
			Indices = new List<int>(p.Indices);
			LineLoopIndices = new List<int>(p.LineLoopIndices);
			IntendedTextureName = p.IntendedTextureName;
			BasisS = new Vector3(p.BasisS);
			BasisT = new Vector3(p.BasisT);
			Offset = new Vector2(p.Offset.X, p.Offset.Y);
			Rotation = p.Rotation;
			Scale = new Vector2(p.Scale.X, p.Scale.Y);
			Normal = new Vector3(p.Normal);
		}

		public static Polygon Rotate(Polygon polygon, float pitch, float yaw, float roll)
		{
			if (pitch < 0.0f)
			{
				pitch = Math.Abs(pitch);
			}
			else
			{
				pitch = 360.0f - pitch;
			}

			Matrix4 rotZ = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(pitch));
			Matrix4 rotY = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(yaw));
			Matrix4 rotX = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(roll));

			Matrix4 rotation = rotZ * rotY * rotX;

			var p = new Polygon(polygon);
			
			Vector4 rotated = new Vector4(p.BasisS, 1.0f)  * rotation;
			p.BasisS = rotated.Xyz;

			rotated = new Vector4(p.BasisT, 1.0f) * rotation;
			p.BasisT = rotated.Xyz;

			rotated = new Vector4(p.Normal, 1.0f) * rotation;
			p.Normal = rotated.Xyz;

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
