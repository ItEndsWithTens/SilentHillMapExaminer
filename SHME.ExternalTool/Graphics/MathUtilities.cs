using OpenTK;
using System;
using System.Collections.Generic;

namespace SHME.ExternalTool
{
	public static class MathExtensions
	{
		public static bool IsNaN(this Vector3 vector)
		{
			return
				Single.IsNaN(vector.X) ||
				Single.IsNaN(vector.Y) ||
				Single.IsNaN(vector.Z);
		}
	}

	public static class MathUtilities
	{
		public static bool ApproximatelyEquivalent(Vector3 a, Vector3 b, float tolerance)
		{
			return
				MathHelper.ApproximatelyEquivalent(a.X, b.X, tolerance) &&
				MathHelper.ApproximatelyEquivalent(a.Y, b.Y, tolerance) &&
				MathHelper.ApproximatelyEquivalent(a.Z, b.Z, tolerance);
		}

		/// <summary>
		/// Get all unique combinations of a set.
		/// </summary>
		/// <param name="count">The number of items to combine.</param>
		/// <param name="size">Combinations must be exactly this length.</param>
		/// <returns></returns>
		public static List<List<int>> Combinations(int count, int size)
		{
			return Combinations(count, size, 0);
		}
		/// <summary>
		/// Get all unique combinations of a set.
		/// </summary>
		/// <param name="count">The number of items to combine.</param>
		/// <param name="size">Combinations must be exactly this length.</param>
		/// <param name="start">The list index to start on; for recursion.</param>
		/// <returns></returns>
		public static List<List<int>> Combinations(int count, int size, int start)
		{
			var items = new List<int>();
			for (int i = 0; i < count; i++)
			{
				items.Add(i);
			}

			return Combinations(items, size, start);
		}
		/// <summary>
		/// Get all unique combinations of a set.
		/// </summary>
		/// <param name="items">The items to combine.</param>
		/// <param name="size">Combinations must be exactly this length.</param>
		/// <returns></returns>
		public static List<List<int>> Combinations(List<int> items, int size)
		{
			return Combinations(items, size, 0);
		}
		/// <summary>
		/// Get all unique combinations of a set.
		/// </summary>
		/// <param name="items">The items to combine.</param>
		/// <param name="size">Combinations must be exactly this length.</param>
		/// <param name="start">The list index to start on; for recursion.</param>
		/// <returns></returns>
		public static List<List<int>> Combinations(List<int> items, int size, int start)
		{
			var combinations = new List<List<int>>();

			if (size == 1)
			{
				for (int i = start; i < items.Count; i++)
				{
					combinations.Add(new List<int>() { items[i] });
				}

				return combinations;
			}

			for (int i = start; i < items.Count; i++)
			{
				List<List<int>> remainingCombos = Combinations(items, size - 1, i + 1);

				foreach (List<int> combo in remainingCombos)
				{
					var output = new List<int>() { items[i] };
					output.AddRange(combo);
					combinations.Add(output);
				}
			}

			return combinations;
		}

		/// <summary>
		/// Get all unique permutations of a set.
		/// </summary>
		/// <param name="count">The number of items to permute.</param>
		/// <param name="size">Permutations must be exactly this length.</param>
		/// <returns></returns>
		public static List<List<int>> Permutations(int count, int size)
		{
			var items = new List<int>();
			for (int i = 0; i < count; i++)
			{
				items.Add(i);
			}

			return Permutations(items, size);
		}
		/// <summary>
		/// Get all unique permutations of a set.
		/// </summary>
		/// <param name="items">The items to permute.</param>
		/// <param name="size">Permutations must be exactly this length.</param>
		/// <returns></returns>
		public static List<List<int>> Permutations(List<int> items, int size)
		{
			var permutations = new List<List<int>>();

			if (size == 1)
			{
				foreach (int item in items)
				{
					permutations.Add(new List<int>() { item });
				}

				return permutations;
			}

			foreach (int item in items)
			{
				var others = new List<int>(items);

				// Remove only removes the first instance of an element from the
				// list, which means it's perfect for duplicates; if a duplicate
				// is in the input, it shouldn't be collapsed into just one, it
				// should be allowed to hang around. Basically, assume users who
				// provide lists with duplicate items know what they're doing.
				others.Remove(item);

				List<List<int>> remainingPerms = Permutations(others, size - 1);

				foreach (List<int> perm in remainingPerms)
				{
					var output = new List<int>() { item };
					output.AddRange(perm);
					permutations.Add(output);
				}
			}

			return permutations;
		}

		/// <summary>
		/// Bring 'angle' into the range (-360.0, 360.0).
		/// </summary>
		/// <param name="angle"></param>
		/// <returns></returns>
		public static float ModAngleToCircleSigned(float angle)
		{
			return angle % 360.0f;
		}

		/// <summary>
		/// Bring 'angle' into the range [0.0, 360.0).
		/// </summary>
		/// <param name="angle"></param>
		/// <returns></returns>
		public static float ModAngleToCircleUnsigned(float angle)
		{
			return (ModAngleToCircleSigned(angle) + 360.0f) % 360.0f;
		}

		/// <summary>
		/// Get the angle in degrees between two points, clockwise from a to b
		/// when looking against the direction of the normal.
		/// </summary>
		/// <param name="a">The starting point.</param>
		/// <param name="b">The ending point.</param>
		/// <param name="normal">The normal of the points' face.</param>
		/// <returns>The angle between a and b, in degrees.</returns>
		public static double GetClockwiseAngle(Vector3 a, Vector3 b, Vector3 normal)
		{
			double result = Double.NaN;

			double angle = SignedAngleBetweenVectors(a, b, normal);
			if (angle > 0.0 || MathHelper.ApproximatelyEquivalent(angle, -180.0, 0.001))
			{
				result = angle;
			}

			return result;
		}

		/// <summary>
		/// Get a series of clockwise angles between every pair of vertices in a set.
		/// </summary>
		/// <param name="vertices">The vertices to measure.</param>
		/// <param name="pairs">A list of indices into 'vertices', defining pairs of
		/// vertices to measure between.</param>
		/// <param name="center">The point around which to measure the angle.</param>
		/// <param name="normal">Angles will be considered either clockwise or
		/// counterclockwise when looking opposite this direction.</param>
		/// <returns>A Dictionary, with one entry per input vertex pair, that
		/// uses the pair as its Key, and the measured angle as its Value.</returns>
		public static Dictionary<List<int>, double> GetClockwiseAngles(List<Vertex> vertices, List<List<int>> pairs, Vector3 center, Vector3 normal)
		{
			var vectors = new List<Vector3>();

			foreach (Vertex vertex in vertices)
			{
				vectors.Add(vertex.Position);
			}

			return GetClockwiseAngles(vectors, pairs, center, normal);
		}
		/// <summary>
		/// Get a series of clockwise angles between every pair of points in a set.
		/// </summary>
		/// <param name="points">The points to measure.</param>
		/// <param name="pairs">A list of indices into 'points', defining pairs of
		/// points to measure between.</param>
		/// <param name="center">The point around which to measure the angle.</param>
		/// <param name="normal">Angles will be considered either clockwise or
		/// counterclockwise when looking opposite this direction.</param>
		/// <returns>A Dictionary, with one entry per input point pair, that
		/// uses the pair as its Key, and the measured angle as its Value.</returns>
		public static Dictionary<List<int>, double> GetClockwiseAngles(List<Vector3> points, List<List<int>> pairs, Vector3 center, Vector3 normal)
		{
			var angles = new Dictionary<List<int>, double>();

			foreach (List<int> pair in pairs)
			{
				Vector3 a = points[pair[0]] - center;
				Vector3 b = points[pair[1]] - center;

				double angle = GetClockwiseAngle(a, b, normal);

				if (!angle.Equals(Double.NaN))
				{
					angles.Add(pair, angle);
				}
			}

			return angles;
		}

		public static double SignedAngleBetweenVectors(Vector3 a, Vector3 b, Vector3 normal)
		{
			float dot1 = Vector3.Dot(normal, Vector3.Cross(a, b));
			float dot2 = Vector3.Dot(a, b);

			return MathHelper.RadiansToDegrees(Math.Atan2(dot1, dot2));
		}

		public static List<Vertex> SortVertices(List<Vertex> vertices, Vector3 normal, Winding winding)
		{
			var sorted = new List<Vertex>();

			if (vertices.Count == 0)
			{
				return sorted;
			}

			sorted.Add(vertices[0]);

			List<List<int>> pairs = Permutations(vertices.Count, 2);

			var aabb = new Aabb(vertices);

			Dictionary<List<int>, double> angles = GetClockwiseAngles(vertices, pairs, aabb.Center, normal);

			int currentIndex = 0;
			for (int i = 0; i < vertices.Count - 1; i++)
			{
				double previousAngle = 181.0;
				int nextIndex = 0;
				foreach (KeyValuePair<List<int>, double> candidate in angles)
				{
					if (candidate.Key[0] != currentIndex)
					{
						continue;
					}

					if (Math.Abs(candidate.Value) < previousAngle)
					{
						nextIndex = candidate.Key[1];
						previousAngle = Math.Abs(candidate.Value);
					}
				}

				sorted.Add(vertices[nextIndex]);
				currentIndex = nextIndex;
			}

			if (winding == Winding.Cw)
			{
				// Reverse the order, but keep the first vertex at index 0.
				sorted.Reverse();
				sorted.Insert(0, sorted[sorted.Count - 1]);
				sorted.RemoveAt(sorted.Count - 1);
			}

			return sorted;
		}
	}
}
