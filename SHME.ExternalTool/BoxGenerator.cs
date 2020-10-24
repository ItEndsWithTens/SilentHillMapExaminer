using OpenTK;
using OpenTK.Graphics;
using System.Collections.Generic;

namespace SHME.ExternalTool
{
	public class BoxGenerator : RenderableGenerator
	{
		public Vector3 Min { get; set; }
		public Vector3 Max { get; set; }

		public BoxGenerator() : this(Color4.Yellow)
		{
		}
		public BoxGenerator(Color4 color) : this(16.0f, color)
		{
		}
		public BoxGenerator(float size, Color4 color) : this(size, size, size, color)
		{
		}
		public BoxGenerator(float width, float depth, float height, Color4 color) : base()
		{
			float Width = width;
			float Depth = depth;
			float Height = height;

			float halfWidth = Width / 2.0f;
			float halfDepth = Depth / 2.0f;
			float halfHeight = Height / 2.0f;

			Min = new Vector3(-halfWidth, -halfHeight, -halfDepth);
			Max = new Vector3(halfWidth, halfHeight, halfDepth);

			Color = color;
		}
		public BoxGenerator(Vector3 min, Vector3 max)
		{
			Min = min;
			Max = max;

			Color = Color4.White;
		}
		public BoxGenerator(Vector3 min, Vector3 max, Color4 color) : this(min, max)
		{
			Color = color;
		}

		public override Renderable Generate()
		{
			var modelVerts = new List<Vertex>()
			{
				// Comments assume Y-up, right-handed coordinates.

				// Negative Y (bottom)
				new Vertex(Min.X, Min.Y, Min.Z),
				new Vertex(Max.X, Min.Y, Min.Z),
				new Vertex(Max.X, Min.Y, Max.Z),
				new Vertex(Min.X, Min.Y, Max.Z),

				// Positive Y (top)
				new Vertex(Max.X, Max.Y, Min.Z, Color4.Lime),
				new Vertex(Min.X, Max.Y, Min.Z, Color4.Lime),
				new Vertex(Min.X, Max.Y, Max.Z, Color4.Lime),
				new Vertex(Max.X, Max.Y, Max.Z, Color4.Lime),

				// Negative X (left)
				new Vertex(Min.X, Min.Y, Min.Z),
				new Vertex(Min.X, Min.Y, Max.Z),
				new Vertex(Min.X, Max.Y, Max.Z),
				new Vertex(Min.X, Max.Y, Min.Z),

				// Positive X (right)
				new Vertex(Max.X, Max.Y, Min.Z, Color4.Red),
				new Vertex(Max.X, Max.Y, Max.Z, Color4.Red),
				new Vertex(Max.X, Min.Y, Max.Z, Color4.Red),
				new Vertex(Max.X, Min.Y, Min.Z, Color4.Red),

				// Positive Z (back)
				new Vertex(Min.X, Min.Y, Max.Z, Color4.Blue),
				new Vertex(Max.X, Min.Y, Max.Z, Color4.Blue),
				new Vertex(Max.X, Max.Y, Max.Z, Color4.Blue),
				new Vertex(Min.X, Max.Y, Max.Z, Color4.Blue),

				// Negative Z (front)
				new Vertex(Max.X, Min.Y, Min.Z),
				new Vertex(Min.X, Min.Y, Min.Z),
				new Vertex(Min.X, Max.Y, Min.Z),
				new Vertex(Max.X, Max.Y, Min.Z)
			};

			var box = new Renderable(modelVerts)
			{
				CoordinateSpace = CoordinateSpace.Model
			};

			for (int i = 0; i < 24; i += 4)
			{
				var p = new Polygon();

				p.LineLoopIndices.Add(i + 0);
				p.LineLoopIndices.Add(i + 1);
				p.LineLoopIndices.Add(i + 2);
				p.LineLoopIndices.Add(i + 3);

				p.Indices.Add(i + 0);
				p.Indices.Add(i + 1);
				p.Indices.Add(i + 2);

				p.Indices.Add(i + 0);
				p.Indices.Add(i + 2);
				p.Indices.Add(i + 3);

				Vector3 a = modelVerts[p.Indices[1]] - modelVerts[p.Indices[0]];
				Vector3 b = modelVerts[p.Indices[2]] - modelVerts[p.Indices[0]];
				p.Normal = Vector3.Cross(a, b);
				p.Normal.Normalize();

				box.Polygons.Add(p);
				box.Indices.AddRange(p.Indices);
				box.LineLoopIndices.AddRange(p.LineLoopIndices);
			}

			box.Transformability = Transformability.Translate;

			return box;
		}
	}
}
