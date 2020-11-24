using BizHawk.Client.Common;
using SHME.ExternalTool;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using static SHME.ExternalTool.Core;

namespace BizHawk.Client.EmuHawk
{
	[ExternalTool(CustomMainForm.ToolName, Description = CustomMainForm.ToolDescription)]

	// TODO: Add support for other versions of the game; EU, JP, demo, etc.
	[ExternalToolApplicability.RomWhitelist(CoreSystem.Playstation, USRetailConstants.HashBizHawk)]

	public partial class CustomMainForm : Form, IExternalToolForm
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

		public Core Core { get; } = new Core();

		public Camera Camera { get; set; } = new Camera() { Fov = 50.0f, CullMode = CullMode.None };

		public List<Renderable> Boxes { get; set; } = new List<Renderable>();

		public Rom Rom { get; set; }

		public CustomMainForm()
		{
			InitializeComponent();

			Core.Rom = new USRetail();
			Rom = Core.Rom;

			TrkFov.Value = (int)Camera.Fov;
		}

		public bool AskSaveChanges()
		{
			return true;
		}

		public void Restart()
		{
		}

		public void UpdateValues(ToolFormUpdateType type)
		{
			if (Emu == null || Mem == null || GI?.GetRomName() == "Null")
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
					if (CbxEnableOverlaySection.Checked)
					{
						ReportOverlayInfo();
					}
					//ReportMisc();
					DrawStuff();
					if (CbxStats.Checked)
					{
						ReportStats();
					}
					//GetRegisterTest();
					break;
				default:
					break;
			}
		}

		private List<Point> Points { get; } = new List<Point>();
		private List<(Polygon, Renderable)> VisiblePolygons { get; } = new List<(Polygon, Renderable)>();

		private void DrawStuff()
		{
			if (Gui == null || Mem == null)
			{
				return;
			}

			List<float> position = Core.GetPosition(Mem);
			List<float> angles = Core.GetAngles(Mem);

			Camera.Position = CoordinateConverter.Convert(position.GetRange(3, 3), CoordinateType.SilentHill, CoordinateType.YUpRightHanded);

			// There are two separate worlds: one, that of the game, in which a
			// camera is looking at a set of geometry and is set to a yaw of 0
			// degrees. Another, that of the overlay, where a separate camera is
			// looking at a different set of geometry, also at a yaw of 0. Said
			// geometry is in the same position and orientation relative to this
			// camera that the other geometry is to its camera.
			//
			// The big wrinkle is that both cameras disagree on which way yaw 0
			// points. The first thinks it should be north, toward positive Z,
			// while the latter uses east, toward positive X.
			//
			// Since both cameras share the characteristic of increasing pitch
			// values tilting the camera up, the pitch value doesn't need to be
			// modified. Likewise, roll needs no adjustment. But because the two
			// cameras' yaws are 90 degrees apart, the yaw of the overlay needs
			// to be adjusted so that the scenes will properly overlap.
			//
			// Each camera uses a different world up vector, Silent Hill's 'up'
			// pointing down and the overlay's pointing up, so yaw rotations go
			// in opposite directions. Nonetheless, simply subtracting 90 from
			// the game's yaw easily achieves the alignment of both cameras.
			Camera.Pitch = angles[3];
			Camera.Yaw = angles[4] - 90.0f;
			Camera.Roll = angles[5];

			Camera.UpdateProjectionMatrix();

			if (!CbxEnableTriggerDisplay.Checked && !CbxEnableModelDisplay.Checked)
			{
				return;
			}

			Gui.DrawNew("emu"); // The name 'emu' is apparently required.

			var origin = new Point(84, 16);
			int w = 640;
			int h = 448;
			Gui.DrawBox(origin.X, origin.Y, w + (origin.X - 1), h + (origin.Y - 1));
			Gui.DrawLine(origin.X, origin.Y + h / 2, origin.X + w - 1, origin.Y + h / 2);
			Gui.DrawLine(origin.X + w / 2, origin.Y, origin.X + w / 2, origin.Y + h - 1);

			// Remember that the projection, view, model order from OpenGL
			// shaders is reversed in C#, to account for System.Numeric's row
			// major matrix layout.
			Matrix4x4 matrix = Camera.ViewMatrix * Camera.ProjectionMatrix;

			VisiblePolygons.Clear();
			if (CbxEnableTriggerDisplay.Checked)
			{
				VisiblePolygons.AddRange(Camera.GetVisiblePolygons(Boxes));
			}
			if (CbxEnableModelDisplay.Checked)
			{
				VisiblePolygons.AddRange(Camera.GetVisiblePolygons(ModelBoxes));
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
						(int)((ndc.X + 1) * 320 + origin.X),
						(int)((-ndc.Y + 1) * 224 + origin.Y));

					Points.Add(screen);
				}

				int argb = r.Vertices[p.LineLoopIndices[0]].Color.ToArgb();

				Gui.DrawPolygon(Points.ToArray(), Color.FromArgb(argb));

				Points.Clear();
			}

			Gui.DrawFinish();
		}
	}
}
