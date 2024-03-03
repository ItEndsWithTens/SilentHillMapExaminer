using SHME.ExternalTool;
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
		public Dictionary<CameraPath, IList<Renderable?>> CameraPaths { get; } = new();

		public IList<Renderable> CameraBoxes { get; } = new List<Renderable>();
		public IList<Renderable> CameraGems { get; } = new List<Renderable>();
		public IList<Line> CameraLines { get; } = new List<Line>();

		private void ClearDisplayedCameraPathInfo()
		{
			string sep = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;

			LblCameraPathAddress.Text = "0x";
			CbxSelectedCameraPathDisabled.Enabled = false;
			CbxSelectedCameraPathDisabled.Checked = false;
			LblCameraPathVolumeMin.Text = $"<x{sep} y{sep} z>";
			LblCameraPathVolumeMax.Text = $"<x{sep} y{sep} z>";
			LblCameraPathAreaMin.Text = $"<x{sep} z>";
			LblCameraPathAreaMax.Text = $"<x{sep} z>";
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

			SetHarryPosition(path.VolumeMax.X, path.VolumeMax.Y, path.VolumeMax.Z);
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
			var gemGen = new GemGenerator(0.125f, 0.25f, 0.125f, Color.FromArgb(0x25, 0xA5, 0x97));
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
					// To ensure that a one-dimensional camera path can be
					// clicked in the viewport, and that it will be drawn on
					// screen in filled render mode, nudge the ends a bit.
					float cheat = 0.0125f;

					volumeMin.X -= cheat;
					volumeMin.Y -= cheat;
					volumeMin.Z -= cheat;

					volumeMax.X += cheat;
					volumeMax.Y += cheat;
					volumeMax.Z += cheat;
				}

				Vector3 size = volumeMax - volumeMin;
				var boxGen = new BoxGenerator(size, Color.Orange);
				Renderable volume = boxGen.Generate().ToWorld();
				volume.Position = volumeMin + (size / 2.0f);

				CameraBoxes.Add(volume);

				float sizeX = path.AreaMaxX - path.AreaMinX;
				float sizeZ = path.AreaMaxZ - path.AreaMinZ;
				var sheetGen = new SheetGenerator(sizeX, sizeZ, Color.FromArgb(0x52, 0x3A, 0xB5));
				Renderable area = sheetGen.Generate().ToWorld();
				area.Position = new Vector3(
					path.AreaMinX + sizeX / 2.0f,
					0.0f,
					-(path.AreaMinZ + sizeZ / 2.0f));

				CameraBoxes.Add(area);

				CameraPaths.Add(path, new[] { area, gemA, volume, gemB });

				address += SilentHillEntitySizes.CameraPath;
			}

			LblCameraPathCount.Text = CameraPaths.Count.ToString(CultureInfo.CurrentCulture);
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

			CultureInfo c = CultureInfo.CurrentCulture;

			SuspendLayout();
			LblCameraPathAddress.Text = $"0x{path.Address.ToString("X", c)}";
			CbxSelectedCameraPathDisabled.Enabled = true;
			CbxSelectedCameraPathDisabled.Checked = path.Disabled;
			LblCameraPathVolumeMin.Text = $"{path.VolumeMin.ToString(String.Empty, c)}";
			LblCameraPathVolumeMax.Text = $"{path.VolumeMax.ToString(String.Empty, c)}";
			LblCameraPathAreaMin.Text = $"<{path.AreaMinX.ToString(c)}, {path.AreaMinZ.ToString(c)}>";
			LblCameraPathAreaMax.Text = $"<{path.AreaMaxX.ToString(c)}, {path.AreaMaxZ.ToString(c)}>";
			LblCameraPathThing4.Text = $"0x{path.Thing4.ToString("X2", c)}";
			LblCameraPathThing5.Text = $"0x{path.Thing5.ToString("X2", c)}";
			LblCameraPathThing6.Text = $"0x{path.Thing6.ToString("X4", c)}";
			LblCameraPathPitch.Text = $"{path.Pitch.ToString(c)}";
			LblCameraPathYaw.Text = $"{path.Yaw.ToString(c)}";
			ResumeLayout();
		}
	}
}
