using System;
using System.Globalization;
using System.Numerics;

namespace SHME.ExternalTool
{
	public class CameraPath : SilentHillEntity
	{
		public override int SizeInBytes => SilentHillEntitySizes.CameraPath;

		// These are separate floats only to avoid the potential confusion of
		// using Vector2s, which have X and Y components instead of X and Z.
		public float AreaMinX { get; }
		public float AreaMaxX { get; }
		public float AreaMinZ { get; }
		public float AreaMaxZ { get; }

		public Vector3 VolumeMin { get; }
		public Vector3 VolumeMax { get; }

		public byte Thing4 { get; }
		public bool Disabled { get; }
		public byte Thing5 { get; }
		public short Thing6 { get; }

		public float Pitch { get; }
		public float Yaw { get; }

		public CameraPath(long address, byte[] bytes)
		{
			_ = bytes ?? throw new ArgumentNullException(nameof(bytes));

			Address = address;

			AreaMinX = Core.QToFloat(BitConverter.ToInt16(bytes, 0), 4);
			AreaMaxX = Core.QToFloat(BitConverter.ToInt16(bytes, 2), 4);
			AreaMinZ = Core.QToFloat(BitConverter.ToInt16(bytes, 4), 4);
			AreaMaxZ = Core.QToFloat(BitConverter.ToInt16(bytes, 6), 4);

			// Sign extending the 8-bit value allows interpreting it as Q12.4.
			short rawMinY = bytes[18];
			if (rawMinY >= 0x80)
			{
				rawMinY = (short)(0xFF00 | bytes[18]);
			}

			VolumeMin = new Vector3(
				Core.QToFloat(BitConverter.ToInt16(bytes, 8), 4),
				Core.QToFloat(rawMinY, 4),
				Core.QToFloat(BitConverter.ToInt16(bytes, 12), 4));

			short rawMaxY = bytes[19];
			if (rawMaxY >= 0x80)
			{
				rawMaxY = (short)(0xFF00 | bytes[19]);
			}

			VolumeMax = new Vector3(
				Core.QToFloat(BitConverter.ToInt16(bytes, 10), 4),
				Core.QToFloat(rawMaxY, 4),
				Core.QToFloat(BitConverter.ToInt16(bytes, 14), 4));

			Thing4 = bytes[16];
			Disabled = (Thing4 & 0b01000000) == 0b01000000;

			Thing5 = bytes[17];
			Thing6 = BitConverter.ToInt16(bytes, 20);

			// TODO: Also where the hell is roll?
			Pitch = Core.GameUnitsToDegrees((uint)(bytes[22] << 4));
			Yaw = Core.GameUnitsToDegrees((uint)(bytes[23] << 4));
		}

		public override string ToString()
		{
			CultureInfo c = CultureInfo.CurrentCulture;

			return
				$"Area: {AreaMinX.ToString("0.##", c)},{AreaMinZ.ToString("0.##", c)}" +
				"  |  " +
				$"{AreaMaxX.ToString("0.##", c)},{AreaMaxZ.ToString("0.##", c)}";
		}
	}
}
