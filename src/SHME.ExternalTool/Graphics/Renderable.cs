using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SHME.ExternalTool
{
	/// <summary>
	/// Anything that, upon update, needs its representation in the back end updated.
	/// </summary>
	public interface IUpdateBackEnd
	{
		event EventHandler Updated;
	}

	public static class RenderableExtensions
	{
		public static Renderable ToWorld(this Renderable renderable)
		{
			var world = new Renderable(renderable);

			if (world.CoordinateSpace != CoordinateSpace.World)
			{
				var worldVerts = new List<Vertex>();
				foreach (Vertex vertex in world.Vertices)
				{
					worldVerts.Add(
						vertex.ModelToWorld(
							Matrix4x4.CreateTranslation(world.Position)));
				}

				world.Vertices = worldVerts;

				world.CoordinateSpace = CoordinateSpace.World;
				world.ModelMatrix = Matrix4x4.Identity;
			}

			return world;
		}
	}

	public enum CoordinateSpace
	{
		Model,
		World,
		View,
		Projection,
		Screen
	}

	/// <summary>
	/// How a Renderable should be transformed when transforming the MapObject
	/// it belongs to.
	/// </summary>
	public enum Transformability
	{
		None = 0x0,
		Translate = 0x1,
		Rotate = 0x2,
		Scale = 0x4,
		All = Translate | Rotate | Scale
	}

	/// <summary>
	/// Any 2D or 3D object that can be drawn on screen.
	/// </summary>
	/// <remarks>
	/// Vector3s are used even for 2D objects to allow simple depth sorting.
	/// </remarks>
	public class Renderable : IUpdateBackEnd
	{
		public Aabb Aabb { get; protected set; }

		/// <summary>
		/// The coordinate space in which this Renderable's vertices are stored.
		/// </summary>
		/// <remarks>Used to set the ModelMatrix for this Renderable.</remarks>
		public CoordinateSpace CoordinateSpace { get; set; }

		/// <summary>
		/// The vertex indices of this object, relative to the Vertices list.
		/// </summary>
		public List<int> Indices;
		public List<int> LineLoopIndices { get; } = new List<int>();

		/// <summary>
		/// The transformation matrix used to bring this Renderable's vertices
		/// into world space from object space.
		/// </summary>
		/// <remarks>Allows for object's vertices to be stored as coordinates in
		/// world space, object space, or anything else. Actual 3D objects can
		/// be drawn with minimal effort, as well as UI elements associated with
		/// said objects, or placeholder meshes, etc. Set the CoordinateSpace
		/// field to switch the matrix used for this Renderable.</remarks>
		public Matrix4x4 ModelMatrix { get; set; }

		public List<Polygon> Polygons { get; } = new List<Polygon>();

		protected Vector3 _position;
		public Vector3 Position
		{
			get { return _position; }
			set
			{
				TranslateRelative(value - _position);
				_position = value;
			}
		}

		public bool Selected { get; set; } = false;

		/// <summary>
		/// What transformations this Renderable supports.
		/// </summary>
		public Transformability Transformability { get; set; }

		public bool Translucent;

		/// <summary>
		/// Vertices of this object.
		/// </summary>
		public List<Vertex> Vertices;

		// TODO: Hoist these up into the backend? Make a dictionary, keyed by a Renderable
		// instance with a value of a tuple, (VertexOffset, IndexOffset). In principle, things
		// to be rendered shouldn't need to carry around information about their place in the
		// backend's buffers, right? Even though this doesn't involve any OpenTK/OpenGL-specific
		// stuff, it's still ugly, and I think unnecessary.
		/// <summary>
		/// The starting offset in bytes of this renderable's vertices, relative
		/// to the back end buffer they're stored in.
		/// </summary>
		public IntPtr VertexOffset { get; set; } = IntPtr.Zero;
		/// <summary>
		/// The starting offset in bytes of this renderable's vertex indices,
		/// relative to the back end buffer they're stored in.
		/// </summary>
		public IntPtr IndexOffset { get; set; } = IntPtr.Zero;

		public IntPtr LineLoopIndexOffset { get; set; } = IntPtr.Zero;

		/// <summary>
		/// If defined, this color will replace this Renderable's deselected color.
		/// </summary>
		public Color? Tint { get; set; } = null;

		public event EventHandler? Updated;

		public Renderable()
		{
			Aabb = new Aabb();
			CoordinateSpace = CoordinateSpace.World;
			Indices = new List<int>();
			ModelMatrix = Matrix4x4.Identity;
			Transformability = Transformability.All;
			Translucent = false;
			Vertices = new List<Vertex>();
		}
		public Renderable(List<Vector3> points) : this()
		{
			foreach (Vector3 point in points)
			{
				Vertices.Add(new Vertex(point.X, point.Y, point.Z));
			}

			Aabb = new Aabb(Vertices);
		}
		public Renderable(List<Vertex> vertices) : this()
		{
			foreach (Vertex vertex in vertices)
			{
				Vertices.Add(vertex);
			}

			Aabb = new Aabb(Vertices);
		}
		public Renderable(Renderable r)
		{
			Aabb = new Aabb(r.Aabb);
			CoordinateSpace = r.CoordinateSpace;
			Indices = new List<int>(r.Indices);
			LineLoopIndices = new List<int>(r.LineLoopIndices);
			ModelMatrix = r.ModelMatrix;

			Polygons = new List<Polygon>(r.Polygons);
			foreach (Polygon p in Polygons)
			{
				p.Renderable = this;
			}

			_position = r.Position;
			Translucent = r.Translucent;
			Vertices = new List<Vertex>(r.Vertices);
		}

		protected void Rotate(Vector3 rotation, Vector3 origin)
		{
			Rotate(rotation.Y, rotation.Z, rotation.X, origin);
		}
		protected void Rotate(float pitch, float yaw, float roll, Vector3 origin)
		{
			if (Transformability.HasFlag(Transformability.Rotate))
			{
				for (int i = 0; i < Vertices.Count; i++)
				{
					Vertex world = Vertices[i].ModelToWorld(ModelMatrix);
					var rotated = Vertex.Rotate(world, pitch, yaw, roll, origin);
					Vertices[i] = rotated.WorldToModel(ModelMatrix);
				}

				for (int i = 0; i < Polygons.Count; i++)
				{
					Polygons[i] = Polygon.Rotate(Polygons[i], pitch, yaw, roll, origin);
				}
			}
			else if (Transformability.HasFlag(Transformability.Translate))
			{
				Position = Position.Rotate(pitch, yaw, roll, origin);
			}

			UpdateBounds();
		}

		protected void Scale(Vector3 scale)
		{
			Scale(scale.X, scale.Y, scale.Z);
		}
		protected void Scale(float x, float y, float z)
		{
			for (int i = 0; i < Vertices.Count; i++)
			{
				Vertex scaled = Vertices[i];

				scaled.Position = new Vector3
				{
					X = scaled.Position.X * x,
					Y = scaled.Position.Y * y,
					Z = scaled.Position.Z * z
				};

				Vertices[i] = scaled;
			}

			for (int i = 0; i < Polygons.Count; i++)
			{
				Polygon scaled = Polygons[i];

				// TODO: Understand, and explain in a comment, why the basis
				// vectors need to be divided by the scale instead of multiplied
				// like the vertex positions. I figured this out by observation,
				// and honestly have no idea why it works.

				scaled.BasisS = new Vector3
				{
					X = scaled.BasisS.X / x,
					Y = scaled.BasisS.Y / y,
					Z = scaled.BasisS.Z / z
				};

				scaled.BasisT = new Vector3
				{
					X = scaled.BasisT.X / x,
					Y = scaled.BasisT.Y / y,
					Z = scaled.BasisT.Z / z
				};

				Polygons[i] = scaled;
			}
		}

		public void Transform(Vector3 translation, Vector3 rotation, Vector3 scale, Vector3 origin)
		{
			if (Transformability.HasFlag(Transformability.Scale) && scale != null)
			{
				Scale(scale);
			}

			if (rotation != null)
			{
				Rotate(rotation, origin);
			}

			if (Transformability.HasFlag(Transformability.Translate) && translation != null)
			{
				TranslateRelative(translation);
			}

			UpdateBounds();

			_position = Aabb.Center;
		}

		protected void TranslateRelative(Vector3 diff)
		{
			if (CoordinateSpace == CoordinateSpace.World)
			{
				for (int i = 0; i < Vertices.Count; i++)
				{
					Vertices[i] = Vertex.TranslateRelative(Vertices[i], diff);
				}
			}

			for (int i = 0; i < Polygons.Count; i++)
			{
				Polygons[i] = Polygon.TranslateRelative(Polygons[i], diff);
			}

			if (CoordinateSpace == CoordinateSpace.Model)
			{
				ModelMatrix *= Matrix4x4.CreateTranslation(diff);
			}

			Aabb += diff;
		}
		public void TranslateRelative(float diffX, float diffY, float diffZ)
		{
			TranslateRelative(new Vector3(diffX, diffY, diffZ));
		}

		// TODO: Add a boolean to avoid updating the buffers? Add an overload
		// for it so it defaults to true, but allow people to avoid the update
		// so they can do a run of renderable color changes at once.
		//
		// TODO: Have SetColor return the object's previous color? To allow
		// callers to set the old color back, if they want.
		/// <summary>
		/// Give this renderable's vertices an arbitrary color, ignoring the
		/// values in its Colors dictionary.
		/// </summary>
		public void SetColor(Color color)
		{
			foreach (Polygon p in Polygons)
			{
				p.Color = color;
			}

			OnUpdated();
		}

		public Aabb UpdateBounds()
		{
			var worldVerts = new List<Vector3>();
			foreach (Vertex v in Vertices)
			{
				Vector3 world = Vector3.Transform(v.Position, ModelMatrix);

				worldVerts.Add(world);
			}

			Aabb = new Aabb(worldVerts);

			return Aabb;
		}

		public void UpdateModelMatrix()
		{
			switch (CoordinateSpace)
			{
				case CoordinateSpace.Model:
					// TODO: Figure out if this is necessary, and if it is, convert
					// it to Y-up right-handed like everything else.
					//ModelMatrix = Matrix4.CreateTranslation(Position.X, Position.Z, -Position.Y);
					break;
				case CoordinateSpace.World:
				default:
					ModelMatrix = Matrix4x4.Identity;
					break;
				case CoordinateSpace.View:
					break;
				case CoordinateSpace.Projection:
					break;
				case CoordinateSpace.Screen:
					break;
			}
		}

		protected virtual void OnUpdated()
		{
			OnUpdated(new EventArgs());
		}
		protected virtual void OnUpdated(EventArgs e)
		{
			Updated?.Invoke(this, e);
		}
	}
}
