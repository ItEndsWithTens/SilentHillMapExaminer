using Nucs.JsonSettings;
using Nucs.JsonSettings.Modulation;
using System;

namespace SHME.ExternalTool.Extras
{
	public static class DefaultRoamingSettings
	{
		// Basics tab
		public static readonly bool EnableHarrySection = true;
		public static readonly bool EnableOverlay;

		public static readonly decimal CameraFlySpeed = 0.125m;
		public static readonly bool HideHarry = true;
		public static readonly bool ShowFeet = true;
		public static readonly decimal EyeHeight = -1.6m;
		public static readonly bool AlwaysRun = true;

		public static readonly bool EnableOverlayCameraReporting;
		public static readonly bool ReadLevelDataOnStageLoad;
		public static readonly bool RenderToFramebuffer;
		public static readonly bool BackfaceCulling;
		public static readonly bool FarClipping = true;
		public static readonly decimal CrosshairLength = 2.5m;
		public static readonly decimal FilledOpacity = 30.0m;
		public static readonly int RenderMode;

		// POIs tab
		public static readonly bool SelectedTriggerEnableUpdates = true;
		public static readonly int PoiRenderShape;
		public static readonly bool AxisColorsGame = true;
		public static readonly bool AxisColorsOverlay;
		public static readonly bool AxisColorsOff;

		// Stats tab
		public static readonly bool EnableStatsReporting = true;

		// Fog tab
		public static readonly decimal CustomFogR = 108m;
		public static readonly decimal CustomFogG = 100m;
		public static readonly decimal CustomFogB = 116m;
		public static readonly decimal CustomWorldTintR = 121m;
		public static readonly decimal CustomWorldTintG = 128m;
		public static readonly decimal CustomWorldTintB = 138m;

		// Test tab
		public static readonly bool EnableTestModelSection;
		public static readonly int TestModelScale = 1000;
		public static readonly decimal TestModelX;
		public static readonly decimal TestModelY;
		public static readonly decimal TestModelZ;

		public static readonly bool EnableTestBox;
		public static readonly decimal TestBoxX;
		public static readonly decimal TestBoxY;
		public static readonly decimal TestBoxZ;
		public static readonly decimal TestBoxSizeX = 1m;
		public static readonly decimal TestBoxSizeY = 1m;
		public static readonly decimal TestBoxSizeZ = 1m;

		public static readonly bool EnableTestLine;
		public static readonly decimal TestLineAX;
		public static readonly decimal TestLineAY = -1m;
		public static readonly decimal TestLineAZ;
		public static readonly decimal TestLineBX = 1m;
		public static readonly decimal TestLineBY = -1m;
		public static readonly decimal TestLineBZ;

		public static readonly bool EnableTestSheet;
		public static readonly decimal TestSheetX;
		public static readonly decimal TestSheetY;
		public static readonly decimal TestSheetZ;
		public static readonly decimal TestSheetSizeX = 1m;
		public static readonly decimal TestSheetSizeZ = 1m;

		// Framebuffer tab
		public static readonly decimal FramebufferOfsX = 0m;
		public static readonly decimal FramebufferOfsY = 32m;
		public static readonly decimal FramebufferW = 320m;
		public static readonly decimal FramebufferH = 448m;
		public static readonly int FramebufferZoom = 3;

		// Misc tab
		public static readonly bool EnableControllerReporting;
	}

	public class RoamingSettings : JsonSettings, IVersionable
	{
		public Version Version { get; set; } = new Version(1, 0, 0, 0);

		public override string FileName { get; set; } = "roaming.json";

		// Basics tab
		virtual public bool EnableHarrySection { get; set; } = DefaultRoamingSettings.EnableHarrySection;
		virtual public bool EnableOverlay { get; set; } = DefaultRoamingSettings.EnableOverlay;

		virtual public decimal CameraFlySpeed { get; set; } = DefaultRoamingSettings.CameraFlySpeed;
		virtual public bool HideHarry { get; set; } = DefaultRoamingSettings.HideHarry;
		virtual public bool ShowFeet { get; set; } = DefaultRoamingSettings.ShowFeet;
		virtual public decimal EyeHeight { get; set; } = DefaultRoamingSettings.EyeHeight;
		virtual public bool AlwaysRun { get; set; } = DefaultRoamingSettings.AlwaysRun;

		virtual public bool EnableOverlayCameraReporting { get; set; } = DefaultRoamingSettings.EnableOverlayCameraReporting;
		virtual public bool ReadLevelDataOnStageLoad { get; set; } = DefaultRoamingSettings.ReadLevelDataOnStageLoad;
		virtual public bool RenderToFramebuffer { get; set; } = DefaultRoamingSettings.RenderToFramebuffer;
		virtual public bool BackfaceCulling { get; set; } = DefaultRoamingSettings.BackfaceCulling;
		virtual public bool FarClipping { get; set; } = DefaultRoamingSettings.FarClipping;
		virtual public decimal CrosshairLength { get; set; } = DefaultRoamingSettings.CrosshairLength;
		virtual public decimal FilledOpacity { get; set; } = DefaultRoamingSettings.FilledOpacity;
		virtual public int RenderMode { get; set; } = DefaultRoamingSettings.RenderMode;

		// POIs tab
		virtual public bool SelectedTriggerEnableUpdates { get; set; } = DefaultRoamingSettings.SelectedTriggerEnableUpdates;
		virtual public int PoiRenderShape { get; set; } = DefaultRoamingSettings.PoiRenderShape;
		virtual public bool AxisColorsGame { get; set; } = DefaultRoamingSettings.AxisColorsGame;
		virtual public bool AxisColorsOverlay { get; set; } = DefaultRoamingSettings.AxisColorsOverlay;
		virtual public bool AxisColorsOff { get; set; } = DefaultRoamingSettings.AxisColorsOff;

		// Stats tab
		virtual public bool EnableStatsReporting { get; set; } = DefaultRoamingSettings.EnableStatsReporting;

		// Fog tab
		virtual public decimal CustomFogR { get; set; } = DefaultRoamingSettings.CustomFogR;
		virtual public decimal CustomFogG { get; set; } = DefaultRoamingSettings.CustomFogG;
		virtual public decimal CustomFogB { get; set; } = DefaultRoamingSettings.CustomFogB;
		virtual public decimal CustomWorldTintR { get; set; } = DefaultRoamingSettings.CustomWorldTintR;
		virtual public decimal CustomWorldTintG { get; set; } = DefaultRoamingSettings.CustomWorldTintG;
		virtual public decimal CustomWorldTintB { get; set; } = DefaultRoamingSettings.CustomWorldTintB;

		// Test tab
		virtual public bool EnableTestModelSection { get; set; } = DefaultRoamingSettings.EnableTestModelSection;
		virtual public int TestModelScale { get; set; } = DefaultRoamingSettings.TestModelScale;
		virtual public decimal TestModelX { get; set; } = DefaultRoamingSettings.TestModelX;
		virtual public decimal TestModelY { get; set; } = DefaultRoamingSettings.TestModelY;
		virtual public decimal TestModelZ { get; set; } = DefaultRoamingSettings.TestModelZ;

		virtual public bool EnableTestBox { get; set; } = DefaultRoamingSettings.EnableTestBox;
		virtual public decimal TestBoxX { get; set; } = DefaultRoamingSettings.TestBoxX;
		virtual public decimal TestBoxY { get; set; } = DefaultRoamingSettings.TestBoxY;
		virtual public decimal TestBoxZ { get; set; } = DefaultRoamingSettings.TestBoxZ;
		virtual public decimal TestBoxSizeX { get; set; } = DefaultRoamingSettings.TestBoxSizeX;
		virtual public decimal TestBoxSizeY { get; set; } = DefaultRoamingSettings.TestBoxSizeY;
		virtual public decimal TestBoxSizeZ { get; set; } = DefaultRoamingSettings.TestBoxSizeZ;

		virtual public bool EnableTestLine { get; set; } = DefaultRoamingSettings.EnableTestLine;
		virtual public decimal TestLineAX { get; set; } = DefaultRoamingSettings.TestLineAX;
		virtual public decimal TestLineAY { get; set; } = DefaultRoamingSettings.TestLineAY;
		virtual public decimal TestLineAZ { get; set; } = DefaultRoamingSettings.TestLineAZ;
		virtual public decimal TestLineBX { get; set; } = DefaultRoamingSettings.TestLineBX;
		virtual public decimal TestLineBY { get; set; } = DefaultRoamingSettings.TestLineBY;
		virtual public decimal TestLineBZ { get; set; } = DefaultRoamingSettings.TestLineBZ;


		virtual public bool EnableTestSheet { get; set; } = DefaultRoamingSettings.EnableTestSheet;
		virtual public decimal TestSheetX { get; set; } = DefaultRoamingSettings.TestSheetX;
		virtual public decimal TestSheetY { get; set; } = DefaultRoamingSettings.TestSheetY;
		virtual public decimal TestSheetZ { get; set; } = DefaultRoamingSettings.TestSheetZ;
		virtual public decimal TestSheetSizeX { get; set; } = DefaultRoamingSettings.TestSheetSizeX;
		virtual public decimal TestSheetSizeZ { get; set; } = DefaultRoamingSettings.TestSheetSizeZ;

		// Framebuffer tab
		virtual public decimal FramebufferOfsX { get; set; } = DefaultRoamingSettings.FramebufferOfsX;
		virtual public decimal FramebufferOfsY { get; set; } = DefaultRoamingSettings.FramebufferOfsY;
		virtual public decimal FramebufferW { get; set; } = DefaultRoamingSettings.FramebufferW;
		virtual public decimal FramebufferH { get; set; } = DefaultRoamingSettings.FramebufferH;
		virtual public int FramebufferZoom { get; set; } = DefaultRoamingSettings.FramebufferZoom;

		// Misc tab
		virtual public bool EnableControllerReporting { get; set; } = DefaultRoamingSettings.EnableControllerReporting;
	}
}
