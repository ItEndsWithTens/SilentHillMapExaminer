﻿using System;
using System.Collections.Generic;
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
			BasisS = new Vector3(p.BasisS.X, p.BasisS.Y, p.BasisS.Z);
			BasisT = new Vector3(p.BasisT.X, p.BasisT.Y, p.BasisT.Z);
			Offset = new Vector2(p.Offset.X, p.Offset.Y);
			Rotation = p.Rotation;
			Scale = new Vector2(p.Scale.X, p.Scale.Y);
			Normal = new Vector3(p.Normal.X, p.Normal.Y, p.Normal.Z);
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

			Matrix4x4 rotZ = Matrix4x4.CreateRotationZ(MathUtilities.DegreesToRadians(pitch));
			Matrix4x4 rotY = Matrix4x4.CreateRotationY(MathUtilities.DegreesToRadians(yaw));
			Matrix4x4 rotX = Matrix4x4.CreateRotationX(MathUtilities.DegreesToRadians(roll));

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
