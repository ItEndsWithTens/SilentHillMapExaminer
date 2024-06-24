using System;
using System.Buffers.Binary;
using System.Collections.Generic;

namespace SHME.ExternalTool
{
	public enum TriggerType
	{
		Unknown0 = 0x00,
		Door1 = 0x05,
		Door2 = 0x06,
		Text = 0x07,
		Save0 = 0x08,
		Save1 = 0x09,
		Function1 = 0x0A,

		/// <summary>
		/// A trigger that updates the area map with red marker
		/// scribbles.
		/// </summary>
		MapScribble = 0x0B
	}

	public enum TriggerStyle
	{
		/// <summary>
		/// ?
		/// </summary>
		Unknown0 = 0x0,

		/// <summary>
		/// Activated by touching an axis-aligned bounding box, defined
		/// by two radii and with its origin in the center.
		/// </summary>
		TouchAabb = 0x1,

		/// <summary>
		/// Activated by pressing the action button when in range of and
		/// aimed toward the trigger's POI.
		/// </summary>
		ButtonOmni = 0x2,

		/// <summary>
		/// Activated by pressing the action button when in range of and
		/// aimed toward the trigger's POI, while also aimed opposite
		/// that POI's yaw.
		/// </summary>
		ButtonYaw = 0x3,

		/// <summary>
		/// Activated by touching an oriented bounding box, defined by a
		/// width and yaw, always 4 units deep and with its origin flush
		/// with the back face.
		/// </summary>
		TouchObb = 0x4,

		/// <summary>
		/// Marks the end of the trigger array in game memory.
		/// </summary>
		Dummy = 0x0F
	}

	public class Trigger : SilentHillType
	{
		public override int SizeInBytes => SilentHillTypeSizes.Trigger;

		public byte Thing0 { get; }
		/// <summary>
		/// Whether this trigger is usable or not.
		/// </summary>
		/// <remarks>
		/// A property named "Enabled" might be more intuitive, but it
		/// would be less reflective of the Silent Hill engine, which
		/// sets a bit for the disabled state and clears it for enabled.
		/// </remarks>
		public bool Disabled { get; }
		public byte Thing1 { get; }
		public byte FiredBitShift { get; }
		public short SomeIndex { get; }

		/// <summary>
		/// How this trigger is activated.
		/// </summary>
		/// <remarks>
		/// The low nibble of its respective byte.
		/// </remarks>
		public TriggerStyle Style { get; }
		/// <summary>
		/// ?
		/// </summary>
		/// <remarks>
		/// The high nibble of the byte that produces Style.
		/// </remarks>
		public byte Thing2 { get; }

		public byte PoiIndex { get; }
		public byte Thing3 { get; } // Could be string index when door is locked?
		public byte Thing4 { get; }
		/// <summary>
		/// Trigger type info, e.g. whether this is a door, and if so
		/// where it goes.
		/// </summary>
		/// <remarks>
		/// Low 5 bits seems to be the type:
		/// 0x05: Door
		/// 0x06: Door
		/// 0x07: Text
		/// 0x0A: Function
		/// 0x0B: Function(?)
		///
		/// If this is in fact a door trigger, shifting the remainder
		/// right by 5 and taking the low 8 bits of the result gives the
		/// target POI index.
		///
		/// Likewise, the same bit shift provides the string array index
		/// for text triggers.
		/// </remarks>
		public uint TypeInfo { get; }

		public TriggerType TriggerType { get; }
		public int TargetIndex { get; }

		public Trigger(long address, IReadOnlyList<byte> current) :
			this(address, current, current)
		{
		}
		public Trigger(long address, IReadOnlyList<byte> current, IReadOnlyList<byte> original)
		{
			Address = address;
			OriginalBytes = original;

			byte[] bytes = [.. current];

			int raw0 = (bytes[0] & 0b01111111) >> 0;
			int raw1 = (bytes[0] & 0b10000000) >> 7;
			Thing0 = (byte)raw0;
			Disabled = raw1 == 1;

			Thing1 = bytes[1];

			short stateRaw = BitConverter.ToInt16(bytes, 2);
			int raw2 = (stateRaw & 0b00000000_00011111) >> 0;
			int raw3 = (stateRaw & 0b11111111_11100000) >> 5;
			FiredBitShift = (byte)raw2;
			SomeIndex = (short)raw3;

			int raw4 = (bytes[4] & 0b00001111) >> 0;
			int raw5 = (bytes[4] & 0b11110000) >> 4;
			Style = (TriggerStyle)raw4;
			Thing2 = (byte)raw5;

			PoiIndex = bytes[5];
			Thing3 = bytes[6];
			Thing4 = bytes[7];

			TypeInfo = BitConverter.ToUInt32(bytes, 8);
			uint raw6 = (TypeInfo & 0b00000000_00000000_00000000_00011111) >> 0;
			uint raw7 = (TypeInfo & 0b00000000_00000000_00011111_11100000) >> 5;
			uint raw8 = (TypeInfo & 0b00000000_00000111_11100000_00000000) >> 13;
			uint raw9 = (TypeInfo & 0b00000001_11111000_00000000_00000000) >> 19;

			// rawA is what stage to load for Door1 types, i.e. level
			// change triggers. Zero-based offset, relative to 1995, the
			// file record index corresponding to MAP0_S00.BIN. Not sure
			// if this is used for anything else yet.
			uint rawA = (TypeInfo & 0b01111110_00000000_00000000_00000000) >> 25;

			uint rawB = (TypeInfo & 0b10000000_00000000_00000000_00000000) >> 31;
			TriggerType = (TriggerType)raw6;
			TargetIndex = (byte)raw7;
		}

		public override ReadOnlySpan<byte> ToBytes()
		{
			Span<byte> bytes = new byte[SizeInBytes];

			bytes[0x0] = Thing0;
			if (Disabled)
			{
				bytes[0x0] |= 0b10000000;
			}

			bytes[0x1] = Thing1;

			BinaryPrimitives.WriteInt16LittleEndian(
				bytes.Slice(0x2), (short)((SomeIndex << 5) | FiredBitShift));

			bytes[0x4] = (byte)((Thing2 << 4) | (byte)Style);

			bytes[0x5] = PoiIndex;

			bytes[0x6] = Thing3;

			bytes[0x7] = Thing4;

			uint info = TypeInfo;
			info |= (uint)((int)TriggerType & 0b00011111);
			info |= (uint)(((byte)TargetIndex) << 5);
			bytes[0x8] = (byte)((info & 0x000000FF) >> 0);
			bytes[0x9] = (byte)((info & 0x0000FF00) >> 8);
			bytes[0xA] = (byte)((info & 0x00FF0000) >> 16);
			bytes[0xB] = (byte)((info & 0xFF000000) >> 24);

			BinaryPrimitives.WriteUInt32LittleEndian(
				bytes.Slice(0x8), info);

			return bytes;
		}
	}
}
