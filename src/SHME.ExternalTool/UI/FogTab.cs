using System;
using System.Drawing;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		// Implemented based on https://en.wikipedia.org/wiki/HSL_and_HSV#HSV_to_RGB_alternative
		private static Color HsvToRgb(float h, float s, float v)
		{
			return Color.FromArgb(
				ComponentFromWedge(5.0f, h, s, v),
				ComponentFromWedge(3.0f, h, s, v),
				ComponentFromWedge(1.0f, h, s, v));
		}

		private static int ComponentFromWedge(float wedge, float h, float s, float v)
		{
			float k = (wedge + (h / 60.0f)) % 6.0f;

			float temp = v - (v * s * Math.Max(0.0f, Math.Min(Math.Min(k, 4.0f - k), 1.0f)));

			return (int)(temp * 255.0f);
		}

		private void UpdateFog()
		{
			var colorF = Color.FromArgb((int)NudCustomFogR.Value, (int)NudCustomFogG.Value, (int)NudCustomFogB.Value);
			var colorW = Color.FromArgb((int)NudCustomWorldTintR.Value, (int)NudCustomWorldTintG.Value, (int)NudCustomWorldTintB.Value);

			if (CbxDiscoMode.Checked)
			{
				uint id = Mem.ReadByte(Rom.Addresses.MainRam.Last3DDrawStartID);

				// The range of 'id' is 0 through 63, so 360 / 64 == 5.625.
				float hueF = id * 5.625f;
				float hueW = ((id + 32) % 64) * 5.625f;

				colorF = HsvToRgb(hueF, 1.0f, 1.0f);
				colorW = HsvToRgb(hueW, 1.0f, 1.0f);
			}

			if (!CbxFog.Checked)
			{
				Mem.WriteByte(Rom.Addresses.MainRam.FogEnabled, 0);
			}

			if (CbxCustomFog.Checked)
			{
				Mem.WriteByte(Rom.Addresses.MainRam.FogColorR, colorF.R);
				Mem.WriteByte(Rom.Addresses.MainRam.FogColorG, colorF.G);
				Mem.WriteByte(Rom.Addresses.MainRam.FogColorB, colorF.B);
			}

			if (CbxCustomWorldTint.Checked)
			{
				Mem.WriteByte(Rom.Addresses.MainRam.WorldTintR, colorW.R);
				Mem.WriteByte(Rom.Addresses.MainRam.WorldTintG, colorW.G);
				Mem.WriteByte(Rom.Addresses.MainRam.WorldTintB, colorW.B);
			}
		}

		private void NudFogR_ValueChanged(object sender, EventArgs e)
		{
			BtnFogColor.BackColor = Color.FromArgb(
				(int)NudCustomFogR.Value,
				BtnFogColor.BackColor.G,
				BtnFogColor.BackColor.B);
		}

		private void NudFogG_ValueChanged(object sender, EventArgs e)
		{
			BtnFogColor.BackColor = Color.FromArgb(
				BtnFogColor.BackColor.R,
				(int)NudCustomFogG.Value,
				BtnFogColor.BackColor.B);
		}

		private void NudFogB_ValueChanged(object sender, EventArgs e)
		{
			BtnFogColor.BackColor = Color.FromArgb(
				BtnFogColor.BackColor.R,
				BtnFogColor.BackColor.G,
				(int)NudCustomFogB.Value);
		}

		private void BtnFogColor_Click(object sender, EventArgs e)
		{
			using var dialog = new ColorDialog()
			{
				FullOpen = true,
				Color = Color.FromArgb((int)NudCustomFogR.Value, (int)NudCustomFogG.Value, (int)NudCustomFogB.Value)
			};

			DialogResult result = dialog.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				NudCustomFogR.Value = dialog.Color.R;
				NudCustomFogG.Value = dialog.Color.G;
				NudCustomFogB.Value = dialog.Color.B;
			}
		}

		private void NudWorldTintR_ValueChanged(object sender, EventArgs e)
		{
			BtnWorldTintColor.BackColor = Color.FromArgb(
				(int)NudCustomWorldTintR.Value,
				BtnWorldTintColor.BackColor.G,
				BtnWorldTintColor.BackColor.B);
		}

		private void NudWorldTintG_ValueChanged(object sender, EventArgs e)
		{
			BtnWorldTintColor.BackColor = Color.FromArgb(
				BtnWorldTintColor.BackColor.R,
				(int)NudCustomWorldTintG.Value,
				BtnWorldTintColor.BackColor.B);
		}

		private void NudWorldTintB_ValueChanged(object sender, EventArgs e)
		{
			BtnWorldTintColor.BackColor = Color.FromArgb(
				BtnWorldTintColor.BackColor.R,
				BtnWorldTintColor.BackColor.G,
				(int)NudCustomWorldTintB.Value);
		}

		private void BtnWorldTintColor_Click(object sender, EventArgs e)
		{
			using var dialog = new ColorDialog()
			{
				FullOpen = true,
				Color = Color.FromArgb((int)NudCustomWorldTintR.Value, (int)NudCustomWorldTintG.Value, (int)NudCustomWorldTintB.Value)
			};

			DialogResult result = dialog.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				NudCustomWorldTintR.Value = dialog.Color.R;
				NudCustomWorldTintG.Value = dialog.Color.G;
				NudCustomWorldTintB.Value = dialog.Color.B;
			}
		}

		private void BtnFogColorDefault_Click(object sender, EventArgs e)
		{
			NudCustomFogR.Value = 108;
			NudCustomFogG.Value = 100;
			NudCustomFogB.Value = 116;
		}

		private void BtnWorldTintDefault_Click(object sender, EventArgs e)
		{
			NudCustomWorldTintR.Value = 121;
			NudCustomWorldTintG.Value = 128;
			NudCustomWorldTintB.Value = 138;
		}

		private void BtnCustomFogCurrent_Click(object sender, EventArgs e)
		{
			NudCustomFogR.Value = Mem.ReadByte(Rom.Addresses.MainRam.FogColorR);
			NudCustomFogG.Value = Mem.ReadByte(Rom.Addresses.MainRam.FogColorG);
			NudCustomFogB.Value = Mem.ReadByte(Rom.Addresses.MainRam.FogColorB);
		}

		private void BtnCustomWorldTintCurrent_Click(object sender, EventArgs e)
		{
			NudCustomWorldTintR.Value = Mem.ReadByte(Rom.Addresses.MainRam.WorldTintR);
			NudCustomWorldTintG.Value = Mem.ReadByte(Rom.Addresses.MainRam.WorldTintG);
			NudCustomWorldTintB.Value = Mem.ReadByte(Rom.Addresses.MainRam.WorldTintB);
		}

		private void BtnFogWorldTintColorSwap_Click(object sender, EventArgs e)
		{
			(NudCustomFogR.Value, NudCustomWorldTintR.Value) = (NudCustomWorldTintR.Value, NudCustomFogR.Value);
			(NudCustomFogG.Value, NudCustomWorldTintG.Value) = (NudCustomWorldTintG.Value, NudCustomFogG.Value);
			(NudCustomFogB.Value, NudCustomWorldTintB.Value) = (NudCustomWorldTintB.Value, NudCustomFogB.Value);
		}

		private void CbxDiscoMode_CheckedChanged(object sender, EventArgs e)
		{
			if (CbxDiscoMode.Checked)
			{
				CbxCustomFog.Checked = true;
				CbxCustomWorldTint.Checked = true;
			}
		}
	}
}
