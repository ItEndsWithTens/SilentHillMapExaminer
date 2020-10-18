using OpenTK.Graphics;

namespace SHME.ExternalTool
{
	public class RenderableGenerator
	{
		public Color4 Color { get; set; } = Color4.White;

		public Transformability Transformability { get; set; }

		public RenderableGenerator()
		{
		}
		public RenderableGenerator(Color4 color)
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
