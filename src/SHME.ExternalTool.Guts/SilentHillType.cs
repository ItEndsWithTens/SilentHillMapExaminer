namespace SHME.ExternalTool;

public static class SilentHillTypeSizes
{
	public static int CameraPath => 24;
	public static int PointOfInterest => 12;
	public static int Trigger => 12;
}

public class SilentHillType
{
	public virtual int SizeInBytes { get; }

	public virtual long Address { get; protected set; }
}
