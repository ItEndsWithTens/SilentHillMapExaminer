using System;
using System.Collections.Generic;

namespace SHME.ExternalTool
{
	public enum TriggerType : byte
	{
		Unknown0 = 0x00,
		Door1 = 0x05,
		Door2 = 0x06,
		Text = 0x07,
		Save0 = 0x08,
		Save1 = 0x09,
		Function1 = 0x0A,
		Function2 = 0x0B
	}

	public class Trigger
	{
		public long Address { get; }

		public byte Thing0 { get; }
		public byte Thing1 { get; }
		public byte FiredBitShift { get; }
		public short SomeIndex { get; }
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
		public byte Thing3 { get; } // Could be string index when door is locked?
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
		/// 0x0A: Function
		/// 0x0B: Function(?)
		///
		/// If this is in fact a door trigger, shifting the remainder right by 5
		/// and taking the low 8 bits of the result gives the target POI index.
		///
		/// Likewise, the same bit shift provides the string array index for
		/// text triggers.
		/// </remarks>
		public uint TypeInfo { get; }

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

			short stateRaw = BitConverter.ToInt16(bytes, 2);
			int raw0 = (stateRaw & 0b00000000_00011111) >> 0;
			int raw1 = (stateRaw & 0b11111111_11100000) >> 5;

			FiredBitShift = (byte)raw0;
			SomeIndex = (short)raw1;

			Style = bytes[4];
			PoiIndex = bytes[5];
			Thing3 = bytes[6];
			Thing4 = bytes[7];
			TypeInfo = BitConverter.ToUInt32(bytes, 8);

			uint raw2 = (TypeInfo & 0b00000000_00000000_00000000_00011111) >> 0;
			uint raw3 = (TypeInfo & 0b00000000_00000000_00011111_11100000) >> 5;
			uint raw4 = (TypeInfo & 0b00000000_00000111_11100000_00000000) >> 13;
			uint raw5 = (TypeInfo & 0b00000001_11111000_00000000_00000000) >> 19;
			uint raw6 = (TypeInfo & 0b11111110_00000000_00000000_00000000) >> 25;

			TriggerType = (TriggerType)raw2;
			TargetIndex = (byte)raw3;
		}
	}
}
