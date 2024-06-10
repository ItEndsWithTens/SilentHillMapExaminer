using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SHME.ExternalTool.Graphics
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
		/// <summary>
		/// Make a SheetGenerator from a minimum and maximum point in model space.
		/// </summary>
		/// <param name="min">The minimum corner of the sheet, in model space.</param>
		/// <param name="max">The maximum corner of the sheet, in model space.</param>
		public SheetGenerator(Vector2 min, Vector2 max) : this(min, max, Color.White)
		{
		}
		/// <summary>
		/// Make a SheetGenerator from a minimum and maximum point in model space,
		/// and a color.
		/// </summary>
		/// <param name="min">The minimum corner of the sheet, in model space.</param>
		/// <param name="max">The maximum corner of the sheet, in model space.</param>
		/// <param name="color">The color of the sheet.</param>
		public SheetGenerator(Vector2 min, Vector2 max, Color color)
		{
			Min = min;
			Max = max;

			Color = color;
		}

		public override Renderable Generate()
		{
			var modelVerts = new List<Vertex>()
			{
				// Comments assume Y-up, right-handed coordinates.

				// Negative Y (bottom)
				new Vertex(Min.X, 0.0f, Min.Y, Color.ToArgb()),
				new Vertex(Max.X, 0.0f, Min.Y, Color.ToArgb()),
				new Vertex(Max.X, 0.0f, Max.Y, Color.ToArgb()),
				new Vertex(Min.X, 0.0f, Max.Y, Color.ToArgb()),

				// Positive Y (top)
				new Vertex(Max.X, 0.0f, Min.Y, Color.ToArgb()),
				new Vertex(Min.X, 0.0f, Min.Y, Color.ToArgb()),
				new Vertex(Min.X, 0.0f, Max.Y, Color.ToArgb()),
				new Vertex(Max.X, 0.0f, Max.Y, Color.ToArgb())
			};

			var sheet = new Renderable() { CoordinateSpace = CoordinateSpace.Model };

			for (int i = 0; i < 8; i += 4)
			{
				var p = new Polygon() { Argb = Color.ToArgb() };

				Vertex a = modelVerts[i + 0];
				Vertex b = modelVerts[i + 1];
				Vertex c = modelVerts[i + 2];
				Vertex d = modelVerts[i + 3];

				p.Vertices.Add(a);
				p.Vertices.Add(b);
				p.Vertices.Add(c);
				p.Vertices.Add(d);

				p.Edges.Add((0, 1, true));
				p.Edges.Add((1, 2, true));
				p.Edges.Add((2, 3, true));
				p.Edges.Add((3, 0, true));

				p.Normal = Vector3.Normalize(Vector3.Cross(b - a, c - a));

				sheet.Polygons.Add(p);
			}

			sheet.Transformability = Transformability.Translate;

			return sheet;
		}
	}
}
