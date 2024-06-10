using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SHME.ExternalTool.Graphics
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
				new Vertex(halfWidth, 0.0f, 0.0f, Color.ToArgb()),
				new Vertex(0.0f, 0.0f, halfHeight, Color.ToArgb()),
				new Vertex(0.0f, -halfDepth, 0.0f, Color.ToArgb()),

				// Top NE
				new Vertex(0.0f, halfDepth, 0.0f, Color.ToArgb()),
				new Vertex(0.0f, 0.0f, halfHeight, Color.ToArgb()),
				new Vertex(halfWidth, 0.0f, 0.0f, Color.ToArgb()),

				// Top NW
				new Vertex(-halfWidth, 0.0f, 0.0f, Color.ToArgb()),
				new Vertex(0.0f, 0.0f, halfHeight, Color.ToArgb()),
				new Vertex(0.0f, halfDepth, 0.0f, Color.ToArgb()),

				// Top SW
				new Vertex(0.0f, -halfDepth, 0.0f, Color.ToArgb()),
				new Vertex(0.0f, 0.0f, halfHeight, Color.ToArgb()),
				new Vertex(-halfWidth, 0.0f, 0.0f, Color.ToArgb()),

				// Bottom NW
				new Vertex(0.0f, halfDepth, 0.0f, Color.ToArgb()),
				new Vertex(0.0f, 0.0f, -halfHeight, Color.ToArgb()),
				new Vertex(-halfWidth, 0.0f, 0.0f, Color.ToArgb()),

				// Bottom NE
				new Vertex(halfWidth, 0.0f, 0.0f, Color.ToArgb()),
				new Vertex(0.0f, 0.0f, -halfHeight, Color.ToArgb()),
				new Vertex(0.0f, halfDepth, 0.0f, Color.ToArgb()),

				// Bottom SE
				new Vertex(0.0f, -halfDepth, 0.0f, Color.ToArgb()),
				new Vertex(0.0f, 0.0f, -halfHeight, Color.ToArgb()),
				new Vertex(halfWidth, 0.0f, 0.0f, Color.ToArgb()),

				// Bottom SW
				new Vertex(-halfWidth, 0.0f, 0.0f, Color.ToArgb()),
				new Vertex(0.0f, 0.0f, -halfHeight, Color.ToArgb()),
				new Vertex(0.0f, -halfDepth, 0.0f, Color.ToArgb())
			};

			var gem = new Renderable() { CoordinateSpace = CoordinateSpace.Model };

			for (int i = 0; i < 24; i += 3)
			{
				var p = new Polygon() { Argb = Color.ToArgb() };

				Vertex a = modelVerts[i + 0];
				Vertex b = modelVerts[i + 1];
				Vertex c = modelVerts[i + 2];

				p.Vertices.Add(a);
				p.Vertices.Add(b);
				p.Vertices.Add(c);

				p.Edges.Add((0, 1, true));
				p.Edges.Add((1, 2, true));
				p.Edges.Add((2, 0, true));

				p.Normal = Vector3.Normalize(Vector3.Cross(b - a, c - a));

				gem.Polygons.Add(p);
			}

			gem.Transformability = Transformability;

			return gem;
		}
	}
}
