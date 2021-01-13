using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		public Dictionary<PointOfInterest, Renderable?> Pois { get; set; } = new Dictionary<PointOfInterest, Renderable?>();

		// TODO: Implement ray shooting of some sort for selection by clicking
		// in the viewport, in addition to this primitive ListBox approach.
		private void LbxPois_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(sender is ListBox))
			{
				return;
			}

			var lbx = (ListBox)sender;

			if (lbx.SelectedItem is PointOfInterest poi)
			{
				foreach(KeyValuePair<PointOfInterest, Renderable?> item in Pois)
				{
					if (item.Value != null)
					{
						item.Value.Tint = null;
					}
				}

				Renderable? r = Pois[poi];

				if (r != null)
				{
					r.Tint = Color.Yellow;
				}

				LblSelectedPoiX.Text = $"{poi.X:N2}";
				LblSelectedPoiZ.Text = $"{poi.Z:N2}";
				LblSelectedPoiThing0.Text = $"0x{poi.Thing0:X2}";
				LblSelectedPoiThing1.Text = $"0x{poi.Thing1:X2}";
				LblSelectedPoiYaw.Text = $"{poi.Yaw:N2}";
				LblSelectedPoiThing2.Text = $"0x{poi.Thing2:X2}";
			}
		}
	}
}
