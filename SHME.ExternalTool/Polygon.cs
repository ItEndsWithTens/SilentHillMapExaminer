using OpenTK;
using System;
using System.Collections.Generic;

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

			var yUpRightHand = new Vector4(p.BasisS.X, p.BasisS.Z, -p.BasisS.Y, 1.0f);
			Vector4 rotated = yUpRightHand * rotation;
			var zUpLeftHand = new Vector3(rotated.X, -rotated.Z, rotated.Y);
			p.BasisS = zUpLeftHand;

			yUpRightHand = new Vector4(p.BasisT.X, p.BasisT.Z, -p.BasisT.Y, 1.0f);
			rotated = yUpRightHand * rotation;
			zUpLeftHand = new Vector3(rotated.X, -rotated.Z, rotated.Y);
			p.BasisT = zUpLeftHand;

			yUpRightHand = new Vector4(p.Normal.X, p.Normal.Z, -p.Normal.Y, 1.0f);
			rotated = yUpRightHand * rotation;
			zUpLeftHand = new Vector3(rotated.X, -rotated.Z, rotated.Y);
			p.Normal = zUpLeftHand;

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
