﻿namespace SHME.ExternalTool
{
	// Reference:
	//
	// Silent Hill's coordinate system appears to be consistent with the one
	// described in Sony's "File Formats" document. The March 2000 revision,
	// chapter 2, page 2-4, describes a scheme used in PLY files that also
	// seems to apply in other contexts, this game's world coordinates being
	// one of them. It's unusual, and relative to the town map view, accessed
	// with the triangle button in game, is oriented as follows:
	//
	//	Positive X points north
	//	Positive Z points east
	//	Positive Y points down
	//
	// Rotations therefore follow the convention of:
	//
	//	Pitch is rotation about Z
	//	Yaw is rotation about Y
	//	Roll is rotation about X
	//
	// Positive rotation goes counter-clockwise, as seen facing the negative
	// direction of the given axis. A yaw value of 0 in game aims Harry north,
	// along Bachman Road, hence the unconventional use of X for north-south.
	//
	// The 3D rendering conventions of this library obey a more traditional
	// Y-up, right-handed coordinate system, which means:
	//
	//	Positive X points east
	//	Positive Z points south
	//	Positive Y points up
	//
	// Rotations in turn become:
	//
	//	Pitch is rotation about Z
	//	Yaw is rotation about Y
	//	Roll is rotation about X
	//
	// Positive rotation goes counter-clockwise, as seen facing the negative
	// direction of the given axis.

	public class Addresses
	{
		public MainRamAddresses MainRam { get; set; } = new MainRamAddresses();
	}

	public class MainRamAddresses
	{
		public long VramCroppedWidth { get; set; }
		public long VramCroppedHeight { get; set; }

		public long ACameraThingFirst { get; set; }
		public long CameraMatrixTranslationZ { get; set; }
		public long CameraMatrixTranslationY { get; set; }
		public long CameraMatrixTranslationX { get; set; }
		public long Blah1 { get; set; }
		public long ACameraThingLast { get; set; }

		public long Mat11_12 { get; set; }
		public long Mat13_21 { get; set; }
		public long Mat22_23 { get; set; }
		public long Mat31_32 { get; set; }
		public long Mat33 { get; set; }

		public long GteTranslationInputX { get; set; }
		public long GteTranslationInputY { get; set; }
		public long GteTranslationInputZ { get; set; }

		public long IsCameraUnlocked { get; set; }

		public long CameraPositionIdealZ { get; set; }
		public long CameraPositionIdealY { get; set; }
		public long CameraPositionIdealX { get; set; }

		public long CameraPositionActualZ { get; set; }
		public long CameraPositionActualY { get; set; }
		public long CameraPositionActualX { get; set; }

		public long CameraActualPitch { get; set; }
		public long CameraActualYaw { get; set; }
		public long CameraActualRoll { get; set; }

		public long CameraIdealPitch { get; set; }
		public long CameraIdealYaw { get; set; }
		public long CameraIdealRoll { get; set; }

		public long CameraLockedToHead { get; set; }

		public long HarryPositionZ { get; set; }
		public long HarryPositionY { get; set; }
		public long HarryPositionX { get; set; }

		public long HarryHealth { get; set; }

		public long HarryUpperBodyAnimation { get; set; }

		public long Thing1 { get; set; }

		public long HarryPitch { get; set; }
		public long HarryYaw { get; set; }
		public long HarryRoll { get; set; }

		public long HarryPositionZTwo { get; set; }

		public long HarryParalyzed { get; set; }

		public long InventoryFirst { get; set; }
		public long Inventory { get; set; }
		public long ItemCount { get; set; }

		public long DistanceRun { get; set; }
		public long DistanceWalked { get; set; }

		public long FramebufferWidth { get; set; }
		public long FramebufferHeight { get; set; }
		public long ProjectionPlaneDistanceCurrent { get; set; }

		public long FogEnabled { get; set; }

		public long ScreenBrightness { get; set; }

		public long DrawDistance { get; set; }

		public long FogThing1 { get; set; }
		public long FogThing2 { get; set; }

		public long FogColorR { get; set; }
		public long FogColorG { get; set; }
		public long FogColorB { get; set; }

		public long WorldTintR { get; set; }
		public long WorldTintG { get; set; }
		public long WorldTintB { get; set; }

		public long SnowVolumeHeightMaybe { get; set; }

		public long ButtonFlags { get; set; }

		public long MapHeader { get; set; }
		public long MapChunkset { get; set; }
		public long Pointer2 { get; set; }
		public long Value1 { get; set; }
		public long Pointer3 { get; set; }
		public long Pointer4 { get; set; }
		public long Value2 { get; set; }
		public long Pointer5 { get; set; }
		public long TriggerVertexTable { get; set; }
		public long Pointer7 { get; set; }
		public long Pointer8 { get; set; }
		public long Pointer9 { get; set; }
		public long Pointer10 { get; set; }
		public long Pointer11 { get; set; }
		public long Pointer12 { get; set; }
		public long Pointer13 { get; set; }
		public long Pointer14 { get; set; }
		public long Pointer15 { get; set; }
		public long Value3 { get; set; }
		public long Pointer16 { get; set; }
		public long Pointer17 { get; set; }
		public long Value4 { get; set; }
		public long Pointer18 { get; set; }
		public long Value5 { get; set; }

		public long MapTim { get; set; }
	}
}
