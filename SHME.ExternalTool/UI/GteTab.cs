using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void GetRegisterTest()
		{
			ulong? blar = Emulation.GetRegister("r17");


			var breakvar = 4;

			LblRegisterTest.Text = blar.ToString();
		}

		private void ReportMisc()
		{
			LblGteX.Text = Core.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.GteTranslationInputX)).ToString();
			LblGteY.Text = Core.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.GteTranslationInputY)).ToString();
			LblGteZ.Text = Core.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.GteTranslationInputZ)).ToString();

			int mat11 = (Mem.ReadS32(Rom.Addresses.MainRam.Mat11_12) & 0b00000000_11111111) >> 0;
			int mat12 = (Mem.ReadS32(Rom.Addresses.MainRam.Mat11_12) & 0b11111111_00000000) >> 8;

			int mat13 = (Mem.ReadS32(Rom.Addresses.MainRam.Mat13_21) & 0b00000000_11111111) >> 0;
			int mat21 = (Mem.ReadS32(Rom.Addresses.MainRam.Mat13_21) & 0b11111111_00000000) >> 8;

			int mat22 = (Mem.ReadS32(Rom.Addresses.MainRam.Mat22_23) & 0b00000000_11111111) >> 0;
			int mat23 = (Mem.ReadS32(Rom.Addresses.MainRam.Mat22_23) & 0b11111111_00000000) >> 8;

			int mat31 = (Mem.ReadS32(Rom.Addresses.MainRam.Mat31_32) & 0b00000000_11111111) >> 0;
			int mat32 = (Mem.ReadS32(Rom.Addresses.MainRam.Mat31_32) & 0b11111111_00000000) >> 8;

			int mat33 = (Mem.ReadS32(Rom.Addresses.MainRam.Mat33) & 0b00000000_11111111) >> 0;

			LblMatrix11.Text = Core.QToFloat(mat11).ToString();
			LblMatrix12.Text = Core.QToFloat(mat12).ToString();
			LblMatrix13.Text = Core.QToFloat(mat13).ToString();

			LblMatrix21.Text = Core.QToFloat(mat21).ToString();
			LblMatrix22.Text = Core.QToFloat(mat22).ToString();
			LblMatrix23.Text = Core.QToFloat(mat23).ToString();

			LblMatrix31.Text = Core.QToFloat(mat31).ToString();
			LblMatrix32.Text = Core.QToFloat(mat32).ToString();
			LblMatrix33.Text = Core.QToFloat(mat33).ToString();

			LblCalculatedPitch.Text = (Math.Asin(mat31) * (180.0 / Math.PI)).ToString();
			LblCalculatedYaw.Text = (Math.Atan2(mat21, mat11) * (180.0 / Math.PI)).ToString();
			LblCalculatedRoll.Text = (Math.Atan2(mat32, mat33) * (180.0 / Math.PI)).ToString();
		}
	}
}
