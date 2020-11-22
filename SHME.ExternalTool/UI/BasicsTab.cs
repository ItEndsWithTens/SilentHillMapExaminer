using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Windows.Forms;
using static SHME.ExternalTool.Core;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
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

		private void ReportControls()
		{
			var raw = (ButtonFlags)Mem.ReadU16(Rom.Addresses.MainRam.ButtonFlags);

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

			float drawDistance = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.DrawDistance), 8);

			LblCameraDrawDistance.Text = $"{drawDistance:N3}m";

			int spawnZ = Mem.ReadS32(Rom.Addresses.MainRam.HarrySpawnZ);
			uint spawnInfo = Mem.ReadU32(Rom.Addresses.MainRam.HarrySpawnInfo);
			int spawnX = Mem.ReadS32(Rom.Addresses.MainRam.HarrySpawnX);

			var sf = new PointOfInterest(spawnZ, spawnInfo, spawnX);

			LblSpawnX.Text = $"{sf.X:N2}";
			LblSpawnThing0.Text = $"0x{sf.Thing0:X2}";
			LblSpawnYaw.Text = $"{sf.Yaw:N2}";
			LblSpawnThing1.Text = $"0x{sf.Thing1:X2}";
			LblSpawnThing2.Text = $"0x{sf.Thing2:X2}";
			LblSpawnZ.Text = $"{sf.Z:N2}";
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

		private void BtnReadPois_Click(object sender, System.EventArgs e)
		{
			Boxes.Clear();

			var generator = new BoxGenerator(1.0f, Color.White);

			int poiSize = 12;
			for (int i = 0; i < NudPoiArraySize.Value; i++)
			{
				int poiArrayAddress = Mem.ReadS32(Rom.Addresses.MainRam.PointsOfInterest);
				poiArrayAddress -= (int)Rom.Addresses.MainRam.BaseAddress;
				int ofs = poiArrayAddress + (poiSize * i);

				float x = QToFloat(Mem.ReadS32(ofs + 8));
				float z = QToFloat(Mem.ReadS32(ofs + 0));

				Renderable box = generator.Generate().ToWorld();
				box.Position = new Vector3(x, 0.0f, z);

				Boxes.Add(box);
			}
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

		private void TrkFov_Scroll(object sender, EventArgs e)
		{
			Camera.Fov = TrkFov.Value;
			LblFov.Text = TrkFov.Value.ToString();
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
				Mem?.WriteByte(Rom.Addresses.MainRam.IsCameraUnlocked, 0x0);
			}
			else
			{
				Mem?.WriteByte(Rom.Addresses.MainRam.IsCameraUnlocked, 0x1);
			}
		}
	}
}
