using BizHawk.Client.Common;
using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace BizHawk.Client.EmuHawk
{
	[ExternalTool(ToolName, Description = ToolDescription)]

	// TODO: Add support for other versions of the game; EU, JP, demo, etc.
	[ExternalToolApplicability.RomWhitelist(CoreSystem.Playstation, USRetailConstants.HashBizHawk)]

	public partial class CustomMainForm : ToolFormBase, IExternalToolForm
	{
		[RequiredApi]
		public IMemoryApi? Mem { get; set; }

		[RequiredApi]
		public IGuiApi? Gui { get; set; }

		[RequiredApi]
		public IJoypadApi? Joy { get; set; }

		[RequiredApi]
		public IEmuClientApi? Emu { get; set; }

		[RequiredApi]
		public IEmulationApi? Emulation { get; set; }

		[RequiredApi]
		public IGameInfoApi? GI { get; set; }

		[RequiredApi]
		public IMemorySaveStateApi? MemSS { get; set; }

		public const string ToolName = "Silent Hill Map Examiner";
		public const string ToolDescription = "";

		protected override string WindowTitleStatic => ToolName;

		public Core Core { get; } = new Core();

		public Camera Camera { get; set; } = new Camera() { Fov = 50.0f, CullMode = CullMode.None };

		public List<Renderable> Boxes { get; set; } = new List<Renderable>();
		public List<Renderable> TestBoxes { get; set; } = new List<Renderable>();

		public Rom Rom => Core.Rom;

		public CustomMainForm()
		{
			InitializeComponent();

			TrkFov.Value = (int)Camera.Fov;

			CmbRenderMode.SelectedIndex = 0;

			CmbSelectedTriggerType.DataSource = Enum.GetValues(typeof(TriggerType));

			_arrayCountdown = new System.Timers.Timer(8)
			{
				AutoReset = true
			};
			_arrayCountdown.Elapsed += ArrayCountdown_Elapsed;
		}

		public override void UpdateValues(ToolFormUpdateType type)
		{
			if (Mem == null || Gui == null || Emu == null || GI?.GetRomName() == "Null")
			{
				return;
			}

			switch (type)
			{
				case ToolFormUpdateType.PreFrame:
					UpdateFog();
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
						CheckForUpdatedTriggers();
					}
					break;
				default:
					break;
			}
		}

		private List<Point> Points { get; } = new List<Point>();
		private List<Color> Colors { get; } = new List<Color>();
		private List<(Polygon, Renderable)> VisiblePolygons { get; } = new List<(Polygon, Renderable)>();

		private void DrawStuff()
		{
			if (Mem == null || Gui == null || Emu == null)
			{
				return;
			}

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

			int w = 320;
			int h = 224;
			var origin = new Point(0, 0);
			if (Emu.BufferWidth() == 350)
			{
				w = 320;
				origin.X = 17;
			}
			else if(Emu.BufferWidth() == 800)
			{
				w = 640;
				origin.X = 84;
			}

			if (Emu.BufferHeight() == 240)
			{
				h = 224;
				origin.Y = 8;
			}
			else if (Emu.BufferHeight() == 480)
			{
				h = 448;
				origin.Y = 16;
			}

			Gui.DrawBox(origin.X, origin.Y, w + (origin.X - 1), h + (origin.Y - 1));
			Gui.DrawLine(origin.X, origin.Y + h / 2, origin.X + w - 1, origin.Y + h / 2);
			Gui.DrawLine(origin.X + w / 2, origin.Y, origin.X + w / 2, origin.Y + h - 1);

			// Remember that the projection, view, model order from OpenGL
			// shaders is reversed in C#, to account for System.Numeric's row
			// major matrix layout.
			Matrix4x4 matrix = Camera.ViewMatrix * Camera.ProjectionMatrix;

			if (CmbRenderMode.SelectedIndex == 1)
			{
				Camera.CullMode = CullMode.Back;
			}
			else
			{
				Camera.CullMode = CullMode.None;
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

			foreach ((Polygon p, Renderable r) in VisiblePolygons)
			{
				matrix = r.ModelMatrix * matrix;

				foreach (int i in p.LineLoopIndices)
				{
					Vertex v = r.Vertices[i];

					Vector4 clip = Vector4.Transform(v.Position, matrix);

					Vector4 divided = clip / clip.W;

					var ndc = new Vector3(divided.X, divided.Y, divided.Z);

					// The above code to calculate normalized device coordinates
					// treats the vertical axis as increasing upwards, but RGB
					// rendering, and subsequently BizHawk's drawing API, treat
					// the axis as increasing downwards. Flipping the sign of
					// the Y component puts the point where it should be.
					var screen = new Point(
						(int)((ndc.X + 1) * (w / 2) + origin.X),
						(int)((-ndc.Y + 1) * (h / 2) + origin.Y));

					Points.Add(screen);
					if (r.Tint != null)
					{
						Colors.Add((Color)r.Tint);
					}
					else
					{
						Colors.Add(v.Color);
					}
				}

				int argb;
				if (r.Tint != null)
				{
					argb = ((Color)r.Tint).ToArgb();
				}
				else
				{
					argb = r.Vertices[p.LineLoopIndices[0]].Color.ToArgb();
				}

				if (CmbRenderMode.SelectedIndex == 0)
				{
					Gui.DrawPolygon(Points.ToArray(), Color.FromArgb(argb));
				}
				else if (CmbRenderMode.SelectedIndex == 1)
				{
					Gui.DrawPolygon(Points.ToArray(), Color.FromArgb(argb), Color.FromArgb(argb));
				}
				else if (CmbRenderMode.SelectedIndex == 2)
				{
					for (int i = 0; i < Points.Count; i++)
					{
						Point point = Points[i];

						Gui.DrawEllipse(point.X, point.Y, 4, 4, Colors[i], Colors[i]);
					}
				}

				Points.Clear();
				Colors.Clear();
			}
		}

		private float CalculateGameFov()
		{
			if (Mem == null)
			{
				return 0.0f;
			}

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
	}
}
