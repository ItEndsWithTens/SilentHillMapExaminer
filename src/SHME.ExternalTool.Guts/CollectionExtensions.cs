using SHME.ExternalTool.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

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

	// These SelectX methods are just a hack to avoid creating anonymous
	// methods in the main tool assembly whose signatures contain types
	// defined in an external assembly. PointOfInterest or Trigger, for
	// example, are defined in SHME.ExternalTool.Guts. Under Mono in
	// Linux, when BizHawk tries to load the main plugin assembly, Mono
	// tries to load the types it finds in method signatures, failing on
	// the aforementioned examples (among others) because the DLLs found
	// in the ExternalTool attribute's LoadAssemblyFiles array haven't
	// been loaded yet. This is a bit roundabout, but still effective.
	public static IEnumerable<TItem2> SelectItem2<TItem1, TItem2>(this IEnumerable<(TItem1, TItem2)> enumerable)
	{
		return enumerable.Select((tuple) => tuple.Item2);
	}
	public static IEnumerable<TItem2> SelectManyItem2<TItem1, TItem2>(this IEnumerable<(TItem1, IList<TItem2>)> enumerable)
	{
		return enumerable.SelectMany((tuple) => tuple.Item2);
	}
	public static IEnumerable<(TItem1, TItem2)> SelectTuple<TItem1, TItem2>(this IEnumerable<(TItem1, TItem2)> enumerable)
	{
		return enumerable.Select((tuple) => tuple);
	}
}
