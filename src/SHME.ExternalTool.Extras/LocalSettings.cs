using Nucs.JsonSettings;
using Nucs.JsonSettings.Modulation;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace SHME.ExternalTool.Extras
{
	public static class DefaultLocalSettings
	{
		// This is tough to easily place in either local or roaming settings,
		// but local might make slightly more sense? Beyond personal preference,
		// whether one prefers to invert could depend on mouse vs. touchpad vs.
		// trackball, among other considerations.
		public static readonly bool CameraFlyInvert;

		// Different input hardware means different sensitivity.
		public static readonly decimal CameraFlySensitivity = 0.25m;

		public static readonly int SaveButton;

		public static readonly Collection<InputBind> FirstPersonBinds = new([
			new(GameCommand.Forward, Keys.W, MouseButtons.None),
			new(GameCommand.Backward, Keys.S, MouseButtons.None),
			new(GameCommand.Action, Keys.E, MouseButtons.Left),
			new(GameCommand.Aim, Keys.Q, MouseButtons.Right),
			new(GameCommand.Light, Keys.F, MouseButtons.None),
			new(GameCommand.Run, Keys.ShiftKey, MouseButtons.None),
			new(GameCommand.View, Keys.Z, MouseButtons.None),
			new(GameCommand.StepLeft, Keys.A, MouseButtons.None),
			new(GameCommand.StepRight, Keys.D, MouseButtons.None)]);
	}

	// Hiding this class, and RoamingSettings, in a satellite assembly turns out
	// to be necessary to prevent BizHawk from failing to load this external
	// tool. Being classes derived from bases defined in an external assembly,
	// they cause problems the first time BizHawk enumerates its external tools
	// directory. Breaking them out to this extra assembly solves that.
	public class LocalSettings : JsonSettings, IVersionable
	{
		public Version Version { get; set; } = new Version(1, 0, 0, 0);

		public override string FileName { get; set; } = "local.json";

		// Basics tab
		public virtual bool CameraFlyInvert { get; set; } = DefaultLocalSettings.CameraFlyInvert;
		public virtual decimal CameraFlySensitivity { get; set; } = DefaultLocalSettings.CameraFlySensitivity;

		public virtual Collection<InputBind> FirstPersonBinds { get; } = [];

		// Save tab
		public virtual int SaveButton { get; set; } = DefaultLocalSettings.SaveButton;
	}
}
