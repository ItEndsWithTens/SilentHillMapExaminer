using SHME.ExternalTool.Graphics;
using System.Collections.Generic;

namespace SHME.ExternalTool;

public static class CollectionExtensions
{
	public static int IndexOf(this IEnumerable<(PointOfInterest, Renderable?)> collection, PointOfInterest target)
	{
		int index = 0;
		foreach ((PointOfInterest p, Renderable? _) in collection)
		{
			if (ReferenceEquals(p, target))
			{
				return index;
			}

			index++;
		}

		return -1;
	}
}
