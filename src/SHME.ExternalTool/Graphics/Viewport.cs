﻿using System.Drawing;

namespace SHME.ExternalTool
{
	/// <summary>
	/// A substitute for System.Drawing.Rectangle that sets Right and Bottom correctly.
	/// </summary>
	public class Viewport
	{
		private Point _topLeft = new Point(0, 0);
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

		private Point _bottomRight = new Point(319, 223);
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

		public Point Center { get; private set; } = new Point(160, 112);

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
	}
}
