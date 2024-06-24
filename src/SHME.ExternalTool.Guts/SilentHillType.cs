using System.Collections.Generic;

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

	public virtual IReadOnlyList<byte> OriginalBytes { get; protected set; } = [];

	public abstract IReadOnlyList<byte> ToBytes();
}
