namespace SHME.ExternalTool.Graphics;

public static class EnumExtensions
{
	public static bool FasterHasFlag(this Culling value, Culling flag)
	{
		return (value & flag) != 0;
	}

	public static bool FasterHasFlag(this Transformability value, Transformability flag)
	{
		return (value & flag) != 0;
	}
}
