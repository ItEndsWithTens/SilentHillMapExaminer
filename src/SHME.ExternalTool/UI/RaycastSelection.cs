using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private Control? GameSurface { get; set; }

		private IList<PointOfInterest> _clickedPois = new List<PointOfInterest>();

		private void ClearListControlSelections()
		{
			LbxPois.SelectedIndex = -1;
		}

		private bool GetClickedPois(Point screen, ref IList<PointOfInterest> pois)
		{
			pois.Clear();

			Point p = DisplayManager.UntransformPoint(screen);
			p.X -= ClickPort.Left;
			p.Y -= ClickPort.Top;

			// Ray preparation based on an article by Dr. Anton Gerdelan:
			// https://antongerdelan.net/opengl/raycasting.html
			// https://github.com/capnramses/antons_opengl_tutorials_book
			var ndc = new PointF(
				(p.X * 2.0f / ClickPort.Width) - 1.0f,
				1.0f - (p.Y * 2.0f / ClickPort.Height));

			var clip = new Vector3(ndc.X, ndc.Y, 1.0f);

			Matrix4x4.Invert(Camera.ProjectionMatrix, out Matrix4x4 mat);
			Vector4 cam = Vector4.Transform(clip, mat);
			cam.Z = -1.0f;
			cam.W = 0.0f;

			Matrix4x4.Invert(Camera.ViewMatrix, out mat);
			Vector4 world = Vector4.Transform(cam, mat);
			var three = new Vector3(world.X, world.Y, world.Z);

			Vector3 n = Vector3.Normalize(three);

			// AABB intersection test based on an article by Tavian Barnes:
			// https://tavianator.com/2022/ray_box_boundary.html
			// https://github.com/tavianator/ray_box
			var inv = new Vector3(1.0f / n.X, 1.0f / n.Y, 1.0f / n.Z);

			foreach ((Polygon _, Renderable r) in VisiblePolygons)
			{
				Vector3 min = (r.Aabb.Min - Camera.Position) * inv;
				Vector3 max = (r.Aabb.Max - Camera.Position) * inv;

				float tmin = 0.0f;
				tmin = Math.Max(tmin, Math.Min(min.X, max.X));
				tmin = Math.Max(tmin, Math.Min(min.Y, max.Y));
				tmin = Math.Max(tmin, Math.Min(min.Z, max.Z));

				float tmax = Single.PositiveInfinity;
				tmax = Math.Min(tmax, Math.Max(min.X, max.X));
				tmax = Math.Min(tmax, Math.Max(min.Y, max.Y));
				tmax = Math.Min(tmax, Math.Max(min.Z, max.Z));

				if (tmin < tmax)
				{
					foreach (KeyValuePair<PointOfInterest, Renderable?> pair in Pois)
					{
						if (ReferenceEquals(pair.Value, r))
						{
							if (!pois.Contains(pair.Key))
							{
								pois.Add(pair.Key);
							}
							break;
						}
					}
				}
			}

			bool outside = false;
			if (p.X < 0 || p.X > ClickPort.Width - 1 || p.Y < 0 || p.Y > ClickPort.Height - 1)
			{
				outside = true;
			}

			return outside;
		}

		private void GameSurface_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}

			if (sender is Control c && c.Parent is GraphicsControl gc)
			{
				bool outside = GetClickedPois(gc.PointToScreen(e.Location), ref _clickedPois);

				if (outside)
				{
					return;
				}

				if (_clickedPois.Count > 0)
				{
					_raycastSelectionIndex = 0;
					LbxPois.SelectedItem = _clickedPois[_raycastSelectionIndex];
					RaycastSelectionTimer.Enabled = true;
				}
				else
				{
					LbxPois.SelectedIndex = -1;
				}
			}
		}
		private void GameSurface_MouseUp(object sender, MouseEventArgs e)
		{
			RaycastSelectionTimer.Enabled = false;
		}

		private int _raycastSelectionIndex;
		private Timer RaycastSelectionTimer { get; } = new Timer() { Interval = 1000 };
		private void RaycastSelectionTimer_Tick(object sender, EventArgs e)
		{
			LbxPois.SelectedItem = _clickedPois[++_raycastSelectionIndex % _clickedPois.Count];
		}
	}
}
