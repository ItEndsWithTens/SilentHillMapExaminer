using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace SHME.ExternalTool.Graphics
{
	public static class Vector3Extensions
	{
		public static Vector3 Rotate(this Vector3 vector, Vector3 rotation, Vector3 origin)
		{
			if (rotation.Z < 0.0f)
			{
				rotation.Z = Math.Abs(rotation.Z);
			}
			else
			{
				rotation.Z = 360.0f - rotation.Z;
			}

			// Assumes that objects are pointing toward +X; thereby pitch
			// represents rotation around Z, yaw around Y, and roll around X.
			Matrix4x4 rotZ = Matrix4x4.CreateRotationZ(MathUtilities.DegreesToRadians(rotation.Z), origin);
			Matrix4x4 rotY = Matrix4x4.CreateRotationY(MathUtilities.DegreesToRadians(rotation.Y), origin);
			Matrix4x4 rotX = Matrix4x4.CreateRotationX(MathUtilities.DegreesToRadians(rotation.X), origin);

			Matrix4x4 matrix = rotZ * rotY * rotX;

			Vector3 rotated = Vector3.Transform(vector, matrix);

			return rotated;
		}
	}

	public static class VertexExtensions
	{
		public static (Vertex, Vertex, bool) ClipPairAgainstPlane(this (Vertex a, Vertex b) pair, Plane plane)
		{
			Vector3 p = plane.A;
			Vector3 n = plane.Normal;

			float distanceA = Vector3.Dot(pair.a.Position - p, n);
			float distanceB = Vector3.Dot(pair.b.Position - p, n);

			bool aBehind = distanceA <= 0.0f;
			bool bBehind = distanceB <= 0.0f;

			if (aBehind && bBehind)
			{
				return (pair.a, pair.b, false);
			}

			if (!aBehind && !bBehind)
			{
				return (pair.a, pair.b, true);
			}

			float factor = distanceA / (distanceA - distanceB);

			Vector3 intersection = pair.a.Position + (pair.b.Position - pair.a.Position) * factor;

			if (aBehind)
			{
				var clipped = new Vertex(pair.a) { Position = intersection };
				return (clipped, pair.b, true);
			}
			else
			{
				var clipped = new Vertex(pair.b) { Position = intersection };
				return (pair.a, clipped, true);
			}
		}

		public static Vertex ModelToWorld(this Vertex v, Matrix4x4 modelMatrix)
		{
			return v.ConvertCoordinateSpace(modelMatrix);
		}

		public static Vertex WorldToModel(this Vertex v, Matrix4x4 modelMatrix)
		{
			Matrix4x4.Invert(modelMatrix, out Matrix4x4 inverted);

			return v.ConvertCoordinateSpace(inverted);
		}

		public static Vertex WorldToScreen(this Vertex v, Matrix4x4 mvpMatrix, int width, int height, bool flip)
		{
			Vector4 ndc = Vector4.Transform(v.Position, mvpMatrix);
			if (ndc.W != 0)
			{
				ndc /= ndc.W;
			}

			// The neutral device coordinates are good to go as-is, except in
			// cases where the Y axis increases downwards instead of upwards.
			if (flip)
			{
				ndc.Y = -ndc.Y;
			}

			Vector3 position = v.Position;

			int halfW = width / 2;
			int halfH = height / 2;

			position.X = (int)Math.Round(halfW + (ndc.X * halfW));
			position.Y = (int)Math.Round(halfH + (ndc.Y * halfH));

			v.Position = position;

			return v;
		}
	}

	public struct Vertex(Vector3 position, Vector3 normal, int argb, Vector2 texCoords) : IEquatable<Vertex>
	{
		public static int MemorySize { get; } = Marshal.SizeOf(typeof(Vertex));

		public Vector3 Position { get; set; } = position;

		public Vector3 Normal { get; set; } = normal;

		public int Argb { get; set; } = argb;

		public Vector2 TexCoords { get; set; } = texCoords;

		public Vertex(Vertex vertex) : this(vertex.Position, vertex.Normal, vertex.Argb)
		{
		}
		public Vertex(Vector3 position) : this(position.X, position.Y, position.Z)
		{
		}
		public Vertex(float x, float y, float z) :
			this(new Vector3(x, y, z), new Vector3(0.0f, 1.0f, 0.0f), unchecked((int)0xffffffff))
		{
		}
		public Vertex(float x, float y, float z, int argb) :
			this(new Vector3(x, y, z), new Vector3(0.0f, 1.0f, 0.0f), argb)
		{
		}
		public Vertex(Vector3 position, int argb) :
			this(position, new Vector3(0.0f, 1.0f, 0.0f), argb)
		{
		}
		public Vertex(Vector3 position, Vector3 normal, int argb) :
			this(position, normal, argb, new Vector2())
		{
		}

		public static Vector3 Add(Vertex lhs, Vertex rhs)
		{
			return lhs.Position + rhs.Position;
		}
		public static Vector3 operator +(Vertex lhs, Vertex rhs)
		{
			return Add(lhs, rhs);
		}

		public static Vector3 Subtract(Vertex lhs, Vertex rhs)
		{
			return lhs.Position - rhs.Position;
		}
		public static Vector3 operator -(Vertex lhs, Vertex rhs)
		{
			return Subtract(lhs, rhs);
		}

		public static Vector3 ToVector3(Vertex vertex)
		{
			return new Vector3(vertex.Position.X, vertex.Position.Y, vertex.Position.Z);
		}
		public static implicit operator Vector3(Vertex vertex)
		{
			return ToVector3(vertex);
		}

		public static bool operator ==(Vertex left, Vertex right)
		{
			return left.Equals(right);
		}
		public static bool operator !=(Vertex left, Vertex right)
		{
			return !(left == right);
		}

		public override readonly string ToString()
		{
			return Position.ToString();
		}

		public override readonly bool Equals(object? obj)
		{
			return obj is Vertex vertex && Equals(vertex);
		}
		public readonly bool Equals(Vertex other)
		{
			return
				Position.Equals(other.Position) &&
				Normal.Equals(other.Normal) &&
				Argb.Equals(other.Argb) &&
				TexCoords.Equals(other.TexCoords);
		}

		public override readonly int GetHashCode()
		{
			int hashCode = 252586052;
			hashCode = hashCode * -1521134295 + Position.GetHashCode();
			hashCode = hashCode * -1521134295 + Normal.GetHashCode();
			hashCode = hashCode * -1521134295 + Argb.GetHashCode();
			hashCode = hashCode * -1521134295 + TexCoords.GetHashCode();
			return hashCode;
		}

		public readonly Vertex ConvertCoordinateSpace(Matrix4x4 matrix)
		{
			Vector3.Transform(Position, matrix);

			return this;
		}

		public Vertex Rotate(Vector3 rotation, Vector3 origin)
		{
			Position = Position.Rotate(rotation, origin);
			Normal = Normal.Rotate(rotation, origin);

			return this;
		}

		public Vertex TranslateRelative(Vector3 diff)
		{
			Position += diff;
			return this;
		}
		public Vertex TranslateRelative(float diffX, float diffY, float diffZ)
		{
			return TranslateRelative(new Vector3(diffX, diffY, diffZ));
		}
	}
}
