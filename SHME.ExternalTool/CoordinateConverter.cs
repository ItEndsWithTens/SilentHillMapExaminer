using System;
using System.Collections.Generic;
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
		public static Vector3 Convert(List<float> coordinates, CoordinateType from, CoordinateType to)
		{
			if (coordinates.Count > 3)
			{
				throw new ArgumentException("Too many coordinates!");
			}
			else if (coordinates.Count < 3)
			{
				throw new ArgumentException("Too few coordinates!");
			}

			return Convert(new Vector3(coordinates[0], coordinates[1], coordinates[2]), from, to);
		}
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
