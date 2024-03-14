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

		public static readonly Collection<InputBind> FlyBinds = new([
			new(ShmeCommand.Forward, Keys.W, MouseButtons.None),
			new(ShmeCommand.Backward, Keys.S, MouseButtons.None),
			new(ShmeCommand.Left, Keys.A, MouseButtons.None),
			new(ShmeCommand.Right, Keys.D, MouseButtons.None),
			new(ShmeCommand.Up, Keys.E, MouseButtons.None),
			new(ShmeCommand.Down, Keys.Q, MouseButtons.None)]);

		public static readonly Collection<InputBind> FpsBinds = new([
			new(ShmeCommand.Forward, Keys.W, MouseButtons.None),
			new(ShmeCommand.Backward, Keys.S, MouseButtons.None),
			new(ShmeCommand.Left, Keys.A, MouseButtons.None),
			new(ShmeCommand.Right, Keys.D, MouseButtons.None),
			new(ShmeCommand.Action, Keys.E, MouseButtons.Left),
			new(ShmeCommand.Aim, Keys.Q, MouseButtons.Right),
			new(ShmeCommand.Light, Keys.F, MouseButtons.None),
			new(ShmeCommand.Run, Keys.ShiftKey, MouseButtons.None),
			new(ShmeCommand.View, Keys.Z, MouseButtons.None),
			new(ShmeCommand.Map, Keys.C, MouseButtons.None)]);
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

		public virtual Collection<InputBind> FlyBinds { get; } = [];
		public virtual Collection<InputBind> FpsBinds { get; } = [];

		// Save tab
		public virtual int SaveButton { get; set; } = DefaultLocalSettings.SaveButton;
	}
}
