using BizHawk.Client.Common;
using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Numerics;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void BtnModelGetHarryPosition_Click(object sender, EventArgs e)
		{
			(Vector3 harry, _) = GetPosition();

			NudModelX.Text = harry.X.ToString("N2");
			NudModelY.Text = harry.Y.ToString("N2");
			NudModelZ.Text = harry.Z.ToString("N2");
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

		private Renderable TestBox { get; set; } = new BoxGenerator(1.0f, Color.White).GenerateRainbowBox().ToWorld();
		private Collection<Line> TestLines { get; } = new Collection<Line>()
		{
			new Line(
				new Vertex(0.0f, 1.0f, 0.0f, Color.Red),
				new Vertex(1.0f, 1.0f, 0.0f, Color.Lime))
		};

		private void NudOverlayTestBoxX_ValueChanged(object sender, EventArgs e)
		{
			TestBox.Position = new Vector3(
				(float)NudOverlayTestBoxX.Value,
				TestBox.Position.Y,
				TestBox.Position.Z);
		}

		private void NudOverlayTestBoxY_ValueChanged(object sender, EventArgs e)
		{
			TestBox.Position = new Vector3(
				TestBox.Position.X,
				-(float)NudOverlayTestBoxY.Value, // Convert from SH coords
				TestBox.Position.Z);
		}

		private void NudOverlayTestBoxZ_ValueChanged(object sender, EventArgs e)
		{
			TestBox.Position = new Vector3(
				TestBox.Position.X,
				TestBox.Position.Y,
				-(float)NudOverlayTestBoxZ.Value); // Convert from SH coords
		}

		private void NudOverlayTestBoxSizeX_ValueChanged(object sender, EventArgs e)
		{
			Renderable rainbow = new BoxGenerator(
				(float)NudOverlayTestBoxSizeX.Value,
				Math.Abs(TestBox.Aabb.Max.Y - TestBox.Aabb.Min.Y),
				Math.Abs(TestBox.Aabb.Max.Z - TestBox.Aabb.Min.Z),
				Color.White).GenerateRainbowBox();

			rainbow.Position = TestBox.Position;

			TestBox = rainbow.ToWorld();
		}

		private void NudOverlayTestBoxSizeY_ValueChanged(object sender, EventArgs e)
		{
			Renderable rainbow = new BoxGenerator(
				Math.Abs(TestBox.Aabb.Max.X - TestBox.Aabb.Min.X),
				(float)NudOverlayTestBoxSizeY.Value,
				Math.Abs(TestBox.Aabb.Max.Z - TestBox.Aabb.Min.Z),
				Color.White).GenerateRainbowBox();

			rainbow.Position = TestBox.Position;

			TestBox = rainbow.ToWorld();
		}

		private void NudOverlayTestBoxSizeZ_ValueChanged(object sender, EventArgs e)
		{
			Renderable rainbow = new BoxGenerator(
				Math.Abs(TestBox.Aabb.Max.X - TestBox.Aabb.Min.X),
				Math.Abs(TestBox.Aabb.Max.Y - TestBox.Aabb.Min.Y),
				(float)NudOverlayTestBoxSizeZ.Value,
				Color.White).GenerateRainbowBox();

			rainbow.Position = TestBox.Position;

			TestBox = rainbow.ToWorld();
		}

		private void NudOverlayTestLineAX_ValueChanged(object sender, EventArgs e)
		{
			Vertex v = TestLines[0].A;

			v = new Vertex(v)
			{
				Position = new Vector3(
					(float)NudOverlayTestLineAX.Value,
					v.Position.Y,
					v.Position.Z)
			};

			TestLines[0].A = v;
		}

		private void NudOverlayTestLineAY_ValueChanged(object sender, EventArgs e)
		{
			Vertex v = TestLines[0].A;

			v = new Vertex(v)
			{
				Position = new Vector3(
					v.Position.X,
					-(float)NudOverlayTestLineAY.Value, // Convert from SH coords
					v.Position.Z)
			};

			TestLines[0].A = v;
		}

		private void NudOverlayTestLineAZ_ValueChanged(object sender, EventArgs e)
		{
			Vertex v = TestLines[0].A;

			v = new Vertex(v)
			{
				Position = new Vector3(
					v.Position.X,
					v.Position.Y,
					-(float)NudOverlayTestLineAZ.Value) // Convert from SH coords
			};

			TestLines[0].A = v;
		}

		private void NudOverlayTestLineBX_ValueChanged(object sender, EventArgs e)
		{
			Vertex v = TestLines[0].B;

			v = new Vertex(v)
			{
				Position = new Vector3(
					(float)NudOverlayTestLineBX.Value,
					v.Position.Y,
					v.Position.Z)
			};

			TestLines[0].B = v;
		}

		private void NudOverlayTestLineBY_ValueChanged(object sender, EventArgs e)
		{
			Vertex v = TestLines[0].B;

			v = new Vertex(v)
			{
				Position = new Vector3(
					v.Position.X,
					-(float)NudOverlayTestLineBY.Value, // Convert from SH coords
					v.Position.Z)
			};

			TestLines[0].B = v;
		}

		private void NudOverlayTestLineBZ_ValueChanged(object sender, EventArgs e)
		{
			Vertex v = TestLines[0].B;

			v = new Vertex(v)
			{
				Position = new Vector3(
					v.Position.X,
					v.Position.Y,
					-(float)NudOverlayTestLineBZ.Value) // Convert from SH coords
			};

			TestLines[0].B = v;
		}

		private Ilm? Model { get; set; }
		private List<Renderable> ModelBoxes { get; } = new List<Renderable>();

		private void BtnReadHarryModel_Click(object sender, EventArgs e)
		{
			int harryModelAddressRaw = Mem.ReadS32(Rom.Addresses.MainRam.HarryModelPointer);

			int harryModelAddress = harryModelAddressRaw - (int)Rom.Addresses.MainRam.BaseAddress;

			List<byte> headerBytes = Mem.ReadByteRange(harryModelAddress, IlmHeader.Length);

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
			List<byte> remaining = Mem.ReadByteRange(harryModelAddress, (int)(Mem.GetMemoryDomainSize("MainRAM") - harryModelAddress));

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
				Gui.WithSurface(DisplaySurfaceID.EmuCore, () => Gui.ClearGraphics());
			}
		}

		private void TrkModelScale_Scroll(object sender, System.EventArgs e)
		{
			LblModelScale.Text = TrkModelScale.Value.ToString();
		}
	}
}
