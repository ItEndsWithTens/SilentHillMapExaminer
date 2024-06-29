using SHME.ExternalTool;
using SHME.ExternalTool.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk;

partial class CustomMainForm
{
	private void CommitCameraPathChanges(CameraPath c)
	{
		_userChange = true;
		Mem.WriteByteRange(c.Address, c.ToBytes().ToArray());

		LbxCameraPaths.BeginUpdate();

		int idxBefore = LbxCameraPaths.SelectedIndex;

		BtnCameraPathReadArray_Click(this, EventArgs.Empty);

		LbxCameraPaths.SelectedIndex = idxBefore;

		LbxCameraPaths.EndUpdate();
	}

	private void SelectedCameraPath_ResetProperty(CameraPath c, string? prop = null)
	{
		if (Guts.Stage is null)
		{
			return;
		}

		if (String.IsNullOrEmpty(prop))
		{
			prop = CmsSelectedCameraPath.SourceControl.Tag as string;
		}

		ReadOnlySpan<byte> stage = Guts.Stage.ToBytes();

		MainRamAddresses ram = Rom.Addresses.MainRam;
		int ofs = (int)(c.Address - ram.StageHeader);
		CameraPath reset = new(c.Address, stage.Slice(ofs, c.SizeInBytes));

		if (String.Equals(prop, "all", StringComparison.OrdinalIgnoreCase))
		{
			CommitCameraPathChanges(reset);
			return;
		}

		switch (prop)
		{
			case nameof(CameraPath.Disabled):
				c.Disabled = reset.Disabled;
				break;
			case nameof(CameraPath.VolumeMin):
				c.VolumeMin = reset.VolumeMin;
				break;
			case nameof(CameraPath.VolumeMax):
				c.VolumeMax = reset.VolumeMax;
				break;
			case nameof(CameraPath.AreaMinX):
				c.AreaMinX = reset.AreaMinX;
				break;
			case nameof(CameraPath.AreaMinZ):
				c.AreaMinZ = reset.AreaMinZ;
				break;
			case nameof(CameraPath.AreaMaxX):
				c.AreaMaxX = reset.AreaMaxX;
				break;
			case nameof(CameraPath.AreaMaxZ):
				c.AreaMaxZ = reset.AreaMaxZ;
				break;
			case nameof(CameraPath.Thing4):
				c.Thing4 = reset.Thing4;
				break;
			case nameof(CameraPath.Thing5):
				c.Thing5 = reset.Thing5;
				break;
			case nameof(CameraPath.Thing6):
				c.Thing6 = reset.Thing6;
				break;
			case nameof(CameraPath.Pitch):
				c.Pitch = reset.Pitch;
				break;
			case nameof(CameraPath.Yaw):
				c.Yaw = reset.Yaw;
				break;
			default:
				break;
		}

		CommitCameraPathChanges(c);
	}

	private void SelectedCameraPath_ValidateInput(Control? c)
	{
		if (LbxCameraPaths.SelectedItem is not CameraPath path)
		{
			return;
		}

		const float Tolerance = 0.0001f;
		NumberStyles hex = NumberStyles.HexNumber;
		CultureInfo culture = CultureInfo.CurrentCulture;

		switch (c?.Tag)
		{
			case nameof(CameraPath.VolumeMin) + nameof(CameraPath.VolumeMin.X):
				if (Single.TryParse(c.Text, out float x))
				{
					if (path.VolumeMin.X.ApproximatelyEquivalent(x, Tolerance))
						return;
					Vector3 min = path.VolumeMin;
					min.X = x;
					path.VolumeMin = min;
				}
				break;
			case nameof(CameraPath.VolumeMin) + nameof(CameraPath.VolumeMin.Y):
				if (Single.TryParse(c.Text, out float y))
				{
					if (path.VolumeMin.Y.ApproximatelyEquivalent(y, Tolerance))
						return;
					Vector3 min = path.VolumeMin;
					min.Y = y;
					path.VolumeMin = min;
				}
				break;
			case nameof(CameraPath.VolumeMin) + nameof(CameraPath.VolumeMin.Z):
				if (Single.TryParse(c.Text, out float z))
				{
					if (path.VolumeMin.Z.ApproximatelyEquivalent(z, Tolerance))
						return;
					Vector3 min = path.VolumeMin;
					min.Z = z;
					path.VolumeMin = min;
				}
				break;
			case nameof(CameraPath.VolumeMax) + nameof(CameraPath.VolumeMax.X):
				if (Single.TryParse(c.Text, out x))
				{
					if (path.VolumeMax.X.ApproximatelyEquivalent(x, Tolerance))
						return;
					Vector3 max = path.VolumeMax;
					max.X = x;
					path.VolumeMax = max;
				}
				break;
			case nameof(CameraPath.VolumeMax) + nameof(CameraPath.VolumeMax.Y):
				if (Single.TryParse(c.Text, out y))
				{
					if (path.VolumeMax.Y.ApproximatelyEquivalent(y, Tolerance))
						return;
					Vector3 max = path.VolumeMax;
					max.Y = y;
					path.VolumeMax = max;
				}
				break;
			case nameof(CameraPath.VolumeMax) + nameof(CameraPath.VolumeMax.Z):
				if (Single.TryParse(c.Text, out z))
				{
					if (path.VolumeMax.Z.ApproximatelyEquivalent(z, Tolerance))
						return;
					Vector3 max = path.VolumeMax;
					max.Z = z;
					path.VolumeMax = max;
				}
				break;
			case nameof(CameraPath.AreaMinX):
				if (Single.TryParse(c.Text, out x))
				{
					if (path.AreaMinX.ApproximatelyEquivalent(x, Tolerance))
						return;
					path.AreaMinX = x;
				}
				break;
			case nameof(CameraPath.AreaMinZ):
				if (Single.TryParse(c.Text, out z))
				{
					if (path.AreaMinZ.ApproximatelyEquivalent(z, Tolerance))
						return;
					path.AreaMinZ = z;
				}
				break;
			case nameof(CameraPath.AreaMaxX):
				if (Single.TryParse(c.Text, out x))
				{
					if (path.AreaMaxX.ApproximatelyEquivalent(x, Tolerance))
						return;
					path.AreaMaxX = x;
				}
				break;
			case nameof(CameraPath.AreaMaxZ):
				if (Single.TryParse(c.Text, out z))
				{
					if (path.AreaMaxZ.ApproximatelyEquivalent(z, Tolerance))
						return;
					path.AreaMaxZ = z;
				}
				break;
			case nameof(CameraPath.Thing4):
				bool good = Byte.TryParse(c.Text, hex, culture, out byte b);
				if (!good || path.Thing4 == b)
					return;
				path.Thing4 = b;
				break;
			case nameof(CameraPath.Disabled):
				bool check = CbxSelectedCameraPathDisabled.Checked;
				if (path.Disabled == check)
					return;
				path.Disabled = check;
				break;
			case nameof(CameraPath.Thing5):
				good = Byte.TryParse(c.Text, hex, culture, out b);
				if (!good || path.Thing5 == b)
					return;
				path.Thing5 = b;
				break;
			case nameof(CameraPath.Thing6):
				good = Byte.TryParse(c.Text, hex, culture, out b);
				if (!good || path.Thing6 == b)
					return;
				path.Thing6 = b;
				break;
			case nameof(CameraPath.Pitch):
				if (Single.TryParse(c.Text, out float pitch))
				{
					if (path.Pitch.ApproximatelyEquivalent(pitch, Tolerance))
						return;
					path.Pitch = pitch;
				}
				break;
			case nameof(CameraPath.Yaw):
				if (Single.TryParse(c.Text, out float yaw))
				{
					if (path.Yaw.ApproximatelyEquivalent(yaw, Tolerance))
						return;
					path.Yaw = yaw;
				}
				break;
			default:
				return;
		}

		CommitCameraPathChanges(path);
	}

	private void CmsSelectedCameraPath_Opening(object sender, CancelEventArgs e)
	{
		Type[] types = [typeof(Label), typeof(CheckBox)];

		TsmSelectedCameraPathResetProperty.Enabled = types
			.Contains(CmsSelectedCameraPath.SourceControl.GetType());
	}

	private void SelectedCameraPath_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Enter)
		{
			SelectedCameraPath_ValidateInput(sender as Control);
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
	}

	private void SelectedCameraPath_Leave(object sender, EventArgs e)
	{
		SelectedCameraPath_ValidateInput(sender as Control);
	}

	private void TsmSelectedCameraPathResetAll_Click(object sender, EventArgs e)
	{
		if (LbxCameraPaths.SelectedItem is not CameraPath c)
		{
			return;
		}

		SelectedCameraPath_ResetProperty(c, "all");
	}

	private void TsmSelectedCameraPathResetProperty_Click(object sender, EventArgs e)
	{
		if (LbxCameraPaths.SelectedItem is not CameraPath c)
		{
			return;
		}

		SelectedCameraPath_ResetProperty(c);
	}
}
