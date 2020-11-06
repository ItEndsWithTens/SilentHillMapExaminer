using BizHawk.Client.Common;
using OpenTK;
using OpenTK.Graphics;
using SHME.ExternalTool;
using SHME.ExternalTool.Addresses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
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
			if (!Ready)
			{
				return;
			}

			switch (type)
			{
				//case ToolFormUpdateType.General:
				//case ToolFormUpdateType.FastPreFrame:
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
				//case ToolFormUpdateType.FastPostFrame:
				//case ToolFormUpdateType.PostFrame:
				//	ReportAngles();
				//	if (CbxEnableOverlaySection.Checked)
				//	{
				//		ReportOverlayInfo();
				//	}
				//	ReportPosition();
				//	DrawStuff();
				//	break;
				default:
					break;
			}
		}

		private void UpdateFog()
		{
			if (!CbxFog.Checked)
			{
				Mem?.WriteByte((long)MainRam.FogEnabled, 0);
			}

			if (CbxFogCustom.Checked)
			{
				Mem?.WriteByte((long)MainRam.FogColorR, (byte)NudFogR.Value);
				Mem?.WriteByte((long)MainRam.FogColorG, (byte)NudFogG.Value);
				Mem?.WriteByte((long)MainRam.FogColorB, (byte)NudFogB.Value);
			}

			if (CbxCustomWorldTint.Checked)
			{
				Mem?.WriteByte((long)MainRam.WorldTintR, (byte)NudWorldTintR.Value);
				Mem?.WriteByte((long)MainRam.WorldTintG, (byte)NudWorldTintG.Value);
				Mem?.WriteByte((long)MainRam.WorldTintB, (byte)NudWorldTintB.Value);
			}
		}

		private void ReportStats()
		{
			float walkedRaw = Core.QToFloat(Mem.ReadS32((long)MainRam.DistanceWalked));
			float runRaw = Core.QToFloat(Mem.ReadS32((long)MainRam.DistanceRun));

			LblDistanceWalked.Text = $"{walkedRaw / 1000.0f:N3} km";
			LblDistanceRun.Text = $"{runRaw / 1000.0f:N3} km";
		}

		private void ReportMisc()
		{
			LblGteX.Text = Core.QToFloat(Mem.ReadS32((long)MainRam.GteTranslationInputX)).ToString();
			LblGteY.Text = Core.QToFloat(Mem.ReadS32((long)MainRam.GteTranslationInputY)).ToString();
			LblGteZ.Text = Core.QToFloat(Mem.ReadS32((long)MainRam.GteTranslationInputZ)).ToString();

			int mat11 = (Mem.ReadS32((long)MainRam.Mat11_12) & 0b00000000_11111111) >> 0;
			int mat12 = (Mem.ReadS32((long)MainRam.Mat11_12) & 0b11111111_00000000) >> 8;

			int mat13 = (Mem.ReadS32((long)MainRam.Mat13_21) & 0b00000000_11111111) >> 0;
			int mat21 = (Mem.ReadS32((long)MainRam.Mat13_21) & 0b11111111_00000000) >> 8;

			int mat22 = (Mem.ReadS32((long)MainRam.Mat22_23) & 0b00000000_11111111) >> 0;
			int mat23 = (Mem.ReadS32((long)MainRam.Mat22_23) & 0b11111111_00000000) >> 8;

			int mat31 = (Mem.ReadS32((long)MainRam.Mat31_32) & 0b00000000_11111111) >> 0;
			int mat32 = (Mem.ReadS32((long)MainRam.Mat31_32) & 0b11111111_00000000) >> 8;

			int mat33 = (Mem.ReadS32((long)MainRam.Mat33) & 0b00000000_11111111) >> 0;

			LblMatrix11.Text = Core.QToFloat(mat11).ToString();
			LblMatrix12.Text = Core.QToFloat(mat12).ToString();
			LblMatrix13.Text = Core.QToFloat(mat13).ToString();

			LblMatrix21.Text = Core.QToFloat(mat21).ToString();
			LblMatrix22.Text = Core.QToFloat(mat22).ToString();
			LblMatrix23.Text = Core.QToFloat(mat23).ToString();

			LblMatrix31.Text = Core.QToFloat(mat31).ToString();
			LblMatrix32.Text = Core.QToFloat(mat32).ToString();
			LblMatrix33.Text = Core.QToFloat(mat33).ToString();

			LblCalculatedPitch.Text = (Math.Asin(mat31) * (180.0 / Math.PI)).ToString();
			LblCalculatedYaw.Text = (Math.Atan2(mat21, mat11) * (180.0 / Math.PI)).ToString();
			LblCalculatedRoll.Text = (Math.Atan2(mat32, mat33) * (180.0 / Math.PI)).ToString();
		}

		private void GetRegisterTest()
		{
			ulong? blar = Emulation.GetRegister("r17");

			
			var breakvar = 4;

			LblRegisterTest.Text = blar.ToString();
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

		[Flags]
		private enum ButtonFlags : ushort
		{
			Select =   0b00000000_00000001,
			L3 =       0b00000000_00000010,
			R3 =       0b00000000_00000100,
			Start =    0b00000000_00001000,
			Up =       0b00000000_00010000,
			Right =    0b00000000_00100000,
			Down =     0b00000000_01000000,
			Left =     0b00000000_10000000,
			L2 =       0b00000001_00000000,
			R2 =       0b00000010_00000000,
			L1 =       0b00000100_00000000,
			R1 =       0b00001000_00000000,
			Triangle = 0b00010000_00000000,
			Circle =   0b00100000_00000000,
			X =        0b01000000_00000000,
			Square =   0b10000000_00000000
		}

		private void ReportControls()
		{
			var raw = (ButtonFlags)Mem.ReadU16((long)MainRam.ButtonFlags);

			foreach (ButtonFlags button in Enum.GetValues(typeof(ButtonFlags)))
			{
				string buttonName = $"LblButton{Enum.GetName(typeof(ButtonFlags), button)}";

				Type thisType = typeof(CustomMainForm);
				FieldInfo? info = thisType.GetField(buttonName, BindingFlags.Instance | BindingFlags.NonPublic);

				if (info != null)
				{
					var label = (Label)info.GetValue(this);

					// For whatever reason, Silent Hill uses 0 for
					// button pressed and 1 for released.
					if (!raw.HasFlag(button))
					{
						label.ForeColor = Color.Lime;
					}
					else
					{
						label.ForeColor = Color.Red;
					}
				}
			}
		}

		private void ReportOverlayInfo()
		{
			LblOverlayCamPositionX.Text = Camera.Position.X.ToString();
			LblOverlayCamPositionY.Text = Camera.Position.Y.ToString();
			LblOverlayCamPositionZ.Text = Camera.Position.Z.ToString();

			LblOverlayCamPitch.Text = Camera.Pitch.ToString();
			LblOverlayCamYaw.Text = Camera.Yaw.ToString();
			LblOverlayCamRoll.Text = Camera.Roll.ToString();
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

			LblHarryHealth.Text = Core.QToFloat(Mem.ReadS32((long)MainRam.HarryHealth)).ToString();

			float drawDistance = Core.QToFloat(Mem.ReadS32((long)MainRam.DrawDistance), 8);

			LblCameraDrawDistance.Text = $"{drawDistance:N3}m";
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

			int tableAddressRaw = Mem.ReadS32((long)MainRam.TriggerVertexTable);
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

		private void TrkFov_Scroll(object sender, EventArgs e)
		{
			Camera.Fov = TrkFov.Value;
			LblFov.Text = TrkFov.Value.ToString();
		}

		private void BtnGrabMapGraphic_Click(object sender, EventArgs e)
		{
			List<byte> headerBytes = Mem.ReadByteRange((long)MainRam.MapTim, TimHeader.Length);

			var header = new TimHeader(headerBytes.ToArray());

			int timLength = header.ImageHeaderOfs + header.ImageBlockLength;

			List<byte> timBytes = Mem.ReadByteRange((long)MainRam.MapTim, timLength);
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
			Boxes[0].Position = new Vector3(
				(float)NudBoxX.Value,
				-(float)NudBoxY.Value,
				(float)NudBoxZ.Value);
		}

		private void NudBoxX_ValueChanged(object sender, EventArgs e)
		{
			Renderable box = Boxes[0];

			box.Position = new Vector3(
				(float)NudBoxX.Value,
				box.Position.Y,
				box.Position.Z);
		}

		private void NudBoxY_ValueChanged(object sender, EventArgs e)
		{
			Renderable box = Boxes[0];

			box.Position = new Vector3(
				box.Position.X,
				-(float)NudBoxY.Value, // Convert to SH coordinate space
				box.Position.Z);
		}

		private void NudBoxZ_ValueChanged(object sender, EventArgs e)
		{
			Renderable box = Boxes[0];

			box.Position = new Vector3(
				box.Position.X,
				box.Position.Y,
				(float)NudBoxZ.Value);
		}

		private void CbxEnableTriggerDisplay_CheckedChanged(object sender, EventArgs e)
		{
			if (!CbxEnableTriggerDisplay.Checked)
			{
				Gui.DrawNew("emu");
				Gui.ClearGraphics();
				Gui.DrawFinish();
			}
		}

		private void CbxCameraFreeze_CheckedChanged(object sender, EventArgs e)
		{
			if (CbxCameraFreeze.Checked)
			{
				Mem?.WriteByte((long)MainRam.IsCameraUnlocked, 0x0);
			}
			else
			{
				Mem?.WriteByte((long)MainRam.IsCameraUnlocked, 0x1);
			}
		}

		private void NudFogR_ValueChanged(object sender, EventArgs e)
		{
			BtnFogColor.BackColor = Color.FromArgb(
				(int)NudFogR.Value,
				BtnFogColor.BackColor.G,
				BtnFogColor.BackColor.B);
		}

		private void NudFogG_ValueChanged(object sender, EventArgs e)
		{
			BtnFogColor.BackColor = Color.FromArgb(
				BtnFogColor.BackColor.R,
				(int)NudFogG.Value,
				BtnFogColor.BackColor.B);
		}

		private void NudFogB_ValueChanged(object sender, EventArgs e)
		{
			BtnFogColor.BackColor = Color.FromArgb(
				BtnFogColor.BackColor.R,
				BtnFogColor.BackColor.G,
				(int)NudFogB.Value);
		}

		private void BtnFogColor_Click(object sender, EventArgs e)
		{
			var dialog = new ColorDialog();
			DialogResult result = dialog.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				NudFogR.Value = dialog.Color.R;
				NudFogG.Value = dialog.Color.G;
				NudFogB.Value = dialog.Color.B;
			}
		}

		private void NudWorldTintR_ValueChanged(object sender, EventArgs e)
		{
			BtnWorldTintColor.BackColor = Color.FromArgb(
				(int)NudWorldTintR.Value,
				BtnWorldTintColor.BackColor.G,
				BtnWorldTintColor.BackColor.B);
		}

		private void NudWorldTintG_ValueChanged(object sender, EventArgs e)
		{
			BtnWorldTintColor.BackColor = Color.FromArgb(
				BtnWorldTintColor.BackColor.R,
				(int)NudWorldTintG.Value,
				BtnWorldTintColor.BackColor.B);
		}

		private void NudWorldTintB_ValueChanged(object sender, EventArgs e)
		{
			BtnWorldTintColor.BackColor = Color.FromArgb(
				BtnWorldTintColor.BackColor.R,
				BtnWorldTintColor.BackColor.G,
				(int)NudWorldTintB.Value);
		}

		private void BtnWorldTintColor_Click(object sender, EventArgs e)
		{
			var dialog = new ColorDialog();
			DialogResult result = dialog.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				NudWorldTintR.Value = dialog.Color.R;
				NudWorldTintG.Value = dialog.Color.G;
				NudWorldTintB.Value = dialog.Color.B;
			}
		}

		private void BtnFogColorDefault_Click(object sender, EventArgs e)
		{
			NudFogR.Value = 108;
			NudFogG.Value = 100;
			NudFogB.Value = 116;
		}

		private void BtnWorldTintDefault_Click(object sender, EventArgs e)
		{
			NudWorldTintR.Value = 121;
			NudWorldTintG.Value = 128;
			NudWorldTintB.Value = 138;
		}

		private void BtnCustomFogCurrent_Click(object sender, EventArgs e)
		{
			NudFogR.Value = Mem.ReadByte((long)MainRam.FogColorR);
			NudFogG.Value = Mem.ReadByte((long)MainRam.FogColorG);
			NudFogB.Value = Mem.ReadByte((long)MainRam.FogColorB);
		}

		private void BtnCustomWorldTintCurrent_Click(object sender, EventArgs e)
		{
			NudWorldTintR.Value = Mem.ReadByte((long)MainRam.WorldTintR);
			NudWorldTintG.Value = Mem.ReadByte((long)MainRam.WorldTintG);
			NudWorldTintB.Value = Mem.ReadByte((long)MainRam.WorldTintB);
		}
	}
}
