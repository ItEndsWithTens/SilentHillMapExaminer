using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SHME.ExternalTool.Graphics;

public class BitmapBackend : IGraphicsBackend
{
	private bool _antialiasing;
	public bool Antialiasing
	{
		get => _antialiasing;
		set
		{
			_antialiasing = value;

			_graphics.SmoothingMode = value switch
			{
				true => SmoothingMode.AntiAlias,
				_ => SmoothingMode.Default
			};
		}
	}

	private readonly System.Drawing.Graphics _graphics;

	public BitmapBackend(Bitmap overlay)
	{
		_graphics = System.Drawing.Graphics.FromImage(overlay);
		_graphics.CompositingMode = CompositingMode.SourceCopy;
		_graphics.CompositingQuality = CompositingQuality.HighSpeed;
	}

	public void Clear(int alpha, int red, int green, int blue)
	{
		_graphics.Clear(Color.FromArgb(alpha, red, green, blue));
	}

	public void DrawEllipse(Pen pen, int x, int y, int width, int height)
	{
		_graphics.FillEllipse(pen.Brush, x, y, width, height);
	}

	public void DrawLine(Pen pen, int x1, int y1, int x2, int y2)
	{
		_graphics.DrawLine(pen, x1, y1, x2, y2);
	}

	public void DrawPolygon(Pen pen, Point[] points)
	{
		_graphics.FillPolygon(pen.Brush, points);
	}

	public void DrawReticle(Pen pen, int left, int top, int width, int height, float percent)
	{
		int size = (int)Math.Round(height * (percent / 100.0f));
		int centerW = left + width / 2;
		int centerH = top + height / 2;

		pen.Color = Color.White;

		_graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		_graphics.PixelOffsetMode = PixelOffsetMode.None;
		_graphics.SmoothingMode = SmoothingMode.Default;

		_graphics.DrawRectangle(pen, left, top, width - 1, height - 1);

		_graphics.DrawLine(pen, left, centerH, left + size, centerH);
		_graphics.DrawLine(pen, centerW - size / 2, centerH, centerW + size / 2, centerH);
		_graphics.DrawLine(pen, left + (width - 1 - size), centerH, left + (width - 1), centerH);

		_graphics.DrawLine(pen, centerW, top, centerW, top + size);
		_graphics.DrawLine(pen, centerW, centerH - size / 2, centerW, centerH + size / 2);
		_graphics.DrawLine(pen, centerW, top + (height - 1 - size), centerW, top + (height - 1));
	}
}
