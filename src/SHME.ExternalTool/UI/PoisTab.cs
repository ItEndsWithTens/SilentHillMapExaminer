using BizHawk.Client.Common;
using SHME.ExternalTool;
using SHME.ExternalTool.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void InitializePoisTab()
		{
			CmbSelectedTriggerStyle.DataSource = Enum.GetValues(typeof(TriggerStyle));
			CmbSelectedTriggerType.DataSource = Enum.GetValues(typeof(TriggerType));
		}

		private void BtnClearPoisTriggers_Click(object sender, EventArgs e)
		{
			ClearDisplayedPoiInfo();
			ClearDisplayedTriggerInfo();
			LbxPois.Items.Clear();
			LbxTriggers.Items.Clear();
			Guts.Pois.Clear();
			Guts.Triggers.Clear();
			Guts.Boxes.Clear();
			LblPoiCount.Text = "-";
			LblTriggerCount.Text = "-";
		}

		private void BtnGoToPoi_Click(object sender, EventArgs e)
		{
			if (LbxPois.SelectedItem is not PointOfInterest poi)
			{
				return;
			}

			SetHarryPosition(poi.X, 0, poi.Z);
		}

		private int? _previousSelectedTriggerIndex;
		private string? _previousTriggerBodyHash;
		private bool? _previousTriggerFired;
		private void CheckForSelectedTriggerUpdate()
		{
			if (LbxTriggers.SelectedItem is not Trigger t)
			{
				return;
			}

			string body = Mem.HashRegion(t.Address, 12);

			long ofs = Rom.Addresses.MainRam.SaveData;
			int group = Mem.ReadS32(ofs + (t.SomeIndex * 4) + 0x168);
			int firedBit = (group >> t.FiredBitShift) & 1;
			bool fired = firedBit != 0;

			if (LbxTriggers.SelectedIndex != _previousSelectedTriggerIndex)
			{
				_previousSelectedTriggerIndex = LbxTriggers.SelectedIndex;
				_previousTriggerBodyHash = body;
				_previousTriggerFired = fired;

				return;
			}

			if (body != _previousTriggerBodyHash || fired != _previousTriggerFired)
			{
				ReadOnlySpan<byte> bytes = Mem.ReadByteRange(t.Address, 12).ToArray();

				var updated = new Trigger(t.Address, bytes);

				LbxTriggers.Items[LbxTriggers.SelectedIndex] = updated;

				_previousTriggerBodyHash = body;
				_previousTriggerFired = fired;

				LbxTriggers_SelectedIndexChanged(LbxTriggers, EventArgs.Empty);

				RefreshLbxPoiAssociatedTriggers();
			}
		}

		private void ClearDisplayedPoiInfo()
		{
			LblSelectedPoiAddress.Text = "0x";
			TbxSelectedPoiX.Text = "<x>";
			TbxSelectedPoiZ.Text = "<z>";
			MtbSelectedPoiGeometry.ResetText();
			LbxPoiAssociatedTriggers.Items.Clear();
		}

		private void ClearDisplayedTriggerInfo()
		{
			LblSelectedTriggerAddress.Text = "0x";

			CbxSelectedTriggerDisabled.Checked = false;
			CbxSelectedTriggerDisabled.Enabled = false;

			MtbSelectedTriggerPoiGeometry.ResetText();
			MtbSelectedTriggerThing0.ResetText();
			MtbSelectedTriggerThing1.ResetText();

			CbxSelectedTriggerFired.Checked = false;
			LblSelectedTriggerFiredDetails.Text = $"Group 0x, bit 0x";

			NudSelectedTriggerSomeIndex.Value = -1;
			NudSelectedTriggerSomeIndex.ResetText();

			MtbSelectedTriggerThing2.ResetText();
			CmbSelectedTriggerStyle.ResetText();

			NudSelectedTriggerPoiIndex.Value = -1;
			NudSelectedTriggerPoiIndex.ResetText();

			MtbSelectedTriggerThing3.ResetText();
			MtbSelectedTriggerThing4.ResetText();
			CmbSelectedTriggerType.SelectedIndex = -1;

			NudSelectedTriggerTargetIndex.Value = -1;
			NudSelectedTriggerTargetIndex.ResetText();

			MtbSelectedTriggerThing5.ResetText();
			MtbSelectedTriggerThing6.ResetText();

			CmbSelectedTriggerStyle.SelectedIndex = -1;

			CbxSelectedTriggerSomeBool.Checked = false;
		}

		private void RefreshLbxPoiAssociatedTriggers()
		{
			LbxPoiAssociatedTriggers.Items.Clear();

			ListBox lbx = LbxPois;

			IEnumerable<Trigger>? associated = LbxTriggers.Items.OfType<Trigger>().Where(item => item.PoiIndex == lbx.SelectedIndex);

			foreach (Trigger? t in associated)
			{
				LbxPoiAssociatedTriggers.Items.Add(t);
			}

			if (!associated.Any())
			{
				LbxTriggers.SelectedIndex = -1;
			}

			var item = LbxTriggers.SelectedItem as Trigger;
			if (item != null)
			{
				LbxPoiAssociatedTriggers.SelectedItem = item;
			}
		}

		private void HexEditorGoToAddress(long address)
		{
			if (MemDomains == null)
			{
				return;
			}

			ViewInHexEditor(MemDomains["MainRAM"], new[] { address }, WatchSize.DWord);
		}

		private string DecodePoiGeometry(Trigger t)
		{
			PointOfInterest p = Guts.Pois.ElementAt(t.PoiIndex).Key;

			(float geoA, float geoB) = p.DecodeGeometry(t.Style);

			CultureInfo c = CultureInfo.CurrentCulture;

			return t.Style switch
			{
				TriggerStyle.TouchAabb =>
					$"X size: {geoA.ToString(c)} Z size: {geoB.ToString(c)}",

				TriggerStyle.TouchObb =>
					$"Yaw: {geoA.ToString(c)} Width: {geoB.ToString(c)}",

				_ => $"Yaw: {geoA.ToString(c)}"
			};
		}

		private void BtnReadPois_Click(object sender, EventArgs e)
		{
			Guts.Boxes.Clear();
			Guts.Pois.Clear();

			MainRamAddresses ram = Rom.Addresses.MainRam;

			int start = Mem.ReadS32(ram.PointerToArrayOfPointsOfInterest);
			start -= (int)ram.BaseAddress;

			if (start < ram.StageHeader)
			{
				return;
			}

			int end = Mem.ReadS32(ram.PointerToArrayOfPointersToFunctions);
			end -= (int)ram.BaseAddress;

			int size = SilentHillTypeSizes.PointOfInterest;
			int count = (end - start) / size;

			LblPoiCount.Text = count.ToString();
			NudSelectedTriggerTargetIndex.Maximum = count - 1;

			LbxPois.BeginUpdate();
			LbxPois.SelectedIndex = -1;
			LbxPois.Items.Clear();

			var generator = new BoxGenerator(1.0f, Color.White);
			for (int i = start; i < end; i += size)
			{
				PointOfInterest poi = new(i, Mem.ReadByteRange(i, size).ToArray());

				Renderable box = generator.Generate().ToWorld();
				Vector3 pos = box.Position;
				pos.X = poi.X;
				pos.Z = -poi.Z;
				box.Position = pos;

				Guts.Boxes.Add(box);

				Guts.Pois.Add(poi, box);
				LbxPois.Items.Add(poi);
			}

			LbxPois.EndUpdate();

			RdoOverlayAxisColors_CheckedChanged(this, EventArgs.Empty);
		}

		private void CmbRenderShape_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (LbxTriggers.Items.Count > 0)
			{
				int oldPoiIndex = LbxPois.SelectedIndex;
				int oldTriggersIndex = LbxTriggers.SelectedIndex;
				int oldPoiAssociatedTriggerIndex = LbxPoiAssociatedTriggers.SelectedIndex;

				BtnReadTriggers_Click(sender, e);

				LbxPois.SelectedIndex = oldPoiIndex;
				LbxTriggers.SelectedIndex = oldTriggersIndex;
				LbxPoiAssociatedTriggers.SelectedIndex = oldPoiAssociatedTriggerIndex;
			}
		}

		private void LblSelectedPoiAddress_Click(object sender, EventArgs e)
		{
			if (LbxPois.SelectedItem is not PointOfInterest p)
			{
				return;
			}

			HexEditorGoToAddress(p.Address);
		}

		private void LblSelectedTriggerAddress_Click(object sender, EventArgs e)
		{
			if (LbxTriggers.SelectedItem is not Trigger t)
			{
				return;
			}

			HexEditorGoToAddress(t.Address);
		}

		private void LblSelectedTriggerFiredDetails_Click(object sender, EventArgs e)
		{
			if (LbxTriggers.SelectedItem is not Trigger t)
			{
				return;
			}

			long ofs = Rom.Addresses.MainRam.SaveData;
			long groupOfs = ofs + (t.SomeIndex * 4) + 0x168;

			HexEditorGoToAddress(groupOfs);
		}

		private void LbxPoiAssociatedTriggers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (LbxPoiAssociatedTriggers.SelectedItem is not Trigger t)
			{
				return;
			}

			LbxTriggers.SelectedItem = t;
		}

		private void LbxPois_Format(object sender, ListControlConvertEventArgs e)
		{
			// The index here could be padded with leading zeroes in principle,
			// but the result is a bit visually cluttered, and it becomes harder
			// to tell at a glance where you are in the list.
			int idx = LbxPois.Items.IndexOf(e.ListItem);
			CultureInfo c = CultureInfo.CurrentCulture;
			e.Value = $"{idx.ToString(c)}: {e.ListItem}";
		}

		private void LbxPois_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sender is not ListBox lbx)
			{
				return;
			}

			foreach (KeyValuePair<PointOfInterest, Renderable?> item in Guts.Pois)
			{
				if (item.Value != null)
				{
					item.Value.Tint = null;
				}
			}

			if (lbx.SelectedItem is not PointOfInterest poi)
			{
				ClearDisplayedPoiInfo();
				return;
			}

			Renderable? r = Guts.Pois[poi];

			if (r != null)
			{
				r.Tint = Color.Yellow.ToArgb();
			}

			CultureInfo c = CultureInfo.CurrentCulture;

			LblSelectedPoiAddress.Text = $"0x{poi.Address.ToString("X2", c)}";
			TbxSelectedPoiX.Text = poi.X.ToString("0.##", c);
			TbxSelectedPoiZ.Text = poi.Z.ToString("0.##", c);
			MtbSelectedPoiGeometry.Text = $"0x{poi.Geometry.ToString("X8", c)}";

			RefreshLbxPoiAssociatedTriggers();

			IEnumerable<Trigger>? associated = LbxTriggers.Items
				.OfType<Trigger>()
				.Where(item => item.PoiIndex == lbx.SelectedIndex);

			if (associated.Any() && !associated.Contains(LbxTriggers.SelectedItem as Trigger))
			{
				LbxPoiAssociatedTriggers.SelectedIndex = 0;
			}
		}

		private void BtnReadTriggers_Click(object sender, EventArgs e)
		{
			BtnReadPois_Click(this, EventArgs.Empty);
			BtnReadStrings_Click(this, EventArgs.Empty);

			MainRamAddresses ram = Rom.Addresses.MainRam;

			int address = Mem.ReadS32(ram.PointerToArrayOfTriggers);
			address -= (int)ram.BaseAddress;

			if (address < ram.StageHeader)
			{
				return;
			}

			Guts.Triggers.Clear();

			LbxTriggers.BeginUpdate();
			LbxTriggers.SelectedIndex = -1;
			LbxTriggers.Items.Clear();

			int max = address + Guts.Stage.SizeInBytes;
			int size = SilentHillTypeSizes.Trigger;
			for (int i = address; i < max; i += size)
			{
				Trigger t = new(i, Mem.ReadByteRange(i, size).ToArray());

				if (t.Style == TriggerStyle.Dummy)
				{
					break;
				}

				Guts.Triggers.Add(t);
				LbxTriggers.Items.Add(t);
			}

			LbxTriggers.EndUpdate();

			LblTriggerCount.Text = Guts.Triggers.Count.ToString(CultureInfo.CurrentCulture);

			foreach (Trigger t in Guts.Triggers)
			{
				if (t.Style == TriggerStyle.ButtonOmni || t.Style == TriggerStyle.ButtonYaw)
				{
					continue;
				}

				KeyValuePair<PointOfInterest, Renderable?> pair = Guts.Pois.ElementAt(t.PoiIndex);
				PointOfInterest p = pair.Key;

				float geoA = 0.0f;
				float geoB = 0.0f;
				if (CmbPoiRenderShape.SelectedIndex == 0)
				{
					(geoA, geoB) = p.DecodeGeometry(t.Style);
				}

				BoxGenerator gen;
				Renderable r;
				if (t.Style == TriggerStyle.TouchAabb)
				{
					gen = new BoxGenerator(geoA, 1.0f, geoB, Color.Orange);
					r = gen.Generate().ToWorld();
					r.Position = pair.Value.Position;
				}
				else if (t.Style == TriggerStyle.TouchObb)
				{
					float depth = 4.0f;

					gen = new BoxGenerator(geoB, 1.0f, depth, Color.Orange);
					r = gen.Generate().ToWorld();
					r.Transformability |= Transformability.Rotate;

					Vector3 rotation = new(0.0f, -geoA, 0.0f);
					r.Transform(
						Vector3.Zero,
						rotation,
						Vector3.One,
						r.Position);

					// OBB triggers' volumes aren't centered on their
					// positions, instead extending away 4 units in the
					// direction of their yaw.
					Vector3 point = new Vector3(0.0f, 0.0f, 1.0f) * (depth / 2.0f);
					point = point.Rotate(rotation, Vector3.Zero);
					r.Position = pair.Value.Position - point;
				}
				else
				{
					gen = new BoxGenerator(1.0f, Color.White);
					r = gen.Generate().ToWorld();
					r.Position = pair.Value.Position;
				}

				int index = Guts.Boxes.IndexOf(pair.Value);
				Guts.Boxes.RemoveAt(index);
				Guts.Boxes.Insert(index, r);

				Guts.Pois.Remove(p);
				Guts.Pois.Add(p, r);
			}

			RdoOverlayAxisColors_CheckedChanged(this, EventArgs.Empty);
		}

		private void CbxSelectedTriggerEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (LbxTriggers.SelectedItem is not Trigger t)
			{
				return;
			}

			uint existing = Mem.ReadByte(t.Address);

			if (CbxSelectedTriggerDisabled.Checked)
			{
				Mem.WriteByte(t.Address, (byte)(existing | 0b10000000));
			}
			else
			{
				Mem.WriteByte(t.Address, (byte)(existing & 0b01111111));
			}
		}

		private void LbxTriggers_Format(object sender, ListControlConvertEventArgs e)
		{
			var t = (Trigger)e.ListItem;

			CultureInfo c = CultureInfo.CurrentCulture;

			string poiString;
			if (t.PoiIndex >= Guts.Pois.Count)
			{
				poiString = "null";
			}
			else
			{
				var poi = (PointOfInterest)LbxPois.Items[t.PoiIndex];
				poiString = $"{t.PoiIndex.ToString(c)} {poi}";
			}

			int idx = LbxTriggers.Items.IndexOf(t);
			e.Value = $"{idx.ToString(c)}: POI {poiString}";
		}

		private void LbxTriggers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sender is not ListBox lbx)
			{
				return;
			}

			if (lbx.SelectedItem is not Trigger t)
			{
				ClearDisplayedTriggerInfo();
				return;
			}

			CultureInfo c = CultureInfo.CurrentCulture;

			LblSelectedTriggerAddress.Text = $"0x{t.Address.ToString("X", c)}";
			MtbSelectedTriggerThing0.Text = $"0x{t.Thing0.ToString("X2", c)}";
			CbxSelectedTriggerDisabled.Checked = t.Disabled;
			CbxSelectedTriggerDisabled.Enabled = true;
			MtbSelectedTriggerThing1.Text = $"0x{t.Thing1.ToString("X2", c)}";
			NudSelectedTriggerSomeIndex.Value = t.SomeIndex;
			MtbSelectedTriggerThing2.Text = $"0x{t.Thing2.ToString("X1", c)}";
			NudSelectedTriggerPoiIndex.Value = t.PoiIndex;
			MtbSelectedTriggerThing3.Text = $"0x{t.Thing3.ToString("X2", c)}";
			MtbSelectedTriggerThing4.Text = $"0x{t.Thing4.ToString("X2", c)}";
			MtbSelectedTriggerThing5.Text = $"0x{t.Thing5.ToString("X2", c)}";
			MtbSelectedTriggerThing6.Text = $"0x{t.Thing6.ToString("X2", c)}";
			CbxSelectedTriggerSomeBool.Checked = t.SomeBool;

			string? style = Enum.GetName(typeof(TriggerStyle), t.Style);
			if (style is not null)
			{
				CmbSelectedTriggerStyle.Text = style.ToString(c);
			}

			long ofs = Rom.Addresses.MainRam.SaveData;
			long groupOfs = ofs + (t.SomeIndex * 4) + 0x168;
			int group = Mem.ReadS32(groupOfs);
			int firedBit = (group >> t.FiredBitShift) & 1;
			CbxSelectedTriggerFired.Checked = firedBit != 0;
			LblSelectedTriggerFiredDetails.Text =
				$"Group 0x{groupOfs.ToString("X", c)}, " +
				$"bit 0x{(1 << t.FiredBitShift).ToString("X", c)}";

			if (t.PoiIndex >= 0 && t.PoiIndex < LbxPois.Items.Count)
			{
				LbxPois.SelectedIndex = t.PoiIndex;
			}
			else
			{
				LbxPois.SelectedIndex = -1;
			}

			if (Enum.IsDefined(typeof(TriggerStyle), t.Style))
			{
				CmbSelectedTriggerStyle.SelectedItem = t.Style;
			}
			else
			{
				CmbSelectedTriggerStyle.SelectedItem = -1;
			}

			if (Enum.IsDefined(typeof(TriggerType), t.TriggerType))
			{
				CmbSelectedTriggerType.SelectedItem = t.TriggerType;
			}
			else
			{
				CmbSelectedTriggerType.SelectedIndex = -1;
			}

			switch (t.TriggerType)
			{
				case TriggerType.Door1:
				case TriggerType.Door2:
					NudSelectedTriggerTargetIndex.Maximum = LbxPois.Items.Count - 1;
					NudSelectedTriggerTargetIndex.Value = t.TargetIndex;
					break;
				case TriggerType.Text:
					NudSelectedTriggerTargetIndex.Maximum = Int32.Parse(LblStringCount.Text) - 1;
					NudSelectedTriggerTargetIndex.Value = t.TargetIndex;
					break;
				case TriggerType.Save0:
				case TriggerType.Save1:
					// On using a save trigger, address 0x801E74A8 is loaded
					// with an array of pointers to save point name strings.
					// There are only 24 in the entire game, plus "Anywhere"
					// which I hope suggests a debug function somewhere that
					// can save wherever you want. Fingers crossed.
					NudSelectedTriggerTargetIndex.Maximum = 24;
					NudSelectedTriggerTargetIndex.Value = t.TargetIndex;
					break;
				case TriggerType.Function1:
				case TriggerType.MapScribble:
					int s = Mem.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfPointersToStrings);
					int f = Mem.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfPointersToFunctions);
					long count = (s - f) / 4;
					NudSelectedTriggerTargetIndex.Maximum = count - 1;
					NudSelectedTriggerTargetIndex.Value = t.TargetIndex;
					break;
				case TriggerType.Unknown0:
				default:
					NudSelectedTriggerTargetIndex.Maximum = Int32.MaxValue;
					NudSelectedTriggerTargetIndex.Value = -1;
					break;
			}

			MtbSelectedTriggerPoiGeometry.Text = DecodePoiGeometry(t);

			object triggersItem = LbxTriggers.SelectedItem;
			object associatedItem = LbxPoiAssociatedTriggers.SelectedItem;
			bool contains = LbxPoiAssociatedTriggers.Items.Contains(triggersItem);
			if (contains && !ReferenceEquals(triggersItem, associatedItem))
			{
				LbxPoiAssociatedTriggers.SelectedItem = LbxTriggers.SelectedItem;
			}
		}

		private void RdoOverlayAxisColors_CheckedChanged(object sender, EventArgs e)
		{
			var east = new Vector3(1.0f, 0.0f, 0.0f);
			var down = new Vector3(0.0f, -1.0f, 0.0f);
			var up = new Vector3(0.0f, 1.0f, 0.0f);
			var south = new Vector3(0.0f, 0.0f, 1.0f);
			var north = new Vector3(0.0f, 0.0f, -1.0f);

			foreach (KeyValuePair<PointOfInterest, Renderable?> pair in Guts.Pois)
			{
				if (pair.Value == null)
				{
					continue;
				}

				Renderable r = pair.Value;

				foreach (Polygon p in r.Polygons)
				{
					p.Argb = Color.White.ToArgb();
				}

				float tolerance = 0.001f;

				// Positive X is always pointing east.
				if (!RdoAxisColorsOff.Checked)
				{
					IEnumerable<Polygon>? easts = r.Polygons
						.Where((p) => p.Normal.ApproximatelyEquivalent(east, tolerance));

					foreach (Polygon p in easts)
					{
						p.Argb = Color.Red.ToArgb();
					}
				}

				// Positive Y down, positive Z north
				if (RdoAxisColorsGame.Checked)
				{
					IEnumerable<Polygon>? downs = r.Polygons
						.Where((p) => p.Normal.ApproximatelyEquivalent(down, tolerance));

					foreach (Polygon p in downs)
					{
						p.Argb = Color.Lime.ToArgb();
					}

					IEnumerable<Polygon>? norths = r.Polygons
						.Where((p) => p.Normal.ApproximatelyEquivalent(north, tolerance));

					foreach (Polygon p in norths)
					{
						p.Argb = Color.Blue.ToArgb();
					}
				}
				// Positive Y up, positive Z south
				else if (RdoAxisColorsOverlay.Checked)
				{
					IEnumerable<Polygon>? ups = r.Polygons
						.Where((p) => p.Normal.ApproximatelyEquivalent(up, tolerance));

					foreach (Polygon p in ups)
					{
						p.Argb = Color.Lime.ToArgb();
					}

					IEnumerable<Polygon>? souths = r.Polygons
						.Where((p) => p.Normal.ApproximatelyEquivalent(south, tolerance));

					foreach (Polygon p in souths)
					{
						p.Argb = Color.Blue.ToArgb();
					}
				}
			}
		}
	}
}
