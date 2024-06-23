using System;
using System.Globalization;
using System.Numerics;

namespace SHME.ExternalTool
{
	public class CameraPath : SilentHillType
	{
		public override int SizeInBytes => SilentHillTypeSizes.CameraPath;

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

			AreaMinX = Guts.QToFloat(BitConverter.ToInt16(bytes, 0), 4);
			AreaMaxX = Guts.QToFloat(BitConverter.ToInt16(bytes, 2), 4);
			AreaMinZ = Guts.QToFloat(BitConverter.ToInt16(bytes, 4), 4);
			AreaMaxZ = Guts.QToFloat(BitConverter.ToInt16(bytes, 6), 4);

			// Sign extending the 8-bit value allows interpreting it as Q12.4.
			short rawMinY = bytes[18];
			if (rawMinY >= 0x80)
			{
				rawMinY = (short)(0xFF00 | bytes[18]);
			}

			VolumeMin = new Vector3(
				Guts.QToFloat(BitConverter.ToInt16(bytes, 8), 4),
				Guts.QToFloat(rawMinY, 4),
				Guts.QToFloat(BitConverter.ToInt16(bytes, 12), 4));

			short rawMaxY = bytes[19];
			if (rawMaxY >= 0x80)
			{
				rawMaxY = (short)(0xFF00 | bytes[19]);
			}

			VolumeMax = new Vector3(
				Guts.QToFloat(BitConverter.ToInt16(bytes, 10), 4),
				Guts.QToFloat(rawMaxY, 4),
				Guts.QToFloat(BitConverter.ToInt16(bytes, 14), 4));

			Thing4 = bytes[16];
			Disabled = (Thing4 & 0b01000000) == 0b01000000;

			Thing5 = bytes[17];
			Thing6 = BitConverter.ToInt16(bytes, 20);

			// TODO: Also where the hell is roll?
			Pitch = Guts.GameUnitsToDegrees((uint)(bytes[22] << 4));
			Yaw = Guts.GameUnitsToDegrees((uint)(bytes[23] << 4));
		}

		public override string ToString()
		{
			CultureInfo c = CultureInfo.CurrentCulture;
			string sep = c.NumberFormat.NumberGroupSeparator;

			return
				$"<{AreaMinX.ToString("0.##", c)}{sep} {AreaMinZ.ToString("0.##", c)}>" +
				"  |  " +
				$"<{AreaMaxX.ToString("0.##", c)}{sep} {AreaMaxZ.ToString("0.##", c)}>";
		}
	}
}
