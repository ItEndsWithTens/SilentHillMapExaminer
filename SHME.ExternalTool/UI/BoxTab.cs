using SHME.ExternalTool;
using System;
using System.Numerics;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void BtnBoxGetPosition_Click(object sender, EventArgs e)
		{
			NudBoxX.Text = LblBoxX.Text;
			NudBoxY.Text = LblBoxY.Text;
			NudBoxZ.Text = LblBoxZ.Text;
		}

		private void BtnBoxSetPosition_Click(object sender, EventArgs e)
		{
			Boxes[0].Position = new Vector3(
				(float)NudBoxX.Value,
				-(float)NudBoxY.Value,
				(float)NudBoxZ.Value);
		}

		private void NudBoxX_ValueChanged(object sender, EventArgs e)
		{
			Renderable box = Boxes[0];

			box.Position = new Vector3(
				(float)NudBoxX.Value,
				box.Position.Y,
				box.Position.Z);
		}

		private void NudBoxY_ValueChanged(object sender, EventArgs e)
		{
			Renderable box = Boxes[0];

			box.Position = new Vector3(
				box.Position.X,
				-(float)NudBoxY.Value, // Convert to SH coordinate space
				box.Position.Z);
		}

		private void NudBoxZ_ValueChanged(object sender, EventArgs e)
		{
			Renderable box = Boxes[0];

			box.Position = new Vector3(
				box.Position.X,
				box.Position.Y,
				(float)NudBoxZ.Value);
		}
	}
}
