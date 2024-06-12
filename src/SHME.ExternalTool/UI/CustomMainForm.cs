﻿using BizHawk.Client.Common;
using BizHawk.Common;
using BizHawk.Emulation.Common;
using BizHawk.Emulation.Cores.Sony.PSX;
using SHME.ExternalTool;
using SHME.ExternalTool.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	[ExternalTool(
		ToolName,
		Description = ToolDescription,
		LoadAssemblyFiles = [
			"SHME.ExternalTool/dll/JsonSettings/JsonSettings.dll",
			"SHME.ExternalTool/dll/JsonSettings/Castle.Core.dll",
			"SHME.ExternalTool/dll/JsonSettings/JsonSettings.Autosave.dll",
			"SHME.ExternalTool/dll/SHME.ExternalTool.Graphics.dll",
			"SHME.ExternalTool/dll/SHME.ExternalTool.Guts.dll"])]

	// TODO: Add support for other versions of the game; EU, JP, demo, etc.
	[ExternalToolApplicability.RomList(VSystemID.Raw.PSX, Slus00707Constants.HashBizHawk)]

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

		private ApiContainer Apis => ApiContainer ?? throw new ArgumentNullException(nameof(ApiContainer));

		[RequiredService]
		private IMemoryDomains? MemDomains { get; set; }

		[OptionalService]
		public Octoshock? Octoshock { get; set; }

		[OptionalService]
		public Nymashock? Nymashock { get; set; }

		public const string ToolName = "Silent Hill Map Examiner";
		public const string ToolDescription = "";

		protected override string WindowTitleStatic => ToolName;

		private object _guts = null!;
		public Guts Guts
		{
			get => (Guts)_guts;
			set => _guts = value;
		}

		public Pen Pen { get; set; } = new(Brushes.White);
		public Bitmap Overlay { get; set; } = new(1, 1, PixelFormat.Format32bppArgb);

		public Rom Rom => Guts.Rom;

		private Rectangle _drawRegionRect;

		// Manually implementing a backing field is necessary to store it as a
		// plain object, which in turn prevents BizHawk under Mono from failing
		// to load the Settings type on first reflection access. To see exactly
		// where things go pear shaped, see the BizHawk codebase:
		// https://github.com/TASEmulators/BizHawk/blob/745efb1dd8eb82f31ba9201a79cdfc5bcaf1f5d1/src/BizHawk.Client.EmuHawk/tools/ExternalToolManager.cs#L124-L125
		private object _settings = null!;
		private Settings Settings
		{
			get => (Settings)_settings;
			set => _settings = value;
		}

		private Action DrawOverlay { get; set; }

		public CustomMainForm()
		{
			InitializeComponent();

			Guts = new Guts();

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

			DrawOverlay = DrawOverlayBitmap;

			UpdateArrays = new Action(() =>
			{
				BtnReadTriggers_Click(this, EventArgs.Empty);
				BtnCameraPathReadArray_Click(this, EventArgs.Empty);
			});

			InitializeBasicsTab();
			InitializePoisTab();
			InitializeSaveTab();
			InitializeFramebufferTab();
			InitializeUtilityTab();

			Guts.GameCameraLookAt = new BoxGenerator(0.25f, Color.Purple).Generate().ToWorld();
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

			LoadSettings();

			SetButtonNames();

			LblTestModelScale.Text = TrkTestModelScale.Value.ToString(CultureInfo.CurrentCulture);

			SetPlaceholderText();

			DetachEventHandlers();
			AttachEventHandlers();

			Guts.Boxes.Clear();
			Guts.Gems.Clear();
			Guts.Lines.Clear();
			Guts.TestBoxes.Clear();
			Guts.ModelBoxes.Clear();

			Guts.CameraBoxes.Clear();
			Guts.CameraGems.Clear();
			Guts.CameraLines.Clear();

			Mem.UseMemoryDomain("MainRAM");

			_initializeOverlayCountdown = 5;
			CbxAlwaysRun_CheckedChanged(this, EventArgs.Empty);

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
		}

		public static void DrawReticle(Graphics g, Pen pen, int width, int height, float percent)
		{
			pen.Color = Color.White;

			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.PixelOffsetMode = PixelOffsetMode.None;
			g.SmoothingMode = SmoothingMode.Default;

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
		}

		public override void UpdateValues(ToolFormUpdateType type)
		{
			if (Game.IsNullInstance())
			{
				ClearOverlay();
				return;
			}

			// At boot, the button flags address first gets populated right in
			// the middle of the "violent and disturbing images" title card,
			// which is the perfect opportunity to set the viewport size. Other
			// suitable occasions, like save state loading or after a change in
			// window size, also only occur when the buttons are already active.
			int buttonFlags = Mem.ReadS32(Rom.Addresses.MainRam.ButtonFlags);
			bool buttonsActive = buttonFlags != 0x00000000;

			// Initializing the overlay graphics includes aligning the rendering
			// with the game content. The Viewport.FromBitmap method does that
			// as part of the InitializeOverlay method, but when loading a save
			// state the first few frames will be the low res preview screenshot
			// that was saved as part of the state, and that picture is a couple
			// of pixels offset horizontally. A few calls to UpdateValues later,
			// everything's fine, so just wait a bit before init.
			if (buttonsActive && _initializeOverlayCountdown > -1)
			{
				if (_initializeOverlayCountdown-- == 0)
				{
					InitializeOverlay();
				}
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

			if (Guts.HarryModel == null)
			{
				int raw = Mem.ReadS32(Rom.Addresses.MainRam.HarryModelPointer);
				int address = raw - (int)Rom.Addresses.MainRam.BaseAddress;
				IReadOnlyList<byte> headerBytes = Mem.ReadByteRange(address, IlmHeader.Length);
				var header = new IlmHeader(headerBytes, raw);

				IReadOnlyList<byte> remaining = Mem.ReadByteRange(address, (int)(Mem.GetMemoryDomainSize("MainRAM") - address));
				Guts.HarryModel = new Ilm(header, remaining);
			}

			var camState = (CameraState)(Mem.ReadS32(Rom.Addresses.MainRam.CameraState));
			bool cutscene = camState.FasterHasFlag(CameraState.Cutscene);

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
					if (CbxShowLookAt.Checked)
					{
						Vector3 pos = Guts.GameCameraLookAt.Position;
						pos.X = Guts.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.CameraLookAtX));
						pos.Y = -Guts.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.CameraLookAtY));
						pos.Z = -Guts.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.CameraLookAtZ));
						Guts.GameCameraLookAt.Position = pos;
					}
					if (cutscene)
					{
						_holdCameraYaw = Mem.ReadU16(Rom.Addresses.MainRam.HarryYaw);
					}
					if (CbxCameraDetach.Checked)
					{
						HoldCamera();
					}
					if (_flyEnabled)
					{
						MoveCamera();
						AimCamera(BtnCameraFly);
					}
					else if (_firstPersonEnabled)
					{
						long address = Rom.Addresses.MainRam.ControllerConfig;
						string hash = Mem.HashRegion(address, SHME.ExternalTool.ControllerConfig.Size);
						if (hash != _lastControllerLayoutHash)
						{
							SetButtonNames();
							_lastControllerLayoutHash = hash;
						}
						if (_forcedCameraYaw != null)
						{
							_holdCameraPitch = 0;
							_holdCameraYaw = Guts.DegreesToGameUnits((float)_forcedCameraYaw);
							_holdCameraRoll = 0;
							HoldCamera();

							_forcedCameraYaw = null;
						}
						MoveCameraFirstPerson();
						AimCamera(BtnCameraFps, cutscene);
						if (!cutscene)
						{
							Mem.WriteU16(Rom.Addresses.MainRam.HarryYaw, _holdCameraYaw);
						}
					}
					break;
				case ToolFormUpdateType.PostFrame:
					if (CbxEnableControllerReporting.Checked)
					{
						ReportControls();
					}
					if (CbxEnableHarrySection.Checked)
					{
						ReportAngles();
						ReportPosition();
					}
					if (CbxEnableOverlayCameraReporting.Checked)
					{
						ReportOverlayInfo();
					}
					if (CbxEnableOverlay.Checked)
					{
						DrawOverlay();
					}
					if (CbxEnableStatsReporting.Checked)
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

			Gui.WithSurface(_displaySurfaceID, () => Gui.ClearGraphics());
		}

		private void LoadSettings()
		{
			Settings?.Dispose();

			Assembly a = typeof(CustomMainForm).Assembly;
			string component = Path.GetFileNameWithoutExtension(a.Location);
			Settings = new Settings("com.gyroshot", ToolName, component);

			InitializeDataBindings();

			TbxSettingsFilesLocal.Text = Settings.Local.FileName;
			TbxSettingsFilesRoaming.Text = Settings.Roaming.FileName;
		}

		private void DrawOverlayCommonPre(ref Matrix4x4 matrix, ref Vector3 position, ref Vector3 angles)
		{
			(_, position) = GetPosition();
			(_, angles) = GetAngles();

			position = CoordinateConverter.Convert(position, CoordinateType.SilentHill, CoordinateType.YUpRightHanded);
			angles = AngleConverter.Convert(angles, CoordinateType.SilentHill, CoordinateType.YUpRightHanded);

			if (!CbxEnableOverlay.Checked && !CbxEnableTestModelSection.Checked)
			{
				return;
			}

			// Remember that the projection, view, model order from OpenGL
			// shaders is reversed in C#, to account for System.Numeric's row
			// major matrix layout.
			matrix = Guts.Camera.ViewMatrix * Guts.Camera.ProjectionMatrix;

			Guts.VisibleRenderables.Clear();
			if (CbxEnableOverlay.Checked)
			{
				Guts.Camera.GetVisibleRenderables(
					ref Guts.VisibleRenderables,
					[.. Guts.Boxes, .. Guts.Gems, .. Guts.CameraBoxes, .. Guts.CameraGems, .. Guts.Lines, .. Guts.CameraLines]);
			}
			if (CbxEnableTestModelSection.Checked)
			{
				Guts.Camera.GetVisibleRenderables(
					ref Guts.VisibleRenderables,
					Guts.ModelBoxes);
			}
			if (CbxEnableTestBox.Checked)
			{
				Guts.Camera.GetVisibleRenderables(
					ref Guts.VisibleRenderables,
					Guts.TestBox);
			}
			if (CbxEnableTestSheet.Checked)
			{
				Guts.Camera.GetVisibleRenderables(
					ref Guts.VisibleRenderables,
					Guts.TestSheet);
			}
			if (CbxEnableTestLine.Checked)
			{
				Guts.Camera.GetVisibleRenderables(
					ref Guts.VisibleRenderables,
					Guts.TestLines);
			}
			if (CbxShowLookAt.Checked)
			{
				Guts.Camera.GetVisibleRenderables(
					ref Guts.VisibleRenderables,
					Guts.GameCameraLookAt);
			}
		}
		private void DrawOverlayBitmap()
		{
			Matrix4x4 matrix = Matrix4x4.Identity;
			Vector3 position = Vector3.Zero;
			Vector3 angles = Vector3.Zero;

			DrawOverlayCommonPre(ref matrix, ref position, ref angles);

			var g = Graphics.FromImage(Overlay);
			g.CompositingMode = CompositingMode.SourceCopy;
			g.CompositingQuality = CompositingQuality.HighSpeed;

			g.Clear(Color.FromArgb(0, 0, 0, 0));
			DrawPolygons(matrix, g);
			DrawReticle(g, Pen, Guts.RenderPort.Width, Guts.RenderPort.Height, (float)NudCrosshairLength.Value);

			if (!RdoOverlayDisplaySurfaceFramebuffer.Checked)
			{
				ApplyOverlayToGui();
			}

			DrawOverlayCommonPost(ref position, ref angles);
		}
		private void DrawOverlayCommonPost(ref Vector3 position, ref Vector3 angles)
		{
			if (CbxOverlayCameraMatchGame.Checked)
			{
				Guts.Camera.UpdateAll(
					position,
					angles.X, angles.Y, angles.Z,
					null, CalculateGameFov(),
					null, null);

				if (CbxEnableOverlayCameraReporting.Checked)
				{
					string f = "N0";
					CultureInfo c = CultureInfo.CurrentCulture;

					NudOverlayCameraX.Text = Guts.Camera.Position.X.ToString(f, c);
					NudOverlayCameraY.Text = Guts.Camera.Position.Y.ToString(f, c);
					NudOverlayCameraZ.Text = Guts.Camera.Position.Z.ToString(f, c);

					NudOverlayCameraPitch.Text = Guts.Camera.Pitch.ToString(f, c);
					NudOverlayCameraYaw.Text = Guts.Camera.Yaw.ToString(f, c);
					NudOverlayCameraRoll.Text = Guts.Camera.Roll.ToString(f, c);
				}
			}
		}

		private SmoothingMode _smoothingMode = SmoothingMode.Default;
		public void DrawPolygons(Matrix4x4 matrix, Graphics g)
		{
			g.SmoothingMode = _smoothingMode;

			for (int i = 0; i < Guts.VisibleRenderables.Count; i++)
			{
				(Renderable r, bool partial) = Guts.VisibleRenderables[i];

				matrix = r.ModelMatrix * matrix;

				for (int j = 0; j < r.Polygons.Count; j++)
				{
					Polygon p = r.Polygons[j];

					if (Guts.Camera.Culling.FasterHasFlag(Culling.Backface) && p.IsBackface(Guts.Camera))
					{
						continue;
					}

					Guts.ScreenSpaceLines.Clear();

					Polygon clipped = partial ? Guts.Camera.ClipPolygonAgainstFrustum(p) : p;

					for (int k = 0; k < clipped.Edges.Count; k++)
					{
						(int idxA, int idxB, bool visible) = clipped.Edges[k];

						Vertex a = clipped.Vertices[idxA];
						Vertex b = clipped.Vertices[idxB];

						a = a.WorldToScreen(matrix, Guts.DummyViewport, true);
						b = b.WorldToScreen(matrix, Guts.DummyViewport, true);

						Guts.ScreenSpaceLines.Add(((a, b), r.Tint ?? clipped.Argb, visible));
					}

					if (Guts.ScreenSpaceLines.Count == 0)
					{
						continue;
					}

					switch (_renderMode)
					{
						case 1:
							var visibleVertices = new PointF[Guts.ScreenSpaceLines.Count * 2];

							for (int k = 0; k < Guts.ScreenSpaceLines.Count; k++)
							{
								((Vertex a, Vertex b), _, _) = Guts.ScreenSpaceLines[k];

								visibleVertices[k * 2 + 0] = new PointF(a.Position.X, a.Position.Y);
								visibleVertices[k * 2 + 1] = new PointF(b.Position.X, b.Position.Y);
							}

							float opacity = (float)NudFilledOpacity.Value / 100.0f;
							int alpha = (int)Math.Round(opacity * 255);
							int argb = (r.Tint ?? Guts.ScreenSpaceLines[0].argb) & 0x00FFFFFF;
							argb |= (alpha << 24);
							Pen.Color = Color.FromArgb(argb);
							g.FillPolygon(Pen.Brush, visibleVertices);
							break;
						case 2:
							for (int k = 0; k < Guts.ScreenSpaceLines.Count; k++)
							{
								((Vertex a, Vertex b), argb, _) = Guts.ScreenSpaceLines[k];
								Pen.Color = Color.FromArgb(argb);

								g.FillEllipse(
									Pen.Brush,
									a.Position.X - 2.0f,
									b.Position.Y - 2.0f,
									4.0f,
									4.0f);
							}
							break;
						default:
							for (int k = 0; k < Guts.ScreenSpaceLines.Count; k++)
							{
								((Vertex a, Vertex b), argb, bool visible) = Guts.ScreenSpaceLines[k];
								Pen.Color = Color.FromArgb(argb);

								if (visible)
								{
									g.DrawLine(
										Pen,
										a.Position.X,
										a.Position.Y,
										b.Position.X,
										b.Position.Y);
								}
							}
							break;
					}
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

					GameSurface.SizeChanged += GameSurface_SizeChanged;
				}
			}

			RaycastSelectionTimer.Tick += RaycastSelectionTimer_Tick;

			BtnCameraFly.LostFocus += BtnCameraFly_LostFocus;
			BtnCameraFps.LostFocus += BtnCameraFps_LostFocus;
		}
		private void DetachEventHandlers()
		{
			Emu.StateLoaded -= Emu_StateLoaded;

			if (GameSurface != null)
			{
				GameSurface.MouseDown -= GameSurface_MouseDown;
				GameSurface.MouseUp -= GameSurface_MouseUp;

				GameSurface.SizeChanged -= GameSurface_SizeChanged;
			}

			RaycastSelectionTimer.Tick -= RaycastSelectionTimer_Tick;

			BtnCameraFly.LostFocus -= BtnCameraFly_LostFocus;
			BtnCameraFps.LostFocus -= BtnCameraFps_LostFocus;
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
			Overlay?.Dispose();

			Guts.AreaMapGraphic?.Dispose();
			PbxHazardStripes?.Image?.Dispose();

			RaycastSelectionTimer?.Dispose();
			FixedPointErrorClearTimer?.Dispose();
			AnglesErrorClearTimer?.Dispose();

			_inputBindsForm?.Dispose();

			Settings?.Dispose();

			GameSurface = null;
		}

		private string _lastControllerLayoutHash = String.Empty;
		private void SetButtonNames()
		{
			long address = Rom.Addresses.MainRam.ControllerConfig;
			IReadOnlyList<byte> bytes = Mem.ReadByteRange(address, SHME.ExternalTool.ControllerConfig.Size);
			Guts.ControllerConfig = new SHME.ExternalTool.ControllerConfig(bytes);

			Dictionary<PsxButtons, string> names = new()
			{
				{ PsxButtons.None, String.Empty },
				{ PsxButtons.Select, "P1 Select" },
				{ PsxButtons.Start, "P1 Start" },
				{ PsxButtons.L2, "P1 L2" },
				{ PsxButtons.R2, "P1 R2" },
				{ PsxButtons.L1, "P1 L1" },
				{ PsxButtons.R1, "P1 R1" }
			};

			if (Octoshock != null)
			{
				names[PsxButtons.L3] = "P1 L3";
				names[PsxButtons.R3] = "P1 R3";
				names[PsxButtons.Up] = "P1 Up";
				names[PsxButtons.Right] = "P1 Right";
				names[PsxButtons.Down] = "P1 Down";
				names[PsxButtons.Left] = "P1 Left";
				names[PsxButtons.Triangle] = "P1 Triangle";
				names[PsxButtons.Circle] = "P1 Circle";
				names[PsxButtons.X] = "P1 Cross";
				names[PsxButtons.Square] = "P1 Square";
			}
			else
			{
				names[PsxButtons.L3] = "P1 Left Stick, Button";
				names[PsxButtons.R3] = "P1 Right Stick, Button";
				names[PsxButtons.Up] = "P1 D-Pad Up";
				names[PsxButtons.Right] = "P1 D-Pad Right";
				names[PsxButtons.Down] = "P1 D-Pad Down";
				names[PsxButtons.Left] = "P1 D-Pad Left";
				names[PsxButtons.Triangle] = "P1 △";
				names[PsxButtons.Circle] = "P1 ○";
				names[PsxButtons.X] = "P1 X";
				names[PsxButtons.Square] = "P1 □";
			}

			_buttonNames[ShmeCommand.Forward] = names[PsxButtons.Up];
			_buttonNames[ShmeCommand.Backward] = names[PsxButtons.Down];
			_buttonNames[ShmeCommand.Action] = names[Guts.ControllerConfig.Action.FilterToAny()];
			_buttonNames[ShmeCommand.Aim] = names[Guts.ControllerConfig.Aim.FilterToAny()];
			_buttonNames[ShmeCommand.Light] = names[Guts.ControllerConfig.Light.FilterToAny()];
			_buttonNames[ShmeCommand.Run] = names[Guts.ControllerConfig.Run.FilterToAny()];
			_buttonNames[ShmeCommand.View] = names[Guts.ControllerConfig.View.FilterToAny()];
			_buttonNames[ShmeCommand.Left] = names[Guts.ControllerConfig.StepL.FilterToAny()];
			_buttonNames[ShmeCommand.Right] = names[Guts.ControllerConfig.StepR.FilterToAny()];
			_buttonNames[ShmeCommand.Map] = names[Guts.ControllerConfig.Map.FilterToAny()];
		}

		private void SetPlaceholderText()
		{
			NumberFormatInfo f = CultureInfo.CurrentCulture.NumberFormat;
			string sep = f.NumberGroupSeparator;

			LblSpawnXZ.Text = $"<x{sep} z>";
			LblSelectedPoiXZ.Text = $"<x{sep} z>";
			LblCameraPathVolumeMin.Text = $"<x{sep} y{sep} z>";
			LblCameraPathVolumeMax.Text = $"<x{sep} y{sep} z>";
			LblCameraPathAreaMin.Text = $"<x{sep} z>";
			LblCameraPathAreaMax.Text = $"<x{sep} z>";
		}

		private void Selectable_Enter(object sender, EventArgs e)
		{
			if (sender is NumericUpDown nud)
			{
				nud.Select(0, nud.Text.Length);
			}
			else if (sender is TextBox tbx)
			{
				tbx.SelectAll();
			}
		}

		private DisplaySurfaceID _displaySurfaceID;
		private int _initializeOverlayCountdown;
		private void InitializeOverlay()
		{
			if (GameSurface == null)
			{
				return;
			}

			ClearOverlay();

			if (Octoshock == null)
			{
				if (RdoOverlayDisplaySurfaceFramebuffer.Checked)
				{
					RdoOverlayDisplaySurfaceClient.Checked = true;
				}

				RdoOverlayDisplaySurfaceFramebuffer.Enabled = false;
			}
			else
			{
				RdoOverlayDisplaySurfaceFramebuffer.Enabled = true;
			}

			Octoshock.eResolutionMode? mode = Octoshock?.GetSettings().ResolutionMode;
			if (mode == Octoshock.eResolutionMode.PixelPro)
			{
				Guts.ClickPort.Width = 640;
				Guts.ClickPort.Height = 448;
				Guts.ClickPort.TopLeft = new Point(84, 16);
			}
			else
			{
				Guts.ClickPort.Width = 320;
				Guts.ClickPort.Height = 224;
				Guts.ClickPort.TopLeft = new Point(17, 8);
			}

			if (RdoOverlayDisplaySurfaceFramebuffer.Checked)
			{
				Guts.RenderPort.Width = 320;
				Guts.RenderPort.Height = 224;
				Guts.RenderPort.TopLeft = new Point(0, 0);
			}
			else if (RdoOverlayDisplaySurfaceEmuCore.Checked)
			{
				Guts.RenderPort.Width = Guts.ClickPort.Width;
				Guts.RenderPort.Height = Guts.ClickPort.Height;
				Guts.RenderPort.TopLeft = Guts.ClickPort.TopLeft;
			}
			else
			{
				// BizHawk's Emu.BorderWidth and BorderHeight methods seem to be
				// perpetually one behind a window resize, showing the previous
				// border size instead of the new one. Grabbing a screenshot of
				// the window's client area and directly examining its pixels
				// avoids that, and has the benefit of cropping out the game's
				// overscan as well.

				IVideoProvider vp = Octoshock != null ? Octoshock.AsVideoProvider() : Nymashock.AsVideoProvider();
				using Bitmap screenshot = DisplayManager.RenderOffscreen(vp, false).ToSysdrawingBitmap();

				Guts.RenderPort = Viewport.FromBitmap(screenshot, Color.Black);
			}

			Guts.DummyViewport = new Viewport(0, 0, Guts.RenderPort.Width, Guts.RenderPort.Height);

			Pen?.Dispose();
			Overlay?.Dispose();

			Pen = new Pen(Brushes.White);
			Overlay = new Bitmap(Guts.RenderPort.Width, Guts.RenderPort.Height, PixelFormat.Format32bppArgb);

			_drawRegionRect = new Rectangle(0, 0, Guts.RenderPort.Width, Guts.RenderPort.Height);

			if (RdoOverlayDisplaySurfaceFramebuffer.Checked)
			{
				long a = Rom.Addresses.MainRam.IndexOfDrawRegion;
				a += Rom.Addresses.MainRam.BaseAddress;

				MemEvents?.AddWriteCallback(IndexOfDrawRegion_ValueChanging, (uint)a, "System Bus");
			}
			else
			{
				if (RdoOverlayDisplaySurfaceClient.Checked)
				{
					_displaySurfaceID = DisplaySurfaceID.Client;
				}
				else if (RdoOverlayDisplaySurfaceEmuCore.Checked)
				{
					_displaySurfaceID = DisplaySurfaceID.EmuCore;
				}

				MemEvents?.RemoveMemoryCallback(IndexOfDrawRegion_ValueChanging);

				// Sadly, this can't be done for framebuffer rendering. When
				// emulation is paused, modifications to the game's framebuffer
				// won't become visible until it resumes.
				if (Emu.IsPaused())
				{
					DrawOverlay();
					ApplyOverlayToGui();
				}
			}
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
				byte[] gameScanline = Mem.ReadByteRange(start, gpuramBytesPerPixel * Overlay.Width).ToArray();

				for (int x = 0; x < Overlay.Width; x++)
				{
					int ofs = (y * data.Stride) + (x * 4);
					int overlayPixel = Marshal.ReadInt32(data.Scan0, ofs);

					int a = (int)((overlayPixel & 0xFF000000) >> 24);
					if (a == 0x00)
					{
						continue;
					}

					int gameOfs = x * 2;

					int gamePixel;
					int r, g, b;
					if (a != 0xFF)
					{
						gamePixel = BitConverter.ToInt16(gameScanline, gameOfs);

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

					gamePixel = b | g | r;
					gameScanline[gameOfs + 0] = (byte)((gamePixel & 0x00FF) >> 0);
					gameScanline[gameOfs + 1] = (byte)((gamePixel & 0xFF00) >> 8);
				}

				Mem.WriteByteRange(start, gameScanline);

				start += gpuramStride;
			}
			Mem.UseMemoryDomain(previousDomain);

			Overlay.UnlockBits(data);
		}
		private void ApplyOverlayToGui()
		{
			Gui.WithSurface(_displaySurfaceID,
				() => Gui.DrawImage(
					Overlay,
					Guts.RenderPort.Left,
					Guts.RenderPort.Top,
					Guts.RenderPort.Width,
					Guts.RenderPort.Height,
					true,
					_displaySurfaceID));
		}

		private void GameSurface_SizeChanged(object sender, EventArgs e)
		{
			InitializeOverlay();
		}

		private void IndexOfDrawRegion_ValueChanging(uint address, uint value, uint flags)
		{
			DrawOverlay();

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
				AimCamera(BtnCameraFly);
			}
			else if (_firstPersonEnabled)
			{
				MoveCameraFirstPerson();
				AimCamera(BtnCameraFps);
				Mem.WriteU16(Rom.Addresses.MainRam.HarryYaw, _holdCameraYaw);
			}
		}

		private void Nud_KeyDown(object sender, KeyEventArgs e)
		{
			if (sender is NumericUpDown nud && e.KeyCode == Keys.Enter)
			{
				nud.ResetIfBad(this);
				BtnFramebufferGrab_Click(this, EventArgs.Empty);
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void Nud_Leave(object sender, EventArgs e)
		{
			if (sender is NumericUpDown nud)
			{
				nud.ResetIfBad(this);
			}
		}
	}
}
