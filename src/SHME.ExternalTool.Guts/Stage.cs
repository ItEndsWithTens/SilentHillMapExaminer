using System;

namespace SHME.ExternalTool;

public class Stage : SilentHillType
{
	private readonly byte[] _bytes;

	public Stage(long address, ReadOnlySpan<byte> current)
	{
		Address = address;

		_bytes = current.ToArray();

		SizeInBytes = current.Length;
	}

	public override ReadOnlySpan<byte> ToBytes()
	{
		Span<byte> span = _bytes;

		return ToBytes(span);
	}
	public override ReadOnlySpan<byte> ToBytes(Span<byte> span)
	{
		return span;
	}
}
