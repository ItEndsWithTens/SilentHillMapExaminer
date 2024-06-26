using System;

namespace SHME.ExternalTool;

public static class SilentHillTypeSizes
{
	public static int CameraPath => 24;
	public static int PointOfInterest => 12;
	public static int Trigger => 12;
}

public abstract class SilentHillType
{
	public virtual int SizeInBytes { get; protected set; }

	public virtual long Address { get; protected set; }

	/// <summary>
	/// Return the Silent Hill memory representation of this game object,
	/// allocating a new array in the process.
	/// </summary>
	/// <returns>A <see cref="ReadOnlySpan{Byte}"/> over the allocated
	/// array.</returns>
	public abstract ReadOnlySpan<byte> ToBytes();
	/// <summary>
	/// Store the Silent Hill memory representation of this game object
	/// in the specified <see cref="Span{Byte}"/> and return it.
	/// </summary>
	/// <param name="span">The <see cref="Span{Byte}"/> into which the
	/// game object's byte representation should be stored.</param>
	/// <returns>A <see cref="ReadOnlySpan{Byte}"/> over the input
	/// <see cref="Span{Byte}"/>, after it's been filled with the game
	/// object's bytes.</returns>
	public abstract ReadOnlySpan<byte> ToBytes(Span<byte> span);
}
