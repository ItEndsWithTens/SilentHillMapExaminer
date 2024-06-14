using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private int _framebufferGrabOriginalW;
		private int _framebufferGrabOriginalH;

		private void InitializeFramebufferTab()
		{
			var zooms = new List<Tuple<double, string>>()
			{
				Tuple.Create(0.25, "25%"),
				Tuple.Create(0.5, "50%"),
				Tuple.Create(0.75, "75%"),
				Tuple.Create(1.0, "100%"),
				Tuple.Create(1.25, "125%"),
				Tuple.Create(1.5, "150%"),
				Tuple.Create(2.0, "200%"),
				Tuple.Create(3.0, "300%"),
				Tuple.Create(4.0, "400%"),
			};

			CmbFramebufferZoom.DataSource = zooms;
			CmbFramebufferZoom.ValueMember = "Item1";
			CmbFramebufferZoom.DisplayMember = "Item2";
		}

		private void SetFramebufferZoom()
		{
			double factor = ((Tuple<double, string>)CmbFramebufferZoom.SelectedItem).Item1;

			BpbFramebuffer.Width = (int)(_framebufferGrabOriginalW * factor);
			BpbFramebuffer.Height = (int)(_framebufferGrabOriginalH * factor);
		}

		private void BtnFramebufferGrab_Click(object sender, EventArgs e)
		{
			int width = (int)NudFramebufferW.Value;
			int height = (int)NudFramebufferH.Value;
			var format = PixelFormat.Format32bppArgb;

			var bmp = new Bitmap(width, height, format);

			const int framebufferWidth = 1024;
			const int bytesPerPixel = 2;
			int pitch = framebufferWidth * bytesPerPixel;

			int start = ((int)NudFramebufferOfsY.Value * pitch) + ((int)NudFramebufferOfsX.Value * bytesPerPixel);

			BitmapData data = bmp.LockBits(
				new Rectangle(0, 0, bmp.Width, bmp.Height),
				ImageLockMode.WriteOnly,
				PixelFormat.Format32bppArgb);

			string previousDomain = Mem.GetCurrentMemoryDomain();
			Mem.UseMemoryDomain("GPURAM");
			for (int y = 0; y < height; y++)
			{
				byte[] scanline = Mem.ReadByteRange(start, bytesPerPixel * width).ToArray();

				for (int x = 0; x < width; x++)
				{
					int pixel = BitConverter.ToInt16(scanline, x * 2);

					// This is the inverse of code in ApplyOverlayToFramebuffer,
					// going in the other direction. The first shift scales the
					// component to an 8-bit value, and the second packs said
					// value into the final ARGB pixel.
					//
					// r = (original << 3) << 16
					// g = (original >> 2) << 8
					// b = (original >> 7)
					int r = (pixel & 0b00000000_00011111) << 19;
					int g = (pixel & 0b00000011_11100000) << 6;
					int b = (pixel & 0b01111100_00000000) >> 7;

					int ofs = (y * data.Stride) + (x * 4);
					Marshal.WriteInt32(data.Scan0 + ofs, 255 << 24 | r | g | b);
				}

				start += pitch;
			}
			Mem.UseMemoryDomain(previousDomain);

			bmp.UnlockBits(data);

			BpbFramebuffer.Image?.Dispose();
			BpbFramebuffer.Image = bmp;

			_framebufferGrabOriginalW = width;
			_framebufferGrabOriginalH = height;

			SetFramebufferZoom();
		}

		private void BtnFramebufferSave_Click(object sender, EventArgs e)
		{
			if (BpbFramebuffer.Image == null)
			{
				return;
			}

			var formats = new Dictionary<string, ImageFormat>()
			{
				{ ".bmp", ImageFormat.Bmp },
				{ ".gif", ImageFormat.Gif },
				{ ".jpg", ImageFormat.Jpeg },
				{ ".jpeg", ImageFormat.Jpeg },
				{ ".png", ImageFormat.Png },
				{ ".tiff", ImageFormat.Tiff }
			};

			using var dlg = new SaveFileDialog()
			{
				Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png|TIFF (*.tiff)|*.tiff|All files (*.*)|*.*",
				FilterIndex = 4,
				RestoreDirectory = true
			};

			DialogResult result = dlg.ShowDialog(this);

			if (result != DialogResult.OK)
			{
				return;
			}

			string ext = Path.GetExtension(dlg.FileName).ToLower();
			BpbFramebuffer.Image.Save(dlg.FileName, formats[ext]);
		}

		private void BtnFramebufferZoomIn_Click(object sender, EventArgs e)
		{
			int zoomed = CmbFramebufferZoom.SelectedIndex + 1;

			if (zoomed <= CmbFramebufferZoom.Items.Count - 1)
			{
				CmbFramebufferZoom.SelectedIndex = zoomed;
			}
		}
		private void BtnFramebufferZoomOut_Click(object sender, EventArgs e)
		{
			int zoomed = CmbFramebufferZoom.SelectedIndex - 1;

			if (zoomed >= 0)
			{
				CmbFramebufferZoom.SelectedIndex = zoomed;
			}
		}

		private void CmbFramebufferZoom_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetFramebufferZoom();
		}

		private void NudFramebuffer_KeyDown(object sender, KeyEventArgs e)
		{
			if (sender is NumericUpDown nud && e.KeyCode == Keys.Enter)
			{
				nud.ResetIfBad(this);
				BtnFramebufferGrab_Click(this, EventArgs.Empty);
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void NudFramebuffer_ValueChanged(object sender, EventArgs e)
		{
			BtnFramebufferGrab_Click(this, EventArgs.Empty);
		}
	}
}
