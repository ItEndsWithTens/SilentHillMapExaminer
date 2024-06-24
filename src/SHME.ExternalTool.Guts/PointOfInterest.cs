using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Globalization;
using static SHME.ExternalTool.Guts;

namespace SHME.ExternalTool
{
	public class PointOfInterest : SilentHillType
	{
		public override int SizeInBytes => SilentHillTypeSizes.PointOfInterest;

		public float X { get; }

		/// <summary>
		/// The shape of this point in the world.
		/// </summary>
		/// <remarks>
		/// The meaning of this value is dependent on the trigger using the POI,
		/// e.g. for action button activated triggers this stores the yaw, while
		/// touch triggers use this to hold their width and length.
		/// </remarks>
		public uint Geometry { get; }

		public float Z { get; }

		public static (float?, float?, float?, float?) DecodeGeometry(TriggerStyle s, PointOfInterest p)
		{
			float? yaw = null;
			float? x = null;
			float? z = null;
			float? width = null;

			uint geo = p.Geometry;

			if (s == TriggerStyle.ButtonOmni || s == TriggerStyle.ButtonYaw)
			{
				uint raw = (geo & 0b00000000_11111111_11110000_00000000) >> 12;

				yaw = GameUnitsToDegrees(raw);
			}
			else if (s == TriggerStyle.TouchAabb)
			{
				uint rawA = (geo & 0b00000000_11111111_00000000_00000000) >> 16;
				uint rawB = (geo & 0b11111111_00000000_00000000_00000000) >> 24;

				float radiusX = QToFloat((int)rawA * 1024);
				float radiusZ = QToFloat((int)rawB * 1024);

				x = radiusX * 2.0f;
				z = radiusZ * 2.0f;
			}
			else if (s == TriggerStyle.TouchObb)
			{
				uint rawA = (geo & 0b00000000_11111111_00000000_00000000) >> 16;
				uint rawB = (geo & 0b11111111_00000000_00000000_00000000) >> 24;

				yaw = GameUnitsToDegrees((rawA << 0x14) >> 0x10);
				width = QToFloat((int)(rawB << 9));
			}

			return (yaw, x, z, width);
		}

		public PointOfInterest(long address, IReadOnlyList<byte> current) :
			this(address, current, current)
		{
		}
		public PointOfInterest(long address, IReadOnlyList<byte> current, IReadOnlyList<byte> original)
		{
			Address = address;
			OriginalBytes = original;

			byte[] bytes = [.. current];

			X = QToFloat(BitConverter.ToInt32(bytes, 0));
			Geometry = BitConverter.ToUInt32(bytes, 4);
			Z = QToFloat(BitConverter.ToInt32(bytes, 8));
		}

		public override ReadOnlySpan<byte> ToBytes()
		{
			Span<byte> bytes = new byte[SizeInBytes];

			BinaryPrimitives.WriteInt32LittleEndian(
				bytes.Slice(0x0), FloatToQ(X));

			BinaryPrimitives.WriteUInt32LittleEndian(
				bytes.Slice(0x4), Geometry);

			BinaryPrimitives.WriteInt32LittleEndian(
				bytes.Slice(0x8), FloatToQ(Z));

			return bytes;
		}

		public override string ToString()
		{
			CultureInfo c = CultureInfo.CurrentCulture;
			string sep = c.NumberFormat.NumberGroupSeparator;

			return $"<{X.ToString("0.##", c)}{sep} {Z.ToString("0.##", c)}>";
		}
	}
}
