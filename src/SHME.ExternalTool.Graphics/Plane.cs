using System;
using System.Numerics;

namespace SHME.ExternalTool.Graphics
{
	public class Plane
	{
		public Vector3 A { get; } = Vector3.Zero;
		public Vector3 B { get; } = Vector3.UnitZ;
		public Vector3 C { get; } = Vector3.UnitX;

		public Vector3 Normal { get; } = Vector3.UnitY;

		public float DistanceFromOrigin { get; }

		public Winding Winding { get; } = Winding.Ccw;

		public Plane()
		{
		}
		public Plane(Vector3 a, Vector3 b, Vector3 c, Winding w)
		{
			A = a;
			B = b;
			C = c;
			Winding = w;

			Vector3 one = C - A;
			Vector3 two = B - A;

			if (Winding == Winding.Ccw)
			{
				(one, two) = (two, one);
			}

			Normal = Vector3.Normalize(Vector3.Cross(one, two));

			DistanceFromOrigin = Vector3.Dot(A, Normal);
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
			crossAB *= c.DistanceFromOrigin;

			var crossBC = Vector3.Cross(b.Normal, c.Normal);
			crossBC *= a.DistanceFromOrigin;

			var crossCA = Vector3.Cross(c.Normal, a.Normal);
			crossCA *= b.DistanceFromOrigin;

			Vector3 added = crossBC + crossCA + crossAB;
			return new Vector3(added.X, added.Y, added.Z) / denominator;
		}
	}
}
