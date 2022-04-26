namespace SHME.ExternalTool
{
	public class USRetail : Rom
	{
		public override string Name => USRetailConstants.Name;

		public override string HashBizHawk => USRetailConstants.HashBizHawk;
		public override string HashCrc32 => USRetailConstants.HashCrc32;
		public override string HashMd5 => USRetailConstants.HashMd5;
		public override string HashSha1 => USRetailConstants.HashSha1;

		public override Addresses Addresses { get; } = new Addresses()
		{
			MainRam = new MainRamAddresses()
			{
				BaseAddress = 0x80000000,

				IndexOfSelectedSaveLoadSlot = 0xA97D4,
				IndexOfSelectedTitleScreenOption = 0xA9A78,
				SaveLoadSlotCount = 0xBCD28, // Includes "New save". Mirrored at 0xBCD30.

				IndexOfMostRecentlyActiveString = 0xA99AC,

				// Number of saves in current run; changing the latter
				// address actually changes what the save management
				// screen shows at the bottom for the "Saves" stat.
				//0xB2784
				//0xB278F

				// Currently loaded save data? Saves are apparently
				// 0x280 (640) bytes long, so this goes up through
				// 0x0xB5C18 (i.e. up to but excluding 0xB5C1C).
				// Hmm, doesn't seem to change anything.
				// This might simply reflect the most recently
				// saved game?
				// 0xB599C

				IsCameraUnlocked = 0xB9CD0,

				CameraSpringArmTensionX = 0xAFCD0, // Mirrored at 0xB9D04
				CameraSpringArmTensionY = 0xAFCD4, // Mirrored at 0xB9D08
				CameraSpringArmTensionZ = 0xAFCD8, // Mirrored at 0xB9D0C

				// Hmm...could these conceivably be the translation parts of
				// a full-on projection matrix? Hadn't paid too much attention
				// to the stuff surrounding them, but it's plausible. If I can
				// interpret the whole thing I can determine the FOV, aspect
				// ratio, the whole deal. Just need to figure it all out.
				CameraPositionIdealX = 0xB9D14,
				CameraPositionIdealY = 0xB9D18,
				CameraPositionIdealZ = 0xB9D1C,

				CameraPositionActualX = 0xB9D20,
				CameraPositionActualY = 0xB9D24,
				CameraPositionActualZ = 0xB9D28,

				CameraLookAtX = 0xB9D4C,
				CameraLookAtY = 0xB9D50,
				CameraLookAtZ = 0xB9D54,

				CameraActualPitch = 0xB9D5E,
				CameraActualYaw = 0xB9D60, // No.
				//CameraActualYaw = 0xB9D68, // No.
				//CameraActualYaw = 0xB9D78, // No.
				CameraActualRoll = 0xB9D62,

				CameraIdealPitch = 0xB9D88,
				CameraIdealYaw = 0xB9D8A,
				CameraIdealRoll = 0xB9D8C,

				CameraRollThing = 0xB9D98, // Low 12 bits is current camera roll speed(?), split in half: 0x000 through 0x7FF rotates CCW relative to camera (CW in terms of the coordinate system, i.e. when looking against the direction of the camera's front vector), while 0x800 through 0xFFF go the other way.
				// Well now wait, there's more than that. 0x00 through 0x4F roll left a certain distance and then stop. At 0x50, the camera starts rolling further and then loops around, perpetually. Not sure what's going on.
				// More details: freezing 0xB9D5E through 0xB9D94, then playing with this value, shows it just does rotation about one world axis. X, I think, and doesn't actually do the perpetual spin thing on its own. I guess this might just be the camera's orientation expressed in world coordinates instead of local coordinates?

				CameraLockedToHead = 0xB9DA8,

				ActiveTriggerType = 0xB9FC8,

				HarryPositionX = 0xBA024,
				HarryPositionY = 0xBA028,
				HarryPositionZ = 0xBA02C,

				HarryHealth = 0xBA0BC,

				HarryUpperBodyAnimation = 0xBA138,

				Thing1 = 0xBA0F8, // Harry position Z, but lags behind 0xBA028? Catches up eventually.

				HarryPitch = 0xBA030,
				HarryYaw = 0xBA032, // Mirrored at 0xBA036
				HarryRoll = 0xBA034,

				HarryPositionXTwo = 0xBA040,

				HarryState = 0xBA150,

				SaveData = 0xBCA34,
				// 0xBCA35 // Health drink count
				// 0xBCA39 // First aid kit count

				Inventory = 0xBCADC, // Not quite. The most significant byte reflects the number of item slots, but doesn't give you the items.
				TriggerState = 0xBCB98,
				ItemCount = 0xBCC70,

				TotalTime = 0xBCC84,
				RunningDistance = 0xBCC88,
				WalkingDistance = 0xBCC8C,

				FramebufferWidth = 0xBCCB0,
				// Keep these two in sync if adjusting by hand! Rendering goes screwy otherwise.
				FramebufferHeight = 0xBCCB2,
				ProjectionPlaneDistanceCurrent = 0xB9D00,

				LastHarrySpawnPoint = 0xBCDB0,

				HarryModelPointer = 0xBE46C,

				FogEnabled = 0xC4169,

				ScreenBrightness = 0xC4170,

				// 32 bit, Q24.8 format; has no effect when fog is disabled.
				DrawDistance = 0xC4178,

				FogThing1 = 0xC417C,
				FogThing2 = 0xC4180,

				FogColorR = 0xC4184,
				FogColorG = 0xC4185,
				FogColorB = 0xC4186,

				WorldTintR = 0xC4190,
				WorldTintG = 0xC4191,
				WorldTintB = 0xC4192,

				// One byte; which ending is displayed on the stats
				// screen.
				// 0x01 - GOOD+
				// 0x02 - GOOD
				// 0x04 - BAD+
				// 0x08 - BAD
				// 0x10 - UFO
				// 0xC48B2

				SnowVolumeHeightMaybe = 0xC6FA8,

				ButtonFlags = 0xC71A2,

				MapHeader = 0xC9578,
				MapChunkset = 0xC9578 + 0x4,
				Pointer2 = 0xC9578 + 0x8,
				Value1 = 0xC9578 + 0xC,
				Pointer3 = 0xC9578 + 0x10,
				Pointer4 = 0xC9578 + 0x14,
				Value2 = 0xC9578 + 0x18,
				Pointer5 = 0xC9578 + 0x1C,
				PointerToArrayOfPointsOfInterest = 0xC9578 + 0x20,
				PointerToArrayOfPointersToFunctions = 0xC9578 + 0x24,
				PointerToArrayOfTriggersMaybe = 0xC9578 + 0x28,
				Pointer9 = 0xC9578 + 0x2C,
				Pointer10 = 0xC9578 + 0x30,
				PointerToArrayOfPointersToStrings = 0xC9578 + 0x34,
				Pointer12 = 0xC9578 + 0x38,
				Pointer13 = 0xC9578 + 0x3C,
				Pointer14 = 0xC9578 + 0x40,
				Pointer15 = 0xC9578 + 0x44,
				Value3 = 0xC9578 + 0x48,
				Pointer16 = 0xC9578 + 0x4C,
				Pointer17 = 0xC9578 + 0x50,
				Value4 = 0xC9578 + 0x54,
				Pointer18 = 0xC9578 + 0x58,
				Value5 = 0xC9578 + 0x5C,
				PointerToUnknownThingAfterArrayOfTriggers = 0xC9578 + 0x188,

				MapTim = 0x1CF600
			}
		};
	}
}
