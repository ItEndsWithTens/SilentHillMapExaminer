using SHME.ExternalTool.Graphics;
using System;
using System.Drawing;

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
				Backend = new BizHawkGuiBackend(Gui);

				CbxAntialiasing.Checked = false;
				CbxAntialiasing.Enabled = false;
			}
			else
			{
				Backend = new BitmapBackend(Overlay);

				CbxAntialiasing.Enabled = true;
			}
		}
	}

	private object _backend = null!;
	public IGraphicsBackend Backend
	{
		get => (IGraphicsBackend)_backend;
		private set => _backend = value;
	}

	private Action<int> _drawFace = null!;
	private void DrawFaceFilled(int argb)
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

		Backend.DrawPolygon(Pen, visibleVertices);
	}
	private void DrawFacePoints(int argb)
	{
		for (int k = 0; k < Guts.ScreenSpaceLines.Count; k++)
		{
			((Vertex a, Vertex b), argb, _) = Guts.ScreenSpaceLines[k];
			Pen.Color = Color.FromArgb(argb);

			Backend.DrawEllipse(
				Pen,
				(int)a.Position.X - 2,
				(int)b.Position.Y - 2,
				4,
				4);
		}
	}
	private void DrawFaceWireframe(int argb)
	{
		for (int k = 0; k < Guts.ScreenSpaceLines.Count; k++)
		{
			((Vertex a, Vertex b), argb, bool visible) = Guts.ScreenSpaceLines[k];
			Pen.Color = Color.FromArgb(argb);

			if (visible)
			{
				Backend.DrawLine(
					Pen,
					(int)a.Position.X,
					(int)a.Position.Y,
					(int)b.Position.X,
					(int)b.Position.Y);
			}
		}
	}
}
