using SHME.ExternalTool;
using SHME.ExternalTool.Graphics;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk;

partial class CustomMainForm
{
	private void CommitPoiChanges(PointOfInterest p)
	{
		Mem.WriteByteRange(p.Address, p.ToBytes().ToArray());

		int idxPois = LbxPois.SelectedIndex;
		int idxTriggers = LbxTriggers.SelectedIndex;

		BtnReadTriggers_Click(this, EventArgs.Empty);

		LbxPois.SelectedIndex = idxPois;
		LbxTriggers.SelectedIndex = idxTriggers;
	}

	private void SelectedPoi_ValidateInput(Control? c)
	{
		if (LbxPois.SelectedItem is not PointOfInterest p)
		{
			return;
		}

		switch (c?.Tag)
		{
			case "X":
				if (Single.TryParse(c.Text, out float x))
				{
					p.X = x;
				}
				break;
			case "Z":
				if (Single.TryParse(c.Text, out float z))
				{
					p.Z = z;
				}
				break;
			case "Geometry":
				if (UInt32.TryParse(c.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out uint geo))
				{
					p.Geometry = geo;
				}
				break;
			default:
				break;
		}

		CommitPoiChanges(p);
	}

	private void CmsSelectedPoi_Opening(object sender, CancelEventArgs e)
	{
		Type[] types = [typeof(Label)];

		TsmSelectedPoiResetProperty.Enabled = types
			.Contains(CmsSelectedPoi.SourceControl.GetType());
	}

	private void TsmSelectedPoiResetProperty_Click(object sender, EventArgs e)
	{
		if (LbxPois.SelectedItem is not PointOfInterest p)
		{
			return;
		}

		ReadOnlySpan<byte> stageBytes = Guts.Stage.ToBytes();

		MainRamAddresses ram = Rom.Addresses.MainRam;
		int ofs = (int)(p.Address - ram.StageHeader);
		PointOfInterest reset = new(p.Address, stageBytes.Slice(ofs, p.SizeInBytes));

		// Now figure out which property needs resetting, and just
		// copy the value from the one in 'reset'.
		switch (CmsSelectedPoi.SourceControl.Tag)
		{
			case "XZ":
				p.X = reset.X;
				p.Z = reset.Z;
				break;
			case "Geometry":
				p.Geometry = reset.Geometry;
				break;
			default:
				break;
		}

		CommitPoiChanges(p);
	}

	private void TsmSelectedPoiResetAll_Click(object sender, EventArgs e)
	{
		if (LbxPois.SelectedItem is not PointOfInterest p)
		{
			return;
		}

		ReadOnlySpan<byte> stageBytes = Guts.Stage.ToBytes();

		MainRamAddresses ram = Rom.Addresses.MainRam;
		int ofs = (int)(p.Address - ram.StageHeader);
		PointOfInterest reset = new(p.Address, stageBytes.Slice(ofs, p.SizeInBytes));

		Renderable? r = Guts.Pois[p];
		if (r is not null)
		{
			Vector3 pos = r.Position;
			pos.X = reset.X;
			pos.Z = reset.Z;
			r.Position = pos;
		}
		Guts.Pois.Remove(p);
		Guts.Pois.Add(reset, r);

		LbxPois.Items[LbxPois.SelectedIndex] = reset;

		CommitPoiChanges(reset);
	}

	private void TbxSelectedPoiX_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Enter)
		{
			SelectedPoi_ValidateInput(sender as Control);
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
	}

	private void TbxSelectedPoiX_Leave(object sender, EventArgs e)
	{
		SelectedPoi_ValidateInput(sender as Control);
	}
}
