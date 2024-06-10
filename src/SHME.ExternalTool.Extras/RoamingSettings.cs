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
		public static readonly bool Antialiasing;
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

		// Settings tab
		public static readonly bool OverlayDisplaySurfaceClient = true;
		public static readonly bool OverlayDisplaySurfaceEmuCore;
		public static readonly bool OverlayDisplaySurfaceFramebuffer;
	}

	public class RoamingSettings : JsonSettings, IVersionable
	{
		public Version Version { get; set; } = new Version(1, 0, 0, 0);

		public override string FileName { get; set; } = "roaming.json";

		// Basics tab
		public virtual bool EnableHarrySection { get; set; } = DefaultRoamingSettings.EnableHarrySection;
		public virtual bool EnableOverlay { get; set; } = DefaultRoamingSettings.EnableOverlay;

		public virtual decimal CameraFlySpeed { get; set; } = DefaultRoamingSettings.CameraFlySpeed;
		public virtual bool HideHarry { get; set; } = DefaultRoamingSettings.HideHarry;
		public virtual bool ShowFeet { get; set; } = DefaultRoamingSettings.ShowFeet;
		public virtual decimal EyeHeight { get; set; } = DefaultRoamingSettings.EyeHeight;
		public virtual bool AlwaysRun { get; set; } = DefaultRoamingSettings.AlwaysRun;

		public virtual bool EnableOverlayCameraReporting { get; set; } = DefaultRoamingSettings.EnableOverlayCameraReporting;
		public virtual bool ReadLevelDataOnStageLoad { get; set; } = DefaultRoamingSettings.ReadLevelDataOnStageLoad;
		public virtual bool Antialiasing { get; set; } = DefaultRoamingSettings.Antialiasing;
		public virtual bool BackfaceCulling { get; set; } = DefaultRoamingSettings.BackfaceCulling;
		public virtual bool FarClipping { get; set; } = DefaultRoamingSettings.FarClipping;
		public virtual decimal CrosshairLength { get; set; } = DefaultRoamingSettings.CrosshairLength;
		public virtual decimal FilledOpacity { get; set; } = DefaultRoamingSettings.FilledOpacity;
		public virtual int RenderMode { get; set; } = DefaultRoamingSettings.RenderMode;

		// POIs tab
		public virtual bool SelectedTriggerEnableUpdates { get; set; } = DefaultRoamingSettings.SelectedTriggerEnableUpdates;
		public virtual int PoiRenderShape { get; set; } = DefaultRoamingSettings.PoiRenderShape;
		public virtual bool AxisColorsGame { get; set; } = DefaultRoamingSettings.AxisColorsGame;
		public virtual bool AxisColorsOverlay { get; set; } = DefaultRoamingSettings.AxisColorsOverlay;
		public virtual bool AxisColorsOff { get; set; } = DefaultRoamingSettings.AxisColorsOff;

		// Stats tab
		public virtual bool EnableStatsReporting { get; set; } = DefaultRoamingSettings.EnableStatsReporting;

		// Fog tab
		public virtual decimal CustomFogR { get; set; } = DefaultRoamingSettings.CustomFogR;
		public virtual decimal CustomFogG { get; set; } = DefaultRoamingSettings.CustomFogG;
		public virtual decimal CustomFogB { get; set; } = DefaultRoamingSettings.CustomFogB;
		public virtual decimal CustomWorldTintR { get; set; } = DefaultRoamingSettings.CustomWorldTintR;
		public virtual decimal CustomWorldTintG { get; set; } = DefaultRoamingSettings.CustomWorldTintG;
		public virtual decimal CustomWorldTintB { get; set; } = DefaultRoamingSettings.CustomWorldTintB;

		// Test tab
		public virtual bool EnableTestModelSection { get; set; } = DefaultRoamingSettings.EnableTestModelSection;
		public virtual int TestModelScale { get; set; } = DefaultRoamingSettings.TestModelScale;
		public virtual decimal TestModelX { get; set; } = DefaultRoamingSettings.TestModelX;
		public virtual decimal TestModelY { get; set; } = DefaultRoamingSettings.TestModelY;
		public virtual decimal TestModelZ { get; set; } = DefaultRoamingSettings.TestModelZ;

		public virtual bool EnableTestBox { get; set; } = DefaultRoamingSettings.EnableTestBox;
		public virtual decimal TestBoxX { get; set; } = DefaultRoamingSettings.TestBoxX;
		public virtual decimal TestBoxY { get; set; } = DefaultRoamingSettings.TestBoxY;
		public virtual decimal TestBoxZ { get; set; } = DefaultRoamingSettings.TestBoxZ;
		public virtual decimal TestBoxSizeX { get; set; } = DefaultRoamingSettings.TestBoxSizeX;
		public virtual decimal TestBoxSizeY { get; set; } = DefaultRoamingSettings.TestBoxSizeY;
		public virtual decimal TestBoxSizeZ { get; set; } = DefaultRoamingSettings.TestBoxSizeZ;

		public virtual bool EnableTestLine { get; set; } = DefaultRoamingSettings.EnableTestLine;
		public virtual decimal TestLineAX { get; set; } = DefaultRoamingSettings.TestLineAX;
		public virtual decimal TestLineAY { get; set; } = DefaultRoamingSettings.TestLineAY;
		public virtual decimal TestLineAZ { get; set; } = DefaultRoamingSettings.TestLineAZ;
		public virtual decimal TestLineBX { get; set; } = DefaultRoamingSettings.TestLineBX;
		public virtual decimal TestLineBY { get; set; } = DefaultRoamingSettings.TestLineBY;
		public virtual decimal TestLineBZ { get; set; } = DefaultRoamingSettings.TestLineBZ;


		public virtual bool EnableTestSheet { get; set; } = DefaultRoamingSettings.EnableTestSheet;
		public virtual decimal TestSheetX { get; set; } = DefaultRoamingSettings.TestSheetX;
		public virtual decimal TestSheetY { get; set; } = DefaultRoamingSettings.TestSheetY;
		public virtual decimal TestSheetZ { get; set; } = DefaultRoamingSettings.TestSheetZ;
		public virtual decimal TestSheetSizeX { get; set; } = DefaultRoamingSettings.TestSheetSizeX;
		public virtual decimal TestSheetSizeZ { get; set; } = DefaultRoamingSettings.TestSheetSizeZ;

		// Framebuffer tab
		public virtual decimal FramebufferOfsX { get; set; } = DefaultRoamingSettings.FramebufferOfsX;
		public virtual decimal FramebufferOfsY { get; set; } = DefaultRoamingSettings.FramebufferOfsY;
		public virtual decimal FramebufferW { get; set; } = DefaultRoamingSettings.FramebufferW;
		public virtual decimal FramebufferH { get; set; } = DefaultRoamingSettings.FramebufferH;
		public virtual int FramebufferZoom { get; set; } = DefaultRoamingSettings.FramebufferZoom;

		// Misc tab
		public virtual bool EnableControllerReporting { get; set; } = DefaultRoamingSettings.EnableControllerReporting;

		// Settings tab
		public virtual bool OverlayDisplaySurfaceClient { get; set; } = DefaultRoamingSettings.OverlayDisplaySurfaceClient;
		public virtual bool OverlayDisplaySurfaceEmuCore { get; set; } = DefaultRoamingSettings.OverlayDisplaySurfaceEmuCore;
		public virtual bool OverlayDisplaySurfaceFramebuffer { get; set; } = DefaultRoamingSettings.OverlayDisplaySurfaceFramebuffer;
	}
}
