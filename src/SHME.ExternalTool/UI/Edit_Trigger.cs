using SHME.ExternalTool;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk;

partial class CustomMainForm
{
	private void CommitTriggerChanges(Trigger t)
	{
		_userChange = true;
		Mem.WriteByteRange(t.Address, t.ToBytes().ToArray());

		LbxPois.BeginUpdate();
		LbxTriggers.BeginUpdate();

		int index = LbxTriggers.Items.IndexOf(t);
		LbxTriggers.Items[index] = t;

		LbxTriggers.EndUpdate();
		LbxPois.EndUpdate();
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
				// TODO: Figure out how to parse user input.
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
			// TODO: Figure this one out. The 'fired' bit is stored in a
			// separate location from the bytes of the trigger.
			//case "Fired":
			case nameof(Trigger.SomeIndex):
				short s = (short)NudSelectedTriggerSomeIndex.Value;
				if (t.SomeIndex == s)
					return;
				t.SomeIndex = s;
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
				break;
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
}
