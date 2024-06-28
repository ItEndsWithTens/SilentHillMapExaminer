using SHME.ExternalTool.Graphics;
using System;
using System.Collections.Generic;

namespace SHME.ExternalTool;

public static class CollectionExtensions
{
	public static int IndexOf(this IEnumerable<(PointOfInterest, Renderable?)> collection, PointOfInterest target)
	{
		if (collection is null)
		{
			throw new ArgumentNullException(nameof(collection));
		}

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

	public static int IndexFromKey<TKey, TValue>(this SortedDictionary<TKey, TValue> dict, TKey key)
	{
		if (dict is null)
		{
			throw new ArgumentNullException(nameof(dict));
		}

		int index = 0;
		foreach (KeyValuePair<TKey, TValue> kvp in dict)
		{
			if (kvp.Key is not null && kvp.Key.Equals(key))
			{
				return index;
			}

			index++;
		}

		return -1;
	}
}
