using BizHawk.Client.Common;
using SHME.ExternalTool;
using SHME.ExternalTool.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void InitializePoisTab()
		{
			CmbSelectedTriggerStyle.DataSource = Enum.GetValues(typeof(TriggerStyle));
			CmbSelectedTriggerType.DataSource = Enum.GetValues(typeof(TriggerType));

			LblSelectedPoiXZ.Tag =
				nameof(PointOfInterest.X) +
				nameof(PointOfInterest.Z);

			TbxSelectedPoiX.Tag = nameof(PointOfInterest.X);
			TbxSelectedPoiZ.Tag = nameof(PointOfInterest.Z);

			LblSelectedPoiGeometry.Tag = nameof(PointOfInterest.Geometry);
			MtbSelectedPoiGeometry.Tag = nameof(PointOfInterest.Geometry);

			CbxSelectedTriggerDisabled.Tag = nameof(Trigger.Disabled);

			LblSelectedTriggerPoiGeometry.Tag = nameof(PointOfInterest.Geometry);
			MtbSelectedTriggerPoiGeometry.Tag = nameof(PointOfInterest.Geometry);

			LblSelectedTriggerThing0.Tag = nameof(Trigger.Thing0);
			MtbSelectedTriggerThing0.Tag = nameof(Trigger.Thing0);

			LblSelectedTriggerThing1.Tag = nameof(Trigger.Thing1);
			MtbSelectedTriggerThing1.Tag = nameof(Trigger.Thing1);

			LblSelectedTriggerFiredGroup.Tag = nameof(Trigger.FiredGroup);
			NudSelectedTriggerFiredGroup.Tag = nameof(Trigger.FiredGroup);

			CbxSelectedTriggerFired.Tag = nameof(Trigger.Fired);
			LblSelectedTriggerFiredDetails.Tag = nameof(Trigger.Fired);

			LblSelectedTriggerThing2.Tag = nameof(Trigger.Thing2);
			MtbSelectedTriggerThing2.Tag = nameof(Trigger.Thing2);

			LblSelectedTriggerStyle.Tag = nameof(Trigger.Style);
			CmbSelectedTriggerStyle.Tag = nameof(Trigger.Style);

			LblSelectedTriggerPoiIndex.Tag = nameof(Trigger.PoiIndex);
			NudSelectedTriggerPoiIndex.Tag = nameof(Trigger.PoiIndex);

			LblSelectedTriggerThing3.Tag = nameof(Trigger.Thing3);
			MtbSelectedTriggerThing3.Tag = nameof(Trigger.Thing3);

			LblSelectedTriggerThing4.Tag = nameof(Trigger.Thing4);
			MtbSelectedTriggerThing4.Tag = nameof(Trigger.Thing4);

			LblSelectedTriggerType.Tag = nameof(Trigger.TriggerType);
			CmbSelectedTriggerType.Tag = nameof(Trigger.TriggerType);

			LblSelectedTriggerTargetIndex.Tag = nameof(Trigger.TargetIndex);
			NudSelectedTriggerTargetIndex.Tag = nameof(Trigger.TargetIndex);

			LblSelectedTriggerThing5.Tag = nameof(Trigger.Thing5);
			MtbSelectedTriggerThing5.Tag = nameof(Trigger.Thing5);

			LblSelectedTriggerThing6.Tag = nameof(Trigger.Thing6);
			MtbSelectedTriggerThing6.Tag = nameof(Trigger.Thing6);

			LblSelectedTriggerStageIndex.Tag = nameof(Trigger.StageIndex);
			NudSelectedTriggerStageIndex.Tag = nameof(Trigger.StageIndex);

			CbxSelectedTriggerSomeBool.Tag = nameof(Trigger.SomeBool);
		}

		private void BtnClearPoisTriggers_Click(object sender, EventArgs e)
		{
			Guts.Pois.Clear();
			LbxPois.Items.Clear();
			LblPoiCount.Text = "-";

			Guts.Triggers.Clear();
			LbxTriggers.Items.Clear();
			LblTriggerCount.Text = "-";

			ClearDisplayedPoiInfo();
			ClearDisplayedTriggerInfo();
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

			string body = Mem.HashRegion(t.Address, t.SizeInBytes);

			bool fired = GetTriggerFired(t);

			if (LbxTriggers.SelectedIndex != _previousSelectedTriggerIndex)
			{
				_previousSelectedTriggerIndex = LbxTriggers.SelectedIndex;
				_previousTriggerBodyHash = body;
				_previousTriggerFired = fired;

				return;
			}

			if (body != _previousTriggerBodyHash || fired != _previousTriggerFired)
			{
				_previousTriggerBodyHash = body;
				_previousTriggerFired = fired;

				if (_userChange)
				{
					_userChange = false;
					return;
				}

				Guts.Triggers[t.Address] = new Trigger(t.Address,
					Mem.ReadByteRange(t.Address, t.SizeInBytes).ToArray());

				LbxTriggers_SelectedIndexChanged(LbxTriggers, EventArgs.Empty);

				RefreshLbxPoiAssociatedTriggers();
			}
		}

		private void ClearDisplayedPoiInfo()
		{
			LbxPoiAssociatedTriggers.Items.Clear();

			LblSelectedPoiAddress.Text = "0x";
			TbxSelectedPoiX.Text = "<x>";
			TbxSelectedPoiZ.Text = "<z>";
			MtbSelectedPoiGeometry.ResetText();

			ResetFonts(typeof(PointOfInterest));
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

			NudSelectedTriggerFiredGroup.Value = 0;
			MtbSelectedTriggerThing2.ResetText();
			CmbSelectedTriggerStyle.ResetText();
			NudSelectedTriggerPoiIndex.Value = 0;
			MtbSelectedTriggerThing3.ResetText();
			MtbSelectedTriggerThing4.ResetText();
			CmbSelectedTriggerType.ResetText();
			NudSelectedTriggerTargetIndex.Value = 0;
			MtbSelectedTriggerThing5.ResetText();
			MtbSelectedTriggerThing6.ResetText();
			NudSelectedTriggerStageIndex.Value = 0;
			CbxSelectedTriggerSomeBool.Checked = false;

			ResetFonts(typeof(Trigger));
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
			PointOfInterest p = Guts.Pois.ElementAt(t.PoiIndex).Value.Item1;

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

		private bool TryEncodePoiGeometry(string text, Trigger t)
		{
			string pattern;
			RegexOptions options = RegexOptions.IgnoreCase;
			var timeout = TimeSpan.FromSeconds(1);
			Regex regex;
			Match match;

			float geoA;
			float geoB;

			PointOfInterest poi = Guts.Pois.ElementAt(t.PoiIndex).Value.Item1;

			bool success = false;

			switch (t.Style)
			{
				case TriggerStyle.TouchAabb:
					string x = @"X\s*?size:";
					string z = @"Z\s*?size:";
					string xz = $"{x}(?<groupX>.*){z}(?<groupZ>.*)";
					string zx = $"{z}(?<groupZ>.*){x}(?<groupX>.*)";
					pattern = $"{xz}|{zx}";
					regex = new Regex(pattern, options, timeout);
					match = regex.Match(text);
					if (!match.Success)
						break;
					if (!Single.TryParse(match.Groups["groupX"].Value, out geoA))
						break;
					if (!Single.TryParse(match.Groups["groupZ"].Value, out geoB))
						break;
					poi.EncodeGeometry(t.Style, geoA, geoB);
					success = true;
					break;
				case TriggerStyle.TouchObb:
					string yaw = "Yaw:";
					string width = "Width:";
					string yawWidth = $"{yaw}(?<groupYaw>.*){width}(?<groupWidth>.*)";
					string widthYaw = $"{width}(?<groupWidth>.*){yaw}(?<groupYaw>.*)";
					pattern = $"{yawWidth}|{widthYaw}";
					regex = new Regex(pattern, options, timeout);
					match = regex.Match(text);
					if (!match.Success)
						break;
					if (!Single.TryParse(match.Groups["groupYaw"].Value, out geoA))
						break;
					if (!Single.TryParse(match.Groups["groupWidth"].Value, out geoB))
						break;
					poi.EncodeGeometry(t.Style, geoA, geoB);
					success = true;
					break;
				case TriggerStyle.ButtonYaw:
					pattern = @"Yaw:\s*?(\S+)";
					regex = new Regex(pattern, options, timeout);
					match = regex.Match(text);
					if (!match.Success)
						break;
					if (!Single.TryParse(match.Groups[1].Value, out geoA))
						break;
					poi.EncodeGeometry(t.Style, geoA, null);
					success = true;
					break;
				default:
					break;
			}

			return success;
		}

		private (PointOfInterest, Renderable?) GetRenderableFromTrigger(Trigger t)
		{
			(PointOfInterest p, Renderable? oldR) = Guts.Pois.ElementAt(t.PoiIndex).Value;

			Vector3 pos = new(p.X, 0.0f, -p.Z);

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
				r.Position = pos;
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
				r.Position = pos - point;
			}
			else
			{
				gen = new BoxGenerator(1.0f, Color.White);
				r = gen.Generate().ToWorld();
				r.Position = pos;
			}

			r.Tint = oldR.Tint;

			return (p, r);
		}

		private void BtnReadPois_Click(object sender, EventArgs e)
		{
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

			LblPoiCount.Text = count.ToString(CultureInfo.CurrentCulture);
			NudSelectedTriggerTargetIndex.Maximum = count - 1;

			BoxGenerator generator = new(1.0f, Color.White);

			Guts.Pois.Clear();
			LbxPois.Items.Clear();
			for (int i = start; i < end; i += size)
			{
				PointOfInterest poi = new(i, Mem.ReadByteRange(i, size).ToArray());

				Renderable box = generator.Generate().ToWorld();
				Vector3 pos = box.Position;
				pos.X = poi.X;
				pos.Z = -poi.Z;
				box.Position = pos;

				Guts.Pois.Add(poi.Address, (poi, box));
				LbxPois.Items.Add(poi);
			}

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

			MainRamAddresses ram = Rom.Addresses.MainRam;
			long ofs = ram.SaveData + 0x168 + t.FiredGroup * sizeof(int);

			HexEditorGoToAddress(ofs);
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

			foreach ((PointOfInterest, Renderable?) tuple in Guts.Pois.Values)
			{
				if (tuple.Item2 != null)
				{
					tuple.Item2.Tint = null;
				}
			}

			if (lbx.SelectedItem is not PointOfInterest poi)
			{
				ClearDisplayedPoiInfo();
				return;
			}

			Renderable? r = Guts.Pois[poi.Address].Item2;

			if (r != null)
			{
				r.Tint = Color.Yellow.ToArgb();
			}

			CultureInfo c = CultureInfo.CurrentCulture;

			LblSelectedPoiAddress.Text = $"0x{poi.Address.ToString("X2", c)}";
			TbxSelectedPoiX.Text = poi.X.ToString("0.##", c);
			TbxSelectedPoiZ.Text = poi.Z.ToString("0.##", c);
			MtbSelectedPoiGeometry.Text = $"0x{poi.Geometry.ToString("X8", c)}";

			IList<(string, IList<Control>)> map = _fontChangeMap[typeof(PointOfInterest)];
			foreach ((string property, IList<Control> controls) in map)
			{
				foreach (Control control in controls)
				{
					MakeBoldIfChanged(control, poi, property);
				}
			}

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
			LbxTriggers.Items.Clear();

			int max = address + Guts.Stage.SizeInBytes;
			int size = SilentHillTypeSizes.Trigger;
			for (int i = address; i < max; i += size)
			{
				Trigger t = new(i, Mem.ReadByteRange(i, size).ToArray());
				t.Fired = GetTriggerFired(t);

				if (t.Style == TriggerStyle.Dummy)
				{
					break;
				}

				Guts.Triggers.Add(t.Address, t);
			}

			foreach (Trigger t in Guts.Triggers.Values)
			{
				LbxTriggers.Items.Add(t);
			}

			LblTriggerCount.Text = Guts.Triggers.Count.ToString(CultureInfo.CurrentCulture);

			foreach (Trigger t in Guts.Triggers.Values)
			{
				(PointOfInterest, Renderable?) changed = GetRenderableFromTrigger(t);

				Guts.Pois[changed.Item1.Address] = changed;
			}

			RdoOverlayAxisColors_CheckedChanged(this, EventArgs.Empty);
		}

		private void CbxSelectedTriggerEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (LbxTriggers.SelectedItem is not Trigger t)
			{
				return;
			}

			SelectedTrigger_ValidateInput(sender as Control);
		}

		private void CbxSelectedTriggerFired_CheckedChanged(object sender, EventArgs e)
		{
			if (LbxTriggers.SelectedItem is not Trigger t)
			{
				return;
			}

			SelectedTrigger_ValidateInput(sender as Control);
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
			CbxSelectedTriggerDisabled.Checked = t.Disabled;
			CbxSelectedTriggerDisabled.Enabled = true;
			MtbSelectedTriggerThing0.Text = $"0x{t.Thing0.ToString("X2", c)}";
			MtbSelectedTriggerThing1.Text = $"0x{t.Thing1.ToString("X2", c)}";
			NudSelectedTriggerFiredGroup.Value = t.FiredGroup;
			MtbSelectedTriggerThing2.Text = $"0x{t.Thing2.ToString("X1", c)}";
			NudSelectedTriggerPoiIndex.Value = t.PoiIndex;
			MtbSelectedTriggerThing3.Text = $"0x{t.Thing3.ToString("X2", c)}";
			MtbSelectedTriggerThing4.Text = $"0x{t.Thing4.ToString("X2", c)}";
			MtbSelectedTriggerThing5.Text = $"0x{t.Thing5.ToString("X2", c)}";
			MtbSelectedTriggerThing6.Text = $"0x{t.Thing6.ToString("X2", c)}";
			NudSelectedTriggerStageIndex.Value = t.StageIndex;
			CbxSelectedTriggerSomeBool.Checked = t.SomeBool;

			string? style = Enum.GetName(typeof(TriggerStyle), t.Style);
			if (style is not null)
			{
				CmbSelectedTriggerStyle.Text = style.ToString(c);
			}

			MainRamAddresses ram = Rom.Addresses.MainRam;

			long ofs = ram.SaveData + 0x168 + t.FiredGroup * sizeof(int);

			CbxSelectedTriggerFired.Checked = GetTriggerFired(t);
			LblSelectedTriggerFiredDetails.Text =
				$"Group 0x{ofs.ToString("X", c)}, " +
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
				CmbSelectedTriggerStyle.ResetText();
			}

			if (Enum.IsDefined(typeof(TriggerType), t.TriggerType))
			{
				CmbSelectedTriggerType.SelectedItem = t.TriggerType;
			}
			else
			{
				CmbSelectedTriggerType.ResetText();
			}

			int max = Int32.MaxValue;
			int val = t.TargetIndex;
			switch (t.TriggerType)
			{
				case TriggerType.Door1:
				case TriggerType.Door2:
					max = Guts.Pois.Count - 1;
					break;
				case TriggerType.Text:
					max = RtbStrings.Lines.Length - 1;
					break;
				case TriggerType.Save0:
				case TriggerType.Save1:
					// On using a save trigger, address 0x801E74A8 is
					// loaded with an array of pointers to save point
					// name strings. There are 24 names in the game, plus
					// "Anywhere" for debug saves (not at a save point).
					max = 24;
					break;
				case TriggerType.Function1:
				case TriggerType.MapScribble:
					int s = Mem.ReadS32(ram.PointerToArrayOfPointersToStrings);
					int f = Mem.ReadS32(ram.PointerToArrayOfPointersToFunctions);
					int count = (s - f) / sizeof(int);
					max = count - 1;
					break;
				case TriggerType.Unknown0:
				default:
					val = 0;
					break;
			}

			// It's important that t.TargetIndex was cached in 'val'
			// earlier, because of how setting Maximum and Value here
			// affect the trigger in question. If Maximum is set first,
			// Value will be automatically capped, but that will in turn
			// be stored in the trigger instance, and subsequent access
			// of t.TargetIndex will yield the wrong value. If done the
			// other way around, setting Value first, an exception will
			// be thrown if Value is above Maximum. Simply storing a
			// copy of the target index takes care of both problems.
			NudSelectedTriggerTargetIndex.Maximum = max;
			NudSelectedTriggerTargetIndex.Value = val;

			MtbSelectedTriggerPoiGeometry.Text = DecodePoiGeometry(t);

			object triggersItem = LbxTriggers.SelectedItem;
			object associatedItem = LbxPoiAssociatedTriggers.SelectedItem;
			bool contains = LbxPoiAssociatedTriggers.Items.Contains(triggersItem);
			if (contains && !ReferenceEquals(triggersItem, associatedItem))
			{
				LbxPoiAssociatedTriggers.SelectedItem = LbxTriggers.SelectedItem;
			}

			IList<(string, IList<Control>)> map = _fontChangeMap[typeof(Trigger)];
			foreach ((string property, IList<Control> controls) in map)
			{
				foreach (Control control in controls)
				{
					MakeBoldIfChanged(control, t, property);
				}
			}
		}

		private void RdoOverlayAxisColors_CheckedChanged(object sender, EventArgs e)
		{
			var east = new Vector3(1.0f, 0.0f, 0.0f);
			var down = new Vector3(0.0f, -1.0f, 0.0f);
			var up = new Vector3(0.0f, 1.0f, 0.0f);
			var south = new Vector3(0.0f, 0.0f, 1.0f);
			var north = new Vector3(0.0f, 0.0f, -1.0f);

			foreach ((PointOfInterest poi, Renderable? r) in Guts.Pois.Values)
			{
				if (r == null)
				{
					continue;
				}

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
