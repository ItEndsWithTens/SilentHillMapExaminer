using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SHME.ExternalTool
{
	public class GemGenerator : RenderableGenerator
	{
		public float Width { get; set; }
		public float Depth { get; set; }
		public float Height { get; set; }

		public GemGenerator() : this(8.0f, 8.0f, 16.0f, Color.Yellow)
		{
		}
		public GemGenerator(Color color) : this(8.0f, 8.0f, 16.0f, color)
		{
		}
		public GemGenerator(float width, float depth, float height, Color color) : base(color)
		{
			Width = width;
			Depth = depth;
			Height = height;
		}

		public override Renderable Generate()
		{
			float halfWidth = Width / 2.0f;
			float halfDepth = Depth / 2.0f;
			float halfHeight = Height / 2.0f;

			var modelVerts = new List<Vertex>()
			{
				// Top SE
				new Vertex(halfWidth, 0.0f, 0.0f, Color),
				new Vertex(0.0f, 0.0f, halfHeight, Color),
				new Vertex(0.0f, -halfDepth, 0.0f, Color),

				// Top NE
				new Vertex(0.0f, halfDepth, 0.0f, Color),
				new Vertex(0.0f, 0.0f, halfHeight, Color),
				new Vertex(halfWidth, 0.0f, 0.0f, Color),

				// Top NW
				new Vertex(-halfWidth, 0.0f, 0.0f, Color),
				new Vertex(0.0f, 0.0f, halfHeight, Color),
				new Vertex(0.0f, halfDepth, 0.0f, Color),

				// Top SW
				new Vertex(0.0f, -halfDepth, 0.0f, Color),
				new Vertex(0.0f, 0.0f, halfHeight, Color),
				new Vertex(-halfWidth, 0.0f, 0.0f, Color),

				// Bottom NW
				new Vertex(0.0f, halfDepth, 0.0f, Color),
				new Vertex(0.0f, 0.0f, -halfHeight, Color),
				new Vertex(-halfWidth, 0.0f, 0.0f, Color),

				// Bottom NE
				new Vertex(halfWidth, 0.0f, 0.0f, Color),
				new Vertex(0.0f, 0.0f, -halfHeight, Color),
				new Vertex(0.0f, halfDepth, 0.0f, Color),

				// Bottom SE
				new Vertex(0.0f, -halfDepth, 0.0f, Color),
				new Vertex(0.0f, 0.0f, -halfHeight, Color),
				new Vertex(halfWidth, 0.0f, 0.0f, Color),

				// Bottom SW
				new Vertex(-halfWidth, 0.0f, 0.0f, Color),
				new Vertex(0.0f, 0.0f, -halfHeight, Color),
				new Vertex(0.0f, -halfDepth, 0.0f, Color)
			};

			var gem = new Renderable(modelVerts)
			{
				CoordinateSpace = CoordinateSpace.Model
			};

			for (int i = 0; i < 24; i += 3)
			{
				var p = new Polygon(gem);

				p.Indices.Add(i + 0);
				p.Indices.Add(i + 1);
				p.Indices.Add(i + 2);

				// Since gems are composed only of triangles, their line loop
				// indices serve as the triangle indices too.
				p.LineLoopIndices.AddRange(p.Indices);

				Vector3 a = modelVerts[p.Indices[1]] - modelVerts[p.Indices[0]];
				Vector3 b = modelVerts[p.Indices[2]] - modelVerts[p.Indices[0]];
				p.Normal = Vector3.Cross(a, b);
				p.Normal = Vector3.Normalize(p.Normal);

				gem.Polygons.Add(p);
				gem.Indices.AddRange(p.Indices);
				gem.LineLoopIndices.AddRange(p.LineLoopIndices);
			}

			gem.Transformability = Transformability;

			return gem;
		}
	}
}
