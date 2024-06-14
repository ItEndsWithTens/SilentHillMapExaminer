using System;
using System.Reflection;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk;

public partial class CustomMainForm
{
	private event EventHandler? StageLoaded;

	private void AttachEventHandlers()
	{
		Emu.StateLoaded += Emu_StateLoaded;

		PropertyInfo? pInfo = typeof(DisplayManager).GetProperty("_graphicsControl", BindingFlags.NonPublic | BindingFlags.Instance);
		if (pInfo != null)
		{
			var gc = (GraphicsControl)pInfo.GetValue(DisplayManager);

			FieldInfo? fInfo = typeof(GraphicsControl).GetField("_managed", BindingFlags.NonPublic | BindingFlags.Instance);
			if (fInfo != null)
			{
				GameSurface = (Control)fInfo.GetValue(gc);

				GameSurface.MouseDown += GameSurface_MouseDown;
				GameSurface.MouseUp += GameSurface_MouseUp;

				GameSurface.SizeChanged += GameSurface_SizeChanged;
			}
		}

		RaycastSelectionTimer.Tick += RaycastSelectionTimer_Tick;

		BtnCameraFly.LostFocus += BtnCameraFly_LostFocus;
		BtnCameraFps.LostFocus += BtnCameraFps_LostFocus;

		StageLoaded += UpdateArrays;
		StageLoaded += LoadHarryModel;

		// It's unseemly to have the framebuffer picture box populated
		// with an image on first loading the tool, so don't attach the
		// ValueChanged handler until after settings are bound.
		NudFramebufferOfsX.ValueChanged += NudFramebuffer_ValueChanged;
		NudFramebufferOfsY.ValueChanged += NudFramebuffer_ValueChanged;
		NudFramebufferW.ValueChanged += NudFramebuffer_ValueChanged;
		NudFramebufferH.ValueChanged += NudFramebuffer_ValueChanged;
	}
	private void DetachEventHandlers()
	{
		Emu.StateLoaded -= Emu_StateLoaded;

		if (GameSurface != null)
		{
			GameSurface.MouseDown -= GameSurface_MouseDown;
			GameSurface.MouseUp -= GameSurface_MouseUp;

			GameSurface.SizeChanged -= GameSurface_SizeChanged;
		}

		RaycastSelectionTimer.Tick -= RaycastSelectionTimer_Tick;

		BtnCameraFly.LostFocus -= BtnCameraFly_LostFocus;
		BtnCameraFps.LostFocus -= BtnCameraFps_LostFocus;

		StageLoaded -= UpdateArrays;
		StageLoaded -= LoadHarryModel;

		NudFramebufferOfsX.ValueChanged -= NudFramebuffer_ValueChanged;
		NudFramebufferOfsY.ValueChanged -= NudFramebuffer_ValueChanged;
		NudFramebufferW.ValueChanged -= NudFramebuffer_ValueChanged;
		NudFramebufferH.ValueChanged -= NudFramebuffer_ValueChanged;
	}

	private void OnStageLoaded(object sender, EventArgs e)
	{
		StageLoaded?.Invoke(sender, e);
	}

	private void UpdateArrays(object sender, EventArgs e)
	{
		BtnReadTriggers_Click(this, EventArgs.Empty);
		BtnCameraPathReadArray_Click(this, EventArgs.Empty);
	}

	private void Nud_KeyDown(object sender, KeyEventArgs e)
	{
		if (sender is NumericUpDown nud && e.KeyCode == Keys.Enter)
		{
			nud.ResetIfBad(this);
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
	}

	private void Nud_Leave(object sender, EventArgs e)
	{
		if (sender is NumericUpDown nud)
		{
			nud.ResetIfBad(this);
		}
	}
	private void Selectable_Enter(object sender, EventArgs e)
	{
		if (sender is NumericUpDown nud)
		{
			nud.Select(0, nud.Text.Length);
		}
		else if (sender is TextBox tbx)
		{
			tbx.SelectAll();
		}
	}
}
