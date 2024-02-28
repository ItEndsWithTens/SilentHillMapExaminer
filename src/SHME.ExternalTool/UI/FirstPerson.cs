using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private Ilm _harryModel;

		private bool _firstPersonEnabled;
		private bool FirstPersonEnabled
		{
			get => _firstPersonEnabled;
			set
			{
				if (_firstPersonEnabled == value)
				{
					return;
				}

				_firstPersonEnabled = value;

				Button btn = BtnFirstPerson;

				if (value)
				{
					btn.Capture = true;

					CursorVisible = false;

					Rectangle bounds = btn.Parent.RectangleToScreen(btn.Bounds);

					_firstPersonCenter.X = btn.Location.X + ((btn.Bounds.Right - btn.Bounds.Left) / 2);
					_firstPersonCenter.Y = btn.Location.Y + ((btn.Bounds.Bottom - btn.Bounds.Top) / 2);

					_firstPersonCenter = btn.Parent.PointToScreen(_firstPersonCenter);

					Cursor.Position = _firstPersonCenter;

					Cursor.Clip = bounds;

					int x = Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionX);
					int y = Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionY);
					int z = Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionZ);

					y += Core.FloatToQ((float)NudEyeHeight.Value);

					Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionActualX, x);
					Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionActualY, y);
					Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionActualZ, z);

					Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionIdealX, x);
					Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionIdealY, y);
					Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionIdealZ, z);

					_holdCameraPitch = 0;
					_holdCameraYaw = Mem.ReadU16(Rom.Addresses.MainRam.HarryYaw);
					_holdCameraRoll = 0;
					HoldCamera();

					if (CbxHideHarry.Checked)
					{
						IEnumerable<Submesh> submeshes = _harryModel.Submeshes.Where((m) =>
							!m.Name.EndsWith("FOOT", StringComparison.Ordinal));

						if (!CbxShowFeet.Checked)
						{
							submeshes = submeshes.Concat(_harryModel.Submeshes.Where((m) =>
							m.Name.EndsWith("FOOT", StringComparison.Ordinal)));
						}

						foreach (Submesh s in submeshes)
						{
							Mem.WriteByte((int)((s.BaseAddress + 8) - Rom.Addresses.MainRam.BaseAddress), 0);
						}
					}

					CbxCameraDetach.Checked = true;

					_run = CbxAlwaysRun.Checked;
				}
				else
				{
					_forward = _backward = _stepL = _stepR = _run = _view = _action = _light = false;

					CbxCameraDetach.Checked = false;

					foreach (Submesh s in _harryModel.Submeshes)
					{
						Mem.WriteByte((int)((s.BaseAddress + 8) - Rom.Addresses.MainRam.BaseAddress), 1);
					}

					Cursor.Clip = Rectangle.Empty;

					CursorVisible = true;

					btn.Capture = false;
				}
			}
		}

		private void BtnFirstPerson_ClickFirst(object sender, EventArgs e)
		{
			FirstPersonEnabled = true;
		}

		// In-game actions, named as per the game's "Controller Config" screen.
		private bool _action;
		private bool _aim;
		private bool _light;
		private bool _run;
		private bool _view;
		private bool _stepL;
		private bool _stepR;
		private void BtnFirstPerson_KeyDown(object sender, KeyEventArgs e)
		{
			if (!FirstPersonEnabled)
			{
				return;
			}

			switch (e.KeyCode)
			{
				case Keys.W:
					_forward = true;
					break;
				case Keys.S:
					_backward = true;
					break;
				case Keys.A:
					_stepL = true;
					break;
				case Keys.D:
					_stepR = true;
					break;
				case Keys.E:
					_action = true;
					break;
				case Keys.F:
					_light = true;
					break;
				case Keys.ShiftKey:
					_run = !CbxAlwaysRun.Checked;
					break;
				case Keys.Escape:
					FirstPersonEnabled = false;
					break;
				default:
					break;
			}
		}
		private void BtnFirstPerson_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.W:
					_forward = false;
					break;
				case Keys.S:
					_backward = false;
					break;
				case Keys.A:
					_stepL = false;
					break;
				case Keys.D:
					_stepR = false;
					break;
				case Keys.E:
					_action = false;
					break;
				case Keys.F:
					_light = false;
					break;
				case Keys.ShiftKey:
					_run = CbxAlwaysRun.Checked;
					break;
				default:
					break;
			}
		}

		private Point _firstPersonCenter;

		/// <summary>
		/// The camera yaw to apply when forcibly aiming the mouselook camera,
		/// for example when going through a door in first person.
		/// </summary>
		private float? _forcedCameraYaw;
		/// <summary>
		/// 
		/// </summary>
		private bool _suppressForcedCameraYaw = true;
		private void AimCameraFirstPerson()
		{
			Button btn = BtnFirstPerson;

			_firstPersonCenter.X = btn.Location.X + ((btn.Bounds.Right - btn.Bounds.Left) / 2);
			_firstPersonCenter.Y = btn.Location.Y + ((btn.Bounds.Bottom - btn.Bounds.Top) / 2);
			_firstPersonCenter = btn.Parent.PointToScreen(_firstPersonCenter);

			(Point screen, _, _, _, _, _, _) = InputManager.GetMainFormMouseInfo();

			float deltaX = (screen.X - _firstPersonCenter.X) * _sensitivity;
			float deltaY = (screen.Y - _firstPersonCenter.Y) * _sensitivity;

			uint pitch = Mem.ReadU16(Rom.Addresses.MainRam.CameraIdealPitch);
			uint yaw = Mem.ReadU16(Rom.Addresses.MainRam.CameraIdealYaw);

			float pitchDegrees = Core.GameUnitsToDegrees(pitch);
			float yawDegrees = Core.GameUnitsToDegrees(yaw);

			if (CbxCameraFlyInvert.Checked)
			{
				pitchDegrees += deltaY;
			}
			else
			{
				pitchDegrees -= deltaY;
			}
			yawDegrees += deltaX;

			_holdCameraPitch = Core.DegreesToGameUnits(pitchDegrees);
			_holdCameraYaw = Core.DegreesToGameUnits(yawDegrees);
			_holdCameraRoll = 0;

			Mem.WriteU16(Rom.Addresses.MainRam.HarryYaw, _holdCameraYaw);

			Cursor.Position = _firstPersonCenter;
		}

		private void MoveCameraFirstPerson()
		{
			int x = Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionX);
			int y = Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionY);
			int z = Mem.ReadS32(Rom.Addresses.MainRam.HarryPositionZ);

			y += Core.FloatToQ((float)NudEyeHeight.Value);

			Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionActualX, x);
			Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionActualY, y);
			Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionActualZ, z);

			Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionIdealX, x);
			Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionIdealY, y);
			Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionIdealZ, z);

			// For future copy pasting: P1 △

			if (_forward)
				Joy.Set("P1 D-Pad Up", true);
			else
				Joy.Set("P1 D-Pad Up", false);

			if (_backward)
				Joy.Set("P1 D-Pad Down", true);
			else
				Joy.Set("P1 D-Pad Down", false);

			if (_stepL)
				Joy.Set("P1 L1", true);
			else
				Joy.Set("P1 L1", false);

			if (_stepR)
				Joy.Set("P1 R1", true);
			else
				Joy.Set("P1 R1", false);

			if (_run)
				Joy.Set("P1 □", true);
			else
				Joy.Set("P1 □", false);

			if (_action)
				Joy.Set(Octoshock != null ? "P1 Cross" : "P1 X", true);
			else
				Joy.Set(Octoshock != null ? "P1 Cross" : "P1 X", false);

			if (_aim)
				Joy.Set("P1 R2", true);
			else
				Joy.Set("P1 R2", false);

			if (_light)
				Joy.Set("P1 ○", true);
			else
				Joy.Set("P1 ○", false);
		}

		private void BtnFirstPerson_LostFocus(object sender, EventArgs e)
		{
			FirstPersonEnabled = false;
		}

		private void BtnFirstPerson_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				_action = true;
			}

			if (e.Button == MouseButtons.Right)
			{
				_aim = true;
			}
		}
		private void BtnFirstPerson_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				_action = false;
			}

			if (e.Button == MouseButtons.Right)
			{
				_aim = false;
			}
		}

		private void CbxAlwaysRun_CheckedChanged(object sender, EventArgs e)
		{
			_run = CbxAlwaysRun.Checked;
		}

		private void CbxHideHarry_CheckedChanged(object sender, EventArgs e)
		{
			CbxShowFeet.Enabled = CbxHideHarry.Checked;

			if (!CbxHideHarry.Checked)
			{
				CbxShowFeet.Checked = true;
			}
		}
	}
}
