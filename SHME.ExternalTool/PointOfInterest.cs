using System;
using System.Collections.Generic;
using static SHME.ExternalTool.Core;

namespace SHME.ExternalTool
{
	public class PointOfInterest
	{
		public long Address { get; }

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

		public PointOfInterest(long address, List<byte> bytes) :
			this(address, bytes.ToArray())
		{
		}
		public PointOfInterest(long address, byte[] bytes) :
			this(address,
				BitConverter.ToInt32(bytes, 0),
				BitConverter.ToUInt32(bytes, 4),
				BitConverter.ToInt32(bytes, 8))
		{
		}
		public PointOfInterest(long address, int x, uint info, int z) :
			this(address, QToFloat(x), info, QToFloat(z))
		{
		}
		public PointOfInterest(long address, float x, uint info, float z)
		{
			Address = address;

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
			return $"{X:0.##}, {Z:0.##}";
		}
	}
}
