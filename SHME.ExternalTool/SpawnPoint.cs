using static SHME.ExternalTool.Core;

namespace SHME.ExternalTool
{
	public class SpawnPoint
	{
		public float Z { get; }

		public uint Thing0 { get; } // TODO: Decipher this

		public float Yaw { get; }

		public uint Thing1 { get; } // TODO: Decipher this

		public float X { get; }

		public SpawnPoint(int z, uint info, int x) : this(QToFloat(z), info, QToFloat(x))
		{
		}
		public SpawnPoint(float z, uint info, float x)
		{
			Z = z;

			uint raw0 = (info & 0b11111111_00000000_00000000_00000000) >> 24;
			uint raw1 = (info & 0b00000000_11111111_11110000_00000000) >> 12;
			uint raw2 = (info & 0b00000000_00000000_00001111_11111111) >> 0;

			Thing0 = raw0;
			Yaw = GameUnitsToDegrees(raw1);
			Thing1 = raw2;

			X = x;
		}
	}
}
