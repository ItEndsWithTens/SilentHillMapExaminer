using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
			if (Emulation!.FrameCount() - _arrayCountdownStartFrameCount < 45)
			{
				return;
			}

			_arrayCountdown.Stop();

			Invoke(new Action(() => { BtnReadTriggers_Click(this, EventArgs.Empty); }));
		}

		private void BtnGoToPoi_Click(object sender, EventArgs e)
		{
			var poi = (PointOfInterest)LbxPois.SelectedItem;

			if (poi != null)
			{
				Core.SetHarryPosition(Mem!, poi.X, 0, poi.Z);
			}
		}

		private void CbxTriggersAutoUpdate_CheckedChanged(object sender, EventArgs e)
		{
			BtnReadPois.Enabled = !CbxTriggersAutoUpdate.Checked;
			BtnReadPois2.Enabled = !CbxTriggersAutoUpdate.Checked;
			BtnReadTriggers.Enabled = !CbxTriggersAutoUpdate.Checked;
		}

		private long _previousPoiArrayAddress;
		private long _previousFunctionPointerArrayAddress;
		private long _previousTriggerArrayAddress;
		private long _previousUnknownThingAddress;
		private void CheckForUpdatedTriggers()
		{
			int poiArrayAddress = Mem!.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfPointsOfInterest);
			poiArrayAddress -= (int)Rom.Addresses.MainRam.BaseAddress;

			int functionPointerArrayAddress = Mem!.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfPointersToFunctions);
			functionPointerArrayAddress -= (int)Rom.Addresses.MainRam.BaseAddress;

			int triggerArrayAddress = Mem!.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfTriggersMaybe);
			triggerArrayAddress -= (int)Rom.Addresses.MainRam.BaseAddress;

			int unknownThingAddress = Mem!.ReadS32(Rom.Addresses.MainRam.PointerToUnknownThingAfterArrayOfTriggers);
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

				_arrayCountdownStartFrameCount = Emulation!.FrameCount();
				_arrayCountdown.Start();
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

			LbxPoiAssociatedTriggers.Items.Clear();

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
				LblSelectedPoiThing0.Text = $"0x{poi.Thing0:X2}";
				LblSelectedPoiThing1.Text = $"0x{poi.Thing1:X2}";
				LblSelectedPoiYaw.Text = $"{poi.Yaw:0.##}";
				LblSelectedPoiThing2.Text = $"0x{poi.Thing2:X2}";

				IEnumerable<Trigger>? associated = LbxTriggers.Items.OfType<Trigger>().Where(item => item.PoiIndex == lbx.SelectedIndex);

				foreach (Trigger? t in associated)
				{
					LbxPoiAssociatedTriggers.Items.Add(t);
				}

				if (!associated.Any())
				{
					LbxTriggers.SelectedIndex = -1;
				}
			}
			else
			{
				LblSelectedPoiAddress.Text = $"0x";
				LblSelectedPoiX.Text = $"";
				LblSelectedPoiZ.Text = $"";
				LblSelectedPoiThing0.Text = $"0x";
				LblSelectedPoiThing1.Text = $"0x";
				LblSelectedPoiYaw.Text = $"";
				LblSelectedPoiThing2.Text = $"0x";
			}
		}

		public List<Trigger> Triggers { get; set; } = new List<Trigger>();

		private void BtnReadTriggers_Click(object sender, EventArgs e)
		{
			BtnReadPois_Click(this, EventArgs.Empty);
			BtnReadStrings_Click(this, EventArgs.Empty);

			Triggers.Clear();

			int triggerArrayAddress = Mem!.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfTriggersMaybe);
			triggerArrayAddress -= (int)Rom.Addresses.MainRam.BaseAddress;

			int unknownThingAddress = Mem!.ReadS32(Rom.Addresses.MainRam.PointerToUnknownThingAfterArrayOfTriggers);
			unknownThingAddress -= (int)Rom.Addresses.MainRam.BaseAddress;

			int triggerArrayBytes = unknownThingAddress - triggerArrayAddress;
			int triggerBytes = 12;
			int triggerCount = triggerArrayBytes / triggerBytes;

			LblTriggerCount.Text = triggerCount.ToString();

			LbxTriggers.Items.Clear();

			for (int i = 0; i < triggerCount; i++)
			{
				int ofs = triggerArrayAddress + (triggerBytes * i);

				var trigger = new Trigger(ofs, Mem!.ReadByteRange(ofs, 12));

				Triggers.Add(trigger);
				LbxTriggers.Items.Add(trigger);
			}
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
				LblSelectedTriggerThing1.Text = $"0x{t.Thing1:X2}";
				LblSelectedTriggerThing2.Text = $"0x{t.Thing2:X4}";
				LblSelectedTriggerStyle.Text = $"0x{t.Style:X2}";
				LblSelectedTriggerPoiIndex.Text = $"{t.PoiIndex}";
				LblSelectedTriggerThing3.Text = $"0x{t.Thing3:X2}";
				LblSelectedTriggerThing4.Text = $"0x{t.Thing4:X2}";
				LblSelectedTriggerTypeInfo.Text = $"0x{t.TypeInfo:X8}";

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
					case TriggerType.Function1:
					case TriggerType.Function2:
						int s = Mem!.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfPointersToStrings);
						int f = Mem!.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfPointersToFunctions);
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
			}
			else
			{
				LblSelectedTriggerAddress.Text = $"0x";
				LblSelectedTriggerThing0.Text = $"0x";
				LblSelectedTriggerThing1.Text = $"0x";
				LblSelectedTriggerThing2.Text = $"0x";
				LblSelectedTriggerStyle.Text = $"0x";
				LblSelectedTriggerPoiIndex.Text = $"";
				LblSelectedTriggerThing3.Text = $"0x";
				LblSelectedTriggerThing4.Text = $"0x";
				LblSelectedTriggerTypeInfo.Text = $"0x";
				NudSelectedTriggerTargetIndex.Value = -1;
				CmbSelectedTriggerType.SelectedIndex = -1;
			}
		}
	}
}
