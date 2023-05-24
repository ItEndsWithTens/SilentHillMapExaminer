using BizHawk.Common.CollectionExtensions;
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
		public static Renderable ClipAgainstPlane(this Renderable r, Plane plane)
		{
			var clipped = new Renderable(r);

			for (int i = 0; i < clipped.Polygons.Count; i++)
			{
				clipped.Polygons[i].ClipAgainstPlane(plane);
			}

			return clipped;
		}

		public static Renderable ToWorld(this Renderable renderable)
		{
			var world = new Renderable(renderable);

			if (world.CoordinateSpace != CoordinateSpace.World)
			{
				foreach (Polygon polygon in world.Polygons)
				{
					var worldVerts = new List<Vertex>();

					foreach (Vertex vertex in polygon.Vertices)
					{
						worldVerts.Add(
							vertex.ModelToWorld(
								Matrix4x4.CreateTranslation(world.Position)));
					}

					polygon.Vertices.Clear();
					polygon.Vertices.AddRange(worldVerts);
				}

				world.CoordinateSpace = CoordinateSpace.World;
				world.ModelMatrix = Matrix4x4.Identity;

				world.UpdateBounds();
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
	[Flags]
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
		public Aabb Aabb { get; protected set; } = new Aabb();

		/// <summary>
		/// The coordinate space in which this Renderable's vertices are stored.
		/// </summary>
		/// <remarks>Used to set the ModelMatrix for this Renderable.</remarks>
		public CoordinateSpace CoordinateSpace { get; set; } = CoordinateSpace.World;

		/// <summary>
		/// The transformation matrix used to bring this Renderable's vertices
		/// into world space from object space.
		/// </summary>
		/// <remarks>Allows for object's vertices to be stored as coordinates in
		/// world space, object space, or anything else. Actual 3D objects can
		/// be drawn with minimal effort, as well as UI elements associated with
		/// said objects, or placeholder meshes, etc. Set the CoordinateSpace
		/// field to switch the matrix used for this Renderable.</remarks>
		public Matrix4x4 ModelMatrix { get; set; } = Matrix4x4.Identity;

		public IList<Polygon> Polygons { get; } = new List<Polygon>(6);

		protected Vector3 _position;
		public Vector3 Position
		{
			get => _position;
			set
			{
				TranslateRelative(value - _position);
				_position = value;
			}
		}

		public bool Selected { get; set; }

		/// <summary>
		/// What transformations this Renderable supports.
		/// </summary>
		public Transformability Transformability { get; set; } = Transformability.All;

		public bool Translucent { get; set; }

		/// <summary>
		/// If defined, this color will replace this Renderable's deselected color.
		/// </summary>
		public Color? Tint { get; set; }

		public event EventHandler? Updated;

		public Renderable()
		{
		}
		public Renderable(IEnumerable<Polygon> polygons) : this()
		{
			foreach (Polygon p in polygons)
			{
				Polygons.Add(p);
			}

			UpdateBounds();
		}
		public Renderable(Renderable r)
		{
			Aabb = new Aabb(r.Aabb);
			CoordinateSpace = r.CoordinateSpace;
			ModelMatrix = r.ModelMatrix;
			Polygons = new List<Polygon>(r.Polygons);
			_position = r.Position;
			Tint = r.Tint;
			Translucent = r.Translucent;
		}

		protected void Rotate(Vector3 rotation, Vector3 origin)
		{
			if (Transformability.FasterHasFlag(Transformability.Rotate))
			{
				for (int i = 0; i < Polygons.Count; i++)
				{
					Polygons[i].Rotate(rotation, origin);
				}
			}
			else if (Transformability.FasterHasFlag(Transformability.Translate))
			{
				Position = Position.Rotate(rotation, origin);
			}

			UpdateBounds();
		}

		protected void Scale(Vector3 scale)
		{
			for (int i = 0; i < Polygons.Count; i++)
			{
				Polygons[i].Scale(scale);
			}
		}

		public void Transform(Vector3 translation, Vector3 rotation, Vector3 scale, Vector3 origin)
		{
			if (Transformability.FasterHasFlag(Transformability.Scale) && scale != null)
			{
				Scale(scale);
			}

			if (rotation != null)
			{
				Rotate(rotation, origin);
			}

			if (Transformability.FasterHasFlag(Transformability.Translate) && translation != null)
			{
				TranslateRelative(translation);
			}

			UpdateBounds();

			_position = Aabb.Center;
		}

		// TODO: Reverse the overload of this! Stop creating a new
		// Vector3 every time somebody calls TranslateRelative with
		// three floats, especially since Matrix4x4.CreateTranslation
		// has its own overload that takes floats.
		protected void TranslateRelative(Vector3 diff)
		{
			switch (CoordinateSpace)
			{
				case CoordinateSpace.World:
					for (int i = 0; i < Polygons.Count; i++)
					{
						Polygons[i].TranslateRelative(diff);
					}
					break;
				case CoordinateSpace.Model:
					ModelMatrix *= Matrix4x4.CreateTranslation(diff);
					break;
				default:
					break;
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
			Vector3 min = Polygons[0].Vertices[0];
			Vector3 max = Polygons[0].Vertices[0];

			for (int i = 0; i < Polygons.Count; i++)
			{
				Polygon p = Polygons[i];

				for (int j = 0; j < p.Vertices.Count; j++)
				{
					Vertex v = p.Vertices[j];

					if (v.Position.X < min.X)
					{
						min.X = v.Position.X;
					}
					else if (v.Position.X > max.X)
					{
						max.X = v.Position.X;
					}

					if (v.Position.Y < min.Y)
					{
						min.Y = v.Position.Y;
					}
					else if (v.Position.Y > max.Y)
					{
						max.Y = v.Position.Y;
					}

					if (v.Position.Z < min.Z)
					{
						min.Z = v.Position.Z;
					}
					else if (v.Position.Z > max.Z)
					{
						max.Z = v.Position.Z;
					}
				}
			}

			Aabb.Update(min, max);

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
			OnUpdated(EventArgs.Empty);
		}
		protected virtual void OnUpdated(EventArgs e)
		{
			Updated?.Invoke(this, e);
		}
	}
}
