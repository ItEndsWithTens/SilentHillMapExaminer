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

			var gem = new Renderable() { CoordinateSpace = CoordinateSpace.Model };

			for (int i = 0; i < 24; i += 3)
			{
				var p = new Polygon(gem) { Color = Color };

				Vertex a = modelVerts[i + 0];
				Vertex b = modelVerts[i + 1];
				Vertex c = modelVerts[i + 2];

				p.Vertices.Add(a);
				p.Vertices.Add(b);
				p.Vertices.Add(c);

				p.Normal = Vector3.Normalize(Vector3.Cross(b - a, c - a));

				gem.Polygons.Add(p);
			}

			gem.Transformability = Transformability;

			return gem;
		}
	}
}
