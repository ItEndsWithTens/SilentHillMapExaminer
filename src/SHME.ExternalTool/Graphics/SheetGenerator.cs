using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SHME.ExternalTool
{
	public class SheetGenerator : RenderableGenerator
	{
		public Vector2 Min { get; set; }
		public Vector2 Max { get; set; }

		public SheetGenerator() : this(Color.Yellow)
		{
		}
		public SheetGenerator(Color color) : this(16.0f, color)
		{
		}
		public SheetGenerator(float size, Color color) : this(size, size, color)
		{
		}
		public SheetGenerator(float sizeX, float sizeZ, Color color) : base()
		{
			float halfSizeX = sizeX / 2.0f;
			float halfSizeZ = sizeZ / 2.0f;

			Min = new Vector2(-halfSizeX, -halfSizeZ);
			Max = new Vector2(halfSizeX, halfSizeZ);

			Color = color;
		}
		public SheetGenerator(Vector2 min, Vector2 max)
		{
			Min = min;
			Max = max;

			Color = Color.White;
		}
		public SheetGenerator(Vector2 min, Vector2 max, Color color) : this(min, max)
		{
			Color = color;
		}

		public override Renderable Generate()
		{
			var modelVerts = new List<Vertex>()
			{
				// Comments assume Y-up, right-handed coordinates.

				// Negative Y (bottom)
				new Vertex(Min.X, 0.0f, Min.Y, Color),
				new Vertex(Max.X, 0.0f, Min.Y, Color),
				new Vertex(Max.X, 0.0f, Max.Y, Color),
				new Vertex(Min.X, 0.0f, Max.Y, Color),

				// Positive Y (top)
				new Vertex(Max.X, 0.0f, Min.Y, Color),
				new Vertex(Min.X, 0.0f, Min.Y, Color),
				new Vertex(Min.X, 0.0f, Max.Y, Color),
				new Vertex(Max.X, 0.0f, Max.Y, Color)
			};

			var box = new Renderable(modelVerts)
			{
				CoordinateSpace = CoordinateSpace.Model
			};

			for (int i = 0; i < 8; i += 4)
			{
				var p = new Polygon(box);

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
				p.Normal = Vector3.Normalize(p.Normal);

				box.Polygons.Add(p);
				box.Indices.AddRange(p.Indices);
				box.LineLoopIndices.AddRange(p.LineLoopIndices);
			}

			box.Transformability = Transformability.Translate;

			return box;
		}
	}
}
