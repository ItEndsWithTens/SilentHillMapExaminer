using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void BtnSettingsGoLocal_Click(object sender, EventArgs e)
		{
			string folder = Path.GetDirectoryName(Settings.Local.FileName);
			if (String.IsNullOrEmpty(folder))
			{
				return;
			}

			Process.Start(folder);
		}

		private void BtnSettingsGoRoaming_Click(object sender, EventArgs e)
		{
			string folder = Path.GetDirectoryName(Settings.Roaming.FileName);
			if (String.IsNullOrEmpty(folder))
			{
				return;
			}

			Process.Start(folder);
		}

		private void BtnSettingsResetAll_Click(object sender, EventArgs e)
		{
			DialogController.StopSound();

			DialogResult msg = MessageBox.Show(
					this,
					"Are you sure you want to restore all settings to their defaults?",
					"Reset all settings?",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button2);

			if (msg != DialogResult.Yes)
			{
				DialogController.StartSound();
				return;
			}

			if (File.Exists(Settings.Local.FileName))
			{
				File.Delete(Settings.Local.FileName);
			}

			if (File.Exists(Settings.Roaming.FileName))
			{
				File.Delete(Settings.Roaming.FileName);
			}

			LoadSettings();

			DialogController.StartSound();
		}

		private void BtnSettingsSaveCopies_Click(object sender, EventArgs e)
		{
			using var dlg = new FolderBrowserDialog();

			DialogController.StopSound();

			DialogResult = dlg.ShowDialog(this);
			if (DialogResult != DialogResult.OK)
			{
				DialogController.StartSound();
				return;
			}

			string localName = Path.GetFileName(Settings.Local.FileName);
			string roamingName = Path.GetFileName(Settings.Roaming.FileName);

			string localOut = Path.Combine(dlg.SelectedPath, localName);
			string roamingOut = Path.Combine(dlg.SelectedPath, roamingName);

			if (File.Exists(localOut) || File.Exists(roamingOut))
			{
				DialogResult msg = MessageBox.Show(
					this,
					"Files already exist! Overwrite?",
					"Confirm overwriting files",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button2);

				if (msg != DialogResult.Yes)
				{
					DialogController.StartSound();
					return;
				}
			}

			File.Copy(Settings.Local.FileName, localOut, true);
			File.Copy(Settings.Roaming.FileName, roamingOut, true);

			DialogController.StartSound();
		}

		private void RdoOverlayBackend_CheckedChanged(object sender, EventArgs e)
		{
			if (RdoBackendBizHawkGui.Checked)
			{
				DrawOverlay = DrawOverlayGui;
			}
			else
			{
				DrawOverlay = DrawOverlayBitmap;
			}
		}

		private void RdoOverlayDisplaySurface_CheckedChanged(object sender, EventArgs e)
		{
			InitializeOverlay();
		}
	}
}
