using System;
using System.Collections.Generic;

namespace SHME.ExternalTool
{
	public enum TriggerType : byte
	{
		Unknown0 = 0x00,
		Door1 = 0x05,
		Door2 = 0x06,
		Text = 0x07
	}

	public class Trigger
	{
		public long Address { get; }

		public byte Thing0 { get; }
		public byte Thing1 { get; }
		public short Thing2 { get; }
		/// <summary>
		/// How this trigger gets activated.
		/// </summary>
		/// <remarks>
		/// 0x00:
		/// 0x01: Proximity Z (maybe)
		/// 0x02: Radius/close proximity
		/// 0x23: Button press
		/// </remarks>
		public byte Style { get; }
		public byte PoiIndex { get; }
		public byte Thing3 { get; }
		public byte Thing4 { get; }
		/// <summary>
		/// Trigger type info, e.g. whether this is a door, and if so where
		/// it goes.
		/// </summary>
		/// <remarks>
		/// Low 5 bits seems to be the type:
		/// 0x05: Door
		/// 0x06: Door
		/// 0x07: Text
		///
		/// If this is in fact a door trigger, shifting the remainder right by 5
		/// and taking the low 8 bits of the result gives the target POI index.
		///
		/// Likewise, the same bit shift provides the string array index for
		/// text triggers.
		/// </remarks>
		public short TypeInfo { get; }
		public short Thing5 { get; }

		public TriggerType TriggerType { get; }
		public int TargetIndex { get; }

		public Trigger(long address, List<byte> bytes) : this(address, bytes.ToArray())
		{
		}
		public Trigger(long address, byte[] bytes)
		{
			Address = address;

			Thing0 = bytes[0];
			Thing1 = bytes[1];
			Thing2 = BitConverter.ToInt16(bytes, 2);
			Style = bytes[4];
			PoiIndex = bytes[5];
			Thing3 = bytes[6];
			Thing4 = bytes[7];
			TypeInfo = BitConverter.ToInt16(bytes, 8);
			Thing5 = BitConverter.ToInt16(bytes, 10);

			TriggerType = (TriggerType)(TypeInfo & 0x0F);
			TargetIndex = (byte)((TypeInfo >> 5) & 0xFF);
		}
	}
}
