using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SHME.ExternalTool
{
	public class BetterPictureBox : PictureBox
	{
		private InterpolationMode _interpolationMode;
		[Category("Behavior")]
		public InterpolationMode InterpolationMode
		{
			get => _interpolationMode;
			set
			{
				_interpolationMode = value;
				Invalidate();
			}
		}

		private PixelOffsetMode _pixelOffsetMode;
		[Category("Behavior")]
		public PixelOffsetMode PixelOffsetMode
		{
			get => _pixelOffsetMode;
			set
			{
				_pixelOffsetMode = value;
				Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			if (pe == null)
			{
				return;
			}

			pe.Graphics.InterpolationMode = InterpolationMode;
			pe.Graphics.PixelOffsetMode = PixelOffsetMode;
			base.OnPaint(pe);
		}
	}
}
