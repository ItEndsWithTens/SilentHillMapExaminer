using System;

namespace BizHawk.Client.EmuHawk;

public partial class CustomMainForm
{
	private event EventHandler? StageLoaded;

	private void OnStageLoaded(object sender, EventArgs e)
	{
		StageLoaded?.Invoke(sender, e);
	}

	private void UpdateArrays(object sender, EventArgs e)
	{
		BtnReadTriggers_Click(this, EventArgs.Empty);
		BtnCameraPathReadArray_Click(this, EventArgs.Empty);
	}
}
