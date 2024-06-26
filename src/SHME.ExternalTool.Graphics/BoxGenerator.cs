﻿using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SHME.ExternalTool.Graphics
{
	public class BoxGenerator : RenderableGenerator
	{
		public Vector3 Min { get; set; }
		public Vector3 Max { get; set; }

		public BoxGenerator() : this(Color.Yellow)
		{
		}
		public BoxGenerator(Color color) : this(16.0f, color)
		{
		}
		public BoxGenerator(float size, Color color) : this(size, size, size, color)
		{
		}
		public BoxGenerator(Vector3 size, Color color) : this(size.X, size.Y, size.Z, color)
		{
		}
		public BoxGenerator(float sizeX, float sizeY, float sizeZ, Color color) : base()
		{
			float halfSizeX = sizeX / 2.0f;
			float halfSizeY = sizeY / 2.0f;
			float halfSizeZ = sizeZ / 2.0f;

			Min = new Vector3(-halfSizeX, -halfSizeY, -halfSizeZ);
			Max = new Vector3(halfSizeX, halfSizeY, halfSizeZ);

			Color = color;
		}
		/// <summary>
		/// Make a BoxGenerator from a minimum and maximum point in model space.
		/// </summary>
		/// <param name="min">The minimum corner of the box, in model space.</param>
		/// <param name="max">The maximum corner of the box, in model space.</param>
		public BoxGenerator(Vector3 min, Vector3 max) : this(min, max, Color.White)
		{
		}
		/// <summary>
		/// Make a BoxGenerator from a minimum and maximum point in model space,
		/// and a color.
		/// </summary>
		/// <param name="min">The minimum corner of the box, in model space.</param>
		/// <param name="max">The maximum corner of the box, in model space.</param>
		/// <param name="color">The color of the box.</param>
		public BoxGenerator(Vector3 min, Vector3 max, Color color)
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
				new Vertex(Min.X, Min.Y, Min.Z, Color.ToArgb()),
				new Vertex(Max.X, Min.Y, Min.Z, Color.ToArgb()),
				new Vertex(Max.X, Min.Y, Max.Z, Color.ToArgb()),
				new Vertex(Min.X, Min.Y, Max.Z, Color.ToArgb()),

				// Positive Y (top)
				new Vertex(Max.X, Max.Y, Min.Z, Color.ToArgb()),
				new Vertex(Min.X, Max.Y, Min.Z, Color.ToArgb()),
				new Vertex(Min.X, Max.Y, Max.Z, Color.ToArgb()),
				new Vertex(Max.X, Max.Y, Max.Z, Color.ToArgb()),

				// Negative X (left)
				new Vertex(Min.X, Min.Y, Min.Z, Color.ToArgb()),
				new Vertex(Min.X, Min.Y, Max.Z, Color.ToArgb()),
				new Vertex(Min.X, Max.Y, Max.Z, Color.ToArgb()),
				new Vertex(Min.X, Max.Y, Min.Z, Color.ToArgb()),

				// Positive X (right)
				new Vertex(Max.X, Max.Y, Min.Z, Color.ToArgb()),
				new Vertex(Max.X, Max.Y, Max.Z, Color.ToArgb()),
				new Vertex(Max.X, Min.Y, Max.Z, Color.ToArgb()),
				new Vertex(Max.X, Min.Y, Min.Z, Color.ToArgb()),

				// Positive Z (back)
				new Vertex(Min.X, Min.Y, Max.Z, Color.ToArgb()),
				new Vertex(Max.X, Min.Y, Max.Z, Color.ToArgb()),
				new Vertex(Max.X, Max.Y, Max.Z, Color.ToArgb()),
				new Vertex(Min.X, Max.Y, Max.Z, Color.ToArgb()),

				// Negative Z (front)
				new Vertex(Max.X, Min.Y, Min.Z, Color.ToArgb()),
				new Vertex(Min.X, Min.Y, Min.Z, Color.ToArgb()),
				new Vertex(Min.X, Max.Y, Min.Z, Color.ToArgb()),
				new Vertex(Max.X, Max.Y, Min.Z, Color.ToArgb())
			};

			var box = new Renderable() { CoordinateSpace = CoordinateSpace.Model };

			for (int i = 0; i < 24; i += 4)
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

				p.Normal = Vector3.Cross(b - a, c - a);
				p.Normal = Vector3.Normalize(p.Normal);

				box.Polygons.Add(p);
			}

			box.Transformability = Transformability.Translate;

			return box;
		}

		public Renderable GenerateRainbowBox()
		{
			Color colorMinMinMin = Color.Black;
			Color colorMaxMinMin = Color.Red;
			Color colorMaxMinMax = Color.Lime;
			Color colorMinMinMax = Color.Blue;

			Color colorMaxMaxMin = Color.Cyan;
			Color colorMinMaxMin = Color.Magenta;
			Color colorMinMaxMax = Color.Yellow;
			Color colorMaxMaxMax = Color.White;

			var modelVerts = new List<Vertex>()
			{
				// Comments assume Y-up, right-handed coordinates.

				// Negative Y (bottom)
				new Vertex(Min.X, Min.Y, Min.Z, colorMinMinMin.ToArgb()),
				new Vertex(Max.X, Min.Y, Min.Z, colorMaxMinMin.ToArgb()),
				new Vertex(Max.X, Min.Y, Max.Z, colorMaxMinMax.ToArgb()),
				new Vertex(Min.X, Min.Y, Max.Z, colorMinMinMax.ToArgb()),

				// Positive Y (top)
				new Vertex(Max.X, Max.Y, Min.Z, colorMaxMaxMin.ToArgb()),
				new Vertex(Min.X, Max.Y, Min.Z, colorMinMaxMin.ToArgb()),
				new Vertex(Min.X, Max.Y, Max.Z, colorMinMaxMax.ToArgb()),
				new Vertex(Max.X, Max.Y, Max.Z, colorMaxMaxMax.ToArgb()),

				// Negative X (left)
				new Vertex(Min.X, Min.Y, Min.Z, colorMinMinMin.ToArgb()),
				new Vertex(Min.X, Min.Y, Max.Z, colorMinMinMax.ToArgb()),
				new Vertex(Min.X, Max.Y, Max.Z, colorMinMaxMax.ToArgb()),
				new Vertex(Min.X, Max.Y, Min.Z, colorMinMaxMin.ToArgb()),

				// Positive X (right)
				new Vertex(Max.X, Max.Y, Min.Z, colorMaxMaxMin.ToArgb()),
				new Vertex(Max.X, Max.Y, Max.Z, colorMaxMaxMax.ToArgb()),
				new Vertex(Max.X, Min.Y, Max.Z, colorMaxMinMax.ToArgb()),
				new Vertex(Max.X, Min.Y, Min.Z, colorMaxMinMin.ToArgb()),

				// Positive Z (back)
				new Vertex(Min.X, Min.Y, Max.Z, colorMinMinMax.ToArgb()),
				new Vertex(Max.X, Min.Y, Max.Z, colorMaxMinMax.ToArgb()),
				new Vertex(Max.X, Max.Y, Max.Z, colorMaxMaxMax.ToArgb()),
				new Vertex(Min.X, Max.Y, Max.Z, colorMinMaxMax.ToArgb()),

				// Negative Z (front)
				new Vertex(Max.X, Min.Y, Min.Z, colorMaxMinMin.ToArgb()),
				new Vertex(Min.X, Min.Y, Min.Z, colorMinMinMin.ToArgb()),
				new Vertex(Min.X, Max.Y, Min.Z, colorMinMaxMin.ToArgb()),
				new Vertex(Max.X, Max.Y, Min.Z, colorMaxMaxMin.ToArgb())
			};

			var box = new Renderable()
			{
				CoordinateSpace = CoordinateSpace.Model
			};

			for (int i = 0; i < 24; i += 4)
			{
				var p = new Polygon();

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

				p.Normal = Vector3.Cross(b - a, c - a);
				p.Normal = Vector3.Normalize(p.Normal);

				box.Polygons.Add(p);
			}

			box.Transformability = Transformability.Translate;

			return box;
		}
	}
}
