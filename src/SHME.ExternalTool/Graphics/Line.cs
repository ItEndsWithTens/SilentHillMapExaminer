namespace SHME.ExternalTool
{
	public class Line : Renderable
	{
		public Vertex A
		{
			get => Polygons[0].Vertices[0];
			set
			{
				Polygons[0].Vertices[0] = value;

				UpdateBounds();
			}
		}

		public Vertex B
		{
			get => Polygons[0].Vertices[1];
			set
			{
				Polygons[0].Vertices[1] = value;

				UpdateBounds();
			}
		}

		public Line() : this(new Vertex(), new Vertex())
		{
		}
		public Line(Vertex a, Vertex b)
		{
			Polygons.Add(new Polygon(this));

			Polygons[0].Vertices.Add(a);
			Polygons[0].Vertices.Add(b);

			UpdateBounds();
		}
		public Line(Line line) : base(line)
		{
			Polygons.Clear();
			Polygons.Add(line.Polygons[0]);

			Polygons[0].Vertices.Add(line.A);
			Polygons[0].Vertices.Add(line.B);

			UpdateBounds();
		}
	}
}
