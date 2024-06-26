﻿using System;

namespace SHME.ExternalTool
{
	public static class EnumExtensions
	{
		public static bool FasterHasFlag(this PsxButtons value, PsxButtons flag)
		{
			return (value & flag) != 0;
		}

		public static bool FasterHasFlag(this CameraState value, CameraState flag)
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
