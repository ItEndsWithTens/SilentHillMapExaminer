using BizHawk.Client.Common;
using OpenTK;
using OpenTK.Graphics;
using SHME.ExternalTool;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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

		public Camera Camera { get; set; } = new Camera() { Fov = 120.0f };

		public List<Renderable> Boxes { get; set; } = new List<Renderable>();

		public Rom Rom { get; set; }

		public CustomMainForm()
		{
			InitializeComponent();

			Core.Rom = new USRetail();
			Rom = Core.Rom;

			TrkFov.Value = (int)Camera.Fov;

			var generator = new BoxGenerator(1.0f, Color4.White);

			//for (int i = 0; i < 4; i++)
			//{
				Boxes.Add(generator.Generate().ToWorld());
			//}

			//Boxes[0].Position = new Vector3(155.5f, -8.5f, 0.15f);
			Boxes[0].Position = new Vector3(0.0f, 0.0f, 0.0f);

			//Boxes.Add(generator.Generate().ToWorld());

			//Boxes[1].Position = new Vector3(159.5f, -0.5f, -13.5f);
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
					//ReportMisc();
					if (CbxEnableTriggerDisplay.Checked)
					{
						DrawStuff();
					}
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

		private List<Point> Points = new List<Point>();

		private void DrawStuff()
		{
			if (Gui == null || Mem == null)
			{
				return;
			}

			List<float> position = Core.GetPosition(Mem);
			List<float> angles = Core.GetAngles(Mem);

			Camera.Position = CoordinateConverter.Convert(position.GetRange(3, 3), CoordinateType.SilentHill, CoordinateType.YUpRightHanded);

			Camera.Pitch = angles[3];
			Camera.Yaw = angles[4];
			Camera.Roll = angles[5];

			Camera.UpdateProjectionMatrix();

			Gui.DrawNew("emu"); // The name 'emu' is apparently required.

			var origin = new Point(84, 16);
			Gui.DrawBox(origin.X, origin.Y, 640 + (origin.X - 1), 448 + (origin.Y - 1));
			Gui.DrawLine(origin.X, origin.Y + 448 / 2, origin.X + 640 - 1, origin.Y + 448 / 2);
			Gui.DrawLine(origin.X + 640 / 2, origin.Y, origin.X + 640 / 2, origin.Y + 448 - 1);

			// Remember that the projection, view, model order from GL
			// shaders is reversed in C#, to account for OpenTK's row
			// major matrix layout.
			Matrix4 matrix = Camera.ViewMatrix * Camera.ProjectionMatrix;

			List<(Polygon, Renderable)> visible = Camera.GetVisiblePolygons(Boxes);

			foreach ((Polygon p, Renderable r) in visible)
			{
				matrix = r.ModelMatrix * matrix;

				foreach (int i in p.LineLoopIndices)
				{
					Vertex v = r.Vertices[i];

					Vector4 clip = new Vector4(v.Position, 1.0f) * matrix;

					Vector3 ndc = clip.Xyz / clip.W;

					// To account for Silent Hill's downward pointing vertical
					// axis, the Y component needs to be inverted.
					var screen = new Point(
						(int)((ndc.X + 1) * 320 + origin.X),
						(int)((-ndc.Y + 1) * 224 + origin.Y));

					Points.Add(screen);
				}

				int argb = r.Vertices[p.LineLoopIndices[0]].Color.ToArgb();

				Gui.DrawPolygon(Points.ToArray(), Color.FromArgb(argb), Color.FromArgb(argb));

				Points.Clear();
			}

			int tableAddressRaw = Mem.ReadS32(Rom.Addresses.MainRam.TriggerVertexTable);
			int tableAddress = (int)(tableAddressRaw - 0x80000000);
			tableAddress += 0xC;

			int vertZ = Mem.ReadS32((long)tableAddress + 0x0);
			int vertY = Mem.ReadS32((long)tableAddress + 0x4);
			int vertX = Mem.ReadS32((long)tableAddress + 0x8);

			float qZ = Core.QToFloat(vertZ);
			float qY = Core.QToFloat(vertY);
			float qX = Core.QToFloat(vertX);

			Vector4 clop = new Vector4(qX, qY, qZ, 1.0f) * matrix;
			Vector3 ndc2 = clop.Xyz / clop.W;
			var screeb = new Point(
				(int)((ndc2.X + 1) * 320 + origin.X),
				(int)((-ndc2.Y + 1) * 224 + origin.Y));

			Gui.DrawText(screeb.X, screeb.Y, "VERTEX");

			Gui.DrawFinish();
		}
	}
}
