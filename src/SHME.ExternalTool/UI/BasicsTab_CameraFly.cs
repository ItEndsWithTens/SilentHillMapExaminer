using BizHawk.Client.Common;
using SHME.ExternalTool;
using SHME.ExternalTool.Extras;
using SHME.ExternalTool.UI;
using System;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		// Cursor visibility in Winforms stacks up, i.e. calling Cursor.Show on
		// a visible cursor isn't a no-op, and would afterward require two calls
		// to Hide before it disappeared.
		private bool _cursorVisible = true;
		private bool CursorVisible
		{
			get => _cursorVisible;
			set
			{
				if (value == _cursorVisible)
				{
					return;
				}

				// Won't work under Mono in Linux:
				// https://github.com/mono/mono/blob/3d11ccdce6df39bb63c783af28ec9756d1b32db1/mcs/class/System.Windows.Forms/System.Windows.Forms.X11Internal/X11Display.cs#L476
				if (value)
				{
					Cursor.Show();
				}
				else
				{
					Cursor.Hide();
				}

				_cursorVisible = value;
			}
		}

		private bool _flyEnabled;
		private bool FlyEnabled
		{
			get => _flyEnabled;
			set
			{
				_flyEnabled = value;

				if (value)
				{
					Button btn = BtnCameraFly;

					btn.Capture = true;

					CursorVisible = false;

					Rectangle bounds = btn.Parent.RectangleToScreen(btn.Bounds);

					_aimCenter.X = btn.Location.X + ((btn.Bounds.Right - btn.Bounds.Left) / 2);
					_aimCenter.Y = btn.Location.Y + ((btn.Bounds.Bottom - btn.Bounds.Top) / 2);

					_aimCenter = btn.Parent.PointToScreen(_aimCenter);

					Cursor.Position = _aimCenter;

					// Doesn't work in Mono yet, as seen here:
					// https://github.com/mono/mono/blob/3d11ccdce6df39bb63c783af28ec9756d1b32db1/mcs/class/System.Windows.Forms/System.Windows.Forms/Cursor.cs#L198
					Cursor.Clip = bounds;

					CbxCameraDetach.Checked = true;
				}
				else
				{
					// Don't reattach the camera, in case users want to leave it
					// where it is to examine something, but do stop moving.
					_forward = _backward = _left = _right = _up = _down = false;

					Cursor.Clip = Rectangle.Empty;

					CursorVisible = true;

					BtnCameraFly.Capture = false;
				}
			}
		}
		private void BtnCameraFly_ClickFirst(object sender, EventArgs e)
		{
			FlyEnabled = true;
		}

		private void CbxCameraDetach_CheckedChanged(object sender, EventArgs e)
		{
			if (CbxCameraDetach.Checked)
			{
				DetachCamera();
			}
			else
			{
				AttachCamera();
			}
		}

		private uint _holdCameraPitch;
		private uint _holdCameraYaw;
		private uint _holdCameraRoll;
		private void DetachCamera()
		{
			Mem.WriteS32(Rom.Addresses.MainRam.CameraState, 0x3);

			_holdCameraPitch = Mem.ReadU32(Rom.Addresses.MainRam.CameraActualPitch);
			_holdCameraYaw = Mem.ReadU32(Rom.Addresses.MainRam.CameraActualYaw);
			_holdCameraRoll = Mem.ReadU32(Rom.Addresses.MainRam.CameraActualRoll);
		}

		private void HoldCamera()
		{
			Mem.WriteS32(Rom.Addresses.MainRam.CameraState, 0x3);

			Mem.WriteU16(Rom.Addresses.MainRam.CameraIdealPitch, _holdCameraPitch);
			Mem.WriteU16(Rom.Addresses.MainRam.CameraIdealYaw, _holdCameraYaw);
			Mem.WriteU16(Rom.Addresses.MainRam.CameraIdealRoll, _holdCameraRoll);

			Mem.WriteU16(Rom.Addresses.MainRam.CameraActualPitch, _holdCameraPitch);
			Mem.WriteU16(Rom.Addresses.MainRam.CameraActualYaw, _holdCameraYaw);
			Mem.WriteU16(Rom.Addresses.MainRam.CameraActualRoll, _holdCameraRoll);

			Mem.WriteU32(Rom.Addresses.MainRam.CameraSpringArmTensionH0, 0);
			Mem.WriteU32(Rom.Addresses.MainRam.CameraSpringArmTensionV0, 0);
			Mem.WriteU32(Rom.Addresses.MainRam.CameraSpringArmTensionH1, 0);
			Mem.WriteU32(Rom.Addresses.MainRam.CameraSpringArmTensionV1, 0);

			float pitchFloat = Core.GameUnitsToDegrees(_holdCameraPitch);
			float yawFloat = Core.GameUnitsToDegrees(_holdCameraYaw);
			float rollFloat = Core.GameUnitsToDegrees(_holdCameraRoll);

			// TODO: Use AngleConverter stuff for this?

			// Remember positive SH Y axis points down, so yaw rotations are reversed.
			Matrix4x4 matrix = Matrix4x4.CreateFromYawPitchRoll(
				MathUtilities.DegreesToRadians(-yawFloat),
				MathUtilities.DegreesToRadians(pitchFloat),
				MathUtilities.DegreesToRadians(rollFloat));

			int xRaw = Mem.ReadS32(Rom.Addresses.MainRam.CameraPositionActualX);
			int yRaw = Mem.ReadS32(Rom.Addresses.MainRam.CameraPositionActualY);
			int zRaw = Mem.ReadS32(Rom.Addresses.MainRam.CameraPositionActualZ);

			// Convert to overlay camera coords.
			float x = Core.QToFloat(xRaw);
			float y = -Core.QToFloat(yRaw);
			float z = -Core.QToFloat(zRaw);

			Vector3 lookAt = Vector3.Transform(new Vector3(0.0f, 0.0f, -1.0f), matrix);

			x += lookAt.X;
			y += lookAt.Y;
			z += lookAt.Z;

			// Back to SH coordinates.
			y = -y;
			z = -z;

			Mem.WriteS32(Rom.Addresses.MainRam.CameraLookAtX, Core.FloatToQ(x));
			Mem.WriteS32(Rom.Addresses.MainRam.CameraLookAtY, Core.FloatToQ(y));
			Mem.WriteS32(Rom.Addresses.MainRam.CameraLookAtZ, Core.FloatToQ(z));
		}

		// These use Silent Hill coordinates, i.e. +X east, +Y down, +Z north.
		private Vector3 _worldUp = new(0.0f, -1.0f, 0.0f);
		private Vector3 _camPos;
		private Vector3 _camLook;
		private Vector3 _camRight;

		private float _speed = 0.125f;
		private bool _forward;
		private bool _backward;
		private bool _left;
		private bool _right;
		private bool _up;
		private bool _down;
		private void MoveCamera()
		{
			_camPos.X = Core.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.CameraPositionActualX));
			_camPos.Y = Core.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.CameraPositionActualY));
			_camPos.Z = Core.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.CameraPositionActualZ));

			_camLook.X = Core.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.CameraLookAtX));
			_camLook.Y = Core.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.CameraLookAtY));
			_camLook.Z = Core.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.CameraLookAtZ));

			Vector3 _diff = _camLook - _camPos;

			if (_forward)
			{
				_camPos += _speed * _diff;
				_camLook += _speed * _diff;
			}
			if (_backward)
			{
				_camPos -= _speed * _diff;
				_camLook -= _speed * _diff;
			}

			_camRight = Vector3.Normalize(Vector3.Cross(_diff, _worldUp));

			if (_left)
			{
				_camPos -= _speed * _camRight;
				_camLook -= _speed * _camRight;
			}
			if (_right)
			{
				_camPos += _speed * _camRight;
				_camLook += _speed * _camRight;
			}

			if (_up)
			{
				_camPos += _speed * _worldUp;
				_camLook += _speed * _worldUp;
			}
			if (_down)
			{
				_camPos -= _speed * _worldUp;
				_camLook -= _speed * _worldUp;
			}

			int qPosX = Core.FloatToQ(_camPos.X);
			int qPosY = Core.FloatToQ(_camPos.Y);
			int qPosZ = Core.FloatToQ(_camPos.Z);

			Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionActualX, qPosX);
			Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionActualY, qPosY);
			Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionActualZ, qPosZ);

			Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionIdealX, qPosX);
			Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionIdealY, qPosY);
			Mem.WriteS32(Rom.Addresses.MainRam.CameraPositionIdealZ, qPosZ);

			int qLookX = Core.FloatToQ(_camLook.X);
			int qLookY = Core.FloatToQ(_camLook.Y);
			int qLookZ = Core.FloatToQ(_camLook.Z);

			Mem.WriteS32(Rom.Addresses.MainRam.CameraLookAtX, qLookX);
			Mem.WriteS32(Rom.Addresses.MainRam.CameraLookAtY, qLookY);
			Mem.WriteS32(Rom.Addresses.MainRam.CameraLookAtZ, qLookZ);
		}

		// TODO: Make aim and move speeds the same whether rendering to the
		// framebuffer or not; look up what I believe is called the "delta time"
		// approach real games use for consistent input with varying framerate.
		private float _sensitivity = 0.25f;
		private Point _aimCenter;
		private void AimCamera(Button btn)
		{
			_aimCenter.X = btn.Location.X + ((btn.Bounds.Right - btn.Bounds.Left) / 2);
			_aimCenter.Y = btn.Location.Y + ((btn.Bounds.Bottom - btn.Bounds.Top) / 2);
			_aimCenter = btn.Parent.PointToScreen(_aimCenter);

			// Ideally one would use the Input API, but the values it returns
			// are in an unrecognizable coordinate space. This'll do for now.
			(Point screen, _, _, _, _, _, _) = InputManager.GetMainFormMouseInfo();

			float deltaX = (screen.X - _aimCenter.X) * _sensitivity;
			float deltaY = (screen.Y - _aimCenter.Y) * _sensitivity;

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

			Cursor.Position = _aimCenter;
		}

		private void AttachCamera()
		{
			FlyEnabled = false;

			Mem.WriteS32(Rom.Addresses.MainRam.CameraState, 0x0);
		}

		private void BtnCameraFly_KeyDown(object sender, KeyEventArgs e)
		{
			if (!FlyEnabled)
			{
				return;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				FlyEnabled = false;
				return;
			}

			ShmeCommand? command = Settings.Local.FlyBinds
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
					_left = true;
					break;
				case ShmeCommand.Right:
					_right = true;
					break;
				case ShmeCommand.Up:
					_up = true;
					break;
				case ShmeCommand.Down:
					_down = true;
					break;
				case ShmeCommand.None:
				case null:
				default:
					break;
			}
		}
		private void BtnCameraFly_KeyUp(object sender, KeyEventArgs e)
		{
			ShmeCommand? command = Settings.Local.FlyBinds
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
					_left = false;
					break;
				case ShmeCommand.Right:
					_right = false;
					break;
				case ShmeCommand.Up:
					_up = false;
					break;
				case ShmeCommand.Down:
					_down = false;
					break;
				case ShmeCommand.None:
				case null:
				default:
					break;
			}
		}

		private void BtnCameraFly_LostFocus(object sender, EventArgs e)
		{
			FlyEnabled = false;
		}

		private void BtnCameraFly_MouseDown(object sender, MouseEventArgs e)
		{
			ShmeCommand? command = Settings.Local.FlyBinds
				.Where((bind) => bind.MouseBind == e.Button)
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
					_left = true;
					break;
				case ShmeCommand.Right:
					_right = true;
					break;
				case ShmeCommand.Up:
					_up = true;
					break;
				case ShmeCommand.Down:
					_down = true;
					break;
				case ShmeCommand.None:
				case null:
				default:
					break;
			}
		}

		private void BtnCameraFly_MouseUp(object sender, MouseEventArgs e)
		{
			ShmeCommand? command = Settings.Local.FlyBinds
				.Where((bind) => bind.MouseBind == e.Button)
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
					_left = false;
					break;
				case ShmeCommand.Right:
					_right = false;
					break;
				case ShmeCommand.Up:
					_up = false;
					break;
				case ShmeCommand.Down:
					_down = false;
					break;
				case ShmeCommand.None:
				case null:
				default:
					break;
			}
		}

		// TODO: Test this in Linux! I think I've had issues with keeping
		// references to Forms around instead of making a new one every
		// time I access it? Need to double check.
		private InputConfigForm _inputConfigForm;
		private void BtnInputConfig_Click(object sender, EventArgs e)
		{
			_inputConfigForm?.Dispose();
			_inputConfigForm = new InputConfigForm(Settings)
			{
				Text = $"{ToolName} input binds"
			};

			// I'll need these stop/start sound things if I have to make
			// this form modal, unfortunately, to avoid the audio hitching.
			// Come to think of it I should add calls to this for the various
			// color picker dialogs.
			//DialogController.StopSound();
			_inputConfigForm.Show(Owner);
			//DialogController.StartSound();
		}

		private void NudCameraFlySensitivity_ValueChanged(object sender, EventArgs e)
		{
			_sensitivity = (float)NudCameraFlySensitivity.Value;
		}

		private void NudCameraFlySpeed_ValueChanged(object sender, EventArgs e)
		{
			_speed = (float)NudCameraFlySpeed.Value;
		}
	}
}
