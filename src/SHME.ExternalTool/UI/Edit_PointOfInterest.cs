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
	/// <summary>
	/// Whether a change to the game's memory was initiated by the user
	/// or is the result of the game itself updating something. Used for
	/// avoiding infinite loops when syncing form controls to the game.
	/// </summary>
	private bool _userChange;

	private void CommitPoiChanges(PointOfInterest p)
	{
		_userChange = true;
		Mem.WriteByteRange(p.Address, p.ToBytes().ToArray());

		int idxBeforeP = LbxPois.SelectedIndex;
		int idxBeforeT = LbxTriggers.SelectedIndex;

		LbxPois.BeginUpdate();
		LbxTriggers.BeginUpdate();

		BtnReadTriggers_Click(this, EventArgs.Empty);

		LbxPois.SelectedIndex = idxBeforeP;
		LbxTriggers.SelectedIndex = idxBeforeT;

		LbxPois.EndUpdate();
		LbxTriggers.EndUpdate();
	}

	private void SelectedPoi_ValidateInput(Control? c)
	{
		if (LbxPois.SelectedItem is not PointOfInterest p)
		{
			return;
		}

		const float Tolerance = 0.0001f;

		switch (c?.Tag)
		{
			case nameof(PointOfInterest.X):
				if (Single.TryParse(c.Text, out float x))
				{
					if (p.X.ApproximatelyEquivalent(x, Tolerance))
						return;
					p.X = x;
				}
				break;
			case nameof(PointOfInterest.Z):
				if (Single.TryParse(c.Text, out float z))
				{
					if (p.Z.ApproximatelyEquivalent(z, Tolerance))
						return;
					p.Z = z;
				}
				break;
			case nameof(PointOfInterest.Geometry):
				if (UInt32.TryParse(c.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out uint geo))
				{
					if (p.Geometry == geo)
						return;
					p.Geometry = geo;
				}
				break;
			default:
				return;
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

		ReadOnlySpan<byte> stage = Guts.Stage.ToBytes();

		MainRamAddresses ram = Rom.Addresses.MainRam;
		int ofs = (int)(p.Address - ram.StageHeader);
		PointOfInterest reset = new(p.Address, stage.Slice(ofs, p.SizeInBytes));

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

		ReadOnlySpan<byte> stage = Guts.Stage.ToBytes();

		MainRamAddresses ram = Rom.Addresses.MainRam;
		int ofs = (int)(p.Address - ram.StageHeader);
		PointOfInterest reset = new(p.Address, stage.Slice(ofs, p.SizeInBytes));

		int index = Guts.Pois.IndexOf(p);

		Renderable? r = Guts.Pois[index].Item2;
		if (r is not null)
		{
			Vector3 pos = r.Position;
			pos.X = reset.X;
			pos.Z = reset.Z;
			r.Position = pos;
		}

		Guts.Pois[index] = (reset, r);

		LbxPois.Items[LbxPois.SelectedIndex] = reset;

		CommitPoiChanges(reset);
	}

	private void SelectedPoi_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Enter)
		{
			SelectedPoi_ValidateInput(sender as Control);
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
	}

	private void SelectedPoi_Leave(object sender, EventArgs e)
	{
		SelectedPoi_ValidateInput(sender as Control);
	}
}
