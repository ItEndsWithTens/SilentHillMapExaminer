using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SHME.ExternalTool
{
	public class TimHeader
	{
		public static int Length { get; } = 544;

		/// <summary>
		/// TIM format identifier
		/// </summary>
		/// <remarks>Always 0x10</remarks>
		public char ID { get; private set; }

		/// <summary>
		/// TIM format version
		/// </summary>
		/// <remarks>Always 0x00</remarks>
		public char Version { get; private set; }

		/// <summary>
		/// Pixel mode
		/// </summary>
		/// <remarks>
		/// 0: 4-bit CLUT <br />
		/// 1: 8-bit CLUT <br />
		/// 2: 15-bit direct <br />
		/// 3: 24-bit direct <br />
		/// 4: Mixed
		/// </remarks>
		public int Pmode { get; private set; }

		/// <summary>
		/// Has CLUT
		/// </summary>
		/// <remarks>
		/// 0: No <br />
		/// 1: Yes
		/// </remarks>
		public bool CF { get; private set; }

		public int ClutHeaderOfs;

		/// <summary>
		/// Data length of CLUT block (including 4 byte Bnum)
		/// </summary>
		public int ClutBlockLength { get; private set; }

		/// <summary>
		/// X coordinate in frame buffer
		/// </summary>
		public short ClutFrameBufferX { get; private set; }
		/// <summary>
		/// // Y coordinate in frame buffer
		/// </summary>
		public short ClutFrameBufferY { get; private set; }

		/// <summary>
		/// Data height
		/// </summary>
		public short ClutDataHeight { get; private set; }
		/// <summary>
		/// Data width
		/// </summary>
		public short ClutDataWidth { get; private set; }

		public int ImageHeaderOfs { get; private set; }

		public int ImageBlockLength { get; private set; }

		public short ImageFrameBufferX { get; private set; }
		public short ImageFrameBufferY { get; private set; }

		public short ImageFrameBufferWidth { get; private set; }
		public short ImageFrameBufferHeight { get; private set; }

		public TimHeader(byte[] headerBytes)
		{
			ID = BitConverter.ToChar(headerBytes, 0);
			Version = BitConverter.ToChar(headerBytes, 1);

			if (ID != 0x10 || Version != 0x00)
			{
				throw new ArgumentException("Byte array is not a TIM header!");
			}

			int flagWord = BitConverter.ToInt32(headerBytes, 4);
			Pmode = flagWord & 0b00000111;
			CF = (flagWord & 0b00001000 >> 3) == 1;

			ClutHeaderOfs = 8;

			ClutBlockLength = BitConverter.ToInt32(headerBytes, ClutHeaderOfs + 0);
			ClutFrameBufferX = BitConverter.ToInt16(headerBytes, ClutHeaderOfs + 4);
			ClutFrameBufferY = BitConverter.ToInt16(headerBytes, ClutHeaderOfs + 6);
			ClutDataWidth = BitConverter.ToInt16(headerBytes, ClutHeaderOfs + 8);
			ClutDataHeight = BitConverter.ToInt16(headerBytes, ClutHeaderOfs + 10);

			ImageHeaderOfs = ClutHeaderOfs + ClutBlockLength;

			ImageBlockLength = BitConverter.ToInt32(headerBytes, ImageHeaderOfs + 0);
			ImageFrameBufferX = BitConverter.ToInt16(headerBytes, ImageHeaderOfs + 4);
			ImageFrameBufferY = BitConverter.ToInt16(headerBytes, ImageHeaderOfs + 6);
			ImageFrameBufferWidth = BitConverter.ToInt16(headerBytes, ImageHeaderOfs + 8);
			ImageFrameBufferHeight = BitConverter.ToInt16(headerBytes, ImageHeaderOfs + 10);
		}
	}

	public sealed class Tim : IDisposable
	{
		public TimHeader Header { get; }

		public byte[] ClutBytes { get; }

		public byte[] ImageBytes { get; }

		public List<Color> Clut { get; } = new List<Color>();
		public Bitmap Bitmap { get; }

		public Tim(TimHeader h, byte[] bytes)
		{
			Header = h;

			int clutHeaderLength = 12;
			ClutBytes = bytes.Skip(h.ClutHeaderOfs + clutHeaderLength).Take(h.ClutBlockLength - clutHeaderLength).ToArray();

			LoadClut();

			int imageHeaderLength = 12;
			ImageBytes = bytes.Skip(h.ImageHeaderOfs + imageHeaderLength).Take(h.ImageBlockLength - imageHeaderLength).ToArray();

			var size = new Size(h.ImageFrameBufferWidth, h.ImageFrameBufferHeight);
			if (Header.Pmode == 1)
			{
				size.Width = h.ImageFrameBufferWidth * 2;
			}
			Bitmap = new Bitmap(size.Width, size.Height);

			LoadPixels();
		}

		private Color InterpretClutColor(short entry)
		{
			int rBase = (entry & 0b00000000_00011111) >> 0;
			int gBase = (entry & 0b00000011_11100000) >> 5;
			int bBase = (entry & 0b01111100_00000000) >> 10;
			int aBase = (entry & 0b10000000_00000000) >> 15;

			int r = (int)Math.Round(Utility.ScaleToRange(rBase, 0, 32, 0, 255));
			int g = (int)Math.Round(Utility.ScaleToRange(gBase, 0, 32, 0, 255));
			int b = (int)Math.Round(Utility.ScaleToRange(bBase, 0, 32, 0, 255));

			int a;
			// Black handling based on table 3-1, in section 3-4, in the
			// March 2000 revision of File Format 47.pdf, the Sony "File
			// Formats" manual.
			if (aBase == 1)
			{
				if (r == 0 && g == 0 && b == 0)
				{
					a = 255;
				}
				else
				{
					a = 127;
				}
			}
			else
			{
				if (r == 0 && g == 0 && b == 0)
				{
					a = 0;
				}
				else
				{
					a = 255;
				}
			}

			return Color.FromArgb(a, r, g, b);
		}

		private void LoadClut()
		{
			int bytesPerRow = Header.ClutDataWidth * sizeof(short);

			for (int y = 0; y < Header.ClutDataHeight; y++)
			{
				int row = bytesPerRow * y;

				for (int x = 0; x < bytesPerRow; x += sizeof(int))
				{
					int pair = BitConverter.ToInt32(ClutBytes, row + x);

					short entry0 = (short)((pair & 0b00000000_00000000_11111111_11111111) >> 0);
					short entry1 = (short)((pair & 0b11111111_11111111_00000000_00000000) >> 16);

					Clut.Add(InterpretClutColor(entry0));
					Clut.Add(InterpretClutColor(entry1));
				}
			}
		}

		private void LoadPixels()
		{
			if (Header.Pmode == 1)
			{
				var pixels = new List<Color>();

				int bytesPerRow = Header.ImageFrameBufferWidth * sizeof(short);

				for (int y = 0; y < Header.ImageFrameBufferHeight; y++)
				{
					int row = bytesPerRow * y;

					for (int x = 0; x < bytesPerRow; x += sizeof(int))
					{
						int group = BitConverter.ToInt32(ImageBytes, row + x);

						short pair0 = (short)((group & 0b00000000_00000000_11111111_11111111) >> 0);
						short pair1 = (short)((group & 0b11111111_11111111_00000000_00000000) >> 16);

						int index0 = (pair0 & 0b00000000_11111111) >> 0;
						int index1 = (pair0 & 0b11111111_00000000) >> 8;

						int index2 = (pair1 & 0b00000000_11111111) >> 0;
						int index3 = (pair1 & 0b11111111_00000000) >> 8;

						pixels.Add(Clut[index0]);
						pixels.Add(Clut[index1]);
						pixels.Add(Clut[index2]);
						pixels.Add(Clut[index3]);
					}
				}

				for (int y = 0; y < Bitmap.Height; y++)
				{
					for (int x = 0; x < Bitmap.Width; x++)
					{
						Bitmap.SetPixel(x, y, pixels[Bitmap.Width * y + x]);
					}
				}
			}
		}

		public void Dispose()
		{
			Bitmap.Dispose();
		}
	}
}
