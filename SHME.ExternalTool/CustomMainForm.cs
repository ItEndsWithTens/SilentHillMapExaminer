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
			Boxes[0].Position = new Vector3(0.0f, 0.0f, 0.0f);

			Boxes.Add(generator.Generate().ToWorld());

			Boxes[1].Position = new Vector3(159.5f, -0.5f, -13.5f);
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
				//case ToolFormUpdateType.General:
				//case ToolFormUpdateType.FastPreFrame:
				case ToolFormUpdateType.PreFrame:
					// The drawn boxes seem much more tightly attached to the
					// world when this is done in PreFrame as opposed to PostFrame.
					ReportAngles();
					ReportPosition();
					DrawStuff();
					break;
				//case ToolFormUpdateType.FastPostFrame:
				//case ToolFormUpdateType.PostFrame:
					//ReportAngles();
					//ReportPosition();
					//DrawStuff();
					//break;
				default:
					break;
			}
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

			Vector3 boxCoords = CoordinateConverter.Convert(
				Boxes[0].Position,
				CoordinateType.YUpRightHanded,
				CoordinateType.SilentHill);

			LblBoxX.Text = boxCoords.X.ToString();
			LblBoxY.Text = boxCoords.Y.ToString();
			LblBoxZ.Text = boxCoords.Z.ToString();
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

			List<float> position = Core.GetPosition(Mem);
			List<float> angles = Core.GetAngles(Mem);

			Camera.Position = CoordinateConverter.Convert(position.GetRange(3, 3), CoordinateType.SilentHill, CoordinateType.YUpRightHanded);

			//TODO: Need to sort out angle conversion. Not sure why it doesn't work yet.
			Camera.Pitch = -angles[3];
			Camera.Yaw = angles[4];
			Camera.Roll = angles[5];

			Camera.UpdateProjectionMatrix();

			Gui.DrawNew("emu"); // The name 'emu' is apparently required.

			var origin = new Point(84, 16);
			Gui.DrawBox(origin.X, origin.Y, 640 + (origin.X - 1), 448 + (origin.Y - 1));
			Gui.DrawLine(origin.X, origin.Y + 448 / 2, origin.X + 640 - 1, origin.Y + 448 / 2);
			Gui.DrawLine(origin.X + 640 / 2, origin.Y, origin.X + 640 / 2, origin.Y + 448 - 1);

			foreach (Renderable box in Boxes)
			{
				if (!Camera.CanSee(box))
				{
					// FIXME: Should be just a 'continue', right? Need to test, too late right now, need sleep.
					Gui.DrawFinish();
					return;
				}

				// Remember that the projection, view, model order from GL
				// shaders is reversed in C#, to account for OpenTK's row
				// major matrix layout.
				Matrix4 matrix = box.ModelMatrix * Camera.ViewMatrix * Camera.ProjectionMatrix;

				List<(Polygon, Renderable)> visible = Camera.GetVisiblePolygons(Boxes);

				//foreach (Polygon p in box.Polygons)
				foreach ((Polygon p, Renderable _) in visible)
				{
					foreach (int i in p.LineLoopIndices)
					{
						Vertex v = box.Vertices[i];

						Vector3 converted = CoordinateConverter.Convert(
							v.Position,
							CoordinateType.YUpRightHanded,
							CoordinateType.SilentHill);

						Vector4 clip = new Vector4(converted, 1.0f) * matrix;

						Vector3 ndc = clip.Xyz / clip.W;

						var screen = new Point(
							(int)((ndc.X + 1) * 320 + origin.X),
							(int)((ndc.Y + 1) * 224 + origin.Y));

						Points.Add(screen);
					}

					int argb = box.Vertices[p.LineLoopIndices[0]].Color.ToArgb();

					Gui.DrawPolygon(Points.ToArray(), Color.FromArgb(argb), Color.FromArgb(argb));
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

		private void TrkBoxVerticalCoord_Scroll(object sender, EventArgs e)
		{
			Vector3 oldPosition = Boxes[0].Position;

			Boxes[0].Position = new Vector3(oldPosition.X, -TrkBoxVerticalCoord.Value, oldPosition.Z);

			LblBoxVerticalCoord.Text = (-TrkBoxVerticalCoord.Value).ToString();
		}

		private void BtnGrabMapGraphic_Click(object sender, EventArgs e)
		{
			List<byte> headerBytes = Mem.ReadByteRange((long)MainRamAddresses.SomeRandomTim, TimHeader.Length);

			var header = new TimHeader(headerBytes.ToArray());

			int timLength = header.ImageHeaderOfs + header.ImageBlockLength;

			List<byte> timBytes = Mem.ReadByteRange((long)MainRamAddresses.SomeRandomTim, timLength);
			var mapGraphic = new Tim(header, timBytes.ToArray());

			PbxMapGraphic.Image = mapGraphic.Bitmap;
			PbxMapGraphic.SizeMode = PictureBoxSizeMode.StretchImage;
			PbxMapGraphic.Width = 640;
		}

		private void BtnBoxGetPosition_Click(object sender, EventArgs e)
		{
			NudBoxX.Text = LblBoxX.Text;
			NudBoxY.Text = LblBoxY.Text;
			NudBoxZ.Text = LblBoxZ.Text;
		}

		private void BtnBoxSetPosition_Click(object sender, EventArgs e)
		{
			Boxes[0].Position = CoordinateConverter.Convert(
				new Vector3(
					(float)NudBoxX.Value,
					(float)NudBoxY.Value,
					(float)NudBoxZ.Value),
				CoordinateType.SilentHill,
				CoordinateType.YUpRightHanded);
		}

		private void NudBoxX_ValueChanged(object sender, EventArgs e)
		{
			Renderable box = Boxes[0];

			box.Position = CoordinateConverter.Convert(
				new Vector3(
					(float)NudBoxX.Value,
					box.Position.Y,
					box.Position.Z),
				CoordinateType.SilentHill,
				CoordinateType.YUpRightHanded);
		}

		private void NudBoxY_ValueChanged(object sender, EventArgs e)
		{
			Renderable box = Boxes[0];

			box.Position = CoordinateConverter.Convert(
				new Vector3(
					box.Position.X,
					(float)NudBoxY.Value,
					box.Position.Z),
				CoordinateType.SilentHill,
				CoordinateType.YUpRightHanded);
		}

		private void NudBoxZ_ValueChanged(object sender, EventArgs e)
		{
			Renderable box = Boxes[0];

			box.Position = CoordinateConverter.Convert(
				new Vector3(
					box.Position.X,
					box.Position.Y,
					(float)NudBoxZ.Value),
				CoordinateType.SilentHill,
				CoordinateType.YUpRightHanded);
		}
	}
}
