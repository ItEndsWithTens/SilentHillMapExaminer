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

			Min = new Vector3(-halfWidth, -halfDepth, -halfHeight);
			Max = new Vector3(halfWidth, halfDepth, halfHeight);

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
				// Bottom
				new Vertex(Min.X, Min.Y, Min.Z),
				new Vertex(Min.X, Max.Y, Min.Z),
				new Vertex(Max.X, Max.Y, Min.Z),
				new Vertex(Max.X, Min.Y, Min.Z),

				// Top
				new Vertex(Max.X, Min.Y, Max.Z),
				new Vertex(Max.X, Max.Y, Max.Z),
				new Vertex(Min.X, Max.Y, Max.Z),
				new Vertex(Min.X, Min.Y, Max.Z),

				// Left
				new Vertex(Min.X, Min.Y, Min.Z),
				new Vertex(Min.X, Min.Y, Max.Z),
				new Vertex(Min.X, Max.Y, Max.Z),
				new Vertex(Min.X, Max.Y, Min.Z),

				// Right
				new Vertex(Max.X, Max.Y, Min.Z),
				new Vertex(Max.X, Max.Y, Max.Z),
				new Vertex(Max.X, Min.Y, Max.Z),
				new Vertex(Max.X, Min.Y, Min.Z),

				// Front
				new Vertex(Min.X, Max.Y, Min.Z),
				new Vertex(Min.X, Max.Y, Max.Z),
				new Vertex(Max.X, Max.Y, Max.Z),
				new Vertex(Max.X, Max.Y, Min.Z),

				// Back
				new Vertex(Max.X, Min.Y, Min.Z),
				new Vertex(Max.X, Min.Y, Max.Z),
				new Vertex(Min.X, Min.Y, Max.Z),
				new Vertex(Min.X, Min.Y, Min.Z)
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
