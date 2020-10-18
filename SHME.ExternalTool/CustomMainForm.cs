using BizHawk.Client.Common;
using OpenTK;
using OpenTK.Graphics;
using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	[ExternalTool(CustomMainForm.ToolName, Description = CustomMainForm.ToolDescription)]

	// FIXME: Figure this part out, not sure what format the hash needs.
	//[ExternalToolApplicability.SingleRom(CoreSystem.Playstation, "1D4A3FF7")]

	public partial class CustomMainForm : Form, IExternalToolForm
	{
		[RequiredApi]
		public IMemoryApi? Mem { get; set; }

		[RequiredApi]
		public IGuiApi? Gui { get; set; }

		[RequiredApi]
		public IJoypadApi? Joy { get; set; }

		private IEmuClientApi? _emu;
		[RequiredApi]
		public IEmuClientApi? Emu
		{
			get { return _emu; }
			set
			{
				_emu = value;

				if (Emu != null)
				{
					Emu.RomLoaded += (sender, e) => Ready = true;
				}
			}
		}

		[RequiredApi]
		public IEmulationApi? Emulation { get; set; }

		[RequiredApi]
		public IGameInfoApi? GI { get; set; }

		[RequiredApi]
		public IMemorySaveStateApi? MemSS { get; set; }

		public const string ToolName = "Silent Hill Map Examiner";
		public const string ToolDescription = "";

		public Core Core { get; } = new Core();

		private bool Ready { get; set; } = false;

		public Camera Camera { get; set; } = new Camera() { Fov = 120.0f };

		public List<Renderable> Boxes { get; set; } = new List<Renderable>();

		public CustomMainForm()
		{
			InitializeComponent();

			TrkFov.Value = (int)Camera.Fov;

			var generator = new BoxGenerator(1.0f, Color4.White);

			//for (int i = 0; i < 4; i++)
			//{
				Boxes.Add(generator.Generate().ToWorld());
			//}

			//Boxes[0].Position = new Vector3(155.5f, -8.5f, 0.15f);
			Boxes[0].Position = new Vector3(0.5f);
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
			if (!Ready)
			{
				return;
			}

			switch (type)
			{
				case ToolFormUpdateType.PreFrame:
					//TestMakingHarryWalkOnAir();
					break;
				case ToolFormUpdateType.PostFrame:
					ReportAngles();
					ReportPosition();
					DrawStuff();
					break;
				default:
					break;
			}
		}

		// I don't hold out much hope of getting this to work; can't
		// seem to walk if the height is set beyond about -0.702 (higher
		// up is lower numbers, for some reason I haven't figured out).
		private void TestMakingHarryWalkOnAir()
		{
			bool success = Single.TryParse(TbxPositionZ.Text, out float z);

			if (!success)
			{
				return;
			}

			Core.SetHarryZ(Mem, z);
			Mem?.WriteS32((long)MainRamAddresses.HarryParalyzed, 0x00000000);
			Mem?.WriteS32((long)MainRamAddresses.HarryPositionZTwo, 0x00000000);
		}

		private void ReportAngles()
		{
			List<float> angles = Core.GetAngles(Mem);

			LblHarryPitch.Text = angles[0].ToString("N2");
			LblHarryYaw.Text = angles[1].ToString("N2");
			LblHarryRoll.Text = angles[2].ToString("N2");

			LblCameraPitch.Text = angles[3].ToString("N2");
			LblCameraYaw.Text = angles[4].ToString("N2");
			LblCameraRoll.Text = angles[5].ToString("N2");
		}

		private void ReportPosition()
		{
			List<float> position = Core.GetPosition(Mem);

			LblHarryPositionX.Text = position[0].ToString("N2");
			LblHarryPositionY.Text = position[1].ToString("N2");
			LblHarryPositionZ.Text = position[2].ToString("N2");

			LblCameraPositionX.Text = position[3].ToString("N2");
			LblCameraPositionY.Text = position[4].ToString("N2");
			LblCameraPositionZ.Text = position[5].ToString("N2");
		}

		private void BtnGetPosition_Click(object sender, EventArgs e)
		{
			TbxPositionX.Text = LblHarryPositionX.Text;
			TbxPositionY.Text = LblHarryPositionY.Text;
			TbxPositionZ.Text = LblHarryPositionZ.Text;
		}

		private void BtnSetPosition_Click(object sender, EventArgs e)
		{
			Core.SetHarryPosition(Mem,
				Single.Parse(TbxPositionX.Text),
				Single.Parse(TbxPositionY.Text),
				Single.Parse(TbxPositionZ.Text));
		}

		private void BtnGetAngles_Click(object sender, EventArgs e)
		{
			TbxHarryPitch.Text = LblHarryPitch.Text;
			TbxHarryYaw.Text = LblHarryYaw.Text;
			TbxHarryRoll.Text = LblHarryRoll.Text;
		}

		private void BtnSetHarryPitch_Click(object sender, EventArgs e)
		{
			Core.SetPitch(Mem, Single.Parse(TbxHarryPitch.Text));
		}

		private void BtnSetHarryYaw_Click(object sender, EventArgs e)
		{
			Core.SetYaw(Mem, Single.Parse(TbxHarryYaw.Text));
		}

		private void BtnSetHarryRoll_Click(object sender, EventArgs e)
		{
			Core.SetRoll(Mem, Single.Parse(TbxHarryRoll.Text));
		}

		private void BtnSetAngles_Click(object sender, EventArgs e)
		{
			Core.SetAngles(Mem,
				Single.Parse(TbxHarryPitch.Text),
				Single.Parse(TbxHarryYaw.Text),
				Single.Parse(TbxHarryRoll.Text));
		}

		private List<Point> Points = new List<Point>();

		private void DrawStuff()
		{
			if (Gui == null || Mem == null)
			{
				return;
			}

			// Silent Hill uses what seem to be right handed coordinates, but
			// rotated so that positive Z points down, for whatever reason. Also
			// could be described as left handed coordinates with Z inverted? I
			// guess. Very annoying to sort this shit out.
			//
			// Starting Harry position:
			// X: -6.08
			// Y: 154.02
			// Z: 0
			//
			// Renderable positions are assumed to be Z up, left handed.
			//Box.Position = new Vector3(-6.08f, -154.02f, 0.0f);
			//Box.Position = new Vector3(-6.0f, -154f, 0.0f);
			//Box.Position = new Vector3(0.5f, 0.0f, -0.5f);
			//Box.Position = new Vector3(0.0f, 0.0f, -0.5f);

			// Starting camera position:
			// X: 156.48
			// Y: -5.56
			// Z: -2.50
			//Camera.Position = new Vector3(156.48f, -2.50f, 5.56f);

			List<float> position = Core.GetPosition(Mem);
			List<float> angles = Core.GetAngles(Mem);
			Camera.Position = new Vector3(
				//Single.Parse(lblCameraPositionX.Text),
				//Single.Parse(lblCameraPositionZ.Text),
				//Single.Parse(lblCameraPositionY.Text));
				position[3],
				position[5],
				position[4]);
			//Camera.Position = new Vector3(-2.0f, 0.0f, 0.0f);

			// SH camera pitch uses +90 for straight down, -90 for straight up.
			//Camera.Pitch = Single.Parse(lblCameraPitch.Text);
			//Camera.Yaw = -Single.Parse(lblCameraYaw.Text);
			//Camera.Roll = Single.Parse(lblCameraRoll.Text);
			Camera.Pitch = angles[3];
			Camera.Yaw = -angles[4];
			Camera.Roll = angles[5];

			// Why, above, do I need to negate the camera Yaw but not the camera
			// Z position? Coordinate system bullshit. Go figure.


			Camera.UpdateProjectionMatrix();

			Gui.DrawNew("emu"); // The name 'emu' is apparently required.

			var origin = new Point(84, 16);

			foreach (Renderable box in Boxes)
			{

				if (!Camera.CanSee(box))
				{
					//Gui.DrawFinish();
					//return;
				}

				Gui.DrawBox(origin.X, origin.Y, 640 + (origin.X - 1), 448 + (origin.Y - 1));

				// Remember that the projection, view, model order from GL
				// shaders is reversed in C#, to account for OpenTK's row
				// major matrix layout.
				Matrix4 matrix = box.ModelMatrix * Camera.ViewMatrix * Camera.ProjectionMatrix;

				foreach (Polygon p in box.Polygons)
				{
					foreach (int i in p.LineLoopIndices)
					{
						Vertex v = box.Vertices[i];

						Vector4 clip = new Vector4(v.Position, 1.0f) * matrix;

						Vector3 ndc = clip.Xyz / clip.W;

						var screen = new Point(
							(int)((ndc.X + 1) * 320 + origin.X),
							(int)((ndc.Y + 1) * 224 + origin.Y));

						Points.Add(screen);
					}

					Gui.DrawPolygon(Points.ToArray(), Color.White);
					Points.Clear();
				}
			}

			Gui.DrawFinish();
		}

		private void TrkFov_Scroll(object sender, EventArgs e)
		{
			Camera.Fov = TrkFov.Value;
			LblFov.Text = TrkFov.Value.ToString();
		}
	}
}
