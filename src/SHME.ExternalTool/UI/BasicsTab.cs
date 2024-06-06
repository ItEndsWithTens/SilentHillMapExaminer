using BizHawk.Client.Common;
using SHME.ExternalTool;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
	public enum PsxButtons
	{
		None =     0x0000,
		Select =   0x0001,
		L3 =       0x0002,
		R3 =       0x0004,
		Start =    0x0008,
		Up =       0x0010,
		Right =    0x0020,
		Down =     0x0040,
		Left =     0x0080,
		L2 =       0x0100,
		R2 =       0x0200,
		L1 =       0x0400,
		R1 =       0x0800,
		Triangle = 0x1000,
		Circle =   0x2000,
		X =        0x4000,
		Square =   0x8000
	}
#pragma warning restore IDE0055

	public partial class CustomMainForm
	{
		private Renderable _gameCameraLookAt;

		private void InitializeBasicsTab()
		{
			TrkFov.Value = (int)Camera.Fov;
			LblFov.Text = TrkFov.Value.ToString(CultureInfo.CurrentCulture);
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
			var raw = (PsxButtons)Mem.ReadU16(Rom.Addresses.MainRam.ButtonFlags);

			foreach (PsxButtons button in Enum.GetValues(typeof(PsxButtons)))
			{
				string buttonName = $"LblButton{Enum.GetName(typeof(PsxButtons), button)}";

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

		private string _lastHarrySpawnPointHash = String.Empty;
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

				// To prevent the camera from being forcibly reoriented upon
				// both SHME startup and save state loading, this boolean not
				// only defaults to true but is set to true in Emu_StateLoaded.
				if (_suppressForcedCameraYaw)
				{
					_forcedCameraYaw = null;
					_suppressForcedCameraYaw = false;
				}
				else
				{
					(_forcedCameraYaw, _, _, _) = PointOfInterest.DecodeGeometry(TriggerStyle.ButtonYaw, _lastHarrySpawnPoint);
				}

				_lastHarrySpawnPointHash = hash;

				string sep = c.NumberFormat.NumberGroupSeparator;

				float x = _lastHarrySpawnPoint.X;
				float z = _lastHarrySpawnPoint.Z;
				LblSpawnXZ.Text = $"<{x.ToString("0.##", c)}{sep} {z.ToString("0.##", c)}>";
				LblSpawnGeometry.Text = $"0x{_lastHarrySpawnPoint.Geometry.ToString("X2", c)}";
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

		private void CbxAntialiasing_CheckedChanged(object sender, EventArgs e)
		{
			if (CbxAntialiasing.Checked)
			{
				_smoothingMode = SmoothingMode.AntiAlias;
			}
			else
			{
				_smoothingMode = SmoothingMode.Default;
			}
		}

		private void CbxEnableOverlay_CheckedChanged(object sender, EventArgs e)
		{
			if (!CbxEnableOverlay.Checked)
			{
				ClearOverlay();
			}
			else
			{
				InitializeOverlay();
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
			if (CbxBackfaceCulling.Checked)
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
			if (CbxFarClipping.Checked)
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

		private void CbxReadLevelDataOnStageLoad_CheckedChanged(object sender, EventArgs e)
		{
			BtnReadPois.Enabled = !CbxReadLevelDataOnStageLoad.Checked;
			BtnReadTriggers.Enabled = !CbxReadLevelDataOnStageLoad.Checked;
			BtnCameraPathReadArray.Enabled = !CbxReadLevelDataOnStageLoad.Checked;

			_levelDataNeedsUpdate = true;
		}

		private int _renderMode;
		private void CmbRenderMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			_renderMode = CmbRenderMode.SelectedIndex;
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
			_suppressForcedCameraYaw = true;
			_initializeOverlayCountdown = 10;
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
