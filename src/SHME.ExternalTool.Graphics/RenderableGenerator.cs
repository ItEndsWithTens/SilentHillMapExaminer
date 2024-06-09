using System.Drawing;

namespace SHME.ExternalTool.Graphics
{
	public class RenderableGenerator
	{
		public Color Color { get; set; } = Color.White;

		public Transformability Transformability { get; set; }

		public RenderableGenerator()
		{
		}
		public RenderableGenerator(Color color)
		{
			Color = color;
		}

		public virtual Renderable Generate()
		{
			var r = new Renderable();

			return r;
		}
	}
}
