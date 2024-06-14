using BizHawk.Client.Common;
using System;
using System.Drawing;

namespace SHME.ExternalTool.Graphics;

public class BizHawkGuiBackend(IGuiApi gui) : IGraphicsBackend
{
	public bool Antialiasing { get; set; }

	private readonly IGuiApi _gui = gui;

	public void Clear(int alpha, int red, int green, int blue)
	{
		_gui.ClearGraphics();
	}

	public void DrawEllipse(Pen pen, int x, int y, int width, int height)
	{
		_gui.DrawEllipse(x, y, width, height, pen.Color, pen.Color);
	}

	public void DrawLine(Pen pen, int x1, int y1, int x2, int y2)
	{
		_gui.DrawLine(x1, y1, x2, y2, pen.Color);
	}

	public void DrawPolygon(Pen pen, Point[] points)
	{
		_gui.DrawPolygon(points, pen.Color, pen.Color);
	}

	public void DrawReticle(Pen pen, int left, int top, int width, int height, float percent)
	{
		int size = (int)Math.Round(height * (percent / 100.0f));
		int centerW = left + width / 2;
		int centerH = top + height / 2;

		var color = Color.White;

		_gui.DrawRectangle(left, top, width - 1, height - 1, color);

		_gui.DrawLine(left, centerH, left + size, centerH, color);
		_gui.DrawLine(centerW - size / 2, centerH, centerW + size / 2, centerH, color);
		_gui.DrawLine(left + (width - 1 - size), centerH, left + (width - 1), centerH, color);

		_gui.DrawLine(centerW, top, centerW, top + size, color);
		_gui.DrawLine(centerW, centerH - size / 2, centerW, centerH + size / 2, color);
		_gui.DrawLine(centerW, top + (height - 1 - size), centerW, top + (height - 1), color);
	}
}
