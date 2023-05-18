﻿using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		public Dictionary<CameraPath, IList<Renderable?>> CameraPaths { get; } = new();

		public IList<Renderable> CameraBoxes { get; } = new List<Renderable>();
		public IList<Renderable> CameraGems { get; } = new List<Renderable>();
		public IList<Line> CameraLines { get; } = new List<Line>();

		private void InitializeCameraTab()
		{
		}

		private void ClearDisplayedCameraPathInfo()
		{
			LblCameraPathAddress.Text = "0x";
			CbxSelectedCameraPathDisabled.Enabled = false;
			CbxSelectedCameraPathDisabled.Checked = false;
			LblCameraPathVolumeMin.Text = "<x, y, z>";
			LblCameraPathVolumeMax.Text = "<x, y, z>";
			LblCameraPathAreaMin.Text = "<x, z>";
			LblCameraPathAreaMax.Text = "<x, z>";
			LblCameraPathThing4.Text = "0x";
			LblCameraPathThing5.Text = "0x";
			LblCameraPathThing6.Text = "0x";
			LblCameraPathThing5.Text = String.Empty;
			LblCameraPathThing6.Text = String.Empty;
		}

		private void BtnCameraPathGoToVolumeMin_Click(object sender, EventArgs e)
		{
			if (LbxCameraPaths.SelectedItem is not CameraPath path)
			{
				return;
			}

			SetHarryPosition(path.VolumeMin.X, path.VolumeMin.Y, path.VolumeMin.Z);
		}

		private void BtnCameraPathGoToVolumeMax_Click(object sender, EventArgs e)
		{
			if (LbxCameraPaths.SelectedItem is not CameraPath path)
			{
				return;
			}

			SetHarryPosition(path.VolumeMin.X, path.VolumeMin.Y, path.VolumeMin.Z);
		}

		private void BtnCameraPathReadArray_Click(object sender, EventArgs e)
		{
			long address = Mem.ReadU32(Rom.Addresses.MainRam.PointerToArrayOfCameraPaths);
			address -= Rom.Addresses.MainRam.BaseAddress;

			CameraPaths.Clear();
			LbxCameraPaths.Items.Clear();
			CameraBoxes.Clear();
			CameraGems.Clear();
			CameraLines.Clear();
			Color color = Color.Orange;
			var gemGen = new GemGenerator(0.125f, 0.25f, 0.125f, color);
			while (true)
			{
				IReadOnlyList<byte> bytes = Mem.ReadByteRange(address, SilentHillEntitySizes.CameraPath);

				var path = new CameraPath(address, bytes.ToArray());

				if (path.Thing4 == 0x1)
				{
					break;
				}

				LbxCameraPaths.Items.Add(path);

				Renderable gemA = gemGen.Generate().ToWorld();
				gemA.Position = new Vector3(path.VolumeMin.X, -path.VolumeMin.Y, -path.VolumeMin.Z);

				Renderable gemB = gemGen.Generate().ToWorld();
				gemB.Position = new Vector3(path.VolumeMax.X, -path.VolumeMax.Y, -path.VolumeMax.Z);

				CameraGems.Add(gemA);
				CameraGems.Add(gemB);

				var boxGen = new BoxGenerator(gemA.Position, gemB.Position, color);
				Renderable volume = boxGen.Generate().ToWorld();

				CameraBoxes.Add(volume);

				// TODO: Optimize this by connecting the gems with a line if
				// they're exactly on a world axis, a sheet if they're on the
				// same plane, and a box only if they're off on both axes. Fewer
				// sides means fewer polys/tris.
				//
				// Oh, but then if users can ever make changes on the fly, the
				// object would have to be recreated to change from a line to
				// a sheet or a box. Damn it.
				float sizeX = path.AreaMaxX - path.AreaMinX;
				float sizeZ = path.AreaMaxZ - path.AreaMinZ;
				var sheetGen = new SheetGenerator(sizeX, sizeZ, color);
				Renderable area = sheetGen.Generate().ToWorld();
				area.Position = new Vector3(
					path.AreaMinX + sizeX / 2.0f,
					0.0f,
					-(path.AreaMinZ + sizeZ / 2.0f));

				CameraBoxes.Add(area);

				CameraPaths.Add(path, new[] { area, gemA, volume, gemB});

				address += SilentHillEntitySizes.CameraPath;
			}

			LblCameraPathCount.Text = $"{CameraPaths.Count}";
		}

		private void CbxSelectedCameraPathEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (LbxCameraPaths.SelectedItem is not CameraPath p)
			{
				return;
			}

			// TODO: Data binding? Or whatever, just come up with some way of
			// connecting the CameraPath instance and its in-game memory
			// representation. Need blittable types to shadow the POCOs? Ugh.
			long address = p.Address + 16;

			uint existing = Mem.ReadByte(address);
			if (CbxSelectedCameraPathDisabled.Checked)
			{
				Mem.WriteByte(address, (byte)(existing | 0b01000000));
			}
			else
			{
				Mem.WriteByte(address, (byte)(existing & 0b10111111));
			}

			int index = LbxCameraPaths.SelectedIndex;
			LbxCameraPaths.BeginUpdate();
			BtnCameraPathReadArray_Click(this, EventArgs.Empty);
			LbxCameraPaths.SelectedIndex = index;
			LbxCameraPaths.EndUpdate();
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
			e.Value = $"{LbxCameraPaths.Items.IndexOf(e.ListItem)}:    {e.ListItem}";
		}

		private void LbxCameraPaths_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sender is not ListBox lbx)
			{
				return;
			}

			foreach (KeyValuePair<CameraPath, IList<Renderable?>> item in CameraPaths)
			{
				foreach (Renderable? r in item.Value)
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

			foreach (Renderable? r in CameraPaths[path])
			{
				if (r != null)
				{
					r.Tint = Color.Yellow;
				}
			}

			SuspendLayout();
			LblCameraPathAddress.Text = $"0x{path.Address:X}";
			CbxSelectedCameraPathDisabled.Enabled = true;
			CbxSelectedCameraPathDisabled.Checked = path.Disabled;
			LblCameraPathVolumeMin.Text = $"{path.VolumeMin}";
			LblCameraPathVolumeMax.Text = $"{path.VolumeMax}";
			LblCameraPathAreaMin.Text = $"<{path.AreaMinX}, {path.AreaMinZ}>";
			LblCameraPathAreaMax.Text = $"<{path.AreaMaxX}, {path.AreaMaxZ}>";
			LblCameraPathThing4.Text = $"0x{path.Thing4:X2}";
			LblCameraPathThing5.Text = $"0x{path.Thing5:X2}";
			LblCameraPathThing6.Text = $"0x{path.Thing6:X4}";
			LblCameraPathPitch.Text = $"{path.Pitch}";
			LblCameraPathYaw.Text = $"{path.Yaw}";
			ResumeLayout();
		}
	}
}