using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void BtnModelGetHarryPosition_Click(object sender, EventArgs e)
		{
			List<float> position = Core.GetPosition(Mem!);

			NudModelX.Text = position[0].ToString("N2");
			NudModelY.Text = position[1].ToString("N2");
			NudModelZ.Text = position[2].ToString("N2");
		}

		private void BtnModelSetModelPosition_Click(object sender, EventArgs e)
		{
			var aabb = new Aabb(ModelBoxes);

			var target = new Vector3(
				(float)NudModelX.Value,
				-(float)NudModelY.Value,
				-(float)NudModelZ.Value);

			Vector3 diff = target - aabb.Center;

			foreach (Renderable box in ModelBoxes)
			{
				box.Position += diff;
			}
		}

		private void NudModelX_ValueChanged(object sender, EventArgs e)
		{
			if (ModelBoxes.Count == 0)
			{
				return;
			}

			var aabb = new Aabb(ModelBoxes);

			var target = new Vector3(
					(float)NudModelX.Value,
					aabb.Center.Y,
					aabb.Center.Z);

			Vector3 diff = target - aabb.Center;

			foreach (Renderable box in ModelBoxes)
			{
				box.Position += diff;
			}
		}

		private void NudModelY_ValueChanged(object sender, EventArgs e)
		{
			if (ModelBoxes.Count == 0)
			{
				return;
			}

			var aabb = new Aabb(ModelBoxes);

			var target = new Vector3(
					aabb.Center.X,
					-(float)NudModelY.Value, // Convert to SH coordinate space
					aabb.Center.Z);

			Vector3 diff = target - aabb.Center;

			foreach (Renderable box in ModelBoxes)
			{
				box.Position += diff;
			}
		}

		private void NudModelZ_ValueChanged(object sender, EventArgs e)
		{
			if (ModelBoxes.Count == 0)
			{
				return;
			}

			var aabb = new Aabb(ModelBoxes);

			var target = new Vector3(
					aabb.Center.X,
					aabb.Center.Y,
					-(float)NudModelZ.Value);

			Vector3 diff = target - aabb.Center;

			foreach (Renderable box in ModelBoxes)
			{
				box.Position += diff;
			}
		}

		private Ilm? Model { get; set; }
		private List<Renderable> ModelBoxes { get; } = new List<Renderable>();

		private void BtnReadHarryModel_Click(object sender, EventArgs e)
		{
			int harryModelAddressRaw = Mem!.ReadS32(Rom.Addresses.MainRam.HarryModelPointer);

			int harryModelAddress = harryModelAddressRaw - (int)Rom.Addresses.MainRam.BaseAddress;

			List<byte> headerBytes = Mem!.ReadByteRange(harryModelAddress, IlmHeader.Length);

			IlmHeader header;
			try
			{
				header = new IlmHeader(headerBytes, harryModelAddressRaw);
			}
			catch (ArgumentException)
			{
				return;
			}

			// Can't get an actual stream from ApiHawk, but this'll do nicely.
			List<byte> remaining = Mem!.ReadByteRange(harryModelAddress, (int)(Mem!.GetMemoryDomainSize() - harryModelAddress));

			Model = new Ilm(header, remaining, TrkModelScale.Value);

			var generator = new BoxGenerator(0.025f, Color.Yellow);

			bool all = CmbModelSubmeshName.Text == "*";
			ModelBoxes.Clear();
			foreach (Submesh submesh in Model.Submeshes)
			{
				if (!all && submesh.Name != CmbModelSubmeshName.Text.ToUpper())
				{
					continue;
				}

				foreach (Vector3 vertex in submesh.Vertices)
				{
					Renderable box = generator.Generate().ToWorld();

					box.Position = new Vector3(vertex.X, -vertex.Y, vertex.Z);

					ModelBoxes.Add(box);
				}

				if (!all)
				{
					break;
				}
			}
		}

		private void CbxEnableModelDisplay_CheckedChanged(object sender, EventArgs e)
		{
			if (!CbxEnableModelDisplay.Checked)
			{
				Gui!.DrawNew("emu");
				Gui!.ClearGraphics();
				Gui!.DrawFinish();
			}
		}

		private void TrkModelScale_Scroll(object sender, System.EventArgs e)
		{
			LblModelScale.Text = TrkModelScale.Value.ToString();
		}
	}
}
