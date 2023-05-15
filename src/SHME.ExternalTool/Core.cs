using System;

namespace SHME.ExternalTool
{
	public class Core
	{
		public Rom Rom { get; set; } = new USRetail();

		public static uint DegreesToGameUnits(float degrees)
		{
			float mod = MathUtilities.ModAngleToCircleUnsigned(degrees);

			return (uint)Utility.ScaleToRange(mod, 0.0, 360.0, 0.0, 4096.0);
		}
		public static float GameUnitsToDegrees(uint gameUnits)
		{
			// Rotations in Silent Hill have only 12 significant bits.
			uint masked = gameUnits & 0b00000000_00000000_00001111_11111111;

			return (float)Utility.ScaleToRange(masked, 0.0, 4096.0, 0.0, 360.0);
		}

		// Silent Hill appears to use the Q(20.12) fixed point number format,
		// at least for Harry's position.
		public static int FloatToQ(float f)
		{
			return FloatToQ(f, 12);
		}
		public static int FloatToQ(float f, int fractionalBits)
		{
			return (int)Math.Round(f * Math.Pow(2.0, fractionalBits));
		}
		public static float QToFloat(int q)
		{
			return QToFloat(q, 12);
		}
		public static float QToFloat(int q, int fractionalBits)
		{
			return (float)(q * Math.Pow(2.0, -fractionalBits));
		}
	}
}
