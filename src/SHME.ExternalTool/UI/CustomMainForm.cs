using BizHawk.Client.Common;
using BizHawk.Emulation.Common;
using BizHawk.Emulation.Cores.Sony.PSX;
using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
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

		private IGameInfoApi GI => Apis.GameInfo;

		private IMemorySaveStateApi MemSS => Apis.MemorySaveState;

		private IToolApi Tool => Apis.Tool;

		private ISaveStateApi SaveState => Apis.SaveState;

		public ApiContainer? ApiContainer { get; set; }

		private ApiContainer Apis => ApiContainer ?? throw new ArgumentNullException();

		[OptionalService]
		public Octoshock? Octoshock { get; set; }

		public const string ToolName = "Silent Hill Map Examiner";
		public const string ToolDescription = "";

		protected override string WindowTitleStatic => ToolName;

		public Core Core { get; } = new Core();

		public Camera Camera { get; set; } = new Camera() { Fov = 50.0f, Culling = Culling.None };

		public List<Renderable> Boxes { get; set; } = new List<Renderable>();
		public List<Renderable> TestBoxes { get; set; } = new List<Renderable>();

		public Rom Rom => Core.Rom;

		private Viewport Viewport { get; } = new Viewport();

		public CustomMainForm()
		{
			InitializeComponent();

			TrkFov.Value = (int)Camera.Fov;

			CmbRenderMode.SelectedIndex = 0;

			// TODO: Switch this to 0 once trigger volume shapes have been fully
			// deciphered. Right now they're iffy at best.
			CmbRenderShape.SelectedIndex = 1;

			CmbSelectedTriggerType.DataSource = Enum.GetValues(typeof(TriggerType));

			CmbSaveButton.DataSource = Enum.GetValues(typeof(ButtonFlags));
			CmbSaveButton.SelectedItem = ButtonFlags.R3;

			_arrayCountdown = new System.Timers.Timer(8)
			{
				AutoReset = true
			};
			_arrayCountdown.Elapsed += ArrayCountdown_Elapsed;
		}

		public override void Restart()
		{
			base.Restart();

			Emu.StateLoaded += Emu_StateLoaded;

			if (Emu.BufferWidth() == 350)
			{
				Viewport.Width = 320;
				Viewport.TopLeft = new Point(17, Viewport.Top);
			}
			else if (Emu.BufferWidth() == 800)
			{
				Viewport.Width = 640;
				Viewport.TopLeft = new Point(84, Viewport.Top);
			}

			if (Emu.BufferHeight() == 240)
			{
				Viewport.Height = 224;
				Viewport.TopLeft = new Point(Viewport.Left, 8);
			}
			else if (Emu.BufferHeight() == 480)
			{
				Viewport.Height = 448;
				Viewport.TopLeft = new Point(Viewport.Left, 16);
			}

			Label[] labels =
			{
				LblSelectedPoiAddress,
				LblSelectedTriggerAddress,
				LblSelectedTriggerFiredDetails
			};

			MethodInfo? info = typeof(HexEditor).GetMethod("GoToAddress", BindingFlags.NonPublic | BindingFlags.Instance);
			if (info != null)
			{
				_foundHexEditorGoToMethod = true;

				foreach (Label l in labels)
				{
					l.BorderStyle = BorderStyle.Fixed3D;
					l.Cursor = Cursors.Hand;
				}
			}
			else
			{
				_foundHexEditorGoToMethod = false;

				foreach (Label l in labels)
				{
					l.BorderStyle = BorderStyle.None;
					l.Cursor = Cursors.Default;
				}
			}
		}

		public override void UpdateValues(ToolFormUpdateType type)
		{
			if (GI.GetRomName() == "Null")
			{
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
					//ReportMisc();
					Gui.WithSurface(DisplaySurfaceID.EmuCore, DrawStuff);
					if (CbxStats.Checked)
					{
						ReportStats();
					}
					//GetRegisterTest();
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

		private List<(Line line, Color color, bool visible, bool aClipped, bool bClipped)> ScreenSpaceLines { get; } = new List<(Line line, Color color, bool visible, bool aClipped, bool bClipped)>();
		private List<(Polygon, Renderable)> VisiblePolygons { get; } = new List<(Polygon, Renderable)>();
		private List<Line> VisibleLines { get; } = new List<Line>();

		private void DrawStuff()
		{
			List<float> position = Core.GetPosition(Mem);
			List<float> angles = Core.GetAngles(Mem);

			Vector3 convertedPosition = CoordinateConverter.Convert(position.GetRange(3, 3), CoordinateType.SilentHill, CoordinateType.YUpRightHanded);
			Vector3 convertedAngles = AngleConverter.Convert(angles.GetRange(3, 3), CoordinateType.SilentHill, CoordinateType.YUpRightHanded);

			if (CbxOverlayCameraMatchGame.Checked)
			{
				Camera.Position = convertedPosition;

				Camera.Pitch = convertedAngles.X;
				Camera.Yaw = convertedAngles.Y;
				Camera.Roll = convertedAngles.Z;

				Camera.Fov = CalculateGameFov();

				Camera.UpdateProjectionMatrix();

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

			if (!CbxEnableOverlay.Checked && !CbxEnableModelDisplay.Checked)
			{
				return;
			}

			Gui.DrawBox(Viewport.Left, Viewport.Top, Viewport.Right, Viewport.Bottom);
			Gui.DrawLine(Viewport.Left, Viewport.Center.Y, Viewport.Right, Viewport.Center.Y);
			Gui.DrawLine(Viewport.Center.X, Viewport.Top, Viewport.Center.X, Viewport.Bottom);

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

			DrawPolygons(matrix);
			DrawLines(matrix);
		}

		public void DrawLines(Matrix4x4 matrix)
		{
			ScreenSpaceLines.Clear();

			foreach (Line line in VisibleLines)
			{
				var clipped = new Line(line);

				bool visible = Camera.ClipLineAgainstFrustum(ref clipped);

				bool aClipped = line.A.Position != clipped.A.Position;
				bool bClipped = line.B.Position != clipped.B.Position;

				clipped.A = clipped.A.WorldToScreen(matrix, Viewport, true);
				clipped.B = clipped.B.WorldToScreen(matrix, Viewport, true);

				ScreenSpaceLines.Add((
					clipped,
					clipped.Tint != null ? (Color)clipped.Tint : clipped.A.Color,
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

							Gui.DrawEllipse(x - 2, y - 2, 4, 4, v.Color, v.Color);
						}
						break;
					default:
						foreach ((Line line, Color color, bool visible, _, _) in ScreenSpaceLines)
						{
							if (visible)
							{
								Gui.DrawLine(
									(int)line.A.Position.X,
									(int)line.A.Position.Y,
									(int)line.B.Position.X,
									(int)line.B.Position.Y,
									color);
							}
						}
						break;
				}
			}
		}

		public void DrawPolygons(Matrix4x4 matrix)
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

					clipped.A = clipped.A.WorldToScreen(matrix, Viewport, true);
					clipped.B = clipped.B.WorldToScreen(matrix, Viewport, true);

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

						Color c = r.Tint ?? ScreenSpaceLines[0].line.A.Color;
						Gui.DrawPolygon(visibleVertices.ToArray(), c, c);
						break;
					case 2:
						IEnumerable<Vertex> unclippedAs = ScreenSpaceLines.Where(ssl => ssl.visible && !ssl.aClipped).Select(ssl => ssl.line.A);
						IEnumerable<Vertex> unclippedBs = ScreenSpaceLines.Where(ssl => ssl.visible && !ssl.bClipped).Select(ssl => ssl.line.B);

						foreach (Vertex v in unclippedAs.Concat(unclippedBs))
						{
							int x = (int)v.Position.X;
							int y = (int)v.Position.Y;

							Gui.DrawEllipse(x - 2, y - 2, 4, 4, v.Color, v.Color);
						}
						break;
					default:
						foreach ((Line line, Color color, bool visible, _, _) in ScreenSpaceLines)
						{
							if (visible)
							{
								Gui.DrawLine(
									(int)line.A.Position.X,
									(int)line.A.Position.Y,
									(int)line.B.Position.X,
									(int)line.B.Position.Y,
									color);
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
	}
}
