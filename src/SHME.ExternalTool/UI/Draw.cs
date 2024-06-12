using BizHawk.Client.Common;
using SHME.ExternalTool.Graphics;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BizHawk.Client.EmuHawk;

public partial class CustomMainForm
{
	private Action _drawOverlay = null!;
	private Action DrawOverlay
	{
		get => _drawOverlay;
		set
		{
			_drawOverlay = value;

			if (value == DrawOverlayGui)
			{
				_drawEllipse = DrawEllipseGui;
				_drawLine = DrawLineGui;
				_drawPolygon = DrawPolygonGui;

				CbxAntialiasing.Checked = false;
				CbxAntialiasing.Enabled = false;
			}
			else
			{
				_drawEllipse = DrawEllipseBitmap;
				_drawLine = DrawLineBitmap;
				_drawPolygon = DrawPolygonBitmap;

				CbxAntialiasing.Enabled = true;
			}
		}
	}

	private Action<object, Pen, int, int, int, int> _drawEllipse = null!;
	private Action<object, Pen, int, int, int, int> _drawLine = null!;
	private Action<object, Pen, Point[]> _drawPolygon = null!;
	private Action<object, int> _drawFace = null!;

	private static void DrawPolygonBitmap(object backend, Pen pen, Point[] visibleVertices)
	{
		((Graphics)backend).FillPolygon(pen.Brush, visibleVertices);
	}
	private static void DrawPolygonGui(object backend, Pen pen, Point[] visibleVertices)
	{
		((IGuiApi)backend).DrawPolygon(visibleVertices, pen.Color, pen.Color);
	}

	private static void DrawEllipseBitmap(object backend, Pen pen, int x, int y, int width, int height)
	{
		((Graphics)backend).FillEllipse(pen.Brush, x, y, width, height);
	}
	private static void DrawEllipseGui(object backend, Pen pen, int x, int y, int width, int height)
	{
		((IGuiApi)backend).DrawEllipse(x, y, width, height, pen.Color, pen.Color);
	}

	private static void DrawLineBitmap(object backend, Pen pen, int x1, int y1, int x2, int y2)
	{
		((Graphics)backend).DrawLine(pen, x1, y1, x2, y2);
	}
	private static void DrawLineGui(object backend, Pen pen, int x1, int y1, int x2, int y2)
	{
		((IGuiApi)backend).DrawLine(x1, y1, x2, y2, pen.Color);
	}

	private void DrawFaceFilled(object api, int argb)
	{
		var visibleVertices = new Point[Guts.ScreenSpaceLines.Count * 2];

		for (int k = 0; k < Guts.ScreenSpaceLines.Count; k++)
		{
			((Vertex a, Vertex b), _, _) = Guts.ScreenSpaceLines[k];

			visibleVertices[k * 2 + 0] = new Point(
				(int)a.Position.X,
				(int)a.Position.Y);

			visibleVertices[k * 2 + 1] = new Point(
				(int)b.Position.X,
				(int)b.Position.Y);
		}

		float opacity = (float)NudFilledOpacity.Value / 100.0f;
		int alpha = (int)Math.Round(opacity * 255);
		argb &= 0x00FFFFFF;
		argb |= (alpha << 24);

		Pen.Color = Color.FromArgb(argb);

		_drawPolygon(api, Pen, visibleVertices);
	}
	private void DrawFacePoints(object api, int argb)
	{
		for (int k = 0; k < Guts.ScreenSpaceLines.Count; k++)
		{
			((Vertex a, Vertex b), argb, _) = Guts.ScreenSpaceLines[k];
			Pen.Color = Color.FromArgb(argb);

			_drawEllipse(
				api,
				Pen,
				(int)a.Position.X - 2,
				(int)b.Position.Y - 2,
				4,
				4);
		}
	}
	private void DrawFaceWireframe(object api, int argb)
	{
		for (int k = 0; k < Guts.ScreenSpaceLines.Count; k++)
		{
			((Vertex a, Vertex b), argb, bool visible) = Guts.ScreenSpaceLines[k];
			Pen.Color = Color.FromArgb(argb);

			if (visible)
			{
				_drawLine(
					api,
					Pen,
					(int)a.Position.X,
					(int)a.Position.Y,
					(int)b.Position.X,
					(int)b.Position.Y);
			}
		}
	}

	private void DrawReticleBitmap(Graphics g, int width, int height, float percent)
	{
		int size = (int)Math.Round(height * (percent / 100.0f));
		int centerW = width / 2;
		int centerH = height / 2;

		Pen.Color = Color.White;
		g.InterpolationMode = InterpolationMode.NearestNeighbor;
		g.PixelOffsetMode = PixelOffsetMode.None;
		g.SmoothingMode = SmoothingMode.Default;

		g.DrawRectangle(Pen, 0, 0, width - 1, height - 1);

		g.DrawLine(Pen, 0, centerH, size, centerH);
		g.DrawLine(Pen, centerW - size / 2, centerH, centerW + size / 2, centerH);
		g.DrawLine(Pen, width - 1 - size, centerH, width - 1, centerH);

		g.DrawLine(Pen, centerW, 0, centerW, size);
		g.DrawLine(Pen, centerW, centerH - size / 2, centerW, centerH + size / 2);
		g.DrawLine(Pen, centerW, height - 1 - size, centerW, height - 1);
	}
	private void DrawReticleGui(int width, int height, float percent)
	{
		int left = Guts.RenderPort.Left;
		int top = Guts.RenderPort.Top;

		int size = (int)Math.Round(height * (percent / 100.0f));
		int centerW = left + width / 2;
		int centerH = top + height / 2;

		var color = Color.White;

		Gui.DrawRectangle(left, top, width - 1, height - 1, color);

		Gui.DrawLine(left, centerH, left + size, centerH, color);
		Gui.DrawLine(centerW - size / 2, centerH, centerW + size / 2, centerH, color);
		Gui.DrawLine(left + (width - 1 - size), centerH, left + (width - 1), centerH, color);

		Gui.DrawLine(centerW, top, centerW, top + size, color);
		Gui.DrawLine(centerW, centerH - size / 2, centerW, centerH + size / 2, color);
		Gui.DrawLine(centerW, top + (height - 1 - size), centerW, top + (height - 1), color);
	}
}
