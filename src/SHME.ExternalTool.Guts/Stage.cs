using System;
using System.Collections.Generic;
using System.Linq;

namespace SHME.ExternalTool;

public class Stage : SilentHillType
{
	public Stage(long address, IReadOnlyList<byte> current) :
		this(address, current, current)
	{
	}
	public Stage(long address, IReadOnlyList<byte> current, IReadOnlyList<byte> original)
	{
		Address = address;
		OriginalBytes = original;

		SizeInBytes = current.Count;
	}

	public override ReadOnlySpan<byte> ToBytes()
	{
		return OriginalBytes.ToArray();
	}
}
