using System;
using System.Numerics;

namespace SHME.ExternalTool.Graphics
{
	public readonly struct Plane(Vector3 normal, float d) : IEquatable<Plane>
	{
		public Vector3 Normal { get; } = normal;

		public float D { get; } = d;

		public static Plane FromVerticesCcw(Vector3 a, Vector3 b, Vector3 c)
		{
			Vector3 one = b - a;
			Vector3 two = c - a;

			Vector3 n = Vector3.Normalize(Vector3.Cross(one, two));

			float d = Vector3.Dot(a, n);

			return new Plane(n, d);
		}
		public static Plane FromVerticesCw(Vector3 a, Vector3 b, Vector3 c)
		{
			return FromVerticesCcw(a, c, b);
		}

		public static Vector3 Intersect(Plane a, Plane b, Plane c)
		{
			float denominator = Vector3.Dot(a.Normal, Vector3.Cross(b.Normal, c.Normal));

			// Planes do not intersect.
			if (denominator.ApproximatelyEquivalent(0.0f, 0.0001f))
			{
				return new Vector3(Single.NaN);
			}

			var crossAB = Vector3.Cross(a.Normal, b.Normal);
			crossAB *= c.D;

			var crossBC = Vector3.Cross(b.Normal, c.Normal);
			crossBC *= a.D;

			var crossCA = Vector3.Cross(c.Normal, a.Normal);
			crossCA *= b.D;

			Vector3 added = crossBC + crossCA + crossAB;
			return new Vector3(added.X, added.Y, added.Z) / denominator;
		}

		public static bool operator ==(Plane left, Plane right)
		{
			return left.Equals(right);
		}
		public static bool operator !=(Plane left, Plane right)
		{
			return !(left == right);
		}

		public override bool Equals(object? obj)
		{
			return obj is Plane plane && Equals(plane);
		}
		public bool Equals(Plane other)
		{
			return
				Normal.Equals(other.Normal) &&
				D == other.D;
		}

		public override int GetHashCode()
		{
			int hashCode = 1385373013;
			hashCode = hashCode * -1521134295 + Normal.GetHashCode();
			hashCode = hashCode * -1521134295 + D.GetHashCode();
			return hashCode;
		}
	}
}
