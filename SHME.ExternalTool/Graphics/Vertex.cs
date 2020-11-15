using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;

namespace SHME.ExternalTool
{
	public static class VertexExtensions
	{
		public static Vector3 Rotate(this Vector3 vector, float pitch, float yaw, float roll)
		{
			if (pitch < 0.0f)
			{
				pitch = Math.Abs(pitch);
			}
			else
			{
				pitch = 360.0f - pitch;
			}

			// Assumes that objects are pointing toward +X; thereby pitch
			// represents rotation around Z, yaw around Y, and roll around X.
			Matrix4x4 rotZ = Matrix4x4.CreateRotationZ(MathUtilities.DegreesToRadians(pitch));
			Matrix4x4 rotY = Matrix4x4.CreateRotationY(MathUtilities.DegreesToRadians(yaw));
			Matrix4x4 rotX = Matrix4x4.CreateRotationX(MathUtilities.DegreesToRadians(roll));

			Matrix4x4 rotation = rotZ * rotY * rotX;

			Vector3 rotated = Vector3.Transform(vector, rotation);

			return rotated;
		}

		public static Vertex ModelToWorld(this Vertex v, Matrix4x4 modelMatrix)
		{
			return ConvertCoordinateSpace(v, modelMatrix);
		}

		public static Vertex WorldToModel(this Vertex v, Matrix4x4 modelMatrix)
		{
			Matrix4x4.Invert(modelMatrix, out Matrix4x4 inverted);

			return ConvertCoordinateSpace(v, inverted);
		}

		public static Vertex ConvertCoordinateSpace(Vertex v, Matrix4x4 matrix)
		{
			Vector3 converted = Vector3.Transform(v, matrix);

			return new Vertex(v) { Position = converted };
		}
	}

	public struct Vertex
	{
		public static int MemorySize { get; } = Marshal.SizeOf(typeof(Vertex));

		public Vector3 Position { get; set; }

		public Vector3 Normal { get; set; }

		public Color Color { get; set; }

		public Vector2 TexCoords { get; set; }

		public Vertex(Vertex vertex) : this(vertex.Position, vertex.Normal, vertex.Color)
		{
		}
		public Vertex(Vector3 position) : this(position.X, position.Y, position.Z)
		{
		}
		public Vertex(float x, float y, float z) :
			this(new Vector3(x, y, z), new Vector3(0.0f, 1.0f, 0.0f), Color.White)
		{
		}
		public Vertex(float x, float y, float z, Color color) :
			this(new Vector3(x, y, z), new Vector3(0.0f, 1.0f, 0.0f), color)
		{
		}
		public Vertex(Vector3 position, Color color) :
			this(position, new Vector3(0.0f, 1.0f, 0.0f), color)
		{
		}
		public Vertex(Vector3 position, Vector3 normal, Color color) :
			this(position, normal, color, new Vector2())
		{
		}
		public Vertex(Vector3 position, Vector3 normal, Color color, Vector2 texCoords)
		{
			Position = position;
			Normal = normal;
			Color = color;
			TexCoords = texCoords;
		}

		public static Vertex Rotate(Vertex vertex, float pitch, float yaw, float roll)
		{
			return new Vertex(vertex)
			{
				Position = vertex.Position.Rotate(pitch, yaw, roll),
				Normal = vertex.Normal.Rotate(pitch, yaw, roll)
			};
		}

		public static Vertex TranslateRelative(Vertex v, Vector3 diff)
		{
			Vector3 translated = v.Position + diff;

			return new Vertex(v)
			{
				Position = new Vector3(translated.X, translated.Y, translated.Z)
			};
		}
		public static Vertex TranslateRelative(Vertex v, float diffX, float diffY, float diffZ)
		{
			return TranslateRelative(v, new Vector3(diffX, diffY, diffZ));
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

		public override string ToString()
		{
			return Position.ToString();
		}
	}
}
