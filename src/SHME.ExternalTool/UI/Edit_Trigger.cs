using SHME.ExternalTool;
using SHME.ExternalTool.Graphics;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static SHME.ExternalTool.CollectionExtensions;

namespace BizHawk.Client.EmuHawk;

partial class CustomMainForm
{
	private void CommitTriggerChanges(Trigger t)
	{
		_userChange = true;
		Mem.WriteByteRange(t.Address, t.ToBytes().ToArray());
		SetTriggerFired(t);

		Guts.Triggers[t.Address] = t;
		LbxTriggers.Items[Guts.Triggers.IndexFromKey(t.Address)] = t;

		(PointOfInterest, Renderable?) changed = GetRenderableFromTrigger(t);

		Guts.Pois[changed.Item1.Address] = changed;

		RdoOverlayAxisColors_CheckedChanged(this, EventArgs.Empty);
	}

	private bool GetTriggerFired(Trigger t)
	{
		MainRamAddresses ram = Rom.Addresses.MainRam;
		long ofs = ram.SaveData + 0x168 + t.FiredGroup * sizeof(int);

		return (Mem.ReadS32(ofs) & (1 << t.FiredBitShift)) != 0;
	}
	private void SetTriggerFired(Trigger t)
	{
		MainRamAddresses ram = Rom.Addresses.MainRam;

		long ofs = ram.SaveData + 0x168 + t.FiredGroup * sizeof(int);

		int group = Mem.ReadS32(ofs);
		if (t.Fired)
		{
			group |= 1 << t.FiredBitShift;
		}
		else
		{
			group &= ~(1 << t.FiredBitShift);
		}

		Mem.WriteS32(ofs, group);
	}

	private void SelectedTrigger_ResetProperty(Trigger t, string? prop = null)
	{
		if (Guts.Stage is null)
		{
			return;
		}

		if (String.IsNullOrEmpty(prop))
		{
			prop = CmsSelectedTrigger.SourceControl.Tag as string;
		}

		ReadOnlySpan<byte> stage = Guts.Stage.ToBytes();

		MainRamAddresses ram = Rom.Addresses.MainRam;
		int ofs = (int)(t.Address - ram.StageHeader);
		Trigger reset = new(t.Address, stage.Slice(ofs, t.SizeInBytes));

		PointOfInterest p = Guts.Pois.ElementAt(t.PoiIndex).Value.Item1;

		if (String.Equals(prop, "all", StringComparison.OrdinalIgnoreCase))
		{
			// The coordinates of a PointOfInterest are unrelated to the
			// particular trigger targeting it, so even a full reset of a
			// Trigger should not affect the PointOfInterest's position.
			SelectedPoi_ResetProperty(p, nameof(PointOfInterest.Geometry));

			CommitTriggerChanges(reset);
			return;
		}

		switch (prop)
		{
			case nameof(Trigger.Disabled):
				t.Disabled = reset.Disabled;
				break;
			case nameof(PointOfInterest.Geometry):
				SelectedPoi_ResetProperty(p, prop);
				return;
			case nameof(Trigger.Thing0):
				t.Thing0 = reset.Thing0;
				break;
			case nameof(Trigger.Thing1):
				t.Thing1 = reset.Thing1;
				break;
			case nameof(Trigger.FiredGroup):
				t.FiredGroup = reset.FiredGroup;
				break;
			case nameof(Trigger.Fired):
				t.Fired = reset.Fired;
				break;
			case nameof(Trigger.Thing2):
				t.Thing2 = reset.Thing2;
				break;
			case nameof(Trigger.Style):
				t.Style = reset.Style;
				break;
			case nameof(Trigger.PoiIndex):
				t.PoiIndex = reset.PoiIndex;
				break;
			case nameof(Trigger.Thing3):
				t.Thing3 = reset.Thing3;
				break;
			case nameof(Trigger.Thing4):
				t.Thing4 = reset.Thing4;
				break;
			case nameof(Trigger.TriggerType):
				t.TriggerType = reset.TriggerType;
				break;
			case nameof(Trigger.TargetIndex):
				t.TargetIndex = reset.TargetIndex;
				break;
			case nameof(Trigger.Thing5):
				t.Thing5 = reset.Thing5;
				break;
			case nameof(Trigger.Thing6):
				t.Thing6 = reset.Thing6;
				break;
			case nameof(Trigger.StageIndex):
				t.StageIndex = reset.StageIndex;
				break;
			case nameof(Trigger.SomeBool):
				t.SomeBool = reset.SomeBool;
				break;
			default:
				break;

		}

		CommitTriggerChanges(t);
	}

	private void SelectedTrigger_ValidateInput(Control? ctrl)
	{
		if (LbxTriggers.SelectedItem is not Trigger t)
		{
			return;
		}

		NumberStyles hex = NumberStyles.HexNumber;
		CultureInfo culture = CultureInfo.CurrentCulture;

		switch (ctrl?.Tag)
		{
			case nameof(Trigger.Disabled):
				bool check = CbxSelectedTriggerDisabled.Checked;
				if (t.Disabled == check)
					return;
				t.Disabled = check;
				break;
			case nameof(PointOfInterest.Geometry):
				if (!TryEncodePoiGeometry(MtbSelectedTriggerPoiGeometry.Text, t))
					return;
				CommitPoiChanges(Guts.Pois.ElementAt(t.PoiIndex).Value.Item1);
				break;
			case nameof(Trigger.Thing0):
				string text = MtbSelectedTriggerThing0.Text;
				bool good = Byte.TryParse(text, hex, culture, out byte b);
				if (!good || t.Thing0 == b)
					return;
				t.Thing0 = b;
				break;
			case nameof(Trigger.Thing1):
				text = MtbSelectedTriggerThing1.Text;
				good = Byte.TryParse(text, hex, culture, out b);
				if (!good || t.Thing1 == b)
					return;
				t.Thing1 = b;
				break;
			case nameof(Trigger.FiredGroup):
				short s = (short)NudSelectedTriggerFiredGroup.Value;
				if (t.FiredGroup == s)
					return;
				t.FiredGroup = s;
				break;
			case nameof(Trigger.Fired):
				if (t.Fired == CbxSelectedTriggerFired.Checked)
					return;
				t.Fired = CbxSelectedTriggerFired.Checked;
				break;
			case nameof(Trigger.Thing2):
				text = MtbSelectedTriggerThing2.Text;
				good = Byte.TryParse(text, hex, culture, out b);
				if (!good || t.Thing2 == b)
					return;
				t.Thing2 = b;
				break;
			case nameof(Trigger.Style):
				var style = (TriggerStyle)CmbSelectedTriggerStyle.SelectedItem;
				if (t.Style == style)
					return;
				t.Style = style;
				break;
			case nameof(Trigger.PoiIndex):
				b = (byte)NudSelectedTriggerPoiIndex.Value;
				if (t.PoiIndex == b)
					return;
				t.PoiIndex = b;
				break;
			case nameof(Trigger.Thing3):
				text = MtbSelectedTriggerThing3.Text;
				good = Byte.TryParse(text, hex, culture, out b);
				if (!good || t.Thing3 == b)
					return;
				t.Thing3 = b;
				break;
			case nameof(Trigger.Thing4):
				text = MtbSelectedTriggerThing4.Text;
				good = Byte.TryParse(text, hex, culture, out b);
				if (!good || t.Thing4 == b)
					return;
				t.Thing4 = b;
				break;
			case nameof(Trigger.TriggerType):
				var type = (TriggerType)CmbSelectedTriggerType.SelectedItem;
				if (t.TriggerType == type)
					return;
				t.TriggerType = type;
				break;
			case nameof(Trigger.TargetIndex):
				int i = (int)NudSelectedTriggerTargetIndex.Value;
				if (t.TargetIndex == i)
					return;
				t.TargetIndex = i;
				break;
			case nameof(Trigger.Thing5):
				text = MtbSelectedTriggerThing5.Text;
				good = Byte.TryParse(text, hex, culture, out b);
				if (!good || t.Thing5 == b)
					return;
				t.Thing5 = b;
				break;
			case nameof(Trigger.Thing6):
				text = MtbSelectedTriggerThing6.Text;
				good = Byte.TryParse(text, hex, culture, out b);
				if (!good || t.Thing6 == b)
					return;
				t.Thing6 = b;
				break;
			case nameof(Trigger.StageIndex):
				b = (byte)NudSelectedTriggerStageIndex.Value;
				if (t.StageIndex == b)
					return;
				t.StageIndex = b;
				break;
			case nameof(Trigger.SomeBool):
				check = CbxSelectedTriggerSomeBool.Checked;
				if (t.SomeBool == check)
					return;
				t.SomeBool = check;
				break;
			default:
				return;
		}

		CommitTriggerChanges(t);
	}

	private void CmbSelectedTrigger_SelectedValueChanged(object sender, EventArgs e)
	{
		SelectedTrigger_ValidateInput(sender as Control);
	}

	private void CmsSelectedTrigger_Opening(object sender, CancelEventArgs e)
	{
		Type[] types = [typeof(Label), typeof(CheckBox)];

		TsmSelectedTriggerResetProperty.Enabled = types
			.Contains(CmsSelectedTrigger.SourceControl.GetType());
	}

	private void NudSelectedTrigger_ValueChanged(object sender, EventArgs e)
	{
		SelectedTrigger_ValidateInput(sender as Control);
	}

	private void SelectedTrigger_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Enter)
		{
			SelectedTrigger_ValidateInput(sender as Control);
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
	}

	private void SelectedTrigger_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
		bool alphanumeric =
			(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.Z) ||
			(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9);

		if (!alphanumeric || sender is not MaskedTextBox mtb)
		{
			return;
		}

		// If any of the two literals in the hex prefix "0x" are selected
		// when starting to type in a MaskedTextBox, the first character
		// typed will be swallowed. To have it simply overwrite the first
		// editable character, reset the selection before KeyDown.
		if (mtb.SelectionLength > 0 && mtb.SelectionStart < 2)
		{
			BeginInvoke(() => mtb.SelectionLength = 0);
		}
	}

	private void SelectedTrigger_Leave(object sender, EventArgs e)
	{
		SelectedTrigger_ValidateInput(sender as Control);
	}

	private void TsmSelectedTriggerResetProperty_Click(object sender, EventArgs e)
	{
		if (LbxTriggers.SelectedItem is not Trigger t)
		{
			return;
		}

		SelectedTrigger_ResetProperty(t);
	}

	private void TsmSelectedTriggerResetAllProperties_Click(object sender, EventArgs e)
	{
		if (LbxTriggers.SelectedItem is not Trigger t)
		{
			return;
		}

		SelectedTrigger_ResetProperty(t, "all");
	}
}
