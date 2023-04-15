using BizHawk.Client.Common;
using BizHawk.Common;
using BizHawk.Emulation.Common;
using BizHawk.Emulation.Cores.Sony.PSX;
using BizHawk.Emulation.Cores.Waterbox;
using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	[ExternalTool(ToolName, Description = ToolDescription)]

	// TODO: Add support for other versions of the game; EU, JP, demo, etc.
	[ExternalToolApplicability.RomWhitelist(CoreSystem.Playstation, USRetailConstants.HashBizHawk)]

	public partial class CustomMainForm : ToolFormBase, IExternalToolForm
	{
		private IMemoryApi Mem => Apis.Memory;

		private IGuiApi Gui => Apis.Gui;

		private IJoypadApi Joy => Apis.Joypad;

		private IEmuClientApi Emu => Apis.EmuClient;

		private IEmulationApi Emulation => Apis.Emulation;

		private IMemorySaveStateApi MemSS => Apis.MemorySaveState;

		private IToolApi Tool => Apis.Tool;

		private ISaveStateApi SaveState => Apis.SaveState;

		public ApiContainer? ApiContainer { get; set; }

		private ApiContainer Apis => ApiContainer ?? throw new ArgumentNullException();

		[OptionalService]
		public Octoshock? Octoshock { get; set; }

		// The "Nymashock" type doesn't exist in BizHawk < 2.8, so sticking with
		// its WaterboxCore base type allows this service without crashing. If
		// the need should ever arise for anything specific to the Nymashock
		// type, it'll be easy enough to drop support for old BizHawk versions,
		// but there's no reason to force that before it's necessary.
		[OptionalService]
		public WaterboxCore? Nymashock { get; set; }

		public const string ToolName = "Silent Hill Map Examiner";
		public const string ToolDescription = "";

		protected override string WindowTitleStatic => ToolName;

		public Core Core { get; } = new Core();

		public Camera Camera { get; set; } = new Camera() { Fov = 50.0f, Culling = Culling.None };

		public List<Renderable> Boxes { get; set; } = new List<Renderable>();
		public List<Renderable> TestBoxes { get; set; } = new List<Renderable>();

		public Pen Pen { get; set; } = new Pen(Brushes.White);
		public Bitmap Reticle { get; set; } = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
		public Bitmap Overlay { get; set; } = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

		public Rom Rom => Core.Rom;

		private Viewport Viewport { get; } = new Viewport();

		// TODO: Try to eliminate need for this; maybe better Viewport class,
		// or a Vertex WorldToScreen method that doesn't need this?
		private Viewport _dummyViewport = new Viewport();
		private Rectangle _drawRegionRect;

		public CustomMainForm()
		{
			InitializeComponent();

			// Set initial size, but let users manually resize the form as they
			// see fit, e.g. for very low res screens. The AutoScroll property
			// will then give scroll bars that can show all content, which the
			// AutoSize options in WinForms don't seem to permit.
			int border = 12;
			AutoScrollMargin = new Size(border, border);
			TbcMainTabs.Location = new Point(border, border);
			ClientSize = new Size(
				border + TbcMainTabs.Width + border,
				border + TbcMainTabs.Height + border);
			MaximumSize = Size;

			InitializeBasicsTab();
			InitializePoisTab();
			InitializeSaveTab();
			InitializeFramebufferTab();
		}

		protected override void Dispose(bool disposing)
		{
			if (!IsDisposed)
			{
				if (disposing)
				{
					CleanUpDisposables();
				}
			}

			base.Dispose(disposing);
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			ClearOverlay();

			base.OnClosing(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			CheckBizHawkVersion();
		}

		public override void Restart()
		{
			base.Restart();

			Boxes.Clear();
			TestBoxes.Clear();
			TestLines.Clear();
			ModelBoxes.Clear();

			Mem.UseMemoryDomain("MainRAM");

			Emu.StateLoaded += Emu_StateLoaded;

			CbxOverlayRenderToFramebuffer_CheckedChanged(this, EventArgs.Empty);

			Label[] labels =
			{
				LblSelectedPoiAddress,
				LblSelectedTriggerAddress,
				LblSelectedTriggerFiredDetails
			};

			_infoHexSetDomain = typeof(HexEditor).GetMethod("SetMemoryDomain", BindingFlags.NonPublic | BindingFlags.Instance);
			_infoHexGoTo = typeof(HexEditor).GetMethod("GoToAddress", BindingFlags.NonPublic | BindingFlags.Instance);

			if (_infoHexSetDomain != null && _infoHexGoTo != null)
			{
				foreach (Label l in labels)
				{
					l.BorderStyle = BorderStyle.Fixed3D;
					l.Cursor = Cursors.Hand;
				}
			}
			else
			{
				foreach (Label l in labels)
				{
					l.BorderStyle = BorderStyle.None;
					l.Cursor = Cursors.Default;
				}
			}
		}

		static public Bitmap GenerateReticle(Pen pen, int width, int height)
		{
			var bmp = new Bitmap(width, height);

			var g = Graphics.FromImage(bmp);
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.PixelOffsetMode = PixelOffsetMode.None;

			g.Clear(Color.FromArgb(0, 0, 0, 0));
			g.DrawRectangle(pen, 0, 0, width - 1, height - 1);
			g.DrawLine(pen, 0, height / 2, width, height / 2);
			g.DrawLine(pen, width / 2, 0, width / 2, height - 1);

			return bmp;
		}

		public override void UpdateValues(ToolFormUpdateType type)
		{
			if (Game.IsNullInstance())
			{
				ClearOverlay();
				return;
			}

			switch (type)
			{
				case ToolFormUpdateType.PreFrame:
					UpdateFog();
					if (CmbSaveButton.SelectedIndex != 0)
					{
						CheckForSaveButtonPress();
					}
					if (!CbxOverlayRenderToFramebuffer.Checked)
					{
						if (CbxCameraDetach.Checked)
						{
							HoldCamera();
						}
						if (_flyEnabled)
						{
							MoveCamera();
							AimCamera();
						}
					}
					break;
				case ToolFormUpdateType.PostFrame:
					if (CbxEnableControlsSection.Checked)
					{
						ReportControls();
					}
					ReportAngles();
					ReportPosition();
					if (CbxEnableOverlayCameraReporting.Checked)
					{
						ReportOverlayInfo();
					}
					if (CbxEnableOverlay.Checked && !CbxOverlayRenderToFramebuffer.Checked)
					{
						UpdateOverlay();
						ApplyOverlayToGui();
					}
					if (CbxStats.Checked)
					{
						ReportStats();
					}
					if (CbxTriggersAutoUpdate.Checked)
					{
						CheckForTriggerArrayUpdate();
					}
					if (CbxSelectedTriggerEnableUpdates.Checked)
					{
						CheckForSelectedTriggerUpdate();
					}
					break;
				default:
					break;
			}
		}

		private void ClearOverlay()
		{
			if (Apis.Libraries.ContainsKey(typeof(IMemoryEventsApi)))
			{
				Apis.MemoryEvents.RemoveMemoryCallback(IndexOfDrawRegion_ValueChanging);
			}
			Gui.WithSurface(DisplaySurfaceID.EmuCore, () => Gui.ClearGraphics());
		}

		private List<(Line line, Color color, bool visible, bool aClipped, bool bClipped)> ScreenSpaceLines { get; } = new List<(Line line, Color color, bool visible, bool aClipped, bool bClipped)>();
		private List<(Polygon, Renderable)> VisiblePolygons { get; } = new List<(Polygon, Renderable)>();
		private List<Line> VisibleLines { get; } = new List<Line>();

		private void UpdateOverlay()
		{
			(_, Vector3 position) = GetPosition();
			(_, Vector3 angles) = GetAngles();

			Vector3 convertedPosition = CoordinateConverter.Convert(position, CoordinateType.SilentHill, CoordinateType.YUpRightHanded);
			Vector3 convertedAngles = AngleConverter.Convert(angles, CoordinateType.SilentHill, CoordinateType.YUpRightHanded);

			if (!CbxEnableOverlay.Checked && !CbxEnableModelDisplay.Checked)
			{
				return;
			}

			// Remember that the projection, view, model order from OpenGL
			// shaders is reversed in C#, to account for System.Numeric's row
			// major matrix layout.
			Matrix4x4 matrix = Camera.ViewMatrix * Camera.ProjectionMatrix;

			if (CmbRenderMode.SelectedIndex == 1)
			{
				Camera.Culling = Culling.All;
			}
			else
			{
				Camera.Culling = Culling.Frustum;
			}

			VisiblePolygons.Clear();
			if (CbxEnableOverlay.Checked)
			{
				VisiblePolygons.AddRange(Camera.GetVisiblePolygons(Boxes));
			}
			if (CbxEnableModelDisplay.Checked)
			{
				VisiblePolygons.AddRange(Camera.GetVisiblePolygons(ModelBoxes));
			}
			if (CbxOverlayTestBox.Checked)
			{
				VisiblePolygons.AddRange(Camera.GetVisiblePolygons(TestBox));
			}

			VisibleLines.Clear();
			if (CbxOverlayTestLine.Checked)
			{
				VisibleLines.AddRange(Camera.GetVisibleLines(TestLines));
			}

			var g = Graphics.FromImage(Overlay);

			g.Clear(Color.FromArgb(0, 0, 0, 0));
			DrawPolygons(matrix, g);
			DrawLines(matrix, g);
			g.DrawImage(Reticle, 0, 0);

			if (CbxOverlayCameraMatchGame.Checked)
			{
				Camera.UpdateAll(
					convertedPosition,
					convertedAngles.X, convertedAngles.Y, convertedAngles.Z,
					null, CalculateGameFov(),
					null, null);

				if (CbxEnableOverlayCameraReporting.Checked)
				{
					NudOverlayCameraX.Text = $"{Camera.Position.X:N0}";
					NudOverlayCameraY.Text = $"{Camera.Position.Y:N0}";
					NudOverlayCameraZ.Text = $"{Camera.Position.Z:N0}";

					NudOverlayCameraPitch.Text = $"{Camera.Pitch:N0}";
					NudOverlayCameraYaw.Text = $"{Camera.Yaw:N0}";
					NudOverlayCameraRoll.Text = $"{Camera.Roll:N0}";
				}
			}
		}

		public void DrawLines(Matrix4x4 matrix, Graphics g)
		{
			ScreenSpaceLines.Clear();

			foreach (Line line in VisibleLines)
			{
				var clipped = new Line(line);

				bool visible = Camera.ClipLineAgainstFrustum(ref clipped);

				bool aClipped = line.A.Position != clipped.A.Position;
				bool bClipped = line.B.Position != clipped.B.Position;

				clipped.A = clipped.A.WorldToScreen(matrix, _dummyViewport, true);
				clipped.B = clipped.B.WorldToScreen(matrix, _dummyViewport, true);

				ScreenSpaceLines.Add((
					clipped,
					clipped.Tint ?? clipped.A.Color,
					visible,
					aClipped,
					bClipped));
			}

			foreach ((Line line, Color color, bool visible, bool aClipped, bool bClipped) b in ScreenSpaceLines)
			{
				switch (CmbRenderMode.SelectedIndex)
				{
					case 2:
						IEnumerable<Vertex> unclippedAs = ScreenSpaceLines.Where(ssl => ssl.visible && !ssl.aClipped).Select(ssl => ssl.line.A);
						IEnumerable<Vertex> unclippedBs = ScreenSpaceLines.Where(ssl => ssl.visible && !ssl.bClipped).Select(ssl => ssl.line.B);

						foreach (Vertex v in unclippedAs.Concat(unclippedBs))
						{
							int x = (int)v.Position.X;
							int y = (int)v.Position.Y;

							Pen.Color = v.Color;
							g.FillEllipse(Pen.Brush, x - 2, y - 2, 4, 4);
						}
						break;
					default:
						foreach ((Line line, Color color, bool visible, _, _) in ScreenSpaceLines)
						{
							if (visible)
							{
								Pen.Color = color;
								g.DrawLine(
									Pen,
									line.A.Position.X,
									line.A.Position.Y,
									line.B.Position.X,
									line.B.Position.Y);
							}
						}
						break;
				}
			}
		}

		public void DrawPolygons(Matrix4x4 matrix, Graphics g)
		{
			foreach ((Polygon p, Renderable r) in VisiblePolygons)
			{
				matrix = r.ModelMatrix * matrix;

				ScreenSpaceLines.Clear();

				for (int i = 0; i < p.LineLoopIndices.Count; i++)
				{
					int wrappedA = (i + 0) % p.LineLoopIndices.Count;
					int wrappedB = (i + 1) % p.LineLoopIndices.Count;

					int indexA = p.LineLoopIndices[wrappedA];
					int indexB = p.LineLoopIndices[wrappedB];

					var line = new Line(r.Vertices[indexA], r.Vertices[indexB]);
					var clipped = new Line(line);

					bool visible = Camera.ClipLineAgainstFrustum(ref clipped);

					bool aClipped = line.A.Position != clipped.A.Position;
					bool bClipped = line.B.Position != clipped.B.Position;

					clipped.A = clipped.A.WorldToScreen(matrix, _dummyViewport, true);
					clipped.B = clipped.B.WorldToScreen(matrix, _dummyViewport, true);

					ScreenSpaceLines.Add((
						clipped,
						r.Tint ?? clipped.A.Color,
						visible,
						aClipped,
						bClipped));
				}

				switch (CmbRenderMode.SelectedIndex)
				{
					case 1:
						// TODO: Figure out how to handle the corner of the screen
						// causing a diagonal to form even when the near clip plane
						// isn't cutting through the object. The vertex mode, case 2,
						// and the wireframe, case 0/default, don't do this because
						// they don't need to connect vertices at the screen edge. The
						// filled poly mode, however, does, and needs new verts added
						// somewhere, based on some criteria I haven't figured out yet.
						var visibleVertices = new List<Point>();
						foreach ((Line line, _, bool visible, bool aClipped, bool bClipped) in ScreenSpaceLines)
						{
							if (!visible)
							{
								continue;
							}

							var a = new Point((int)line.A.Position.X, (int)line.A.Position.Y);
							var b = new Point((int)line.B.Position.X, (int)line.B.Position.Y);

							if (!visibleVertices.Contains(a))
							{
								visibleVertices.Add(a);
							}

							if (!visibleVertices.Contains(b))
							{
								visibleVertices.Add(b);
							}
						}

						if (visibleVertices.Count == 0)
						{
							break;
						}

						Pen.Color = r.Tint ?? ScreenSpaceLines[0].line.A.Color;
						g.FillPolygon(Pen.Brush, visibleVertices.ToArray());
						break;
					case 2:
						IEnumerable<Vertex> unclippedAs = ScreenSpaceLines.Where(ssl => ssl.visible && !ssl.aClipped).Select(ssl => ssl.line.A);
						IEnumerable<Vertex> unclippedBs = ScreenSpaceLines.Where(ssl => ssl.visible && !ssl.bClipped).Select(ssl => ssl.line.B);

						foreach (Vertex v in unclippedAs.Concat(unclippedBs))
						{
							int x = (int)v.Position.X;
							int y = (int)v.Position.Y;

							Pen.Color = v.Color;
							g.FillEllipse(Pen.Brush, x - 2, y - 2, 4, 4);
						}
						break;
					default:
						foreach ((Line line, Color color, bool visible, _, _) in ScreenSpaceLines)
						{
							if (visible)
							{
								Pen.Color = color;
								g.DrawLine(
									Pen,
									line.A.Position.X,
									line.A.Position.Y,
									line.B.Position.X,
									line.B.Position.Y);
							}
						}
						break;
				}
			}
		}

		private float CalculateGameFov()
		{
			// The idea that the render height and projection plane distance are
			// meant to be used this way to determine a vertical FOV is hardly
			// set in stone, but it seems about right when eyeballing things.
			uint distance = Mem.ReadU16(Rom.Addresses.MainRam.ProjectionPlaneDistanceCurrent);
			uint height = Mem.ReadU16(Rom.Addresses.MainRam.FramebufferHeight);

			return CalculateFov(distance, height);
		}
		private float CalculateFov(uint distance, uint height)
		{
			float opposite = height / 2.0f;

			float hSquared = (float)(Math.Pow(distance, 2.0f) + Math.Pow(opposite, 2.0f));

			float h = (float)Math.Sqrt(hSquared);

			float halfAngle = (float)Math.Asin(opposite / h);

			return MathUtilities.RadiansToDegrees(halfAngle * 2.0f);
		}

		private void CheckBizHawkVersion()
		{
			string v = VersionInfo.MainVersion;

			Assembly e = Assembly.GetExecutingAssembly();
			var a = (AssemblyTitleAttribute)e.GetCustomAttribute(typeof(AssemblyTitleAttribute));

			string raw = a.Title.Trim();
			string b = raw.Substring(raw.LastIndexOf(' ') + 1);

			if (b == v)
			{
				return;
			}

			DialogResult result = MessageBox.Show(
				$"You're using BizHawk version {v}, but SHME was built for " +
				$"version {b}, and might crash or work incorrectly. Do you " +
				"want to try loading it anyway?",
				"SHME: Mismatched BizHawk version!",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning);

			if (result != DialogResult.Yes)
			{
				Close();
			}
		}

		private void CleanUpDisposables()
		{
			Pen?.Dispose();
			Reticle?.Dispose();
			Overlay?.Dispose();

			_mapGraphic?.Dispose();
			PbxHazardStripes?.Image?.Dispose();
		}

		private void Selectable_Enter(object sender, EventArgs e)
		{
			if (sender is NumericUpDown nud)
			{
				int length = nud.Value.ToString().Length;

				nud.Select(0, length);
			}
			else if (sender is TextBox tbx)
			{
				tbx.SelectAll();
			}
		}

		private void InitializeOverlay()
		{
			if (Octoshock == null)
			{
				CbxOverlayRenderToFramebuffer.Enabled = false;
				CbxOverlayRenderToFramebuffer.Checked = false;
			}
			else
			{
				CbxOverlayRenderToFramebuffer.Enabled = true;
			}

			if (CbxOverlayRenderToFramebuffer.Checked)
			{
				Viewport.Width = 320;
				Viewport.Height = 224;
				Viewport.TopLeft = new Point(0, 0);
			}
			else
			{
				Octoshock.eResolutionMode? mode = Octoshock?.GetSettings().ResolutionMode;
				if (mode == Octoshock.eResolutionMode.PixelPro)
				{
					Viewport.Width = 640;
					Viewport.Height = 448;
					Viewport.TopLeft = new Point(84, 16);
				}
				else
				{
					Viewport.Width = 320;
					Viewport.Height = 224;
					Viewport.TopLeft = new Point(17, 8);
				}
			}

			_dummyViewport = new Viewport(0, 0, Viewport.Width, Viewport.Height);

			CleanUpDisposables();

			Pen = new Pen(Brushes.White);
			Reticle = GenerateReticle(Pen, Viewport.Width, Viewport.Height);
			Overlay = new Bitmap(Viewport.Width, Viewport.Height, PixelFormat.Format32bppArgb);

			_drawRegionRect = new Rectangle(0, 0, Viewport.Width, Viewport.Height);
		}
		private void ApplyOverlayToFramebuffer(uint index)
		{
			BitmapData data = Overlay.LockBits(
				_drawRegionRect,
				ImageLockMode.ReadOnly,
				PixelFormat.Format32bppArgb);

			int gpuramBytesPerPixel = 2;
			int gpuramStride = 1024 * gpuramBytesPerPixel;

			long bufferRegionStart = 32 * gpuramStride;
			long start = bufferRegionStart + (224 * gpuramStride * index);

			string previousDomain = Mem.GetCurrentMemoryDomain();
			Mem.UseMemoryDomain("GPURAM");
			for (int y = 0; y < Overlay.Height; y++)
			{
				for (int x = 0; x < Overlay.Width; x++)
				{
					int ofs = (y * data.Stride) + (x * 4);
					int pixel = Marshal.ReadInt32(data.Scan0, ofs);

					// Any pixels in the overlay Bitmap that aren't opaque are
					// assumed to be transparent background, and safe to skip.
					uint a = (uint)pixel & 0xFF000000;
					if (a != 0xFF000000)
					{
						continue;
					}

					// Selecting the high 5 bits of each component with an AND
					// and then shifting them into their final positions is an
					// efficient equivalent of unpacking the 32bpp ARGB pixels,
					// dividing each component by 8, then repacking them into
					// the 16bpp SBGR format of the PSX framebuffer. The 'S', or
					// semi-transparent bit, remains 0 to overwrite the screen.
					int r = (pixel & 0x00F80000) >> 19;
					int g = (pixel & 0x0000F800) >> 6;
					int b = (pixel & 0x000000F8) << 7;

					Mem.WriteS16(start + (gpuramBytesPerPixel * x), b | g | r);
				}

				start += gpuramStride;
			}
			Mem.UseMemoryDomain(previousDomain);

			Overlay.UnlockBits(data);
		}
		private void ApplyOverlayToGui()
		{
			Gui.WithSurface(DisplaySurfaceID.EmuCore, () => Gui.DrawImage(Overlay, Viewport.Left, Viewport.Top));
		}

		private void IndexOfDrawRegion_ValueChanging(uint address, uint value, uint flags)
		{
			UpdateOverlay();

			// IndexOfDrawRegion_ValueChanging is attached as a write callback,
			// which means it's called just before the write is performed. The
			// value passed in is what's about to be written, so the current
			// back buffer index is its opposite, either 0 or 1, hence the XOR.
			ApplyOverlayToFramebuffer(value ^ 1);

			if (CbxCameraDetach.Checked)
			{
				HoldCamera();
			}
			if (_flyEnabled)
			{
				MoveCamera();
				AimCamera();
			}
		}
	}
}
