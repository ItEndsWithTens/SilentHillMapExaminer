using System.Drawing;

namespace SHME.ExternalTool.Graphics;

public interface IGraphicsBackend
{
	public bool Antialiasing { get; set; }

	public void Clear(int alpha, int red, int green, int blue);

	public void DrawEllipse(Pen pen, int x, int y, int width, int height);
	public void DrawLine(Pen pen, int x1, int y1, int x2, int y2);
	public void DrawPolygon(Pen pen, Point[] points);
	public void DrawReticle(Pen pen, int left, int top, int width, int height, float percent);
}
