using System;

namespace SHME.ExternalTool
{
	public static class Utility
	{
		public static double ScaleToRange(double number, double inMin, double inMax, double outMin, double outMax)
		{
			return ((outMax - outMin) * (number - inMin) / (inMax - inMin)) + outMin;
		}
	}
}
