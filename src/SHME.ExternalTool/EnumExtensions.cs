using BizHawk.Client.EmuHawk;

namespace SHME.ExternalTool
{
	public static class EnumExtensions
	{
		public static bool FasterHasFlag(this Buttons value, Buttons flag)
		{
			return (value & flag) != 0;
		}

		public static bool FasterHasFlag(this Culling value, Culling flag)
		{
			return (value & flag) != 0;
		}

		public static bool FasterHasFlag(this Transformability value, Transformability flag)
		{
			return (value & flag) != 0;
		}
	}
}
