using System;
using System.Collections.Generic;
using System.Numerics;

namespace SHME.ExternalTool
{
	public enum AngleType
	{
		SilentHill,
		YUpRightHanded
	}

	public class AngleConverter
	{
		public static Vector3 Convert(List<float> angles, CoordinateType from, CoordinateType to)
		{
			if (angles.Count > 3)
			{
				throw new ArgumentException("Too many angles!");
			}
			else if (angles.Count < 3)
			{
				throw new ArgumentException("Too few coordinates!");
			}

			return Convert(new Vector3(angles[0], angles[1], angles[2]), from, to);
		}
		public static Vector3 Convert(Vector3 angles, CoordinateType from, CoordinateType to)
		{
			Vector3 converted;

			if (from == CoordinateType.SilentHill && to == CoordinateType.YUpRightHanded)
			{
				converted = SilentHillToYUpRightHanded(angles);
			}
			else if (from == CoordinateType.YUpRightHanded && to == CoordinateType.SilentHill)
			{
				converted = YUpRightHandedToSilentHill(angles);
			}
			else
			{
				throw new NotSupportedException("Unsupported angle conversion!");
			}

			return converted;
		}

		// Both the game camera and this plugin's overlay camera use the same
		// convention of rotation, the so-called "right hand rule", whereby
		// increasing rotation values turn counter-clockwise as viewed when
		// looking in the negative direction of the axis.
		//
		// Since both cameras' axis of pitch increases off to the right of the
		// camera, the pitch values don't need to be changed. Likewise, each
		// camera's roll axis points forward, in the direction the camera is
		// looking, so that value is also fine as-is.
		//
		// Yaw is unique, in two ways. First, the direction of rotation. The
		// game treats its vertical axis as pointing down, while the overlay
		// camera has its pointing up. That means increasing yaw values rotate
		// in opposite directions depending on the camera, and the sign of the
		// yaw value needs to flip.
		//
		// The second problem with yaw is the assumed orientation of yaw 0, with
		// the game camera pointing north (positive Z), but the overlay camera
		// pointing toward the more traditional east (positive X). Subtracting
		// 90 accommodates that in combination with the sign flip, and lets the
		// cameras stay syncronized despite their different conventions.
		private static Vector3 YUpRightHandedToSilentHill(Vector3 from)
		{
			return new Vector3(from.X, -(from.Y + 90.0f), from.Z);
		}
		private static Vector3 SilentHillToYUpRightHanded(Vector3 from)
		{
			return new Vector3(from.X, -(from.Y - 90.0f), from.Z);
		}
	}
}
