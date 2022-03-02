using System.Drawing;

namespace SHME.ExternalTool
{
	public static class Utility
	{
		public static void ClampToMinMax(ref Point p, Point min, Point max)
		{
			if (p.X < min.X)
			{
				p.X = min.X;
			}
			else if (p.X > max.X)
			{
				p.X = max.X;
			}

			if (p.Y < min.Y)
			{
				p.Y = min.Y;
			}
			else if (p.Y > max.Y)
			{
				p.Y = max.Y;
			}
		}

		public static double ScaleToRange(double number, double inMin, double inMax, double outMin, double outMax)
		{
			return ((outMax - outMin) * (number - inMin) / (inMax - inMin)) + outMin;
		}
	}
}
