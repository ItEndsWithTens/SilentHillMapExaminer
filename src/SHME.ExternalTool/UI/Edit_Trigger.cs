using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk;

partial class CustomMainForm
{
	private void CmsSelectedTrigger_Opening(object sender, CancelEventArgs e)
	{
		Type[] types = [typeof(Label), typeof(CheckBox)];

		TsmSelectedTriggerResetProperty.Enabled = types
			.Contains(CmsSelectedTrigger.SourceControl.GetType());
	}
}
