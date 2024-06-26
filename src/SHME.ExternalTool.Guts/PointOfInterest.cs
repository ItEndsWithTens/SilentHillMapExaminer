using System;
using System.Globalization;
using static SHME.ExternalTool.Guts;
using bp = System.Buffers.Binary.BinaryPrimitives;

namespace SHME.ExternalTool
{
	public static class PointOfInterestExtensions
	{
		public static (float geoA, float geoB) DecodeGeometry(this PointOfInterest p, TriggerStyle s)
		{
			float geoA = 0.0f;
			float geoB = 0.0f;

			uint geo = p.Geometry;
			uint rawA;
			uint rawB;

			switch (s)
			{
				case TriggerStyle.ButtonOmni:
				case TriggerStyle.ButtonYaw:
					geoA = GameUnitsToDegrees((geo & 0x00FFF000) >> 12);
					break;
				case TriggerStyle.TouchAabb:
					rawA = (geo & 0x00FF0000) >> 16;
					rawB = (geo & 0xFF000000) >> 24;

					float radiusX = QToFloat((int)rawA * 1024);
					float radiusZ = QToFloat((int)rawB * 1024);

					geoA = radiusX * 2.0f;
					geoB = radiusZ * 2.0f;
					break;
				case TriggerStyle.TouchObb:
					rawA = (geo & 0x00FF0000) >> 16;
					rawB = (geo & 0xFF000000) >> 24;

					geoA = GameUnitsToDegrees((rawA << 0x14) >> 0x10);
					geoB = QToFloat((int)(rawB << 9));
					break;
				default:
					break;
			}

			return (geoA, geoB);
		}
	}

	public class PointOfInterest : SilentHillType
	{
		public override int SizeInBytes => SilentHillTypeSizes.PointOfInterest;

		public float X { get; set; }

		/// <summary>
		/// The shape of this point in the world.
		/// </summary>
		/// <remarks>
		/// The meaning of this value is dependent on the trigger using the POI,
		/// e.g. for action button activated triggers this stores the yaw, while
		/// touch triggers use this to hold their width and length.
		/// </remarks>
		public uint Geometry { get; set; }

		public float Z { get; set; }

		public PointOfInterest(long address, ReadOnlySpan<byte> bytes)
		{
			Address = address;

			X = QToFloat(bp.ReadInt32LittleEndian(bytes.Slice(0)));
			Geometry = bp.ReadUInt32LittleEndian(bytes.Slice(4));
			Z = QToFloat(bp.ReadInt32LittleEndian(bytes.Slice(8)));
		}

		public override ReadOnlySpan<byte> ToBytes()
		{
			Span<byte> span = new byte[SizeInBytes];

			return ToBytes(span);
		}
		public override ReadOnlySpan<byte> ToBytes(Span<byte> span)
		{
			bp.WriteInt32LittleEndian(span.Slice(0x0), FloatToQ(X));
			bp.WriteUInt32LittleEndian(span.Slice(0x4), Geometry);
			bp.WriteInt32LittleEndian(span.Slice(0x8), FloatToQ(Z));

			return span;
		}

		public override string ToString()
		{
			CultureInfo c = CultureInfo.CurrentCulture;
			string sep = c.NumberFormat.NumberGroupSeparator;

			return $"<{X.ToString("0.##", c)}{sep} {Z.ToString("0.##", c)}>";
		}
	}
}
