using BizHawk.Client.EmuHawk;
using System;

namespace SHME.ExternalTool
{
	public static class EnumExtensions
	{
		public static bool FasterHasFlag(this PsxButtons value, PsxButtons flag)
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

		public static PsxButtons FilterToAny(this PsxButtons value)
		{
			PsxButtons filtered = value;

			foreach (PsxButtons button in Enum.GetValues(typeof(PsxButtons)))
			{
				if (value.FasterHasFlag(button))
				{
					filtered = button;
					break;
				}
			}

			return filtered;
		}
	}
}
