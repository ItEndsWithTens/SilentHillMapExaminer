using System;
using System.Numerics;

namespace SHME.ExternalTool
{
	public enum CoordinateType
	{
		SilentHill,
		YUpRightHanded
	}

	public static class CoordinateConverter
	{
		public static Vector3 Convert(Vector3 coordinates, CoordinateType from, CoordinateType to)
		{
			Vector3 converted;

			if (from == CoordinateType.SilentHill && to == CoordinateType.YUpRightHanded)
			{
				converted = SilentHillToYUpRightHanded(coordinates);
			}
			else if (from == CoordinateType.YUpRightHanded && to == CoordinateType.SilentHill)
			{
				converted = YUpRightHandedToSilentHill(coordinates);
			}
			else
			{
				throw new NotSupportedException("Unsupported coordinate conversion!");
			}

			return converted;
		}

		// Silent Hill uses a coordinate system where X points east, Y points
		// down, and Z points north. The overlay camera instead uses a more
		// traditional Y-up, right-handed system, in which X points east, Y
		// points up, and Z points south. Conversions are thankfully simple.
		private static Vector3 YUpRightHandedToSilentHill(Vector3 from)
		{
			return new Vector3(from.X, -from.Y, -from.Z);
		}
		private static Vector3 SilentHillToYUpRightHanded(Vector3 from)
		{
			return new Vector3(from.X, -from.Y, -from.Z);
		}
	}
}
