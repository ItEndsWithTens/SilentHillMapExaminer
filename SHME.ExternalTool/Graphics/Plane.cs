using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace SHME.ExternalTool
{
	public class Plane
	{
		public readonly List<Vertex> Points;

		public readonly Vector3 Normal;

		public readonly float DistanceFromOrigin;

		public readonly Winding Winding;

		public Plane(Vector3 _a, Vector3 _b, Vector3 _c, Winding _winding) : this(new Vertex(_a), new Vertex(_b), new Vertex(_c), _winding)
		{
		}
		public Plane(Vertex _a, Vertex _b, Vertex _c, Winding _winding) : this(new List<Vertex>() { _a, _b, _c }, _winding)
		{
		}
		public Plane(List<Vertex> _points, Winding _winding)
		{
			Winding = _winding;

			Points = _points;

			Vector3 a = Points[2] - Points[0];
			Vector3 b = Points[1] - Points[0];

			if (Winding == Winding.Ccw)
			{
				Vector3 c = a;
				a = b;
				b = c;
			}

			Normal = Vector3.Normalize(Vector3.Cross(a, b));

			DistanceFromOrigin = Vector3.Dot(Points[0].Position, Normal);
		}

		public static Vector3 Intersect(IEnumerable<Plane> planes)
		{
			if (planes.Count() != 3)
			{
				throw new ArgumentException("Can only intersect 3 planes at once!");
			}

			return Intersect(planes.ElementAt(0), planes.ElementAt(1), planes.ElementAt(2));
		}
		public static Vector3 Intersect(Plane a, Plane b, Plane c)
		{
			float denominator = Vector3.Dot(a.Normal, Vector3.Cross(b.Normal, c.Normal));

			// Planes do not intersect.
			if (MathUtilities.ApproximatelyEquivalent(denominator, 0.0f, 0.0001f))
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
