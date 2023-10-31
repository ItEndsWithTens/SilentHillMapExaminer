﻿using BizHawk.Client.Common;
using SHME.ExternalTool;
using System;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Windows.Forms;
using static SHME.ExternalTool.Core;

namespace BizHawk.Client.EmuHawk
{
#pragma warning disable IDE0055
	// IDE0055 covers all code style formatting rules, including the removal of
	// whitespace some developers use to line up values when assigning many
	// variables at once. That's usually desirable, but in cases like this, i.e.
	// bitfields/flags, the alignment helps make it more visually obvious which
	// bits correspond to which enum members.
	[Flags]
	public enum ButtonFlags : ushort
	{
		None =     0b00000000_00000000,
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
#pragma warning restore IDE0055

	public partial class CustomMainForm
	{
		private void InitializeBasicsTab()
		{
			TrkFov.Value = (int)Camera.Fov;

			CmbRenderMode.SelectedIndex = 0;
		}

		private void ReportAngles()
		{
			(Vector3 harry, Vector3 camera) = GetAngles();

			string f = "N2";
			CultureInfo c = CultureInfo.CurrentCulture;

			LblHarryPitch.Text = harry.X.ToString(f, c);
			LblHarryYaw.Text = harry.Y.ToString(f, c);
			LblHarryRoll.Text = harry.Z.ToString(f, c);

			LblCameraPitch.Text = camera.X.ToString(f, c);
			LblCameraYaw.Text = camera.Y.ToString(f, c);
			LblCameraRoll.Text = camera.Z.ToString(f, c);
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
					if (!raw.FasterHasFlag(button))
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
			string f = "N2";
			CultureInfo c = CultureInfo.CurrentCulture;

			LblOverlayCamPositionX.Text = Camera.Position.X.ToString(f, c);
			LblOverlayCamPositionY.Text = Camera.Position.Y.ToString(f, c);
			LblOverlayCamPositionZ.Text = Camera.Position.Z.ToString(f, c);

			LblOverlayCamPitch.Text = Camera.Pitch.ToString(f, c);
			LblOverlayCamYaw.Text = Camera.Yaw.ToString(f, c);
			LblOverlayCamRoll.Text = Camera.Roll.ToString(f, c);
		}

		private string _lastHarrySpawnPointHash = "";
		private PointOfInterest? _lastHarrySpawnPoint;
		private void ReportPosition()
		{
			(Vector3 harry, Vector3 camera) = GetPosition();

			string f = "N2";
			CultureInfo c = CultureInfo.CurrentCulture;

			LblHarryPositionX.Text = harry.X.ToString(f, c);
			LblHarryPositionY.Text = harry.Y.ToString(f, c);
			LblHarryPositionZ.Text = harry.Z.ToString(f, c);

			LblCameraPositionX.Text = camera.X.ToString(f, c);
			LblCameraPositionY.Text = camera.Y.ToString(f, c);
			LblCameraPositionZ.Text = camera.Z.ToString(f, c);

			float drawDistance = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.DrawDistance), 8);

			LblCameraDrawDistance.Text = $"{drawDistance.ToString("N3", c)}m";

			long address = Rom.Addresses.MainRam.LastHarrySpawnPoint;
			string hash = Mem.HashRegion(address, 12);
			if (hash != _lastHarrySpawnPointHash)
			{
				_lastHarrySpawnPoint = new PointOfInterest(address, Mem.ReadByteRange(address, 12));
				_lastHarrySpawnPointHash = hash;

				LblSpawnX.Text = $"{_lastHarrySpawnPoint.X.ToString("0.##", c)}";
				LblSpawnGeometry.Text = $"0x{_lastHarrySpawnPoint.Geometry.ToString("X2", c)}";
				LblSpawnZ.Text = $"{_lastHarrySpawnPoint.Z.ToString("0.##", c)}";
			}
		}

		public (Vector3 harry, Vector3 camera) GetAngles()
		{
			Vector3 harry;
			harry.X = GameUnitsToDegrees(Mem.ReadU16(Rom.Addresses.MainRam.HarryPitch));
			harry.Y = GameUnitsToDegrees(Mem.ReadU16(Rom.Addresses.MainRam.HarryYaw));
			harry.Z = GameUnitsToDegrees(Mem.ReadU16(Rom.Addresses.MainRam.HarryRoll));

			Vector3 camera;
			camera.X = GameUnitsToDegrees(Mem.ReadU16(Rom.Addresses.MainRam.CameraActualPitch));
			camera.Y = GameUnitsToDegrees(Mem.ReadU16(Rom.Addresses.MainRam.CameraActualYaw));
			camera.Z = GameUnitsToDegrees(Mem.ReadU16(Rom.Addresses.MainRam.CameraActualRoll));

			return (harry, camera);
		}
		public void SetHarryAngles(float pitch, float yaw, float roll)
		{
			Mem.WriteU16(Rom.Addresses.MainRam.HarryPitch, DegreesToGameUnits(pitch));
			Mem.WriteU16(Rom.Addresses.MainRam.HarryYaw, DegreesToGameUnits(yaw));
			Mem.WriteU16(Rom.Addresses.MainRam.HarryRoll, DegreesToGameUnits(roll));
		}

		public (Vector3 harry, Vector3 camera) GetPosition()
		{
			Vector3 harry;
			harry.X = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionX));
			harry.Y = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionY));
			harry.Z = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionZ));

			Vector3 camera;
			camera.X = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.CameraPositionActualX));
			camera.Y = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.CameraPositionActualY));
			camera.Z = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.CameraPositionActualZ));

			return (harry, camera);
		}

		public void SetHarryPosition(float x, float y, float z)
		{
			MainRamAddresses ram = Rom.Addresses.MainRam;

			Mem.WriteS32(ram.HarryPositionX, FloatToQ(x));
			Mem.WriteS32(ram.HarryPositionY, FloatToQ(y));
			Mem.WriteS32(ram.HarryPositionZ, FloatToQ(z));

			if (CbxHarrySetPositionMoveCamera.Checked)
			{
				Mem.WriteS32(ram.CameraPositionActualX, FloatToQ(x));
				Mem.WriteS32(ram.CameraPositionActualY, FloatToQ(y - 3.0f));
				Mem.WriteS32(ram.CameraPositionActualZ, FloatToQ(z));

				Mem.WriteS32(ram.CameraPositionIdealX, FloatToQ(x));
				Mem.WriteS32(ram.CameraPositionIdealY, FloatToQ(y - 3.0f));
				Mem.WriteS32(ram.CameraPositionIdealZ, FloatToQ(z));

				Mem.WriteS32(ram.CameraLookAtX, FloatToQ(x));
				Mem.WriteS32(ram.CameraLookAtY, FloatToQ(y));
				Mem.WriteS32(ram.CameraLookAtZ, FloatToQ(z));
			}
		}

		private void BtnGetPosition_Click(object sender, EventArgs e)
		{
			TbxPositionX.Text = LblHarryPositionX.Text;
			TbxPositionY.Text = LblHarryPositionY.Text;
			TbxPositionZ.Text = LblHarryPositionZ.Text;
		}

		private void BtnSetPosition_Click(object sender, EventArgs e)
		{
			if (!Single.TryParse(TbxPositionX.Text, out float x))
			{
				x = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionX));
			}

			if (!Single.TryParse(TbxPositionY.Text, out float y))
			{
				y = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionY));
			}

			if (!Single.TryParse(TbxPositionZ.Text, out float z))
			{
				z = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionZ));
			}

			SetHarryPosition(x, y, z);
		}

		private void BtnGetAngles_Click(object sender, EventArgs e)
		{
			TbxHarryPitch.Text = LblHarryPitch.Text;
			TbxHarryYaw.Text = LblHarryYaw.Text;
			TbxHarryRoll.Text = LblHarryRoll.Text;
		}

		private void BtnSetAngles_Click(object sender, EventArgs e)
		{
			(Vector3 harry, _) = GetAngles();

			if (!Single.TryParse(TbxHarryPitch.Text, out float pitch))
			{
				pitch = harry.X;
			}

			if (!Single.TryParse(TbxHarryYaw.Text, out float yaw))
			{
				yaw = harry.Y;
			}

			if (!Single.TryParse(TbxHarryRoll.Text, out float roll))
			{
				roll = harry.Z;
			}

			SetHarryAngles(pitch, yaw, roll);
		}

		private void CbxEnableOverlay_CheckedChanged(object sender, EventArgs e)
		{
			if (!CbxEnableOverlay.Checked)
			{
				ClearOverlay();
			}
			else
			{
				CbxOverlayRenderToFramebuffer_CheckedChanged(this, EventArgs.Empty);
			}
		}

		private void CbxCameraFreeze_CheckedChanged(object sender, EventArgs e)
		{
			if (CbxCameraFreeze.Checked)
			{
				Mem.WriteByte(Rom.Addresses.MainRam.IsCameraUnlocked, 0x0);
			}
			else
			{
				Mem.WriteByte(Rom.Addresses.MainRam.IsCameraUnlocked, 0x1);
			}
		}

		private void CbxCullBackfaces_CheckedChanged(object sender, EventArgs e)
		{
			if (CbxCullBackfaces.Checked)
			{
				Camera.Culling |= Culling.Backface;
			}
			else
			{
				Camera.Culling ^= Culling.Backface;
			}
		}

		private void CbxCullBeyondFarClip_CheckedChanged(object sender, EventArgs e)
		{
			if (CbxCullBeyondFarClip.Checked)
			{
				Camera.Culling |= Culling.Far;
			}
			else
			{
				Camera.Culling ^= Culling.Far;
			}
		}

		private void CbxOverlayCameraMatchGame_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!CbxOverlayCameraMatchGame.Checked)
			{
				Camera.Position = new Vector3(
					(float)NudOverlayCameraX.Value,
					(float)NudOverlayCameraY.Value,
					(float)NudOverlayCameraZ.Value);

				Camera.Pitch = (float)NudOverlayCameraPitch.Value;
				Camera.Yaw = (float)NudOverlayCameraYaw.Value;
				Camera.Roll = (float)NudOverlayCameraRoll.Value;
			}
		}

		private void CbxOverlayRenderToFramebuffer_CheckedChanged(object sender, EventArgs e)
		{
			ClearOverlay();
			InitializeOverlay();

			if (CbxOverlayRenderToFramebuffer.Checked)
			{
				long a = Rom.Addresses.MainRam.IndexOfDrawRegion;
				a += Rom.Addresses.MainRam.BaseAddress;

				MemEvents?.AddWriteCallback(IndexOfDrawRegion_ValueChanging, (uint)a, "System Bus");
			}
		}

		private void CbxReadLevelDataOnStageLoad_CheckedChanged(object sender, EventArgs e)
		{
			BtnReadPois.Enabled = !CbxReadLevelDataOnStageLoad.Checked;
			BtnReadTriggers.Enabled = !CbxReadLevelDataOnStageLoad.Checked;
			BtnCameraPathReadArray.Enabled = !CbxReadLevelDataOnStageLoad.Checked;

			_levelDataNeedsUpdate = true;
		}

		private void CmbRenderMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (CmbRenderMode.SelectedIndex)
			{
				case 1:
					CbxCullBackfaces.Checked = true;
					CbxCullBeyondFarClip.Checked = true;
					break;
				default:
					CbxCullBackfaces.Checked = false;
					CbxCullBeyondFarClip.Checked = true;
					break;
			}
		}

		private void Emu_StateLoaded(object sender, StateLoadedEventArgs e)
		{
			Pois.Clear();
			LbxPois.Items.Clear();
			LblPoiCount.Text = "-";

			Triggers.Clear();
			LbxTriggers.Items.Clear();
			LblTriggerCount.Text = "-";

			LbxPoiAssociatedTriggers.Items.Clear();

			ClearDisplayedPoiInfo();
			ClearDisplayedTriggerInfo();

			_levelDataNeedsUpdate = true;
		}

		private void NudCrosshairLength_ValueChanged(object sender, EventArgs e)
		{
			Bitmap reticle = GenerateReticle(Pen, RenderPort.Width, RenderPort.Height, (float)NudCrosshairLength.Value);

			Reticle?.Dispose();
			Reticle = reticle;
		}

		private void NudOverlayCameraPitch_ValueChanged(object sender, EventArgs e)
		{
			Camera.Pitch = (float)NudOverlayCameraPitch.Value;
		}

		private void NudOverlayCameraYaw_ValueChanged(object sender, EventArgs e)
		{
			Camera.Yaw = (float)NudOverlayCameraYaw.Value;
		}

		private void NudOverlayCameraRoll_ValueChanged(object sender, EventArgs e)
		{
			Camera.Roll = (float)NudOverlayCameraRoll.Value;
		}

		private void NudOverlayCameraX_ValueChanged(object sender, EventArgs e)
		{
			Camera.Position = new Vector3(
				(float)NudOverlayCameraX.Value,
				Camera.Position.Y,
				Camera.Position.Z);
		}

		private void NudOverlayCameraY_ValueChanged(object sender, EventArgs e)
		{
			Camera.Position = new Vector3(
				Camera.Position.X,
				(float)NudOverlayCameraY.Value,
				Camera.Position.Z);
		}

		private void NudOverlayCameraZ_ValueChanged(object sender, EventArgs e)
		{
			Camera.Position = new Vector3(
				Camera.Position.X,
				Camera.Position.Y,
				(float)NudOverlayCameraZ.Value);
		}

		private void TbxAngles_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				BtnSetAngles_Click(sender, EventArgs.Empty);
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void TbxPosition_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				BtnSetPosition_Click(sender, EventArgs.Empty);
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void TrkFov_Scroll(object sender, EventArgs e)
		{
			uint height = Mem.ReadU16(Rom.Addresses.MainRam.FramebufferHeight);

			float opposite = height / 2.0f;

			float halfAngle = TrkFov.Value / 2.0f;

			float h = (float)(opposite / Math.Sin(MathUtilities.DegreesToRadians(halfAngle)));

			float adjacentSquared = (float)(Math.Pow(h, 2.0f) - Math.Pow(opposite, 2.0f));

			uint distance = (uint)Math.Sqrt(adjacentSquared);

			Mem.WriteU16(Rom.Addresses.MainRam.ProjectionPlaneDistanceCurrent, distance);

			LblFov.Text = TrkFov.Value.ToString();
		}
	}
}
