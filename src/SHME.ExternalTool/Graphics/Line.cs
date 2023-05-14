﻿namespace SHME.ExternalTool
{
	public class Line : Renderable
	{
		public Vertex A
		{
			get => Vertices[0];
			set
			{
				Vertices[0] = value;

				UpdateBounds();
			}
		}

		public Vertex B
		{
			get => Vertices[1];
			set
			{
				Vertices[1] = value;

				UpdateBounds();
			}
		}

		public Line() : this(new Vertex(), new Vertex())
		{
		}
		public Line(Vertex a, Vertex b)
		{
			Vertices.Capacity = 2;

			Vertices.Add(a);
			Vertices.Add(b);

			UpdateBounds();
		}
		public Line(Line line) : base(line)
		{
			Vertices.Capacity = 2;

			Vertices.Add(line.A);
			Vertices.Add(line.B);

			UpdateBounds();
		}
	}
}
