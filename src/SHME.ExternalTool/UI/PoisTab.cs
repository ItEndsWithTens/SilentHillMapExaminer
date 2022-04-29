using BizHawk.Client.Common;
using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		public Dictionary<PointOfInterest, Renderable?> Pois { get; set; } = new Dictionary<PointOfInterest, Renderable?>();

		private long _arrayCountdownStartFrameCount;
		private readonly System.Timers.Timer _arrayCountdown;
		private void ArrayCountdown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			// During some particularly long map loads, various array pointers
			// will be updated before the arrays have been filled with their
			// contents. Waiting for a few frames takes care of that.
			if (Emulation.FrameCount() - _arrayCountdownStartFrameCount < 45)
			{
				return;
			}

			_arrayCountdown.Stop();

			Invoke(new Action(() => { BtnReadTriggers_Click(this, EventArgs.Empty); }));
		}

		private void BtnClearPoisTriggers_Click(object sender, EventArgs e)
		{
			ClearDisplayedPoiInfo();
			ClearDisplayedTriggerInfo();
			LbxPois.Items.Clear();
			LbxTriggers.Items.Clear();
			Pois.Clear();
			Triggers.Clear();
			Boxes.Clear();
		}

		private void BtnGoToPoi_Click(object sender, EventArgs e)
		{
			var poi = (PointOfInterest)LbxPois.SelectedItem;

			if (poi != null)
			{
				Core.SetHarryPosition(Mem, poi.X, 0, poi.Z);
			}
		}

		private void CbxTriggersAutoUpdate_CheckedChanged(object sender, EventArgs e)
		{
			BtnReadPois.Enabled = !CbxTriggersAutoUpdate.Checked;
			BtnReadTriggers.Enabled = !CbxTriggersAutoUpdate.Checked;
		}

		private long _previousPoiArrayAddress;
		private long _previousFunctionPointerArrayAddress;
		private long _previousTriggerArrayAddress;
		private long _previousUnknownThingAddress;
		private void CheckForTriggerArrayUpdate()
		{
			int poiArrayAddress = Mem.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfPointsOfInterest);
			poiArrayAddress -= (int)Rom.Addresses.MainRam.BaseAddress;

			int functionPointerArrayAddress = Mem.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfPointersToFunctions);
			functionPointerArrayAddress -= (int)Rom.Addresses.MainRam.BaseAddress;

			int triggerArrayAddress = Mem.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfTriggersMaybe);
			triggerArrayAddress -= (int)Rom.Addresses.MainRam.BaseAddress;

			int unknownThingAddress = Mem.ReadS32(Rom.Addresses.MainRam.PointerToUnknownThingAfterArrayOfTriggers);
			unknownThingAddress -= (int)Rom.Addresses.MainRam.BaseAddress;

			bool poiArrayLocationChange = poiArrayAddress != _previousPoiArrayAddress;
			bool poiArrayLengthChange = functionPointerArrayAddress != _previousFunctionPointerArrayAddress;
			bool triggerArrayLocationChange = triggerArrayAddress != _previousTriggerArrayAddress;
			bool triggerArrayLengthChange = unknownThingAddress != _previousUnknownThingAddress;

			if (poiArrayLocationChange || poiArrayLengthChange || triggerArrayLocationChange || triggerArrayLengthChange)
			{
				_previousPoiArrayAddress = poiArrayAddress;
				_previousFunctionPointerArrayAddress = functionPointerArrayAddress;
				_previousTriggerArrayAddress = triggerArrayAddress;
				_previousUnknownThingAddress = unknownThingAddress;

				_arrayCountdownStartFrameCount = Emulation.FrameCount();
				_arrayCountdown.Start();
			}
		}

		private int? _previousSelectedTriggerIndex;
		private string? _previousTriggerBodyHash;
		private bool? _previousTriggerFired;
		private void CheckForSelectedTriggerUpdate()
		{
			if (LbxTriggers.SelectedItem == null)
			{
				return;
			}

			var t = (Trigger)LbxTriggers.SelectedItem;

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
				List<byte> bytes = Mem.ReadByteRange(t.Address, 12);

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
			LblSelectedPoiX.Text = "???.??";
			LblSelectedPoiZ.Text = "???.??";
			LblSelectedPoiGeometry.Text = "0x";
		}

		private void ClearDisplayedTriggerInfo()
		{
			LblSelectedTriggerAddress.Text = "0x";
			LblSelectedTriggerThing0.Text = "0x";
			CbxSelectedTriggerDisabled.Checked = false;
			CbxSelectedTriggerDisabled.Enabled = false;
			LblSelectedTriggerPoiGeometry.Text = "";
			LblSelectedTriggerThing1.Text = "0x";
			LblSelectedTriggerFired.Text = "";
			LblSelectedTriggerFiredDetails.Text = $"(Group 0xDEADBEEF, bit 0xCAFEBABE)";
			LblSelectedTriggerSomeIndex.Text = "0x";
			LblSelectedTriggerThing2.Text = "0x";
			LblSelectedTriggerStyle.Text = "0x";
			LblSelectedTriggerPoiIndex.Text = "";
			LblSelectedTriggerThing3.Text = "0x";
			LblSelectedTriggerThing4.Text = "0x";
			LblSelectedTriggerTypeInfo.Text = "0x";
			NudSelectedTriggerTargetIndex.Value = -1;
			CmbSelectedTriggerType.SelectedIndex = -1;
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

		private bool _foundHexEditorGoToMethod;
		private void HexEditorGoToAddress(long address)
		{
			if (!_foundHexEditorGoToMethod)
			{
				return;
			}

			MethodInfo? info = typeof(HexEditor).GetMethod("GoToAddress", BindingFlags.NonPublic | BindingFlags.Instance);

			Tool.OpenHexEditor();
			var tool = (HexEditor)Tool.GetTool("HexEditor");
			info.Invoke(tool, new object[] { address });
		}

		private string DecodePoiGeometry(Trigger t)
		{
			PointOfInterest p = Pois.ElementAt(t.PoiIndex).Key;

			(float? yaw, float? x, float? z, float? width) = PointOfInterest.DecodeGeometry(t.Style, p);

			string geometry = "";
			if (x != null && z != null)
			{
				geometry = $"X size: {x} Z size: {z}";
			}
			else if (yaw != null && width != null)
			{
				geometry = $"Width: {width} Yaw: {yaw}";
			}
			else if (yaw != null)
			{
				geometry = $"Yaw: {yaw}";
			}

			return geometry;
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
			if (LbxPois.SelectedItem is PointOfInterest p)
			{
				HexEditorGoToAddress(p.Address);
			}
		}

		private void LblSelectedTriggerAddress_Click(object sender, EventArgs e)
		{
			if (LbxTriggers.SelectedItem is Trigger t)
			{
				HexEditorGoToAddress(t.Address);
			}
		}

		private void LblSelectedTriggerFiredDetails_Click(object sender, EventArgs e)
		{
			if (LbxTriggers.SelectedItem is Trigger t)
			{
				long ofs = Rom.Addresses.MainRam.SaveData;
				long groupOfs = ofs + (t.SomeIndex * 4) + 0x168;

				HexEditorGoToAddress(groupOfs);
			}
		}

		private void LbxPoiAssociatedTriggers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (LbxPoiAssociatedTriggers.SelectedItem is Trigger t)
			{
				LbxTriggers.SelectedItem = t;
			}
		}

		private void LbxPois_Format(object sender, ListControlConvertEventArgs e)
		{
			// The index here could be padded with leading zeroes in principle,
			// but the result is a bit visually cluttered, and it becomes harder
			// to tell at a glance where you are in the list.
			e.Value = $"{LbxPois.Items.IndexOf(e.ListItem)}:    {e.ListItem}";
		}

		// TODO: Implement ray shooting of some sort for selection by clicking
		// in the viewport, in addition to this primitive ListBox approach.
		private void LbxPois_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(sender is ListBox))
			{
				return;
			}

			var lbx = (ListBox)sender;

			foreach (KeyValuePair<PointOfInterest, Renderable?> item in Pois)
			{
				if (item.Value != null)
				{
					item.Value.Tint = null;
				}
			}

			if (lbx.SelectedItem is PointOfInterest poi)
			{
				Renderable? r = Pois[poi];

				if (r != null)
				{
					r.Tint = Color.Yellow;
				}

				LblSelectedPoiAddress.Text = $"0x{poi.Address:X2}";
				LblSelectedPoiX.Text = $"{poi.X:0.##}";
				LblSelectedPoiZ.Text = $"{poi.Z:0.##}";
				LblSelectedPoiGeometry.Text = $"0x{poi.Geometry:X2}";

				RefreshLbxPoiAssociatedTriggers();
			}
			else
			{
				ClearDisplayedPoiInfo();
			}
		}

		public List<Trigger> Triggers { get; set; } = new List<Trigger>();

		private void BtnReadTriggers_Click(object sender, EventArgs e)
		{
			BtnReadPois_Click(this, EventArgs.Empty);
			BtnReadStrings_Click(this, EventArgs.Empty);

			int triggerArrayAddress = Mem.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfTriggersMaybe);
			triggerArrayAddress -= (int)Rom.Addresses.MainRam.BaseAddress;

			if (triggerArrayAddress < Rom.Addresses.MainRam.MapHeader)
			{
				return;
			}

			Triggers.Clear();
			LbxTriggers.Items.Clear();

			int ofs = triggerArrayAddress;
			var t = new Trigger(ofs, Mem.ReadByteRange(ofs, Trigger.SizeInBytes));
			while (t.Style != TriggerStyle.Dummy)
			{
				Triggers.Add(t);
				LbxTriggers.Items.Add(t);

				ofs += Trigger.SizeInBytes;
				t = new Trigger(ofs, Mem.ReadByteRange(ofs, Trigger.SizeInBytes));
			}

			LblTriggerCount.Text = $"{Triggers.Count}";

			foreach (Trigger trigger in Triggers)
			{
				if (trigger.Style != TriggerStyle.ButtonOmni && trigger.Style != TriggerStyle.ButtonYaw)
				{
					KeyValuePair<PointOfInterest, Renderable?> pair = Pois.ElementAt(trigger.PoiIndex);
					PointOfInterest p = pair.Key;

					float? yaw = null;
					float? x = null;
					float? z = null;
					float? width = null;
					if (CmbRenderShape.SelectedIndex == 0)
					{
						(yaw, x, z, width) = PointOfInterest.DecodeGeometry(trigger.Style, p);
					}

					Renderable r;
					if (x != null && z != null)
					{
						r = new BoxGenerator((float)x, (float)z, 1.0f, Color.Orange).Generate().ToWorld();
						r.Position = pair.Value.Position;
					}
					else if (yaw != null && width != null)
					{
						float depth = 4.0f;
						float yawConverted = -(float)yaw;

						r = new BoxGenerator((float)width, depth, 1.0f, Color.Orange).Generate().ToWorld();
						r.Transformability |= Transformability.Rotate;
						r.Transform(
							Vector3.Zero,
							new Vector3(0.0f, 0.0f, yawConverted),
							Vector3.Zero,
							r.Position);

						// OBB triggers' volumes aren't centered on their
						// positions, instead extending away 4 units in the
						// direction of their yaw.
						Vector3 point = new Vector3(0.0f, 0.0f, 1.0f) * (depth / 2.0f);
						point = point.Rotate(0.0f, yawConverted, 0.0f, Vector3.Zero);
						r.Position = pair.Value.Position - point;
					}
					else
					{
						r = new BoxGenerator(1.0f, Color.White).Generate().ToWorld();
						r.Position = pair.Value.Position;
					}

					int index = Boxes.IndexOf(pair.Value);
					Boxes.RemoveAt(index);
					Boxes.Insert(index, r);

					Pois.Remove(p);
					Pois.Add(p, r);
				}
			}

			RdoOverlayAxisColors_CheckedChanged(this, EventArgs.Empty);
		}

		private void CbxSelectedTriggerEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (LbxTriggers.SelectedItem is Trigger t)
			{
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
		}

		private void Emu_StateLoaded(object sender, StateLoadedEventArgs e)
		{
			Pois.Clear();
			LbxPois.Items.Clear();
			LblPoiCount.Text = "0";

			Triggers.Clear();
			LbxTriggers.Items.Clear();
			LblTriggerCount.Text = "0";

			LbxPoiAssociatedTriggers.Items.Clear();

			ClearDisplayedPoiInfo();
			ClearDisplayedTriggerInfo();

			_previousPoiArrayAddress = 0x0;
			_previousFunctionPointerArrayAddress = 0x0;
			_previousTriggerArrayAddress = 0x0;
			_previousUnknownThingAddress = 0x0;
	}

		private void LbxTriggers_Format(object sender, ListControlConvertEventArgs e)
		{
			var t = (Trigger)e.ListItem;

			string poiString;
			if (t.PoiIndex >= Pois.Count)
			{
				poiString = "null";
			}
			else
			{
				var poi = (PointOfInterest)LbxPois.Items[t.PoiIndex];
				poiString = $"{t.PoiIndex} ({poi})";
			}

			e.Value = $"{LbxTriggers.Items.IndexOf(t)}: POI {poiString}";
		}

		private void LbxTriggers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(sender is ListBox))
			{
				return;
			}

			var lbx = (ListBox)sender;

			if (lbx.SelectedItem is Trigger t)
			{
				LblSelectedTriggerAddress.Text = $"0x{t.Address:X}";
				LblSelectedTriggerThing0.Text = $"0x{t.Thing0:X2}";
				CbxSelectedTriggerDisabled.Checked = t.Disabled;
				CbxSelectedTriggerDisabled.Enabled = true;
				LblSelectedTriggerThing1.Text = $"0x{t.Thing1:X2}";
				LblSelectedTriggerSomeIndex.Text = $"0x{t.SomeIndex:X}";
				LblSelectedTriggerThing2.Text = $"0x{t.Thing2:X1}";
				LblSelectedTriggerPoiIndex.Text = $"{t.PoiIndex}";
				LblSelectedTriggerThing3.Text = $"0x{t.Thing3:X2}";
				LblSelectedTriggerThing4.Text = $"0x{t.Thing4:X2}";
				LblSelectedTriggerTypeInfo.Text = $"0x{t.TypeInfo:X8}";

				string? style = Enum.GetName(typeof(TriggerStyle), t.Style);
				LblSelectedTriggerStyle.Text = $"{style ?? $"0x{t.Style:X}"}";

				long ofs = Rom.Addresses.MainRam.SaveData;
				long groupOfs = ofs + (t.SomeIndex * 4) + 0x168;
				int group = Mem.ReadS32(groupOfs);
				int firedBit = (group >> t.FiredBitShift) & 1;
				LblSelectedTriggerFired.Text = $"{firedBit != 0}";
				LblSelectedTriggerFiredDetails.Text = $"(Group address 0x{groupOfs:X}, bit 0x{1 << t.FiredBitShift:X})";

				if (t.PoiIndex >= 0 && t.PoiIndex < LbxPois.Items.Count)
				{
					LbxPois.SelectedIndex = t.PoiIndex;
				}
				else
				{
					LbxPois.SelectedIndex = -1;
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

				LblSelectedTriggerPoiGeometry.Text = DecodePoiGeometry(t);

				object triggersItem = LbxTriggers.SelectedItem;
				object associatedItem = LbxPoiAssociatedTriggers.SelectedItem;
				bool contains = LbxPoiAssociatedTriggers.Items.Contains(triggersItem);
				if (contains && !ReferenceEquals(triggersItem, associatedItem))
				{
					LbxPoiAssociatedTriggers.SelectedItem = LbxTriggers.SelectedItem;
				}
			}
			else
			{
				ClearDisplayedTriggerInfo();
			}
		}

		private void RdoOverlayAxisColors_CheckedChanged(object sender, EventArgs e)
		{
			var east = new Vector3(1.0f, 0.0f, 0.0f);
			var down = new Vector3(0.0f, -1.0f, 0.0f);
			var up = new Vector3(0.0f, 1.0f, 0.0f);
			var south = new Vector3(0.0f, 0.0f, 1.0f);
			var north = new Vector3(0.0f, 0.0f, -1.0f);

			foreach (KeyValuePair<PointOfInterest, Renderable?> pair in Pois)
			{
				if (pair.Value == null)
				{
					continue;
				}

				Renderable r = pair.Value;

				foreach (Polygon p in r.Polygons)
				{
					p.Color = Color.White;
				}

				float tolerance = 0.001f;

				// Positive X is always pointing east.
				if (!RdoOverlayAxisColorsOff.Checked)
				{
					IEnumerable<Polygon>? easts = r.Polygons
						.Where((p) => p.Normal.ApproximatelyEquivalent(east, tolerance));

					foreach (Polygon p in easts)
					{
						p.Color = Color.Red;
					}
				}

				// Positive Y down, positive Z north
				if (RdoOverlayAxisColorsGame.Checked)
				{
					IEnumerable<Polygon>? downs = r.Polygons
						.Where((p) => p.Normal.ApproximatelyEquivalent(down, tolerance));

					foreach (Polygon p in downs)
					{
						p.Color = Color.Lime;
					}

					IEnumerable<Polygon>? norths = r.Polygons
						.Where((p) => p.Normal.ApproximatelyEquivalent(north, tolerance));

					foreach (Polygon p in norths)
					{
						p.Color = Color.Blue;
					}
				}
				// Positive Y up, positive Z south
				else if (RdoOverlayAxisColorsOverlay.Checked)
				{
					IEnumerable<Polygon>? ups = r.Polygons
						.Where((p) => p.Normal.ApproximatelyEquivalent(up, tolerance));

					foreach (Polygon p in ups)
					{
						p.Color = Color.Lime;
					}

					IEnumerable<Polygon>? souths = r.Polygons
						.Where((p) => p.Normal.ApproximatelyEquivalent(south, tolerance));

					foreach (Polygon p in souths)
					{
						p.Color = Color.Blue;
					}
				}
			}
		}
	}
}
