﻿using BizHawk.Emulation.Common;
using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void InitializeSaveTab()
		{
			CmbSaveButton.DataSource = Enum.GetValues(typeof(PsxButtons));
		}

		private void CheckForSaveButtonPress()
		{
			var raw = (PsxButtons)Mem.ReadU16(Rom.Addresses.MainRam.ButtonFlags);

			if (Guts.SaveButton != PsxButtons.None && !raw.FasterHasFlag(Guts.SaveButton))
			{
				BtnOpenSaveMenu_Click(BtnOpenSaveMenu, EventArgs.Empty);
			}
		}

		private async Task ConvertSaveRamToState(string path)
		{
			if (!File.Exists(path))
			{
				return;
			}

			bool wasPaused = Emu.IsPaused();
			Emu.Pause();

			// There doesn't seem to be a way with public APIs to determine if
			// framerate limiting is on, so rely on ClockThrottle to make the
			// decision but the public IEmulationApi to do the actual work.
			bool oldThrottle = Config?.ClockThrottle ?? true;
			Emulation.LimitFramerate(false);

			ImportSaveRam(path);

			// TODO: Press start at the Konami and KCET screens too? Might
			// save a little time, especially with as many save states as I
			// need to convert.

			// Skip ahead to the "fear of blood" opening cinematic.
			int frame = 2100;
			for (int i = 0; i < frame; i++)
			{
				Debug.WriteLine($"Seeking; frame {i}/{frame - 1}");

				// TODO: Figure out how to keep the UI from locking up during
				// calls to DoFrameAdvance.
				Emu.DoFrameAdvance();
			}

			// Hold Start for a bit to make sure the game registers the press.
			HoldButtonsAndDoFrameAdvance(15, "P1 Start");

			// Wait a second for the title screen to fade in.
			for (int i = 0; i < 60; i++)
			{
				Emu.DoFrameAdvance();
			}

			// Select the "Load" menu option and press X.
			Mem.WriteByte(Rom.Addresses.MainRam.IndexOfSelectedTitleScreenOption, 0);
			HoldButtonsAndDoFrameAdvance(15, _buttonNames[ShmeCommand.Action]);

			// Wait for the load screen transition to complete.
			for (int i = 0; i < 350; i++)
			{
				Emu.DoFrameAdvance();
			}

			// Select the newest save slot and load.
			uint slotCount = Mem.ReadU32(Rom.Addresses.MainRam.SaveLoadSlotCount);
			Mem.WriteByte(Rom.Addresses.MainRam.IndexOfSelectedSaveLoadSlot, slotCount - 1);
			HoldButtonsAndDoFrameAdvance(15, _buttonNames[ShmeCommand.Action]);

			// Wait until the load is complete.
			for (int i = 0; i < 1000; i++)
			{
				Emu.DoFrameAdvance();
			}

			Emulation.LimitFramerate(oldThrottle);

			if (!wasPaused)
			{
				// Unpause doesn't seem to work soon after DoFrameAdvance, so
				// wait a bit to let things settle into a condition where it
				// will.
				await Task.Delay(1000).ConfigureAwait(true);
				Emu.Unpause();
			}

			// Save the state after re-throttling the framerate and unpausing,
			// just so the states don't end up capturing those things.
			string name = Path.GetFileNameWithoutExtension(path);
			SaveState.Save(Path.Combine(
				TbxConvertSaveRamToStatesOutputPath.Text,
				$"{name}.State"));
		}
		private async Task ConvertStateToSaveRam(string path)
		{
			if (!File.Exists(path))
			{
				return;
			}

			bool wasPaused = Emu.IsPaused();
			Emu.Pause();

			bool oldThrottle = Config?.ClockThrottle ?? true;
			Emulation.LimitFramerate(false);

			string dir = Path.GetDirectoryName(path);
			string name = Path.GetFileNameWithoutExtension(path);

			Emu.LoadState(Path.Combine(dir, name));

			BtnOpenSaveMenu_Click(this, EventArgs.Empty);

			// Wait for save screen to open.
			for (int i = 0; i < 200; i++)
			{
				Emu.DoFrameAdvance();
			}

			uint slotCount = Mem.ReadU32(Rom.Addresses.MainRam.SaveLoadSlotCount);
			Mem.WriteByte(Rom.Addresses.MainRam.IndexOfSelectedSaveLoadSlot, slotCount - 1);

			// Create new in-game save.
			HoldButtonsAndDoFrameAdvance(15, _buttonNames[ShmeCommand.Action]);

			// Wait for save to complete.
			for (int i = 0; i < 200; i++)
			{
				Emu.DoFrameAdvance();
			}

			ExportSaveRam(Path.Combine(
				TbxConvertStatesToSaveRamOutputPath.Text,
				$"{name}.SaveRAM"));

			Emulation.LimitFramerate(oldThrottle);

			if (!wasPaused)
			{
				await Task.Delay(1000).ConfigureAwait(true);
				Emu.Unpause();
			}
		}

		private void ExportSaveRam(string file)
		{
			bool wasPaused = Emu.IsPaused();
			Emu.Pause();

			byte[]? sram = (Emulator as ISaveRam)?.CloneSaveRam();

			using var fs = new FileStream(file, FileMode.Create, FileAccess.Write);
			using var bw = new BinaryWriter(fs);

			bw.Write(sram);

			if (!wasPaused)
			{
				Emu.Unpause();
			}
		}
		private void ImportSaveRam(string file)
		{
			if (!File.Exists(file))
			{
				return;
			}

			using var fs = new FileStream(file, FileMode.Open, FileAccess.Read);
			using var br = new BinaryReader(fs);

			fs.Seek(0, SeekOrigin.End);
			int count = (int)fs.Position;
			fs.Seek(0, SeekOrigin.Begin);

			byte[]? sram = br.ReadBytes(count);

			bool wasPaused = Emu.IsPaused();

			Emu.Pause();

			// Silent Hill won't pick up on SaveRAM changes without a reboot.
			Emu.RebootCore();

			(Emulator as ISaveRam)?.StoreSaveRam(sram);

			if (!wasPaused)
			{
				Emu.Unpause();
			}
		}

		private void HoldButtonsAndDoFrameAdvance(int frames, params string[] buttons)
		{
			foreach (string b in buttons)
			{
				Joy.Set(b, true);
			}

			for (int i = 0; i < frames; i++)
			{
				Emu.DoFrameAdvance();
			}

			foreach (string b in buttons)
			{
				Joy.Set(b, false);
			}
		}

		private void RefreshSaveRamList()
		{
			LbxConvertSaveRamToStates.Items.Clear();

			string path = TbxConvertSaveRamToStatesInputPath.Text;
			if (Directory.Exists(path))
			{
				LbxConvertSaveRamToStates.Items.AddRange(Directory.GetFiles(
					path, "*.SaveRAM"));
			}
		}

		private void RefreshSaveStateList()
		{
			LbxConvertStatesToSaveRam.Items.Clear();

			string path = TbxConvertStatesToSaveRamInputPath.Text;
			if (Directory.Exists(path))
			{
				LbxConvertStatesToSaveRam.Items.AddRange(Directory.GetFiles(
					path, "*.State"));
			}
		}

		private void UpdateStripes()
		{
			Image old = PbxHazardStripes.Image;

			PbxHazardStripes.Image = GenerateHazardStripes(Color.Yellow, Color.Black);

			old?.Dispose();
		}

		public Bitmap GenerateHazardStripes(Color colorA, Color colorB, int stripeWidth = 16)
		{
			int width = 16;
			int height = 16;

			if (PbxHazardStripes.Width > 0 && PbxHazardStripes.Height > 0)
			{
				width = PbxHazardStripes.Width;
				height = PbxHazardStripes.Height;
			}

			var image = new Bitmap(width, height, PixelFormat.Format32bppRgb);

			Color baselineA = colorA;
			Color baselineB = colorB;

			int firstStripeWidth = stripeWidth;

			BitmapData data = image.LockBits(
				new Rectangle(0, 0, image.Width, image.Height),
				ImageLockMode.WriteOnly,
				PixelFormat.Format32bppArgb);

			for (int y = 0; y < image.Height; y++)
			{
				int stripeCount = y % stripeWidth;

				Color current = baselineA;
				Color other = baselineB;

				for (int x = 0; x < image.Width; x++)
				{
					if (stripeCount == stripeWidth)
					{
						(current, other) = (other, current);
						stripeCount = 0;
					}

					int ofs = (y * data.Stride) + (x * 4);
					Marshal.WriteInt32(data.Scan0 + ofs, current.ToArgb());

					stripeCount++;
				}

				firstStripeWidth--;

				if (firstStripeWidth == 0)
				{
					(baselineA, baselineB) = (baselineB, baselineA);
					firstStripeWidth = stripeWidth;
				}
			}

			image.UnlockBits(data);

			return image;
		}

		private async void BtnConvertSaveRamToStatesGo_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show(
				"This process can't be cancelled once started, will appear to " +
				"lock up the emulator, and may take a long time. Continue?",
				"Confirm SaveRAM to save state conversion",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning);
			if (result == DialogResult.No)
			{
				return;
			}

			var paths = new List<string>();
			if (LbxConvertSaveRamToStates.SelectedItems.Count > 0)
			{
				foreach (string p in LbxConvertSaveRamToStates.SelectedItems)
				{
					paths.Add(p);
				}
			}
			else
			{
				foreach (string p in LbxConvertSaveRamToStates.Items)
				{
					paths.Add(p);
				}
			}

			foreach (string path in paths)
			{
				await ConvertSaveRamToState(path).ConfigureAwait(true);
			}
		}

		private void BtnConvertSaveRamToStatesInputPathBrowse_Click(object sender, EventArgs e)
		{
			using var dlg = new FolderBrowserDialog()
			{
				SelectedPath = TbxConvertSaveRamToStatesInputPath.Text
			};

			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.Cancel)
			{
				return;
			}

			TbxConvertSaveRamToStatesInputPath.Text = dlg.SelectedPath;
		}

		private void BtnConvertSaveRamToStatesOutputPathBrowse_Click(object sender, EventArgs e)
		{
			using var dlg = new FolderBrowserDialog()
			{
				SelectedPath = TbxConvertSaveRamToStatesOutputPath.Text
			};

			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.Cancel)
			{
				return;
			}

			TbxConvertSaveRamToStatesOutputPath.Text = dlg.SelectedPath;
		}

		private void BtnConvertSaveRamToStatesRefresh_Click(object sender, EventArgs e)
		{
			RefreshSaveRamList();
		}

		private void BtnConvertStatesToSaveRamInputPathBrowse_Click(object sender, EventArgs e)
		{
			using var dlg = new FolderBrowserDialog()
			{
				SelectedPath = TbxConvertStatesToSaveRamInputPath.Text
			};

			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.Cancel)
			{
				return;
			}

			TbxConvertStatesToSaveRamInputPath.Text = dlg.SelectedPath;
		}

		private void BtnConvertStatesToSaveRamOutputPathBrowse_Click(object sender, EventArgs e)
		{
			using var dlg = new FolderBrowserDialog()
			{
				SelectedPath = TbxConvertStatesToSaveRamOutputPath.Text
			};

			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.Cancel)
			{
				return;
			}

			TbxConvertStatesToSaveRamOutputPath.Text = dlg.SelectedPath;
		}

		private async void BtnConvertStatesToSaveRamGo_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show(
				"This process can't be cancelled once started, will appear to " +
				"lock up the emulator, and may take a long time. Continue?",
				"Confirm save state to SaveRAM conversion",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning);
			if (result == DialogResult.No)
			{
				return;
			}

			if (!Directory.Exists(TbxConvertStatesToSaveRamOutputPath.Text))
			{
				MessageBox.Show(
					"Output directory not found!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			// TODO: Figure out why ListBox.SelectedObjectCollections can't be
			// treated the same as ListBox.ObjectCollections. Seems weird.
			if (LbxConvertStatesToSaveRam.SelectedItems.Count > 0)
			{
				foreach (string path in LbxConvertStatesToSaveRam.SelectedItems)
				{
					await ConvertStateToSaveRam(path).ConfigureAwait(true);
				}
			}
			else
			{
				foreach (string path in LbxConvertStatesToSaveRam.Items)
				{
					await ConvertStateToSaveRam(path).ConfigureAwait(true);
				}
			}
		}

		private void BtnConvertStatesToSaveRamRefresh_Click(object sender, EventArgs e)
		{
			RefreshSaveStateList();
		}

		private void BtnOpenSaveMenu_Click(object sender, EventArgs e)
		{
			Mem.WriteByte(Rom.Addresses.MainRam.ActiveTriggerType, (uint)TriggerType.Save0);
		}

		private void BtnSaveRamExport_Click(object sender, EventArgs e)
		{
			string file = TbxSaveRamExportPath.Text;
			if (!String.IsNullOrEmpty(file))
			{
				ExportSaveRam(file);
			}
		}
		private void BtnSaveRamImport_Click(object sender, EventArgs e)
		{
			string file = TbxSaveRamImportPath.Text;
			if (!String.IsNullOrEmpty(file))
			{
				DialogResult result = MessageBox.Show(
					"Reboot core and replace current SaveRAM?",
					"Core reboot required",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning);
				if (result == DialogResult.No)
				{
					return;
				}

				ImportSaveRam(file);
			}
		}

		private void BtnSaveRamExportBrowse_Click(object sender, EventArgs e)
		{
			using var dlg = new SaveFileDialog()
			{
				Filter = "BizHawk SaveRAM files (*.SaveRAM)|*.SaveRAM|All files (*.*)|*.*",
				RestoreDirectory = true
			};

			DialogResult result = dlg.ShowDialog(this);
			if (result == DialogResult.Cancel)
			{
				return;
			}

			TbxSaveRamExportPath.Text = dlg.FileName;
		}

		private void BtnSaveRamImportBrowse_Click(object sender, EventArgs e)
		{
			using var dlg = new OpenFileDialog()
			{
				Filter = "BizHawk SaveRAM files (*.SaveRAM)|*.SaveRAM|All files (*.*)|*.*",
				RestoreDirectory = true
			};

			DialogResult result = dlg.ShowDialog(this);
			if (result == DialogResult.Cancel)
			{
				return;
			}

			TbxSaveRamImportPath.Text = dlg.FileName;
		}

		private void CmbSaveButton_SelectedValueChanged(object sender, EventArgs e)
		{
			string text = CmbSaveButton.GetItemText(CmbSaveButton.SelectedItem);

			if (!Enum.TryParse(text, out Guts.SaveButton))
			{
				Guts.SaveButton = PsxButtons.None;
			};
		}

		private void CbxSaveRamDanger_CheckedChanged(object sender, EventArgs e)
		{
			if (CbxSaveRamDanger.Checked)
			{
				DialogResult result = MessageBox.Show(
					"SaveRAM is one of the things a save state captures, and " +
					"mixing them can very easily lead to one clobbering the " +
					"other. Please be careful with the below features!",
					"Save states and SaveRAM don't mix!",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Warning);
				if (result == DialogResult.Cancel)
				{
					CbxSaveRamDanger.Checked = false;
					return;
				}
			}

			BtnSaveRamImport.Enabled = CbxSaveRamDanger.Checked;
			TbxSaveRamImportPath.Enabled = CbxSaveRamDanger.Checked;
			BtnSaveRamImportBrowse.Enabled = CbxSaveRamDanger.Checked;

			GbxConvertStatesOrSaveRam.Enabled = CbxSaveRamDanger.Checked;
		}

		private void PbxHazardStripes_SizeChanged(object sender, EventArgs e)
		{
			UpdateStripes();
		}

		private void PbxHazardStripes_VisibleChanged(object sender, EventArgs e)
		{
			UpdateStripes();
		}

		private void TbxConvertSaveRamToStatesInputPath_TextChanged(object sender, EventArgs e)
		{
			RefreshSaveRamList();
		}

		private void TbxConvertStatesToSaveRamInputPath_TextChanged(object sender, EventArgs e)
		{
			RefreshSaveStateList();
		}
	}
}
