using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void BtnGrabMapGraphic_Click(object sender, EventArgs e)
		{
			List<byte> headerBytes = Mem!.ReadByteRange(Rom.Addresses.MainRam.MapTim, TimHeader.Length);

			TimHeader header;
			try
			{
				header = new TimHeader(headerBytes.ToArray());
			}
			catch (ArgumentException)
			{
				return;
			}

			int timLength = header.ImageHeaderOfs + header.ImageBlockLength;

			List<byte> timBytes = Mem!.ReadByteRange(Rom.Addresses.MainRam.MapTim, timLength);
			var mapGraphic = new Tim(header, timBytes.ToArray());

			PbxMapGraphic.Image = mapGraphic.Bitmap;
			PbxMapGraphic.SizeMode = PictureBoxSizeMode.StretchImage;
			PbxMapGraphic.Width = 640;
		}
	}
}
