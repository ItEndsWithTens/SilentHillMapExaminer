using System;
using System.Collections.Generic;
using System.Numerics;

namespace SHME.ExternalTool.Graphics
{
	/// <summary>
	/// An axis-aligned bounding box surrounding a given set of points.
	/// </summary>
	public class Aabb : IEquatable<Aabb>
	{
		private Vector3 _min;
		public Vector3 Min
		{
			get => _min;
			set
			{
				_min = value;
				Update();
			}
		}

		private Vector3 _max;
		public Vector3 Max
		{
			get => _max;
			set
			{
				_max = value;
				Update();
			}
		}

		public Vector3 Center { get; private set; }

		private readonly Vector3[] _points = new Vector3[8]
		{
			Vector3.Zero,
			Vector3.Zero,
			Vector3.Zero,
			Vector3.Zero,
			Vector3.Zero,
			Vector3.Zero,
			Vector3.Zero,
			Vector3.Zero
		};

		public IList<Vector3> Points => _points;

		public Aabb()
		{
			Update();
		}
		public Aabb(IList<Renderable> renderables)
		{
			var points = new List<Vector3>();

			for (int i = 0; i < renderables.Count; i++)
			{
				Renderable r = renderables[i];

				for (int j = 0; j < r.Polygons.Count; j++)
				{
					Polygon p = r.Polygons[j];

					for (int k = 0; k < p.Vertices.Count; k++)
					{
						points.Add(p.Vertices[k].Position);
					}
				}
			}

			Init(points.ToArray());
		}
		public Aabb(IEnumerable<Vertex> vertices)
		{
			var points = new List<Vector3>();

			foreach (Vertex vertex in vertices)
			{
				points.Add(vertex.Position);
			}

			Init(points.ToArray());
		}
		public Aabb(IEnumerable<Vector3> vectors)
		{
			var points = new List<Vector3>();

			foreach (Vector3 vector in vectors)
			{
				points.Add(vector);
			}

			Init(points.ToArray());
		}
		public Aabb(Vector3[] points)
		{
			Init(points);
		}
		public Aabb(Aabb aabb)
		{
			_min = aabb.Min;
			_max = aabb.Max;
			Update();
		}
		public Aabb(Vector3 min, Vector3 max)
		{
			_min = min;
			_max = max;
			Update();
		}

		private void Init(Vector3[] points)
		{
			if (points.Length == 0)
			{
				return;
			}

			Vector3 newMin = points[0];
			Vector3 newMax = points[0];

			for (int i = 0; i < points.Length; i++)
			{
				Vector3 point = points[i];

				if (point.X < newMin.X)
				{
					newMin.X = point.X;
				}
				else if (point.X > newMax.X)
				{
					newMax.X = point.X;
				}

				if (point.Y < newMin.Y)
				{
					newMin.Y = point.Y;
				}
				else if (point.Y > newMax.Y)
				{
					newMax.Y = point.Y;
				}

				if (point.Z < newMin.Z)
				{
					newMin.Z = point.Z;
				}
				else if (point.Z > newMax.Z)
				{
					newMax.Z = point.Z;
				}
			}

			_min = newMin;
			_max = newMax;
			Update();
		}

		public void Update(Vector3 min, Vector3 max)
		{
			_min = min;
			_max = max;

			Update();
		}
		private void Update()
		{
			Center = _min + ((_max - _min) / 2.0f);

			_points[0].X = Min.X;
			_points[0].Y = Min.Y;
			_points[0].Z = Min.Z;

			_points[1].X = Max.X;
			_points[1].Y = Min.Y;
			_points[1].Z = Min.Z;

			_points[2].X = Max.X;
			_points[2].Y = Min.Y;
			_points[2].Z = Max.Z;

			_points[3].X = Min.X;
			_points[3].Y = Min.Y;
			_points[3].Z = Max.Z;

			_points[4].X = Max.X;
			_points[4].Y = Max.Y;
			_points[4].Z = Min.Z;

			_points[5].X = Min.X;
			_points[5].Y = Max.Y;
			_points[5].Z = Min.Z;

			_points[6].X = Min.X;
			_points[6].Y = Max.Y;
			_points[6].Z = Max.Z;

			_points[7].X = Max.X;
			_points[7].Y = Max.Y;
			_points[7].Z = Max.Z;
		}

		/// <summary>
		/// Combine two Aabbs to produce a new one that covers them both.
		/// </summary>
		/// <param name="lhs">The first Aabb to combine.</param>
		/// <param name="rhs">The second Aabb to combine.</param>
		/// <returns>A new Aabb representing the total of the two inputs.</returns>
		public static Aabb Add(Aabb lhs, Aabb rhs)
		{
			Vector3 newMin = lhs.Min;
			Vector3 newMax = lhs.Max;

			if (rhs.Min.X < newMin.X)
			{
				newMin.X = rhs.Min.X;
			}

			if (rhs.Min.Y < newMin.Y)
			{
				newMin.Y = rhs.Min.Y;
			}

			if (rhs.Min.Z < newMin.Z)
			{
				newMin.Z = rhs.Min.Z;
			}

			if (rhs.Max.X > newMax.X)
			{
				newMax.X = rhs.Max.X;
			}

			if (rhs.Max.Y > newMax.Y)
			{
				newMax.Y = rhs.Max.Y;
			}

			if (rhs.Max.Z > newMax.Z)
			{
				newMax.Z = rhs.Max.Z;
			}

			return new Aabb(newMin, newMax);
		}
		public static Aabb operator +(Aabb lhs, Aabb rhs)
		{
			return Add(lhs, rhs);
		}

		/// <summary>
		/// Offset an Aabb in 3D.
		/// </summary>
		/// <param name="lhs">The Aabb to offset.</param>
		/// <param name="rhs">The distance by which to offset.</param>
		/// <returns>A new Aabb, offset by the specified amounts.</returns>
		public static Aabb Add(Aabb lhs, Vector3 rhs)
		{
			return new Aabb(lhs.Min + rhs, lhs.Max + rhs);
		}
		public static Aabb operator +(Aabb lhs, Vector3 rhs)
		{
			return Add(lhs, rhs);
		}

		/// <summary>
		/// Offset an Aabb in 3D.
		/// </summary>
		/// <param name="lhs">The Aabb to offset.</param>
		/// <param name="rhs">The distance by which to offset.</param>
		/// <returns>A new Aabb, offset by the specified amounts.</returns>
		public static Aabb Subtract(Aabb lhs, Vector3 rhs)
		{
			return new Aabb(lhs.Min - rhs, lhs.Max - rhs);
		}
		public static Aabb operator -(Aabb lhs, Vector3 rhs)
		{
			return Subtract(lhs, rhs);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Aabb);
		}

		public bool Equals(Aabb? other)
		{
			return other != null && Min.Equals(other.Min) && Max.Equals(other.Max);
		}

		public override int GetHashCode()
		{
			int hashCode = 1537547080;
			hashCode = hashCode * -1521134295 + EqualityComparer<Vector3>.Default.GetHashCode(Min);
			hashCode = hashCode * -1521134295 + EqualityComparer<Vector3>.Default.GetHashCode(Max);

			return hashCode;
		}

		public static bool operator ==(Aabb? lhs, Aabb? rhs)
		{
			return EqualityComparer<Aabb?>.Default.Equals(lhs, rhs);
		}

		public static bool operator !=(Aabb? lhs, Aabb? rhs)
		{
			return !(lhs == rhs);
		}
	}
}
