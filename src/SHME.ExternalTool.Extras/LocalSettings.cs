using Nucs.JsonSettings;
using Nucs.JsonSettings.Modulation;
using System;

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
		virtual public bool CameraFlyInvert { get; set; } = DefaultLocalSettings.CameraFlyInvert;
		virtual public decimal CameraFlySensitivity { get; set; } = DefaultLocalSettings.CameraFlySensitivity;

		// Save tab
		virtual public int SaveButton { get; set; } = DefaultLocalSettings.SaveButton;
	}
}
