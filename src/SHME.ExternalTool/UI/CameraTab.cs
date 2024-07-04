using SHME.ExternalTool;
using SHME.ExternalTool.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void InitializeCameraTab()
		{
			CbxSelectedCameraPathDisabled.Tag = nameof(CameraPath.Disabled);

			LblSelectedCameraPathVolumeMin.Tag = nameof(CameraPath.VolumeMin);
			TbxCameraPathVolumeMinX.Tag = $"{nameof(CameraPath.VolumeMin)}.X";
			TbxCameraPathVolumeMinY.Tag = $"{nameof(CameraPath.VolumeMin)}.Y";
			TbxCameraPathVolumeMinZ.Tag = $"{nameof(CameraPath.VolumeMin)}.Z";

			LblSelectedCameraPathVolumeMax.Tag = nameof(CameraPath.VolumeMax);
			TbxCameraPathVolumeMaxX.Tag = $"{nameof(CameraPath.VolumeMax)}.X";
			TbxCameraPathVolumeMaxY.Tag = $"{nameof(CameraPath.VolumeMax)}.Y";
			TbxCameraPathVolumeMaxZ.Tag = $"{nameof(CameraPath.VolumeMax)}.Z";

			LblSelectedCameraPathAreaMin.Tag =
				nameof(CameraPath.AreaMinX) +
				nameof(CameraPath.AreaMinZ);

			TbxCameraPathAreaMinX.Tag = nameof(CameraPath.AreaMinX);
			TbxCameraPathAreaMinZ.Tag = nameof(CameraPath.AreaMinZ);

			LblSelectedCameraPathAreaMax.Tag =
				nameof(CameraPath.AreaMaxX) +
				nameof(CameraPath.AreaMaxZ);

			TbxCameraPathAreaMaxX.Tag = nameof(CameraPath.AreaMaxX);
			TbxCameraPathAreaMaxZ.Tag = nameof(CameraPath.AreaMaxZ);

			LblSelectedCameraPathThing4.Tag = nameof(CameraPath.Thing4);
			MtbCameraPathThing4.Tag = nameof(CameraPath.Thing4);

			LblSelectedCameraPathThing5.Tag = nameof(CameraPath.Thing5);
			MtbCameraPathThing5.Tag = nameof(CameraPath.Thing5);

			LblSelectedCameraPathThing6.Tag = nameof(CameraPath.Thing6);
			MtbCameraPathThing6.Tag = nameof(CameraPath.Thing6);

			LblSelectedCameraPathPitch.Tag = nameof(CameraPath.Pitch);
			TbxCameraPathPitch.Tag = nameof(CameraPath.Pitch);

			LblSelectedCameraPathYaw.Tag = nameof(CameraPath.Yaw);
			TbxCameraPathYaw.Tag = nameof(CameraPath.Yaw);
		}

		private int? _previousSelectedCameraPathIndex;
		private string? _previousSelectedCameraPathBodyHash;
		private void CheckForSelectedCameraPathUpdate()
		{
			if (LbxCameraPaths.SelectedItem is not CameraPath c)
			{
				return;
			}

			string body = Mem.HashRegion(c.Address, c.SizeInBytes);

			if (LbxCameraPaths.SelectedIndex != _previousSelectedCameraPathIndex)
			{
				_previousSelectedCameraPathIndex = LbxCameraPaths.SelectedIndex;
				_previousSelectedCameraPathBodyHash = body;

				return;
			}

			if (body != _previousSelectedCameraPathBodyHash)
			{
				_previousSelectedCameraPathBodyHash = body;

				if (_userChange)
				{
					_userChange = false;
					return;
				}

				int index = LbxCameraPaths.SelectedIndex;

				LbxCameraPaths.BeginUpdate();
				BtnCameraPathReadArray_Click(this, EventArgs.Empty);
				LbxCameraPaths.SelectedIndex = index;
				LbxCameraPaths.EndUpdate();
			}
		}

		private void ClearDisplayedCameraPathInfo()
		{
			LblCameraPathAddress.Text = "0x";
			CbxSelectedCameraPathDisabled.Enabled = false;
			CbxSelectedCameraPathDisabled.Checked = false;
			TbxCameraPathVolumeMinX.Text = "<x>";
			TbxCameraPathVolumeMinY.Text = "<y>";
			TbxCameraPathVolumeMinZ.Text = "<z>";
			TbxCameraPathVolumeMaxX.Text = "<x>";
			TbxCameraPathVolumeMaxY.Text = "<y>";
			TbxCameraPathVolumeMaxZ.Text = "<z>";
			TbxCameraPathAreaMinX.Text = "<x>";
			TbxCameraPathAreaMinZ.Text = "<z>";
			TbxCameraPathAreaMaxX.Text = "<x>";
			TbxCameraPathAreaMaxZ.Text = "<z>";
			MtbCameraPathThing4.ResetText();
			MtbCameraPathThing5.ResetText();
			MtbCameraPathThing6.ResetText();
		}

		private void BtnCameraPathGoToVolumeMin_Click(object sender, EventArgs e)
		{
			if (LbxCameraPaths.SelectedItem is not CameraPath path)
			{
				return;
			}

			SetHarryPosition(path.VolumeMin);
		}

		private void BtnCameraPathGoToVolumeMax_Click(object sender, EventArgs e)
		{
			if (LbxCameraPaths.SelectedItem is not CameraPath path)
			{
				return;
			}

			SetHarryPosition(path.VolumeMax);
		}

		private void BtnCameraPathReadArray_Click(object sender, EventArgs e)
		{
			MainRamAddresses ram = Rom.Addresses.MainRam;

			long address = Mem.ReadU32(ram.PointerToArrayOfCameraPaths);
			address -= ram.BaseAddress;

			Guts.CameraPaths.Clear();
			LbxCameraPaths.Items.Clear();

			GemGenerator gemGen = new(0.125f, 0.25f, 0.125f, Color.FromArgb(0x25, 0xA5, 0x97));

			while (true)
			{
				ReadOnlySpan<byte> span = Mem.ReadByteRange(address, SilentHillTypeSizes.CameraPath).ToArray();

				CameraPath path = new(address, span);

				if (path.Thing4 == 0x1)
				{
					break;
				}

				Renderable gemA = gemGen.Generate().ToWorld();
				gemA.Position = new Vector3(path.VolumeMin.X, -path.VolumeMin.Y, -path.VolumeMin.Z);

				Renderable gemB = gemGen.Generate().ToWorld();
				gemB.Position = new Vector3(path.VolumeMax.X, -path.VolumeMax.Y, -path.VolumeMax.Z);

				Vector3 volumeMin;
				volumeMin.X = Math.Min(gemA.Position.X, gemB.Position.X);
				volumeMin.Y = Math.Min(gemA.Position.Y, gemB.Position.Y);
				volumeMin.Z = Math.Min(gemA.Position.Z, gemB.Position.Z);

				Vector3 volumeMax;
				volumeMax.X = Math.Max(gemA.Position.X, gemB.Position.X);
				volumeMax.Y = Math.Max(gemA.Position.Y, gemB.Position.Y);
				volumeMax.Z = Math.Max(gemA.Position.Z, gemB.Position.Z);

				bool equalX = gemA.Position.X == gemB.Position.X;
				bool equalY = gemA.Position.Y == gemB.Position.Y;
				bool equalZ = gemA.Position.Z == gemB.Position.Z;
				if ((equalX && equalY) || (equalY && equalZ) || (equalZ && equalX))
				{
					// To ensure that a one-dimensional camera path can
					// be clicked in the viewport, and that it will be
					// drawn on screen in filled render mode, nudge the
					// ends a bit.
					float cheat = 0.0125f;

					volumeMin.X -= cheat;
					volumeMin.Y -= cheat;
					volumeMin.Z -= cheat;

					volumeMax.X += cheat;
					volumeMax.Y += cheat;
					volumeMax.Z += cheat;
				}

				Vector3 size = volumeMax - volumeMin;
				BoxGenerator boxGen = new(size, Color.Orange);
				Renderable volume = boxGen.Generate().ToWorld();
				volume.Position = volumeMin + (size / 2.0f);

				float sizeX = path.AreaMaxX - path.AreaMinX;
				float sizeZ = path.AreaMaxZ - path.AreaMinZ;
				SheetGenerator sheetGen = new(sizeX, sizeZ, Color.FromArgb(0x52, 0x3A, 0xB5));
				Renderable area = sheetGen.Generate().ToWorld();
				area.Position = new Vector3(
					path.AreaMinX + sizeX / 2.0f,
					0.0f,
					-(path.AreaMinZ + sizeZ / 2.0f));

				Guts.CameraPaths.Add(path.Address, (path, [area, gemA, volume, gemB]));
				LbxCameraPaths.Items.Add(path);

				address += SilentHillTypeSizes.CameraPath;
			}

			LblCameraPathCount.Text = Guts.CameraPaths.Count.ToString(CultureInfo.CurrentCulture);
		}

		private void BtnClearCameraPaths_Click(object sender, EventArgs e)
		{
			Guts.CameraPaths.Clear();
			LbxCameraPaths.Items.Clear();
			LblCameraPathCount.Text = "-";

			ClearDisplayedCameraPathInfo();
		}

		private void CbxSelectedCameraPathEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (LbxCameraPaths.SelectedItem is not CameraPath p)
			{
				return;
			}

			SelectedCameraPath_ValidateInput(sender as Control);
		}

		private void LblCameraPathAddress_Click(object sender, EventArgs e)
		{
			if (LbxCameraPaths.SelectedItem is not CameraPath path)
			{
				return;
			}

			HexEditorGoToAddress(path.Address);
		}

		private void LbxCameraPaths_Format(object sender, ListControlConvertEventArgs e)
		{
			int idx = LbxCameraPaths.Items.IndexOf(e.ListItem);
			CultureInfo c = CultureInfo.CurrentCulture;
			e.Value = $"{idx.ToString(c)}: {e.ListItem}";
		}

		private void LbxCameraPaths_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sender is not ListBox lbx)
			{
				return;
			}

			foreach ((CameraPath, IList<Renderable?>) tuple in Guts.CameraPaths.Values)
			{
				foreach (Renderable? r in tuple.Item2)
				{
					if (r != null)
					{
						r.Tint = null;
					}
				}
			}

			if (lbx.SelectedItem is not CameraPath path)
			{
				ClearDisplayedCameraPathInfo();
				return;
			}

			foreach (Renderable? r in Guts.CameraPaths[path.Address].Item2)
			{
				if (r != null)
				{
					r.Tint = Color.Yellow.ToArgb();
				}
			}

			CultureInfo c = CultureInfo.CurrentCulture;

			SuspendLayout();

			LblCameraPathAddress.Text = $"0x{path.Address.ToString("X", c)}";
			CbxSelectedCameraPathDisabled.Enabled = true;
			CbxSelectedCameraPathDisabled.Checked = path.Disabled;
			TbxCameraPathVolumeMinX.Text = path.VolumeMin.X.ToString(c);
			TbxCameraPathVolumeMinY.Text = path.VolumeMin.Y.ToString(c);
			TbxCameraPathVolumeMinZ.Text = path.VolumeMin.Z.ToString(c);
			TbxCameraPathVolumeMaxX.Text = path.VolumeMax.X.ToString(c);
			TbxCameraPathVolumeMaxY.Text = path.VolumeMax.Y.ToString(c);
			TbxCameraPathVolumeMaxZ.Text = path.VolumeMax.Z.ToString(c);
			TbxCameraPathAreaMinX.Text = path.AreaMinX.ToString(c);
			TbxCameraPathAreaMinZ.Text = path.AreaMinZ.ToString(c);
			TbxCameraPathAreaMaxX.Text = path.AreaMaxX.ToString(c);
			TbxCameraPathAreaMaxZ.Text = path.AreaMaxZ.ToString(c);
			MtbCameraPathThing4.Text = $"0x{path.Thing4.ToString("X2", c)}";
			MtbCameraPathThing5.Text = $"0x{path.Thing5.ToString("X2", c)}";
			MtbCameraPathThing6.Text = $"0x{path.Thing6.ToString("X4", c)}";
			TbxCameraPathPitch.Text = path.Pitch.ToString(c);
			TbxCameraPathYaw.Text = path.Yaw.ToString(c);

			IList<(string, IList<Control>)> map = _fontChangeMap[typeof(CameraPath)];
			foreach ((string property, IList<Control> controls) in map)
			{
				foreach (Control control in controls)
				{
					MakeBoldIfChanged(control, path, property);
				}
			}

			ResumeLayout();
		}
	}
}
