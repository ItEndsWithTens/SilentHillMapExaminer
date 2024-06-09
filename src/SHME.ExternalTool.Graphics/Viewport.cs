using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SHME.ExternalTool.Graphics
{
	/// <summary>
	/// A substitute for System.Drawing.Rectangle that sets Right and Bottom correctly.
	/// </summary>
	public class Viewport
	{
		private Point _topLeft = new(0, 0);
		public Point TopLeft
		{
			get => _topLeft;
			set
			{
				_topLeft = value;
				Center = new Point(Left + Width / 2, Top + Height / 2);
				_bottomRight = new Point(Left + Width - 1, Top + Height - 1);
			}
		}

		private int _width = 1;
		public int Width
		{
			get => _width;
			set
			{
				_width = value;
				Center = new Point(Left + Width / 2, Top + Height / 2);
				_bottomRight = new Point(Left + value - 1, Bottom);
			}
		}

		private int _height = 1;
		public int Height
		{
			get => _height;
			set
			{
				_height = value;
				Center = new Point(Left + Width / 2, Top + Height / 2);
				_bottomRight = new Point(Right, Top + value - 1);
			}
		}

		private Point _bottomRight = new(319, 223);
		public Point BottomRight
		{
			get => _bottomRight;
			private set
			{
				_bottomRight = value;
				Center = new Point(Left + Width / 2, Top + Height / 2);
				_width = value.X + 1 - _topLeft.X;
				_height = value.Y + 1 - _topLeft.Y;
			}
		}

		public int Left => TopLeft.X;
		public int Top => TopLeft.Y;
		public int Right => BottomRight.X;
		public int Bottom => BottomRight.Y;

		public Point Center { get; private set; } = new(160, 112);

		public Viewport()
		{
		}
		public Viewport(Point topLeft, Point bottomRight)
		{
			Width = bottomRight.X + 1 - topLeft.X;
			Height = bottomRight.Y + 1 - topLeft.Y;
			TopLeft = topLeft;
			BottomRight = bottomRight;
		}
		public Viewport(int left, int top, int width, int height)
		{
			Width = width;
			Height = height;
			TopLeft = new Point(left, top);
			BottomRight = new Point(left + width - 1, top + height - 1);
		}

		/// <summary>
		/// Create a Viewport based on an input Bitmap, assuming said input has
		/// image content surrounded by a solid color border.
		/// </summary>	
		public static Viewport FromBitmap(Bitmap bmp, Color backgroundColor)
		{
			Viewport viewport = new(0, 0, bmp.Width, bmp.Height);

			int halfWidth = bmp.Width / 2;
			int halfHeight = bmp.Height / 2;

			const int BytesPerPixel = 4;
			const int Mask = 0xFFFFFF;

			int rgb = backgroundColor.ToArgb() & Mask;

			BitmapData data = bmp.LockBits(
				new Rectangle(0, 0, bmp.Width, bmp.Height),
				ImageLockMode.ReadOnly,
				PixelFormat.Format32bppArgb);

			for (int x = 0; x < halfWidth; x++)
			{
				int ofs = (data.Stride * halfHeight) + (BytesPerPixel * x);
				int pixel = Marshal.ReadInt32(data.Scan0, ofs);

				if ((pixel & Mask) != rgb)
				{
					Point tl = viewport.TopLeft;
					tl.X = x;
					viewport.TopLeft = tl;
					break;
				}
			}

			for (int y = 0; y < halfHeight; y++)
			{
				int ofs = (data.Stride * y) + (BytesPerPixel * halfWidth);
				int pixel = Marshal.ReadInt32(data.Scan0, ofs);

				if ((pixel & Mask) != rgb)
				{
					Point tl = viewport.TopLeft;
					tl.Y = y;
					viewport.TopLeft = tl;
					break;
				}
			}

			for (int x = bmp.Width - 1; x > halfWidth; x--)
			{
				int ofs = (data.Stride * halfHeight) + (BytesPerPixel * x);
				int pixel = Marshal.ReadInt32(data.Scan0, ofs);

				if ((pixel & Mask) != rgb)
				{
					viewport.Width = x - viewport.Left + 1;
					break;
				}
			}

			for (int y = bmp.Height - 1; y > halfHeight; y--)
			{
				int ofs = (data.Stride * y) + (BytesPerPixel * halfWidth);
				int pixel = Marshal.ReadInt32(data.Scan0, ofs);

				if ((pixel & Mask) != rgb)
				{
					viewport.Height = y - viewport.Top + 1;
					break;
				}
			}

			bmp.UnlockBits(data);

			return viewport;
		}
	}
}
