using SHME.ExternalTool;
using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Windows.Forms;
using static SHME.ExternalTool.Core;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
#pragma warning disable IDE0055
		// IDE0055 covers all code style formatting rules, including the removal
		// of whitespace some developers use to line up values when assigning
		// many variables at once. That's usually desirable, but in cases like
		// this, i.e. bitfields/flags, the alignment helps make it more visually
		// obvious which bits correspond to which enum members.
		[Flags]
		private enum ButtonFlags : ushort
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

		private void ReportAngles()
		{
			(Vector3 harry, Vector3 camera) = GetAngles();

			LblHarryPitch.Text = harry.X.ToString("N2");
			LblHarryYaw.Text = harry.Y.ToString("N2");
			LblHarryRoll.Text = harry.Z.ToString("N2");

			LblCameraPitch.Text = camera.X.ToString("N2");
			LblCameraYaw.Text = camera.Y.ToString("N2");
			LblCameraRoll.Text = camera.Z.ToString("N2");
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
			LblOverlayCamPositionX.Text = $"{Camera.Position.X:N2}";
			LblOverlayCamPositionY.Text = $"{Camera.Position.Y:N2}";
			LblOverlayCamPositionZ.Text = $"{Camera.Position.Z:N2}";

			LblOverlayCamPitch.Text = $"{Camera.Pitch:N2}";
			LblOverlayCamYaw.Text = $"{Camera.Yaw:N2}";
			LblOverlayCamRoll.Text = $"{Camera.Roll:N2}";
		}

		private string _lastHarrySpawnPointHash = "";
		private PointOfInterest? _lastHarrySpawnPoint;
		private void ReportPosition()
		{
			(Vector3 harry, Vector3 camera) = GetPosition();

			LblHarryPositionX.Text = harry.X.ToString("N2");
			LblHarryPositionY.Text = harry.Y.ToString("N2");
			LblHarryPositionZ.Text = harry.Z.ToString("N2");

			LblCameraPositionX.Text = camera.X.ToString("N2");
			LblCameraPositionY.Text = camera.Y.ToString("N2");
			LblCameraPositionZ.Text = camera.Z.ToString("N2");

			float drawDistance = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.DrawDistance), 8);

			LblCameraDrawDistance.Text = $"{drawDistance:N3}m";

			long address = Rom.Addresses.MainRam.LastHarrySpawnPoint;
			string hash = Mem.HashRegion(address, 12);
			if (hash != _lastHarrySpawnPointHash)
			{
				_lastHarrySpawnPoint = new PointOfInterest(address, Mem.ReadByteRange(address, 12));
				_lastHarrySpawnPointHash = hash;

				LblSpawnX.Text = $"{_lastHarrySpawnPoint.X:0.##}";
				LblSpawnGeometry.Text = $"0x{_lastHarrySpawnPoint.Geometry:X2}";
				LblSpawnZ.Text = $"{_lastHarrySpawnPoint.Z:0.##}";
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
			bool success;

			success = Single.TryParse(TbxPositionX.Text, out float x);
			if (!success)
			{
				x = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionX));
			}

			success = Single.TryParse(TbxPositionY.Text, out float y);
			if (!success)
			{
				y = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionY));
			}

			success = Single.TryParse(TbxPositionZ.Text, out float z);
			if (!success)
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
			bool success;

			(Vector3 harry, _) = GetAngles();

			success = Single.TryParse(TbxHarryPitch.Text, out float pitch);
			if (!success)
			{
				pitch = harry.X;
			}

			success = Single.TryParse(TbxHarryYaw.Text, out float yaw);
			if (!success)
			{
				yaw = harry.Y;
			}

			success = Single.TryParse(TbxHarryRoll.Text, out float roll);
			if (!success)
			{
				roll = harry.Z;
			}

			SetHarryAngles(pitch, yaw, roll);
		}

		private void CbxEnableTriggerDisplay_CheckedChanged(object sender, EventArgs e)
		{
			if (!CbxEnableOverlay.Checked)
			{
				ClearOverlay();
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
