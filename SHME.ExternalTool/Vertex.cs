using OpenTK;
using OpenTK.Graphics;
using System;
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
			// represents rotation around world Y (camera Z), yaw is world
			// Z (camera Y), and roll is world/camera X.
			Matrix4 rotZ = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(pitch));
			Matrix4 rotY = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(yaw));
			Matrix4 rotX = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(roll));

			Matrix4 rotation = rotZ * rotY * rotX;

			var yUpRightHand = new Vector4(vector.X, vector.Z, -vector.Y, 1.0f);
			Vector4 rotated = yUpRightHand * rotation;
			var zUpLeftHand = new Vector3(rotated.X, -rotated.Z, rotated.Y);

			return zUpLeftHand;
		}

		public static Vertex ModelToWorld(this Vertex v, Matrix4 modelMatrix)
		{
			return ConvertCoordinateSpace(v, modelMatrix);
		}

		public static Vertex WorldToModel(this Vertex v, Matrix4 modelMatrix)
		{
			var inverted = modelMatrix;
			inverted.Invert();

			return ConvertCoordinateSpace(v, inverted);
		}

		public static Vertex ConvertCoordinateSpace(Vertex v, Matrix4 matrix)
		{
			var vec4 = new Vector4(v.Position.X, v.Position.Z, -v.Position.Y, 1.0f);
			Vector4 converted = vec4 * matrix;
			var vec3 = new Vector3(converted.X, -converted.Z, converted.Y);

			return new Vertex(v) { Position = vec3 };
		}
	}

	public struct Vertex
	{
		public static int MemorySize { get; } = Marshal.SizeOf(typeof(Vertex));

		public Vector3 Position { get; set; }

		public Vector3 Normal { get; set; }

		public Color4 Color { get; set; }

		public Vector2 TexCoords { get; set; }

		public Vertex(Vertex vertex) : this(vertex.Position, vertex.Normal, vertex.Color)
		{
		}
		public Vertex(Vector3 position) : this(position.X, position.Y, position.Z)
		{
		}
		public Vertex(float x, float y, float z) :
			this(new Vector3(x, y, z), new Vector3(0.0f, 0.0f, 1.0f), Color4.White)
		{
		}
		public Vertex(float x, float y, float z, Color4 color) :
			this(new Vector3(x, y, z), new Vector3(0.0f, 0.0f, 1.0f), color)
		{
		}
		public Vertex(Vector3 position, Color4 color) :
			this(position, new Vector3(0.0f, 0.0f, 1.0f), color)
		{
		}
		public Vertex(Vector3 position, Vector3 normal, Color4 color) :
			this(position, normal, color, new Vector2())
		{
		}
		public Vertex(Vector3 position, Vector3 normal, Color4 color, Vector2 texCoords)
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
			return new Vertex(v)
			{
				Position = new Vector3(v.Position + diff)
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
			return new Vector3(vertex.Position);
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
