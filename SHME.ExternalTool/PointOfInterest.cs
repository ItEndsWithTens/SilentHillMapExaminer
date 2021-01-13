using static SHME.ExternalTool.Core;

namespace SHME.ExternalTool
{
	public class PointOfInterest
	{
		public float X { get; }

		public byte Thing0 { get; } // TODO: Decipher this

		/// <summary>
		/// High 12 bits of yaw short
		/// </summary>
		public float Yaw { get; }

		/// <summary>
		/// Low 4 bits of yaw short
		/// </summary>
		public byte Thing1 { get; } // TODO: Decipher this

		public byte Thing2 { get; }

		public float Z { get; }

		public PointOfInterest(int x, uint info, int z) : this(QToFloat(x), info, QToFloat(z))
		{
		}
		public PointOfInterest(float x, uint info, float z)
		{
			X = x;

			uint raw0 = (info & 0b00000000_00000000_00000000_11111111) >> 0;
			uint raw1 = (info & 0b00000000_00000000_00001111_00000000) >> 8;
			uint raw2 = (info & 0b00000000_11111111_11110000_00000000) >> 12;
			uint raw3 = (info & 0b11111111_00000000_00000000_00000000) >> 24;

			Thing0 = (byte)raw0;
			Thing1 = (byte)raw1;
			Yaw = GameUnitsToDegrees(raw2);
			Thing2 = (byte)raw3;

			Z = z;
		}

		public override string ToString()
		{
			return $"{X}, {Z}";
		}
	}
}
