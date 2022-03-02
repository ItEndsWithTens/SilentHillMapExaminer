using System;
using System.Collections.Generic;
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

		public static Vertex WorldToScreen(this Vertex v, Matrix4x4 mvpMatrix, Viewport viewport, bool flip)
		{
			Vector4 clip = Vector4.Transform(v.Position, mvpMatrix);

			Vector4 div = clip;
			if (clip.W != 0)
			{
				div /= clip.W;
			}

			var ndc = new Vector3(div.X, div.Y, div.Z);

			// The neutral device coordinates are good to go as-is, except in
			// cases where the Y axis increases downwards instead of upwards.
			if (flip)
			{
				ndc.Y = -ndc.Y;
			}

			var screen = new Point(
				(int)(viewport.Center.X + (ndc.X * viewport.Width / 2)),
				(int)(viewport.Center.Y + (ndc.Y * viewport.Height / 2)));

			// This is a dirty, underhanded trick to "clip" the coordinates in
			// question to the bounds of the viewport without actually doing any
			// clipping. It only works when the 3D points are just barely beyond
			// the edge of the view frustum.
			Utility.ClampToMinMax(ref screen, viewport.TopLeft, viewport.BottomRight);

			return new Vertex(v)
			{
				Position = new Vector3(screen.X, screen.Y, v.Position.Z)
			};
		}

		public static Vertex ConvertCoordinateSpace(Vertex v, Matrix4x4 matrix)
		{
			Vector3 converted = Vector3.Transform(v, matrix);

			return new Vertex(v) { Position = converted };
		}
	}

	public struct Vertex : IEquatable<Vertex>
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

		public static bool operator ==(Vertex left, Vertex right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Vertex left, Vertex right)
		{
			return !(left == right);
		}

		public override string ToString()
		{
			return Position.ToString();
		}

		public override bool Equals(object? obj)
		{
			return obj is Vertex vertex && Equals(vertex);
		}

		public bool Equals(Vertex other)
		{
			return
				Position.Equals(other.Position) &&
				Normal.Equals(other.Normal) &&
				EqualityComparer<Color>.Default.Equals(Color, other.Color) &&
				TexCoords.Equals(other.TexCoords);
		}

		public override int GetHashCode()
		{
			int hashCode = 252586052;
			hashCode = hashCode * -1521134295 + Position.GetHashCode();
			hashCode = hashCode * -1521134295 + Normal.GetHashCode();
			hashCode = hashCode * -1521134295 + Color.GetHashCode();
			hashCode = hashCode * -1521134295 + TexCoords.GetHashCode();
			return hashCode;
		}
	}
}
