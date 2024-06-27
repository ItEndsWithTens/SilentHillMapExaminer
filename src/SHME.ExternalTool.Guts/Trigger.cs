using System;
using bp = System.Buffers.Binary.BinaryPrimitives;

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

		public byte Thing0 { get; set; }
		/// <summary>
		/// Whether this trigger is usable or not.
		/// </summary>
		/// <remarks>
		/// A property named "Enabled" might be more intuitive, but it
		/// would be less reflective of the Silent Hill engine, which
		/// sets a bit for the disabled state and clears it for enabled.
		/// </remarks>
		public bool Disabled { get; set; }
		public byte Thing1 { get; set; }
		public byte FiredBitShift { get; }
		public short SomeIndex { get; set; }

		/// <summary>
		/// How this trigger is activated.
		/// </summary>
		/// <remarks>
		/// The low nibble of its respective byte.
		/// </remarks>
		public TriggerStyle Style { get; set; }
		/// <summary>
		/// ?
		/// </summary>
		/// <remarks>
		/// The high nibble of the byte that produces Style.
		/// </remarks>
		public byte Thing2 { get; set; }

		public byte PoiIndex { get; set; }
		public byte Thing3 { get; set; } // Could be string index when door is locked?
		public byte Thing4 { get; set; }

		public TriggerType TriggerType { get; set; }
		public int TargetIndex { get; set; }

		public byte Thing5 { get; set; }
		public byte Thing6 { get; set; }

		/// <summary>
		/// What stage to load for Door1 types, i.e. level change
		/// triggers. Zero-based offset, relative to 1995, the file
		/// record index corresponding to MAP0_S00.BIN. Not sure if this
		/// is used for anything else yet.
		/// </summary>
		public byte StageIndex { get; set; }

		public bool SomeBool { get; set; }

		public Trigger(long address, ReadOnlySpan<byte> span)
		{
			Address = address;

			int raw0 = (span[0] & 0b01111111) >> 0;
			int raw1 = (span[0] & 0b10000000) >> 7;
			Thing0 = (byte)raw0;
			Disabled = raw1 == 1;

			Thing1 = span[1];

			short stateRaw = bp.ReadInt16LittleEndian(span.Slice(2));
			int raw2 = (stateRaw & 0b00000000_00011111) >> 0;
			int raw3 = (stateRaw & 0b11111111_11100000) >> 5;
			FiredBitShift = (byte)raw2;
			SomeIndex = (short)raw3;

			int raw4 = (span[4] & 0b00001111) >> 0;
			int raw5 = (span[4] & 0b11110000) >> 4;
			Style = (TriggerStyle)raw4;
			Thing2 = (byte)raw5;

			PoiIndex = span[5];
			Thing3 = span[6];
			Thing4 = span[7];

			uint info = bp.ReadUInt32LittleEndian(span.Slice(8));
			uint raw6 = (info & 0b00000000_00000000_00000000_00011111) >> 0;
			uint raw7 = (info & 0b00000000_00000000_00011111_11100000) >> 5;
			uint raw8 = (info & 0b00000000_00000111_11100000_00000000) >> 13;
			uint raw9 = (info & 0b00000001_11111000_00000000_00000000) >> 19;
			uint rawA = (info & 0b01111110_00000000_00000000_00000000) >> 25;
			uint rawB = (info & 0b10000000_00000000_00000000_00000000) >> 31;
			TriggerType = (TriggerType)raw6;
			TargetIndex = (byte)raw7;
			Thing5 = (byte)raw8;
			Thing6 = (byte)raw9;
			StageIndex = (byte)rawA;
			SomeBool = rawB == 1;
		}

		public override ReadOnlySpan<byte> ToBytes()
		{
			Span<byte> span = new byte[SizeInBytes];

			return ToBytes(span);
		}

		public override ReadOnlySpan<byte> ToBytes(Span<byte> span)
		{
			span[0x0] = Thing0;
			if (Disabled)
			{
				span[0x0] |= 0b10000000;
			}

			span[0x1] = Thing1;

			bp.WriteInt16LittleEndian(
				span.Slice(0x2), (short)((SomeIndex << 5) | FiredBitShift));

			span[0x4] = (byte)((Thing2 << 4) | (byte)Style);

			span[0x5] = PoiIndex;

			span[0x6] = Thing3;

			span[0x7] = Thing4;

			uint info = 0;
			info |= (uint)((int)TriggerType & 0b00011111);
			info |= (uint)(((byte)TargetIndex) << 5);
			info |= (uint)((Thing5 & 0b00111111) << 13);
			info |= (uint)((Thing6 & 0b00111111) << 19);
			info |= (uint)((StageIndex & 0b00111111) << 25);
			if (SomeBool)
			{
				info |= 0x80000000;
			}

			bp.WriteUInt32LittleEndian(span.Slice(0x8), info);

			return span;
		}
	}
}
