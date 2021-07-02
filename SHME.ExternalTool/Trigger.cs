using System;
using System.Collections.Generic;

namespace SHME.ExternalTool
{
	public class Trigger
	{
		public long Address { get; }

		public byte Thing0 { get; }
		public byte Thing1 { get; }
		public short Thing2 { get; }
		public byte Style { get; }
		public byte PoiIndex { get; }
		public byte Thing3 { get; }
		public byte Thing4 { get; }
		public uint Thing5 { get; }

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
			Thing5 = BitConverter.ToUInt32(bytes, 8);
		}
	}
}
