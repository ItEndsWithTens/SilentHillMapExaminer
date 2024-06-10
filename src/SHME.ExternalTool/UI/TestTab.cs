using BizHawk.Client.Common;
using SHME.ExternalTool;
using SHME.ExternalTool.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void BtnModelGetHarryPosition_Click(object sender, EventArgs e)
		{
			(Vector3 harry, _) = GetPosition();

			NudTestModelX.Value = (int)harry.X;
			NudTestModelY.Value = (int)harry.Y;
			NudTestModelZ.Value = (int)harry.Z;
		}

		private void BtnModelSetModelPosition_Click(object sender, EventArgs e)
		{
			var aabb = new Aabb(Guts.ModelBoxes);

			var target = new Vector3(
				(float)NudTestModelX.Value,
				-(float)NudTestModelY.Value,
				-(float)NudTestModelZ.Value);

			Vector3 diff = target - aabb.Center;

			foreach (Renderable box in Guts.ModelBoxes)
			{
				box.Position += diff;
			}
		}

		private void NudModel_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				BtnModelSetModelPosition_Click(sender, EventArgs.Empty);
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void NudOverlayTestBoxX_ValueChanged(object sender, EventArgs e)
		{
			Guts.TestBox.Position = new Vector3(
				(float)NudTestBoxX.Value,
				Guts.TestBox.Position.Y,
				Guts.TestBox.Position.Z);
		}

		private void NudOverlayTestBoxY_ValueChanged(object sender, EventArgs e)
		{
			Guts.TestBox.Position = new Vector3(
				Guts.TestBox.Position.X,
				-(float)NudTestBoxY.Value, // Convert from SH coords
				Guts.TestBox.Position.Z);
		}

		private void NudOverlayTestBoxZ_ValueChanged(object sender, EventArgs e)
		{
			Guts.TestBox.Position = new Vector3(
				Guts.TestBox.Position.X,
				Guts.TestBox.Position.Y,
				-(float)NudTestBoxZ.Value); // Convert from SH coords
		}

		private void NudOverlayTestBoxSizeX_ValueChanged(object sender, EventArgs e)
		{
			Renderable rainbow = new BoxGenerator(
				(float)NudTestBoxSizeX.Value,
				Math.Abs(Guts.TestBox.Aabb.Max.Y - Guts.TestBox.Aabb.Min.Y),
				Math.Abs(Guts.TestBox.Aabb.Max.Z - Guts.TestBox.Aabb.Min.Z),
				Color.White).GenerateRainbowBox().ToWorld();

			rainbow.Position = Guts.TestBox.Position;

			Guts.TestBox = rainbow;
		}

		private void NudOverlayTestBoxSizeY_ValueChanged(object sender, EventArgs e)
		{
			Renderable rainbow = new BoxGenerator(
				Math.Abs(Guts.TestBox.Aabb.Max.X - Guts.TestBox.Aabb.Min.X),
				(float)NudTestBoxSizeY.Value,
				Math.Abs(Guts.TestBox.Aabb.Max.Z - Guts.TestBox.Aabb.Min.Z),
				Color.White).GenerateRainbowBox().ToWorld();

			rainbow.Position = Guts.TestBox.Position;

			Guts.TestBox = rainbow;
		}

		private void NudOverlayTestBoxSizeZ_ValueChanged(object sender, EventArgs e)
		{
			Renderable rainbow = new BoxGenerator(
				Math.Abs(Guts.TestBox.Aabb.Max.X - Guts.TestBox.Aabb.Min.X),
				Math.Abs(Guts.TestBox.Aabb.Max.Y - Guts.TestBox.Aabb.Min.Y),
				(float)NudTestBoxSizeZ.Value,
				Color.White).GenerateRainbowBox().ToWorld();

			rainbow.Position = Guts.TestBox.Position;

			Guts.TestBox = rainbow;
		}

		private void NudOverlayTestLineAX_ValueChanged(object sender, EventArgs e)
		{
			if (Guts.TestLines[0] is not Line line)
			{
				return;
			}

			Vertex v = line.A;

			v = new Vertex(v)
			{
				Position = new Vector3(
					(float)NudTestLineAX.Value,
					v.Position.Y,
					v.Position.Z)
			};

			line.A = v;

			Guts.TestLines[0] = line;
		}

		private void NudOverlayTestLineAY_ValueChanged(object sender, EventArgs e)
		{
			if (Guts.TestLines[0] is not Line line)
			{
				return;
			}

			Vertex v = line.A;

			v = new Vertex(v)
			{
				Position = new Vector3(
					v.Position.X,
					-(float)NudTestLineAY.Value, // Convert from SH coords
					v.Position.Z)
			};

			line.A = v;

			Guts.TestLines[0] = line;
		}

		private void NudOverlayTestLineAZ_ValueChanged(object sender, EventArgs e)
		{
			if (Guts.TestLines[0] is not Line line)
			{
				return;
			}

			Vertex v = line.A;

			v = new Vertex(v)
			{
				Position = new Vector3(
					v.Position.X,
					v.Position.Y,
					-(float)NudTestLineAZ.Value) // Convert from SH coords
			};

			line.A = v;

			Guts.TestLines[0] = line;
		}

		private void NudOverlayTestLineBX_ValueChanged(object sender, EventArgs e)
		{
			if (Guts.TestLines[0] is not Line line)
			{
				return;
			}

			Vertex v = line.B;

			v = new Vertex(v)
			{
				Position = new Vector3(
					(float)NudTestLineBX.Value,
					v.Position.Y,
					v.Position.Z)
			};

			line.B = v;

			Guts.TestLines[0] = line;
		}

		private void NudOverlayTestLineBY_ValueChanged(object sender, EventArgs e)
		{
			if (Guts.TestLines[0] is not Line line)
			{
				return;
			}

			Vertex v = line.B;

			v = new Vertex(v)
			{
				Position = new Vector3(
					v.Position.X,
					-(float)NudTestLineBY.Value, // Convert from SH coords
					v.Position.Z)
			};

			line.B = v;

			Guts.TestLines[0] = line;
		}

		private void NudOverlayTestLineBZ_ValueChanged(object sender, EventArgs e)
		{
			if (Guts.TestLines[0] is not Line line)
			{
				return;
			}

			Vertex v = line.B;

			v = new Vertex(v)
			{
				Position = new Vector3(
					v.Position.X,
					v.Position.Y,
					-(float)NudTestLineBZ.Value) // Convert from SH coords
			};

			line.B = v;

			Guts.TestLines[0] = line;
		}

		private void NudOverlayTestSheetX_ValueChanged(object sender, EventArgs e)
		{
			Guts.TestSheet.Position = new Vector3(
				(float)NudTestSheetX.Value,
				Guts.TestSheet.Position.Y,
				Guts.TestSheet.Position.Z);
		}

		private void NudOverlayTestSheetY_ValueChanged(object sender, EventArgs e)
		{
			Guts.TestSheet.Position = new Vector3(
				Guts.TestSheet.Position.X,
				-(float)NudTestSheetY.Value, // Convert from SH coords
				Guts.TestSheet.Position.Z);
		}

		private void NudOverlayTestSheetZ_ValueChanged(object sender, EventArgs e)
		{
			Guts.TestSheet.Position = new Vector3(
				Guts.TestSheet.Position.X,
				Guts.TestSheet.Position.Y,
				-(float)NudTestSheetZ.Value); // Convert from SH coords
		}

		private void NudOverlayTestSheetSizeX_ValueChanged(object sender, EventArgs e)
		{
			Renderable sheet = new SheetGenerator(
				(float)NudTestSheetSizeX.Value,
				Math.Abs(Guts.TestSheet.Aabb.Max.Z - Guts.TestSheet.Aabb.Min.Z),
				Color.White).Generate().ToWorld();

			sheet.Position = Guts.TestSheet.Position;

			Guts.TestSheet = sheet;
		}

		private void NudOverlayTestSheetSizeZ_ValueChanged(object sender, EventArgs e)
		{
			Renderable sheet = new SheetGenerator(
				Math.Abs(Guts.TestSheet.Aabb.Max.X - Guts.TestSheet.Aabb.Min.X),
				(float)NudTestSheetSizeZ.Value,
				Color.White).Generate().ToWorld();

			sheet.Position = Guts.TestSheet.Position;

			Guts.TestSheet = sheet;
		}

		private void BtnReadHarryModel_Click(object sender, EventArgs e)
		{
			int harryModelAddressRaw = Mem.ReadS32(Rom.Addresses.MainRam.HarryModelPointer);

			int harryModelAddress = harryModelAddressRaw - (int)Rom.Addresses.MainRam.BaseAddress;

			IReadOnlyList<byte> headerBytes = Mem.ReadByteRange(harryModelAddress, IlmHeader.Length);

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
			IReadOnlyList<byte> remaining = Mem.ReadByteRange(harryModelAddress, (int)(Mem.GetMemoryDomainSize("MainRAM") - harryModelAddress));

			Guts.Model = new Ilm(header, remaining, TrkTestModelScale.Value);

			var generator = new BoxGenerator(0.025f, Color.Yellow);

			bool all = CmbModelSubmeshName.Text == "*";
			Guts.ModelBoxes.Clear();
			foreach (Submesh submesh in Guts.Model.Submeshes)
			{
				if (!all && !String.Equals(submesh.Name, CmbModelSubmeshName.Text, StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}

				foreach (Vector3 vertex in submesh.Vertices)
				{
					Renderable box = generator.Generate().ToWorld();

					box.Position = new Vector3(vertex.X, -vertex.Y, vertex.Z);

					Guts.ModelBoxes.Add(box);
				}

				if (!all)
				{
					break;
				}
			}

			BtnModelSetModelPosition_Click(this, EventArgs.Empty);
		}

		private void CbxEnableModelDisplay_CheckedChanged(object sender, EventArgs e)
		{
			if (!CbxEnableTestModelSection.Checked)
			{
				Gui.WithSurface(DisplaySurfaceID.EmuCore, () => Gui.ClearGraphics());
			}
		}

		private void TrkModelScale_Scroll(object sender, EventArgs e)
		{
			LblTestModelScale.Text = TrkTestModelScale.Value.ToString(CultureInfo.CurrentCulture);
		}
	}
}
