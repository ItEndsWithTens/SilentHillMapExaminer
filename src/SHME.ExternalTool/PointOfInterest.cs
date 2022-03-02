using System;
using System.Collections.Generic;
using static SHME.ExternalTool.Core;

namespace SHME.ExternalTool
{
	public class PointOfInterest
	{
		public long Address { get; }

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

		public static (float?, float?, float?) DecodeGeometry(TriggerStyle s, PointOfInterest p)
		{
			float? yaw = null;
			float? x = null;
			float? z = null;

			uint geo = p.Geometry;

			if (s == TriggerStyle.Button)
			{
				uint raw = (geo & 0b00000000_11111111_11110000_00000000) >> 12;

				yaw = GameUnitsToDegrees(raw);
			}
			else
			{
				// FIXME: Not quite right. Close, but there's more going on here,
				// namely how to distinguish whether these are really X and Z. Some
				// seem to be Z and X instead, so maybe there's a yaw somewhere?
				x = QToFloat((int)((geo >> 5) & 0xFFFFF));
				z = QToFloat((int)((geo >> 13) & 0x1FFFF));
			}

			return (yaw, x, z);
		}

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
		public PointOfInterest(long address, int x, uint geo, int z) :
			this(address, QToFloat(x), geo, QToFloat(z))
		{
		}
		public PointOfInterest(long address, float x, uint geo, float z)
		{
			Address = address;

			X = x;
			Geometry = geo;
			Z = z;
		}

		public override string ToString()
		{
			return $"{X:0.##}, {Z:0.##}";
		}
	}
}
