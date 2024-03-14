using BizHawk.Client.Common;
using SHME.ExternalTool;
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
			var aabb = new Aabb(ModelBoxes);

			var target = new Vector3(
				(float)NudTestModelX.Value,
				-(float)NudTestModelY.Value,
				-(float)NudTestModelZ.Value);

			Vector3 diff = target - aabb.Center;

			foreach (Renderable box in ModelBoxes)
			{
				box.Position += diff;
			}
		}

		private Renderable TestBox { get; set; } = new BoxGenerator(1.0f, Color.White).GenerateRainbowBox().ToWorld();
		private IList<Renderable> TestLines { get; } = new List<Renderable>()
		{
			new Line(
				new Vertex(0.0f, 1.0f, 0.0f, Color.Red),
				new Vertex(1.0f, 1.0f, 0.0f, Color.Lime))
		};
		private Renderable TestSheet { get; set; } = new SheetGenerator(1.0f, Color.White).Generate().ToWorld();

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
			TestBox.Position = new Vector3(
				(float)NudTestBoxX.Value,
				TestBox.Position.Y,
				TestBox.Position.Z);
		}

		private void NudOverlayTestBoxY_ValueChanged(object sender, EventArgs e)
		{
			TestBox.Position = new Vector3(
				TestBox.Position.X,
				-(float)NudTestBoxY.Value, // Convert from SH coords
				TestBox.Position.Z);
		}

		private void NudOverlayTestBoxZ_ValueChanged(object sender, EventArgs e)
		{
			TestBox.Position = new Vector3(
				TestBox.Position.X,
				TestBox.Position.Y,
				-(float)NudTestBoxZ.Value); // Convert from SH coords
		}

		private void NudOverlayTestBoxSizeX_ValueChanged(object sender, EventArgs e)
		{
			Renderable rainbow = new BoxGenerator(
				(float)NudTestBoxSizeX.Value,
				Math.Abs(TestBox.Aabb.Max.Y - TestBox.Aabb.Min.Y),
				Math.Abs(TestBox.Aabb.Max.Z - TestBox.Aabb.Min.Z),
				Color.White).GenerateRainbowBox().ToWorld();

			rainbow.Position = TestBox.Position;

			TestBox = rainbow;
		}

		private void NudOverlayTestBoxSizeY_ValueChanged(object sender, EventArgs e)
		{
			Renderable rainbow = new BoxGenerator(
				Math.Abs(TestBox.Aabb.Max.X - TestBox.Aabb.Min.X),
				(float)NudTestBoxSizeY.Value,
				Math.Abs(TestBox.Aabb.Max.Z - TestBox.Aabb.Min.Z),
				Color.White).GenerateRainbowBox().ToWorld();

			rainbow.Position = TestBox.Position;

			TestBox = rainbow;
		}

		private void NudOverlayTestBoxSizeZ_ValueChanged(object sender, EventArgs e)
		{
			Renderable rainbow = new BoxGenerator(
				Math.Abs(TestBox.Aabb.Max.X - TestBox.Aabb.Min.X),
				Math.Abs(TestBox.Aabb.Max.Y - TestBox.Aabb.Min.Y),
				(float)NudTestBoxSizeZ.Value,
				Color.White).GenerateRainbowBox().ToWorld();

			rainbow.Position = TestBox.Position;

			TestBox = rainbow;
		}

		private void NudOverlayTestLineAX_ValueChanged(object sender, EventArgs e)
		{
			if (TestLines[0] is not Line line)
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

			TestLines[0] = line;
		}

		private void NudOverlayTestLineAY_ValueChanged(object sender, EventArgs e)
		{
			if (TestLines[0] is not Line line)
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

			TestLines[0] = line;
		}

		private void NudOverlayTestLineAZ_ValueChanged(object sender, EventArgs e)
		{
			if (TestLines[0] is not Line line)
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

			TestLines[0] = line;
		}

		private void NudOverlayTestLineBX_ValueChanged(object sender, EventArgs e)
		{
			if (TestLines[0] is not Line line)
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

			TestLines[0] = line;
		}

		private void NudOverlayTestLineBY_ValueChanged(object sender, EventArgs e)
		{
			if (TestLines[0] is not Line line)
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

			TestLines[0] = line;
		}

		private void NudOverlayTestLineBZ_ValueChanged(object sender, EventArgs e)
		{
			if (TestLines[0] is not Line line)
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

			TestLines[0] = line;
		}

		private void NudOverlayTestSheetX_ValueChanged(object sender, EventArgs e)
		{
			TestSheet.Position = new Vector3(
				(float)NudTestSheetX.Value,
				TestSheet.Position.Y,
				TestSheet.Position.Z);
		}

		private void NudOverlayTestSheetY_ValueChanged(object sender, EventArgs e)
		{
			TestSheet.Position = new Vector3(
				TestSheet.Position.X,
				-(float)NudTestSheetY.Value, // Convert from SH coords
				TestSheet.Position.Z);
		}

		private void NudOverlayTestSheetZ_ValueChanged(object sender, EventArgs e)
		{
			TestSheet.Position = new Vector3(
				TestSheet.Position.X,
				TestSheet.Position.Y,
				-(float)NudTestSheetZ.Value); // Convert from SH coords
		}

		private void NudOverlayTestSheetSizeX_ValueChanged(object sender, EventArgs e)
		{
			Renderable sheet = new SheetGenerator(
				(float)NudTestSheetSizeX.Value,
				Math.Abs(TestSheet.Aabb.Max.Z - TestSheet.Aabb.Min.Z),
				Color.White).Generate().ToWorld();

			sheet.Position = TestSheet.Position;

			TestSheet = sheet;
		}

		private void NudOverlayTestSheetSizeZ_ValueChanged(object sender, EventArgs e)
		{
			Renderable sheet = new SheetGenerator(
				Math.Abs(TestSheet.Aabb.Max.X - TestSheet.Aabb.Min.X),
				(float)NudTestSheetSizeZ.Value,
				Color.White).Generate().ToWorld();

			sheet.Position = TestSheet.Position;

			TestSheet = sheet;
		}

		private Ilm? Model { get; set; }
		private List<Renderable> ModelBoxes { get; } = [];

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

			Model = new Ilm(header, remaining, TrkTestModelScale.Value);

			var generator = new BoxGenerator(0.025f, Color.Yellow);

			bool all = CmbModelSubmeshName.Text == "*";
			ModelBoxes.Clear();
			foreach (Submesh submesh in Model.Submeshes)
			{
				if (!all && !String.Equals(submesh.Name, CmbModelSubmeshName.Text, StringComparison.OrdinalIgnoreCase))
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
