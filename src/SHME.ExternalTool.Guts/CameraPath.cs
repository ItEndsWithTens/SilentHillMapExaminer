using System;
using System.Globalization;
using System.Numerics;
using bp = System.Buffers.Binary.BinaryPrimitives;

namespace SHME.ExternalTool
{
	public class CameraPath : SilentHillType
	{
		public override int SizeInBytes => SilentHillTypeSizes.CameraPath;

		// These are separate floats only to avoid the potential confusion of
		// using Vector2s, which have X and Y components instead of X and Z.
		public float AreaMinX { get; set; }
		public float AreaMaxX { get; set; }
		public float AreaMinZ { get; set; }
		public float AreaMaxZ { get; set; }

		public Vector3 VolumeMin { get; set; }
		public Vector3 VolumeMax { get; set; }

		public byte Thing4 { get; set; }
		public bool Disabled
		{
			get => (Thing4 & 0b01000000) != 0;
			set
			{
				if (value)
				{
					Thing4 |= 0b01000000;
				}
				else
				{
					Thing4 &= 0b10111111;
				}
			}
		}

		public byte Thing5 { get; set; }
		public short Thing6 { get; set; }

		public float Pitch { get; set; }
		public float Yaw { get; set; }

		public CameraPath(long address, ReadOnlySpan<byte> span)
		{
			Address = address;

			AreaMinX = Guts
				.QToFloat(bp.ReadInt16LittleEndian(span.Slice(0)), 4);

			AreaMaxX = Guts
				.QToFloat(bp.ReadInt16LittleEndian(span.Slice(2)), 4);

			AreaMinZ = Guts
				.QToFloat(bp.ReadInt16LittleEndian(span.Slice(4)), 4);

			AreaMaxZ = Guts
				.QToFloat(bp.ReadInt16LittleEndian(span.Slice(6)), 4);

			// Sign extending the 8-bit value allows interpreting it as
			// Q12.4 fixed point.
			short rawMinY = span[18];
			if (rawMinY >= 0x80)
			{
				rawMinY = (short)(0xFF00 | span[18]);
			}

			VolumeMin = new Vector3(
				Guts.QToFloat(bp.ReadInt16LittleEndian(span.Slice(8)), 4),
				Guts.QToFloat(rawMinY, 4),
				Guts.QToFloat(bp.ReadInt16LittleEndian(span.Slice(12)), 4));

			short rawMaxY = span[19];
			if (rawMaxY >= 0x80)
			{
				rawMaxY = (short)(0xFF00 | span[19]);
			}

			VolumeMax = new Vector3(
				Guts.QToFloat(bp.ReadInt16LittleEndian(span.Slice(10)), 4),
				Guts.QToFloat(rawMaxY, 4),
				Guts.QToFloat(bp.ReadInt16LittleEndian(span.Slice(14)), 4));

			Thing4 = span[16];
			Thing5 = span[17];
			Thing6 = bp.ReadInt16LittleEndian(span.Slice(20));

			// TODO: Also where the hell is roll?
			Pitch = Guts.GameUnitsToDegrees((uint)(span[22] << 4));
			Yaw = Guts.GameUnitsToDegrees((uint)(span[23] << 4));
		}

		public override ReadOnlySpan<byte> ToBytes()
		{
			Span<byte> span = new byte[SizeInBytes];

			return ToBytes(span);
		}
		public override ReadOnlySpan<byte> ToBytes(Span<byte> span)
		{
			bp.WriteInt16LittleEndian(
				span.Slice(0x00), (short)Guts.FloatToQ(AreaMinX, 4));

			bp.WriteInt16LittleEndian(
				span.Slice(0x02), (short)Guts.FloatToQ(AreaMaxX, 4));

			bp.WriteInt16LittleEndian(
				span.Slice(0x04), (short)Guts.FloatToQ(AreaMinZ, 4));

			bp.WriteInt16LittleEndian(
				span.Slice(0x06), (short)Guts.FloatToQ(AreaMaxZ, 4));

			bp.WriteInt16LittleEndian(
				span.Slice(0x08), (short)Guts.FloatToQ(VolumeMin.X, 4));

			bp.WriteInt16LittleEndian(
				span.Slice(0x0A), (short)Guts.FloatToQ(VolumeMax.X, 4));

			bp.WriteInt16LittleEndian(
				span.Slice(0x0C), (short)Guts.FloatToQ(VolumeMin.Z, 4));

			bp.WriteInt16LittleEndian(
				span.Slice(0x0E), (short)Guts.FloatToQ(VolumeMax.Z, 4));

			span[0x10] = Thing4;

			span[0x11] = Thing5;

			span[0x12] = (byte)Guts.FloatToQ(VolumeMin.Y, 4);

			span[0x13] = (byte)Guts.FloatToQ(VolumeMax.Y, 4);

			bp.WriteInt16LittleEndian(span.Slice(0x14), Thing6);

			span[0x16] = (byte)(Guts.DegreesToGameUnits(Pitch) >> 4);

			span[0x17] = (byte)(Guts.DegreesToGameUnits(Yaw) >> 4);

			return span;
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
