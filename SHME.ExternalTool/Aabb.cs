using OpenTK;
using System;
using System.Collections.Generic;

namespace SHME.ExternalTool
{
	/// <summary>
	/// An axis-aligned bounding box surrounding a given set of points.
	/// </summary>
	public class Aabb : IEquatable<Aabb>
	{
		private Vector3 min;
		public Vector3 Min
		{
			get { return min; }
			set
			{
				min = value;
				Center = Min + ((Max - Min) / 2.0f);
			}
		}

		private Vector3 max;
		public Vector3 Max
		{
			get { return max; }
			set
			{
				max = value;
				Center = Min + ((Max - Min) / 2.0f);
			}
		}

		public Vector3 Center { get; private set; }

		public Aabb()
		{
			Min = new Vector3();
			Max = new Vector3();
		}
		public Aabb(List<Vertex> vertices) : base()
		{
			var points = new List<Vector3>();

			foreach (Vertex vertex in vertices)
			{
				points.Add(vertex.Position);
			}

			Init(points);
		}
		public Aabb(List<Vector3> points) : base()
		{
			Init(points);
		}
		public Aabb(params Vector3[] points)
		{
			Init(points);
		}
		public Aabb(Aabb aabb)
		{
			Min = new Vector3(aabb.Min);
			Max = new Vector3(aabb.Max);
		}

		private void Init(List<Vector3> points)
		{
			Init(points.ToArray());
		}
		private void Init(params Vector3[] points)
		{
			Vector3 newMin = points[0];
			Vector3 newMax = points[0];

			foreach (Vector3 point in points)
			{
				if (point.X < newMin.X)
				{
					newMin.X = point.X;
				}
				if (point.X > newMax.X)
				{
					newMax.X = point.X;
				}

				if (point.Y < newMin.Y)
				{
					newMin.Y = point.Y;
				}
				if (point.Y > newMax.Y)
				{
					newMax.Y = point.Y;
				}

				if (point.Z < newMin.Z)
				{
					newMin.Z = point.Z;
				}
				if (point.Z > newMax.Z)
				{
					newMax.Z = point.Z;
				}
			}

			Min = newMin;
			Max = newMax;
		}

		/// <summary>
		/// Combine two AABBs to produce a new AABB that covers them both.
		/// </summary>
		/// <param name="lhs">The first AABB to combine.</param>
		/// <param name="rhs">The second AABB to combine.</param>
		/// <returns>A new AABB representing the total AABB of the two inputs.</returns>
		public static Aabb Add(Aabb lhs, Aabb rhs)
		{
			Vector3 newMin = lhs.Min;
			Vector3 newMax = lhs.Max;

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

			return new Aabb()
			{
				Min = newMin,
				Max = newMax
			};
		}
		public static Aabb operator +(Aabb lhs, Aabb rhs)
		{
			return Add(lhs, rhs);
		}

		/// <summary>
		/// Offset an AABB in 3D.
		/// </summary>
		/// <param name="lhs">The AABB to offset.</param>
		/// <param name="rhs">The distance to offset.</param>
		/// <returns>A new AABB, offset by the specified amounts.</returns>
		public static Aabb Add(Aabb lhs, Vector3 rhs)
		{
			return new Aabb
			{
				Min = lhs.Min + rhs,
				Max = lhs.Max + rhs
			};
		}
		public static Aabb operator +(Aabb lhs, Vector3 rhs)
		{
			return Add(lhs, rhs);
		}

		/// <summary>
		/// Offset an AABB in 3D.
		/// </summary>
		/// <param name="lhs">The AABB to offset.</param>
		/// <param name="rhs">The distance to offset.</param>
		/// <returns>A new AABB, offset by the specified amounts.</returns>
		public static Aabb Subtract(Aabb lhs, Vector3 rhs)
		{
			return new Aabb
			{
				Min = lhs.Min - rhs,
				Max = lhs.Max - rhs
			};
		}
		public static Aabb operator -(Aabb lhs, Vector3 rhs)
		{
			return Subtract(lhs, rhs);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Aabb);
		}

		public bool Equals(Aabb other)
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

		public static bool operator ==(Aabb lhs, Aabb rhs)
		{
			return EqualityComparer<Aabb>.Default.Equals(lhs, rhs);
		}

		public static bool operator !=(Aabb lhs, Aabb rhs)
		{
			return !(lhs == rhs);
		}
	}
}
