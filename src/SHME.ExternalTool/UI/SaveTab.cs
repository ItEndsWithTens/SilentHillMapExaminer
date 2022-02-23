using SHME.ExternalTool;
using System;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private ButtonFlags _saveButton = ButtonFlags.None;

		private void CheckForSaveButtonPress()
		{
			var raw = (ButtonFlags)Mem!.ReadU16(Rom.Addresses.MainRam.ButtonFlags);

			if (!raw.HasFlag(_saveButton))
			{
				BtnOpenSaveMenu_Click(BtnOpenSaveMenu, EventArgs.Empty);
			}
		}

		private void BtnOpenSaveMenu_Click(object sender, EventArgs e)
		{
			Mem!.WriteByte(Rom.Addresses.MainRam.ActiveTriggerType, (uint)TriggerType.Save0);
		}

		private void CmbSaveButton_SelectedValueChanged(object sender, EventArgs e)
		{
			Enum.TryParse(CmbSaveButton.SelectedValue.ToString(), out _saveButton);
		}
	}
}
