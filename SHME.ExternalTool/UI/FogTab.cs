using System;
using System.Drawing;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void UpdateFog()
		{
			if (!CbxFog.Checked)
			{
				Mem?.WriteByte(Rom.Addresses.MainRam.FogEnabled, 0);
			}

			if (CbxFogCustom.Checked)
			{
				Mem?.WriteByte(Rom.Addresses.MainRam.FogColorR, (byte)NudFogR.Value);
				Mem?.WriteByte(Rom.Addresses.MainRam.FogColorG, (byte)NudFogG.Value);
				Mem?.WriteByte(Rom.Addresses.MainRam.FogColorB, (byte)NudFogB.Value);
			}

			if (CbxCustomWorldTint.Checked)
			{
				Mem?.WriteByte(Rom.Addresses.MainRam.WorldTintR, (byte)NudWorldTintR.Value);
				Mem?.WriteByte(Rom.Addresses.MainRam.WorldTintG, (byte)NudWorldTintG.Value);
				Mem?.WriteByte(Rom.Addresses.MainRam.WorldTintB, (byte)NudWorldTintB.Value);
			}
		}

		private void NudFogR_ValueChanged(object sender, EventArgs e)
		{
			BtnFogColor.BackColor = Color.FromArgb(
				(int)NudFogR.Value,
				BtnFogColor.BackColor.G,
				BtnFogColor.BackColor.B);
		}

		private void NudFogG_ValueChanged(object sender, EventArgs e)
		{
			BtnFogColor.BackColor = Color.FromArgb(
				BtnFogColor.BackColor.R,
				(int)NudFogG.Value,
				BtnFogColor.BackColor.B);
		}

		private void NudFogB_ValueChanged(object sender, EventArgs e)
		{
			BtnFogColor.BackColor = Color.FromArgb(
				BtnFogColor.BackColor.R,
				BtnFogColor.BackColor.G,
				(int)NudFogB.Value);
		}

		private void BtnFogColor_Click(object sender, EventArgs e)
		{
			var dialog = new ColorDialog();
			DialogResult result = dialog.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				NudFogR.Value = dialog.Color.R;
				NudFogG.Value = dialog.Color.G;
				NudFogB.Value = dialog.Color.B;
			}
		}

		private void NudWorldTintR_ValueChanged(object sender, EventArgs e)
		{
			BtnWorldTintColor.BackColor = Color.FromArgb(
				(int)NudWorldTintR.Value,
				BtnWorldTintColor.BackColor.G,
				BtnWorldTintColor.BackColor.B);
		}

		private void NudWorldTintG_ValueChanged(object sender, EventArgs e)
		{
			BtnWorldTintColor.BackColor = Color.FromArgb(
				BtnWorldTintColor.BackColor.R,
				(int)NudWorldTintG.Value,
				BtnWorldTintColor.BackColor.B);
		}

		private void NudWorldTintB_ValueChanged(object sender, EventArgs e)
		{
			BtnWorldTintColor.BackColor = Color.FromArgb(
				BtnWorldTintColor.BackColor.R,
				BtnWorldTintColor.BackColor.G,
				(int)NudWorldTintB.Value);
		}

		private void BtnWorldTintColor_Click(object sender, EventArgs e)
		{
			var dialog = new ColorDialog();
			DialogResult result = dialog.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				NudWorldTintR.Value = dialog.Color.R;
				NudWorldTintG.Value = dialog.Color.G;
				NudWorldTintB.Value = dialog.Color.B;
			}
		}

		private void BtnFogColorDefault_Click(object sender, EventArgs e)
		{
			NudFogR.Value = 108;
			NudFogG.Value = 100;
			NudFogB.Value = 116;
		}

		private void BtnWorldTintDefault_Click(object sender, EventArgs e)
		{
			NudWorldTintR.Value = 121;
			NudWorldTintG.Value = 128;
			NudWorldTintB.Value = 138;
		}

		private void BtnCustomFogCurrent_Click(object sender, EventArgs e)
		{
			NudFogR.Value = Mem.ReadByte(Rom.Addresses.MainRam.FogColorR);
			NudFogG.Value = Mem.ReadByte(Rom.Addresses.MainRam.FogColorG);
			NudFogB.Value = Mem.ReadByte(Rom.Addresses.MainRam.FogColorB);
		}

		private void BtnCustomWorldTintCurrent_Click(object sender, EventArgs e)
		{
			NudWorldTintR.Value = Mem.ReadByte(Rom.Addresses.MainRam.WorldTintR);
			NudWorldTintG.Value = Mem.ReadByte(Rom.Addresses.MainRam.WorldTintG);
			NudWorldTintB.Value = Mem.ReadByte(Rom.Addresses.MainRam.WorldTintB);
		}
	}
}
