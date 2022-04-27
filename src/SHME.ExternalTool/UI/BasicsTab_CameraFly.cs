﻿using SHME.ExternalTool;
using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);

			BtnCameraFly_ClickSecond(this, EventArgs.Empty);
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
					Cursor.Hide();

					Button btn = BtnCameraFly;

					Rectangle bounds = btn.Parent.RectangleToScreen(btn.Bounds);

					center.X = btn.Location.X + ((btn.Bounds.Right - btn.Bounds.Left) / 2);
					center.Y = btn.Location.Y + ((btn.Bounds.Bottom - btn.Bounds.Top) / 2);

					center = btn.Parent.PointToScreen(center);

					Cursor.Position = center;

					Cursor.Clip = bounds;

					CbxCameraDetach.Checked = true;
				}
				else
				{
					// Don't reattach the camera, in case users want to leave it
					// where it is to examine something, but do stop moving.
					_forward = _backward = _left = _right = _up = _down = false;

					Cursor.Clip = new Rectangle();

					Cursor.Show();
				}
			}
		}
		private void BtnCameraFly_ClickFirst(object sender, EventArgs e)
		{
			BtnCameraFly.Click -= BtnCameraFly_ClickFirst;
			BtnCameraFly.Click += BtnCameraFly_ClickSecond;

			FlyEnabled = true;
		}
		private void BtnCameraFly_ClickSecond(object sender, EventArgs e)
		{
			FlyEnabled = false;

			BtnCameraFly.Click -= BtnCameraFly_ClickSecond;
			BtnCameraFly.Click += BtnCameraFly_ClickFirst;
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

			x += (lookAt.X * 1.0f);
			y += (lookAt.Y * 1.0f);
			z += (lookAt.Z * 1.0f);

			// Back to SH coordinates.
			y = -y;
			z = -z;

			Mem.WriteS32(Rom.Addresses.MainRam.CameraLookAtX, Core.FloatToQ(x));
			Mem.WriteS32(Rom.Addresses.MainRam.CameraLookAtY, Core.FloatToQ(y));
			Mem.WriteS32(Rom.Addresses.MainRam.CameraLookAtZ, Core.FloatToQ(z));
		}

		// These use Silent Hill coordinates, i.e. +X east, +Y down, +Z north.
		private Vector3 _worldUp = new Vector3(0.0f, -1.0f, 0.0f);
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
			else if (_backward)
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
			else if (_right)
			{
				_camPos += _speed * _camRight;
				_camLook += _speed * _camRight;
			}

			if (_up)
			{
				_camPos += _speed * _worldUp;
				_camLook += _speed * _worldUp;
			}
			else if (_down)
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

			switch (e.KeyCode)
			{
				case Keys.W:
					_forward = true;
					break;
				case Keys.S:
					_backward = true;
					break;
				case Keys.A:
					_left = true;
					break;
				case Keys.D:
					_right = true;
					break;
				case Keys.E:
					_up = true;
					break;
				case Keys.Q:
					_down = true;
					break;
				case Keys.Escape:
					BtnCameraFly_ClickSecond(this, EventArgs.Empty);
					break;
				default:
					break;
			}
		}
		private void BtnCameraFly_KeyUp(object sender, KeyEventArgs e)
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
					_left = false;
					break;
				case Keys.D:
					_right = false;
					break;
				case Keys.E:
					_up = false;
					break;
				case Keys.Q:
					_down = false;
					break;
				default:
					break;
			}
		}

		private float _sensitivity = 0.25f;
		Point center;
		private void BtnCameraFly_MouseMove(object sender, MouseEventArgs e)
		{
			if (!FlyEnabled)
			{
				return;
			}

			Button btn = BtnCameraFly;

			center.X = btn.Location.X + ((btn.Bounds.Right - btn.Bounds.Left) / 2);
			center.Y = btn.Location.Y + ((btn.Bounds.Bottom - btn.Bounds.Top) / 2);

			center = btn.Parent.PointToScreen(center);

			Point screen = btn.PointToScreen(e.Location);

			float deltaX = screen.X - center.X;
			float deltaY = screen.Y - center.Y;

			deltaX *= _sensitivity;
			deltaY *= _sensitivity;

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

			float pitchCircle = MathUtilities.ModAngleToCircleUnsigned(pitchDegrees);
			float yawCircle = MathUtilities.ModAngleToCircleUnsigned(yawDegrees);

			_holdCameraPitch = Core.DegreesToGameUnits(pitchCircle);
			_holdCameraYaw = Core.DegreesToGameUnits(yawCircle);
			_holdCameraRoll = 0;

			Cursor.Position = center;
		}

		private void TbxCameraFlySensitivity_TextChanged(object sender, EventArgs e)
		{
			bool success = Single.TryParse(TbxCameraFlySensitivity.Text, out float temp);

			if (success)
			{
				_sensitivity = temp;
			}
		}

		private void TbxCameraFlySpeed_TextChanged(object sender, EventArgs e)
		{
			bool success = Single.TryParse(TbxCameraFlySpeed.Text, out float temp);

			if (success)
			{
				_speed = temp;
			}
		}
	}
}
