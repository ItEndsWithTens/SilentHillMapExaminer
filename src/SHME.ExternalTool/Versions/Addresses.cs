namespace SHME.ExternalTool
{
	public class Addresses
	{
		public MainRamAddresses MainRam { get; set; } = new MainRamAddresses();
	}

	public class MainRamAddresses
	{
		public long BaseAddress { get; set; }

		public long VramCroppedWidth { get; set; }
		public long VramCroppedHeight { get; set; }

		public long ACameraThingFirst { get; set; }
		public long CameraMatrixTranslationX { get; set; }
		public long CameraMatrixTranslationY { get; set; }
		public long CameraMatrixTranslationZ { get; set; }
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

		public long CameraPositionIdealX { get; set; }
		public long CameraPositionIdealY { get; set; }
		public long CameraPositionIdealZ { get; set; }

		public long CameraPositionActualX { get; set; }
		public long CameraPositionActualY { get; set; }
		public long CameraPositionActualZ { get; set; }

		public long CameraLookAtX { get; set; }
		public long CameraLookAtY { get; set; }
		public long CameraLookAtZ { get; set; }

		public long CameraActualPitch { get; set; }
		public long CameraActualYaw { get; set; }
		public long CameraActualRoll { get; set; }

		public long CameraIdealPitch { get; set; }
		public long CameraIdealYaw { get; set; }
		public long CameraIdealRoll { get; set; }

		public long CameraLockedToHead { get; set; }

		public long HarryPositionX { get; set; }
		public long HarryPositionY { get; set; }
		public long HarryPositionZ { get; set; }

		public long HarryHealth { get; set; }

		public long HarryUpperBodyAnimation { get; set; }

		public long Thing1 { get; set; }

		public long HarryPitch { get; set; }
		public long HarryYaw { get; set; }
		public long HarryRoll { get; set; }

		public long HarryPositionXTwo { get; set; }

		public long HarryState { get; set; }

		public long InventoryFirst { get; set; }
		public long Inventory { get; set; }
		public long ItemCount { get; set; }

		public long TotalTime { get; set; }
		public long RunningDistance { get; set; }
		public long WalkingDistance { get; set; }

		public long FramebufferWidth { get; set; }
		public long FramebufferHeight { get; set; }
		public long ProjectionPlaneDistanceCurrent { get; set; }

		public long LastHarrySpawnPoint { get; set; }

		public long HarryModelPointer { get; set; }

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
		public long PointerToArrayOfPointsOfInterest { get; set; }
		public long PointerToArrayOfPointersToFunctions { get; set; }
		public long PointerToArrayOfTriggersMaybe { get; set; }
		public long Pointer9 { get; set; }
		public long Pointer10 { get; set; }
		public long PointerToArrayOfPointersToStrings { get; set; }
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
		public long PointerToUnknownThingAfterArrayOfTriggers { get; set; }

		public long MapTim { get; set; }
	}
}
