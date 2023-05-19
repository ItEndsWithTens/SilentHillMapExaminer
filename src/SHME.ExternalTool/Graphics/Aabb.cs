﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace SHME.ExternalTool
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

		public IList<Vector3> Points { get; } = new List<Vector3>(8);

		public Aabb()
		{
			_min = new Vector3();
			_max = new Vector3();
			Update();
		}
		public Aabb(IEnumerable<Renderable> renderables) : base()
		{
			var points = new List<Vector3>();

			foreach (Renderable r in renderables)
			{
				foreach (Vertex v in r.Vertices)
				{
					points.Add(v.Position);
				}
			}

			Init(points.ToArray());
		}
		public Aabb(IEnumerable<Vertex> vertices) : base()
		{
			var points = new List<Vector3>();

			foreach (Vertex vertex in vertices)
			{
				points.Add(vertex.Position);
			}

			Init(points.ToArray());
		}
		public Aabb(IEnumerable<Vector3> points) : base()
		{
			Init(points.ToArray());
		}
		public Aabb(Vector3[] points)
		{
			Init(points);
		}
		public Aabb(Aabb aabb)
		{
			_min = new Vector3(aabb.Min.X, aabb.Min.Y, aabb.Min.Z);
			_max = new Vector3(aabb.Max.X, aabb.Max.Y, aabb.Max.Z);
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

		private void Update()
		{
			Center = Min + ((Max - Min) / 2.0f);

			Points.Clear();
			Points.Add(Min);
			Points.Add(new Vector3(Max.X, Min.Y, Min.Z));
			Points.Add(new Vector3(Max.X, Min.Y, Max.Z));
			Points.Add(new Vector3(Min.X, Min.Y, Max.Z));
			Points.Add(new Vector3(Max.X, Max.Y, Min.Z));
			Points.Add(new Vector3(Min.X, Max.Y, Min.Z));
			Points.Add(new Vector3(Min.X, Max.Y, Max.Z));
			Points.Add(Max);
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
		/// Offset an AABB in 3D.
		/// </summary>
		/// <param name="lhs">The AABB to offset.</param>
		/// <param name="rhs">The distance to offset.</param>
		/// <returns>A new AABB, offset by the specified amounts.</returns>
		public static Aabb Add(Aabb lhs, Vector3 rhs)
		{
			return new Aabb(lhs.Min + rhs, lhs.Max + rhs);
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
