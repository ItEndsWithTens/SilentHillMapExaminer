using SHME.ExternalTool;
using SHME.ExternalTool.Extras;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private Ilm? _harryModel;

		private bool _firstPersonEnabled;
		private bool FpsEnabled
		{
			get => _firstPersonEnabled;
			set
			{
				if (_firstPersonEnabled == value)
				{
					return;
				}

				_firstPersonEnabled = value;

				Button btn = BtnCameraFps;

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

		private void BtnCameraFps_ClickFirst(object sender, EventArgs e)
		{
			FpsEnabled = true;
		}

		// In-game actions, named as per the game's "Controller Config" screen.
		private bool _action;
		private bool _aim;
		private bool _light;
		private bool _run;
		private bool _view;
		private bool _stepL;
		private bool _stepR;
		private bool _map;
		private void BtnCameraFps_KeyDown(object sender, KeyEventArgs e)
		{
			if (!FpsEnabled)
			{
				return;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				FpsEnabled = false;
				return;
			}

			ShmeCommand? command = Settings.Local.FpsBinds
				.Where((bind) => bind.KeyBind == e.KeyCode)
				.FirstOrDefault()
				?.Command;

			switch (command)
			{
				case ShmeCommand.Forward:
					_forward = true;
					break;
				case ShmeCommand.Backward:
					_backward = true;
					break;
				case ShmeCommand.Left:
					_stepL = true;
					break;
				case ShmeCommand.Right:
					_stepR = true;
					break;
				case ShmeCommand.Action:
					_action = true;
					break;
				case ShmeCommand.Aim:
					_aim = true;
					break;
				case ShmeCommand.Light:
					_light = true;
					break;
				case ShmeCommand.Run:
					_run = !CbxAlwaysRun.Checked;
					break;
				case ShmeCommand.Map:
					_map = true;
					break;
				case ShmeCommand.None:
				case null:
				default:
					break;
			}
		}
		private void BtnCameraFps_KeyUp(object sender, KeyEventArgs e)
		{
			ShmeCommand? command = Settings.Local.FpsBinds
				.Where((bind) => bind.KeyBind == e.KeyCode)
				.FirstOrDefault()
				?.Command;

			switch (command)
			{
				case ShmeCommand.Forward:
					_forward = false;
					break;
				case ShmeCommand.Backward:
					_backward = false;
					break;
				case ShmeCommand.Left:
					_stepL = false;
					break;
				case ShmeCommand.Right:
					_stepR = false;
					break;
				case ShmeCommand.Action:
					_action = false;
					break;
				case ShmeCommand.Aim:
					_aim = false;
					break;
				case ShmeCommand.Light:
					_light = false;
					break;
				case ShmeCommand.Run:
					_run = CbxAlwaysRun.Checked;
					break;
				case ShmeCommand.Map:
					_map = false;
					break;
				case ShmeCommand.None:
				case null:
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
		/// Whether to ignore the next attempt to forcibly aim the mouselook
		/// camera. Useful on initial tool load, or when loading a save state.
		/// </summary>
		private bool _suppressForcedCameraYaw = true;

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

			var dict = Settings.Local.FpsBinds.ToDictionary((item) => item.Command);

			Joy.Set(dict[ShmeCommand.Forward].ButtonName, _forward);
			Joy.Set(dict[ShmeCommand.Backward].ButtonName, _backward);
			Joy.Set(dict[ShmeCommand.Action].ButtonName, _action);
			Joy.Set(dict[ShmeCommand.Aim].ButtonName, _aim);
			Joy.Set(dict[ShmeCommand.Light].ButtonName, _light);
			Joy.Set(dict[ShmeCommand.Run].ButtonName, _run);
			Joy.Set(dict[ShmeCommand.View].ButtonName, _view);
			Joy.Set(dict[ShmeCommand.Map].ButtonName, _map);

			// Sending both sidestep inputs at the same time attempts to do
			// an about-face, but since the camera's under user control, the
			// sidestep controls lock up. Just silently ignore such input.
			if (_stepL && _stepR)
			{
				Joy.Set(dict[ShmeCommand.Left].ButtonName, false);
				Joy.Set(dict[ShmeCommand.Right].ButtonName, false);
			}
			else
			{
				Joy.Set(dict[ShmeCommand.Left].ButtonName, _stepL);
				Joy.Set(dict[ShmeCommand.Right].ButtonName, _stepR);
			}
		}

		private void BtnCameraFps_LostFocus(object sender, EventArgs e)
		{
			FpsEnabled = false;
		}

		private void BtnCameraFps_MouseDown(object sender, MouseEventArgs e)
		{
			ShmeCommand? command = Settings.Local.FpsBinds
				.Where((bind) => bind.MouseBind == e.Button)
				.FirstOrDefault()
				?.Command;

			switch (command)
			{
				case ShmeCommand.Action:
					_action = true;
					break;
				case ShmeCommand.Aim:
					_aim = true;
					break;
				case ShmeCommand.None:
				case null:
				default:
					break;
			}
		}
		private void BtnCameraFps_MouseUp(object sender, MouseEventArgs e)
		{
			ShmeCommand? command = Settings.Local.FpsBinds
				.Where((bind) => bind.MouseBind == e.Button)
				.FirstOrDefault()
				?.Command;

			switch (command)
			{
				case ShmeCommand.Action:
					_action = false;
					break;
				case ShmeCommand.Aim:
					_aim = false;
					break;
				case ShmeCommand.None:
				case null:
				default:
					break;
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
