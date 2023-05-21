using BizHawk.Client.Common;
using BizHawk.Common;
using BizHawk.Emulation.Common;
using BizHawk.Emulation.Cores.Sony.PSX;
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
	[ExternalToolApplicability.RomList(VSystemID.Raw.PSX, USRetailConstants.HashBizHawk)]

	public partial class CustomMainForm : ToolFormBase, IExternalToolForm
	{
		private IMemoryApi Mem => Apis.Memory;

		private IMemoryEventsApi? MemEvents => Apis.MemoryEvents;

		private IGuiApi Gui => Apis.Gui;

		private IJoypadApi Joy => Apis.Joypad;

		private IEmuClientApi Emu => Apis.EmuClient;

		private IEmulationApi Emulation => Apis.Emulation;

		private IMemorySaveStateApi? MemSS => Apis.MemorySaveState;

		private IToolApi Tool => Apis.Tool;

		private ISaveStateApi SaveState => Apis.SaveState;

		public ApiContainer? ApiContainer { get; set; }

		private ApiContainer Apis => ApiContainer ?? throw new ArgumentNullException();

		[RequiredService]
		private IMemoryDomains? MemDomains { get; set; }

		[OptionalService]
		public Octoshock? Octoshock { get; set; }

		[OptionalService]
		public Nymashock? Nymashock { get; set; }

		public const string ToolName = "Silent Hill Map Examiner";
		public const string ToolDescription = "";

		protected override string WindowTitleStatic => ToolName;

		public Core Core { get; } = new Core();

		public Camera Camera { get; set; } = new Camera()
		{
			Culling = Culling.Frustum,
			Fov = 50.0f
		};

		public IList<Renderable> Boxes { get; } = new List<Renderable>();
		public IList<Renderable> TestBoxes { get; } = new List<Renderable>();
		public IList<Renderable> Gems { get; } = new List<Renderable>();
		public IList<Line> Lines { get; } = new List<Line>();

		public Pen Pen { get; set; } = new Pen(Brushes.White);
		public Bitmap Reticle { get; set; } = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
		public Bitmap Overlay { get; set; } = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

		public Rom Rom => Core.Rom;

		private Viewport ClickPort { get; set; } = new Viewport();
		private Viewport RenderPort { get; set; } = new Viewport();

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

			UpdateArrays = new Action(() =>
			{
				BtnReadTriggers_Click(this, EventArgs.Empty);
				BtnCameraPathReadArray_Click(this, EventArgs.Empty);
			});

			InitializeBasicsTab();
			InitializePoisTab();
			InitializeCameraTab();
			InitializeSaveTab();
			InitializeFramebufferTab();
			InitializeUtilityTab();
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

			DetachEventHandlers();

			base.Dispose(disposing);
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			DetachEventHandlers();
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
			Gems.Clear();
			Lines.Clear();
			TestBoxes.Clear();
			ModelBoxes.Clear();

			CameraBoxes.Clear();
			CameraGems.Clear();
			CameraLines.Clear();

			Mem.UseMemoryDomain("MainRAM");

			CbxOverlayRenderToFramebuffer_CheckedChanged(this, EventArgs.Empty);

			Label[] labels =
			{
				LblSelectedPoiAddress,
				LblSelectedTriggerAddress,
				LblSelectedTriggerFiredDetails,
				LblCameraPathAddress
			};

			if (MemDomains != null)
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

			DetachEventHandlers();
			AttachEventHandlers();
		}

		public static Bitmap GenerateReticle(Pen pen, int width, int height, float percent)
		{
			pen.Color = Color.White;

			var bmp = new Bitmap(width, height);

			var g = Graphics.FromImage(bmp);
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.PixelOffsetMode = PixelOffsetMode.None;

			g.Clear(Color.FromArgb(0, 0, 0, 0));
			g.DrawRectangle(pen, 0, 0, width - 1, height - 1);

			int size = (int)Math.Round(height * (percent / 100.0f));
			int centerW = width / 2;
			int centerH = height / 2;

			g.DrawLine(pen, 0, centerH, size, centerH);
			g.DrawLine(pen, centerW - size / 2, centerH, centerW + size / 2, centerH);
			g.DrawLine(pen, width - 1 - size, centerH, width - 1, centerH);

			g.DrawLine(pen, centerW, 0, centerW, size);
			g.DrawLine(pen, centerW, centerH - size / 2, centerW, centerH + size / 2);
			g.DrawLine(pen, centerW, height - 1 - size, centerW, height - 1);

			return bmp;
		}

		public override void UpdateValues(ToolFormUpdateType type)
		{
			if (Game.IsNullInstance())
			{
				ClearOverlay();
				return;
			}

			// This value is always 0xFF during gameplay, and switches to other
			// values only when a stage is being loaded. Once that's done, the
			// value goes back to 0xFF, so any other value means we're not in
			// an actual level yet, and there's no sense continuing.
			uint stage = Mem.ReadByte(Rom.Addresses.MainRam.IndexOfStageBeingLoaded);
			if (stage != 0xFF)
			{
				_levelDataNeedsUpdate = true;
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
					if (CbxCameraLockToHead.Checked)
					{
						Mem.WriteByte(Rom.Addresses.MainRam.CameraLockedToHead, 0x1);
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
					if (CbxReadLevelDataOnStageLoad.Checked)
					{
						CheckForArrayUpdates();
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
			MemEvents?.RemoveMemoryCallback(IndexOfDrawRegion_ValueChanging);

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

			VisiblePolygons.Clear();
			if (CbxEnableOverlay.Checked)
			{
				VisiblePolygons.AddRange(
					Camera.GetVisiblePolygons(
						Boxes
						.Concat(Gems)
						.Concat(CameraBoxes)
						.Concat(CameraGems)));
			}
			if (CbxEnableModelDisplay.Checked)
			{
				VisiblePolygons.AddRange(Camera.GetVisiblePolygons(ModelBoxes));
			}
			if (CbxOverlayTestBox.Checked)
			{
				VisiblePolygons.AddRange(Camera.GetVisiblePolygons(TestBox));
			}
			if (CbxOverlayTestSheet.Checked)
			{
				VisiblePolygons.AddRange(Camera.GetVisiblePolygons(TestSheet));
			}

			VisibleLines.Clear();
			if (CbxEnableOverlay.Checked)
			{
				VisibleLines.AddRange(
					Camera.GetVisibleLines(
						Lines
						.Concat(CameraLines)
						.ToList()));
			}
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
				Polygon clipped = Camera.ClipPolygonAgainstFrustum(line.Polygons[0]);

				for (int i = 0; i < clipped.Edges.Count; i++)
				{
					(int idxA, int idxB, bool visible) = clipped.Edges[i];

					var final = new Line(
						clipped.Vertices[idxA].WorldToScreen(matrix, _dummyViewport, true),
						clipped.Vertices[idxB].WorldToScreen(matrix, _dummyViewport, true));

					ScreenSpaceLines.Add((
						final,
						line.Tint ?? clipped.Color,
						visible,
						false,
						false));
				}
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

				Polygon clipped = Camera.ClipPolygonAgainstFrustum(p);

				for (int i = 0; i < clipped.Edges.Count; i++)
				{
					(int idxA, int idxB, bool visible) = clipped.Edges[i];

					Vertex a = clipped.Vertices[idxA];
					Vertex b = clipped.Vertices[idxB];

					var line = new Line(a, b);

					line.A = line.A.WorldToScreen(matrix, _dummyViewport, true);
					line.B = line.B.WorldToScreen(matrix, _dummyViewport, true);

					ScreenSpaceLines.Add((
						line,
						r.Tint ?? clipped.Color,
						visible,
						false,
						false));
				}

				switch (CmbRenderMode.SelectedIndex)
				{
					case 1:
						var visibleVertices = new List<Point>();
						foreach ((Line line, _, _, _, _) in ScreenSpaceLines)
						{
							var a = new Point((int)line.A.Position.X, (int)line.A.Position.Y);
							var b = new Point((int)line.B.Position.X, (int)line.B.Position.Y);

							visibleVertices.Add(a);
							visibleVertices.Add(b);
						}

						if (visibleVertices.Count == 0)
						{
							break;
						}

						float opacity = (float)NudOverlayRenderableOpacity.Value / 100.0f;
						int alpha = (int)Math.Round(opacity * 255);
						Pen.Color = Color.FromArgb(alpha, r.Tint ?? ScreenSpaceLines[0].color);
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

		private void AttachEventHandlers()
		{
			Emu.StateLoaded += Emu_StateLoaded;

			PropertyInfo? pInfo = typeof(DisplayManager).GetProperty("_graphicsControl", BindingFlags.NonPublic | BindingFlags.Instance);
			if (pInfo != null)
			{
				var gc = (GraphicsControl)pInfo.GetValue(DisplayManager);

				FieldInfo? fInfo = typeof(GraphicsControl).GetField("_managed", BindingFlags.NonPublic | BindingFlags.Instance);
				if (fInfo != null)
				{
					GameSurface = (Control)fInfo.GetValue(gc);

					GameSurface.MouseDown += GameSurface_MouseDown;
					GameSurface.MouseUp += GameSurface_MouseUp;
				}
			}

			RaycastSelectionTimer.Tick += RaycastSelectionTimer_Tick;
		}
		private void DetachEventHandlers()
		{
			Emu.StateLoaded -= Emu_StateLoaded;

			if (GameSurface != null)
			{
				GameSurface.MouseDown -= GameSurface_MouseDown;
				GameSurface.MouseUp -= GameSurface_MouseUp;
			}

			RaycastSelectionTimer.Tick -= RaycastSelectionTimer_Tick;
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

		private bool _levelDataNeedsUpdate;
		private Action UpdateArrays { get; }
		private void CheckForArrayUpdates()
		{
			if (!_levelDataNeedsUpdate)
			{
				return;
			}

			Invoke(UpdateArrays);

			_levelDataNeedsUpdate = false;
		}

		private void CleanUpDisposables()
		{
			Pen?.Dispose();
			Reticle?.Dispose();
			Overlay?.Dispose();

			_mapGraphic?.Dispose();
			PbxHazardStripes?.Image?.Dispose();

			RaycastSelectionTimer?.Dispose();
			FixedPointErrorClearTimer?.Dispose();
			AnglesErrorClearTimer?.Dispose();

			GameSurface = null;
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

			Octoshock.eResolutionMode? mode = Octoshock?.GetSettings().ResolutionMode;
			if (mode == Octoshock.eResolutionMode.PixelPro)
			{
				ClickPort.Width = 640;
				ClickPort.Height = 448;
				ClickPort.TopLeft = new Point(84, 16);
			}
			else
			{
				ClickPort.Width = 320;
				ClickPort.Height = 224;
				ClickPort.TopLeft = new Point(17, 8);
			}

			if (CbxOverlayRenderToFramebuffer.Checked)
			{
				RenderPort.Width = 320;
				RenderPort.Height = 224;
				RenderPort.TopLeft = new Point(0, 0);
			}
			else
			{
				RenderPort.Width = ClickPort.Width;
				RenderPort.Height = ClickPort.Height;
				RenderPort.TopLeft = ClickPort.TopLeft;
			}

			_dummyViewport = new Viewport(0, 0, RenderPort.Width, RenderPort.Height);

			CleanUpDisposables();

			Pen = new Pen(Brushes.White);
			Reticle = GenerateReticle(Pen, RenderPort.Width, RenderPort.Height, (float)NudCrosshairLength.Value);
			Overlay = new Bitmap(RenderPort.Width, RenderPort.Height, PixelFormat.Format32bppArgb);

			_drawRegionRect = new Rectangle(0, 0, RenderPort.Width, RenderPort.Height);
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
					int overlayPixel = Marshal.ReadInt32(data.Scan0, ofs);

					int a = (int)((overlayPixel & 0xFF000000) >> 24);
					if (a == 0x00)
					{
						continue;
					}

					long framebufferOffset = start + (gpuramBytesPerPixel * x);

					int r, g, b;
					if (a != 0xFF)
					{
						int gamePixel = Mem.ReadS16(framebufferOffset);

						int rGame = (gamePixel & 0b00000000_00011111) << 3;
						int gGame = (gamePixel & 0b00000011_11100000) >> 2;
						int bGame = (gamePixel & 0b01111100_00000000) >> 7;

						int rOverlay = (overlayPixel & 0xFF0000) >> 16;
						int gOverlay = (overlayPixel & 0x00FF00) >> 8;
						int bOverlay = (overlayPixel & 0x0000FF) >> 0;

						r = (rOverlay * a + rGame * (255 - a)) / 255;
						g = (gOverlay * a + gGame * (255 - a)) / 255;
						b = (bOverlay * a + bGame * (255 - a)) / 255;

						r = (r & 0xF8) >> 3;
						g = (g & 0xF8) << 2;
						b = (b & 0xF8) << 7;
					}
					else
					{
						// Selecting the high 5 bits of each component with AND
						// and then shifting them into their final positions is
						// an efficient equivalent of unpacking the 32bpp ARGB
						// pixels, dividing each component by 8, then repacking
						// them into the 16bpp SBGR format of the Playstation's
						// framebuffer. The high order "semi-transparent" bit
						// remains 0 to overwrite the screen with the overlay.
						r = (overlayPixel & 0x00F80000) >> 19;
						g = (overlayPixel & 0x0000F800) >> 6;
						b = (overlayPixel & 0x000000F8) << 7;
					}

					Mem.WriteS16(framebufferOffset, b | g | r);
				}

				start += gpuramStride;
			}
			Mem.UseMemoryDomain(previousDomain);

			Overlay.UnlockBits(data);
		}
		private void ApplyOverlayToGui()
		{
			Gui.WithSurface(DisplaySurfaceID.EmuCore, () => Gui.DrawImage(Overlay, RenderPort.Left, RenderPort.Top));
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
