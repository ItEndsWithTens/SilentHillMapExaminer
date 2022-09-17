using BizHawk.Emulation.DiscSystem;
using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	// Tremendous thanks to horror_x from http://consolgames.ru/ for their
	// Silent Hill Files Extractor utility, from which most of the details of
	// this process were pulled.

	public class FileRecord
	{
		public const int ChunkSize = 256;

		public int Index { get; }

		public int StartSector { get; }
		public int ChunkCount { get; }
		public int DirectoryIndex { get; }
		public int Name0 { get; }
		public int Name1 { get; }
		public int ExtensionIndex { get; }

		public string Filename { get; }
		public string Directory { get; }
		public int Size { get; }

		public FileRecord(int index, int startSector, int chunkCount, int directoryIndex, int name0, int name1, int extensionIndex, string filename, string directory)
		{
			Index = index;

			StartSector = startSector;
			ChunkCount = chunkCount;
			DirectoryIndex = directoryIndex;
			Name0 = name0;
			Name1 = name1;
			ExtensionIndex = extensionIndex;

			Filename = filename;
			Directory = directory;
			Size = ChunkSize * ChunkCount;
		}

		public override string ToString()
		{
			return $"{Index}: {Filename}";
		}
	}

	public partial class CustomMainForm
	{
		private readonly List<string> _directories = new List<string>();
		private readonly List<string> _extensions = new List<string>();
		private readonly List<FileRecord> _records = new List<FileRecord>();

		private void ExtractFiles(IEnumerable<FileRecord> records, string path, bool createDirectories = false)
		{
			using Disc disc = Disc.LoadAutomagic(MainForm.CurrentlyOpenRom);

			var dsr = new DiscSectorReader(disc);
			dsr.Policy.UserData2048Mode = DiscSectorReaderPolicy.EUserData2048Mode.AssumeMode2_Form1;

			if (createDirectories)
			{
				foreach (FileRecord r in records)
				{
					string trimmed = r.Directory.Trim('\\', '/');
					string full = Path.Combine(path, trimmed);
					if (Directory.Exists(full))
					{
						DialogResult result = MessageBox.Show(
						"One or more existing directories found! Overwrite?",
						"Overwrite existing directories?",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Warning,
						MessageBoxDefaultButton.Button2);

						if (result == DialogResult.Yes)
						{
							break;
						}
						else
						{
							return;
						}
					}
				}
			}
			else
			{
				foreach (FileRecord r in records)
				{
					string full = Path.Combine(path, r.Filename);
					if (File.Exists(full))
					{
						DialogResult result = MessageBox.Show(
						"One or more existing files found! Overwrite?",
						"Overwrite existing files?",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Warning,
						MessageBoxDefaultButton.Button2);

						if (result == DialogResult.Yes)
						{
							break;
						}
						else
						{
							return;
						}
					}
				}
			}

			if (createDirectories)
			{
				foreach (string s in records.Select(r => r.Directory).Distinct())
				{
					string trimmed = s.Trim('\\', '/');
					string full = Path.Combine(path, trimmed);
					Directory.CreateDirectory(full);
				}
			}

			foreach (FileRecord r in records)
			{
				byte[] bytes = RetrieveFile(r, dsr);

				string finalPath;
				if (createDirectories)
				{
					string trimmed = r.Directory.Trim('\\', '/');
					finalPath = Path.Combine(path, trimmed, r.Filename);
				}
				else
				{
					finalPath = Path.Combine(path, r.Filename);
				}

				using FileStream fs = File.OpenWrite(finalPath);
				fs.Write(bytes, 0, bytes.Length);
			}
		}

		private byte[] RetrieveFile(FileRecord r, DiscSectorReader dsr)
		{
			int sectorSize = 2048;
			int totalSectors = (int)Math.Ceiling(r.Size / (double)sectorSize);
			int totalSourceBytes = totalSectors * sectorSize;
			byte[] raw = new byte[totalSourceBytes];

			int start = Rom.BaseLba + r.StartSector;
			for (int j = 0; j < totalSectors; j++)
			{
				dsr.ReadLBA_2048(start + j, raw, sectorSize * j);
			}

			byte[] final = new byte[r.Size];
			Array.Copy(raw, final, final.Length);

			return final;
		}

		private void BtnReadFiles_Click(object sender, EventArgs e)
		{
			_directories.Clear();
			_extensions.Clear();
			_records.Clear();

			LbxFilesDirectories.BeginUpdate();

			LbxFilesDirectories.DataSource = null;
			LbxFilesDirectories.Items.Clear();

			LbxFilesFiles.DataSource = null;
			LbxFilesFiles.Items.Clear();

			long address = Rom.Addresses.MainRam.ArrayOfDirectoryNames;

			var sb = new StringBuilder();
			for (int i = 0; i < 11; i++)
			{
				int sp = Mem.ReadS32(address);
				sp -= (int)Rom.Addresses.MainRam.BaseAddress;

				char c = (char)Mem.ReadS8(sp++);
				while (c != 0)
				{
					sb.Append(c);
					c = (char)Mem.ReadS8(sp++);
				}

				_directories.Add(sb.ToString());

				sb.Clear();

				address += 4;
			}

			address = Rom.Addresses.MainRam.ArrayOfFileExtensions;

			for (int i = 0; i < 12; i++)
			{
				int sp = Mem.ReadS32(address);
				sp -= (int)Rom.Addresses.MainRam.BaseAddress;

				char c = (char)Mem.ReadS8(sp++);
				while (c != 0)
				{
					sb.Append(c);
					c = (char)Mem.ReadS8(sp++);
				}

				_extensions.Add(sb.ToString());

				sb.Clear();

				address += 4;
			}

			address = Rom.Addresses.MainRam.ArrayOfFileRecords;

			// TODO: Is the file record count stored somewhere, or are there
			// just hardcoded assumptions made in each version of the game?
			for (int i = 0; i < 2074; i++)
			{
				int bytes = Mem.ReadS32(address);
				int startSector = bytes & 0b00000000_00000111_11111111_11111111;
				int chunkCount = (int)((bytes & 0b11111111_11111000_00000000_00000000) >> 19);

				address += 4;

				bytes = Mem.ReadS32(address);
				int dirIndex = bytes & 0b00000000_00000000_00000000_00001111;
				int name0 = (bytes & 0b00001111_11111111_11111111_11110000) >> 4;

				address += 4;

				bytes = Mem.ReadS32(address);
				int name1 = bytes & 0b00000000_11111111_11111111_11111111;
				int extIndex = (int)((bytes & 0b11111111_00000000_00000000_00000000) >> 24);

				address += 4;

				int shifted = name0;
				char c = (char)((shifted & 0x3F) + 0x20);
				while (c != ' ')
				{
					sb.Append(c);
					shifted >>= 6;
					c = (char)((shifted & 0x3F) + 0x20);
				}

				shifted = name1;
				c = (char)((shifted & 0x3F) + 0x20);
				while (c != ' ')
				{
					sb.Append(c);
					shifted >>= 6;
					c = (char)((shifted & 0x3F) + 0x20);
				}

				if (extIndex != 0xF)
				{
					sb.Append(_extensions[extIndex]);
				}

				_records.Add(new FileRecord(i,
					startSector, chunkCount,
					dirIndex, name0,
					name1, extIndex,
					sb.ToString(), _directories[dirIndex]));

				sb.Clear();
			}

			LbxFilesDirectories.DataSource = _records
				.Select(r => r.Directory)
				.Distinct()
				.ToList();

			LbxFilesDirectories.EndUpdate();
		}

		private void ExtractSelectedDirectoriesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using var dlg = new FolderBrowserDialog();

			DialogResult result = dlg.ShowDialog(this);

			if (result != DialogResult.OK)
			{
				return;
			}

			var files = new List<FileRecord>();
			foreach (string dir in LbxFilesDirectories.SelectedItems)
			{
				files.AddRange(_records.Where(r => r.Directory == dir));
			}

			ExtractFiles(files, dlg.SelectedPath, true);
		}

		private void ExtractSelectedFilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using var dlg = new FolderBrowserDialog();

			DialogResult result = dlg.ShowDialog(this);

			if (result != DialogResult.OK)
			{
				return;
			}

			ExtractFiles(LbxFilesFiles.SelectedItems.Cast<FileRecord>(), dlg.SelectedPath);
		}

		private void LbxFilesDirectories_SelectedIndexChanged(object sender, EventArgs e)
		{
			LbxFilesFiles.BeginUpdate();

			LbxFilesFiles.DataSource = null;
			LbxFilesFiles.Items.Clear();

			if (LbxFilesDirectories.SelectedItems.Count == 1)
			{
				string dir = (string)LbxFilesDirectories.SelectedItem;
				LbxFilesFiles.DataSource = _records
					.Where(r => r.Directory == dir)
					.ToList();
			}

			LbxFilesFiles.EndUpdate();
		}
	}
}
