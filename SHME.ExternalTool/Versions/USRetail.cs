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
				ACameraThingFirst = 0xC3804,
				CameraMatrixTranslationZ = 0xC3850,
				CameraMatrixTranslationY = 0xC3854,
				CameraMatrixTranslationX = 0xC3858,
				Blah1 = 0xC3888, // As the camera's ideal yaw reaches 0, this reaches 1.
				ACameraThingLast = 0xC3898,

				// Just a quick test, assuming this actually is a matrix.
				Mat11_12 = 0xC3804,
				Mat13_21 = 0xC3808,
				Mat22_23 = 0xC380C,
				Mat31_32 = 0xC3810,
				Mat33 = 0xC3814,

				// From the no$psx docs:
				//
				// cop2r37 (cnt5) - TRX - Translation vector X (R/W?)
				// cop2r38 (cnt6) - TRY - Translation vector Y (R/W?)
				// cop2r39 (cnt7) - TRZ - Translation vector Z (R/W?)
				// Each element is 32bit (1bit sign, 31bit integer).
				// Used only for MVMVA, RTPS, RTPT commands.
				GteTranslationInputX = 0xB0320,
				GteTranslationInputY = 0xB0324,
				GteTranslationInputZ = 0xB0328,

				IsCameraUnlocked = 0xB9CD0,

				// Hmm...could these conceivably be the translation parts of
				// a full-on projection matrix? Hadn't paid too much attention
				// to the stuff surrounding them, but it's plausible. If I can
				// interpret the whole thing I can determine the FOV, aspect
				// ratio, the whole deal. Just need to figure it all out.
				CameraPositionIdealZ = 0xB9D14,
				CameraPositionIdealY = 0xB9D18,
				CameraPositionIdealX = 0xB9D1C,

				CameraPositionActualZ = 0xB9D20,
				CameraPositionActualY = 0xB9D24,
				CameraPositionActualX = 0xB9D28,

				CameraActualPitch = 0xB9D5E,
				CameraActualYaw = 0xB9D60, // No.
				//CameraActualYaw = 0xB9D68, // No.
				//CameraActualYaw = 0xB9D78, // No.
				CameraActualRoll = 0xB9D62,

				CameraIdealPitch = 0xB9D88,
				CameraIdealYaw = 0xB9D8A,
				CameraIdealRoll = 0xB9D8C,

				CameraLockedToHead = 0xB9DA8,

				HarryPositionZ = 0xBA024,
				HarryPositionY = 0xBA028,
				HarryPositionX = 0xBA02C,

				HarryHealth = 0xBA0BC,

				HarryUpperBodyAnimation = 0xBA138,

				Thing1 = 0xBA0F8, // Harry position Z, but lags behind 0xBA028? Catches up eventually.

				HarryPitch = 0xBA030,
				HarryYaw = 0xBA032, // Mirrored at 0xBA036
				HarryRoll = 0xBA034,

				HarryPositionZTwo = 0xBA040,

				HarryParalyzed = 0xBA150,

				InventoryFirst = 0xBCA34,
				Inventory = 0xBCADC, // Not quite. The most significant byte reflects the number of item slots, but doesn't give you the items.
				ItemCount = 0xBCC70,

				DistanceRun = 0xBCC88,
				DistanceWalked = 0xBCC8C,

				FramebufferWidth = 0xBCCB0,
				// Keep these two in sync if adjusting by hand! Rendering goes screwy otherwise.
				FramebufferHeight = 0xBCCB2,
				ProjectionPlaneDistanceCurrent = 0xB9D00,

				HarrySpawnZ = 0xBCDB0,
				HarrySpawnInfo = 0xBCDB4,
				HarrySpawnX = 0xBCDB8,

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

				SnowVolumeHeightMaybe = 0xC6FA8,

				ButtonFlags = 0xC71A2,

				MapHeader = 0xC9578,
				MapChunkset = 0xC9578 + 0x4,
				Pointer2 = 0xC9578 + 0x8, // Freeze on increment (code?)
				Value1 = 0xC9578 + 0xC, // No freeze on increment (data?)
				Pointer3 = 0xC9578 + 0x10, // Freeze
				Pointer4 = 0xC9578 + 0x14,
				Value2 = 0xC9578 + 0x18, // No freeze
				Pointer5 = 0xC9578 + 0x1C, // No freeze
				TriggerVertexTable = 0xC9578 + 0x20, // Freeze
				Pointer7 = 0xC9578 + 0x24, // No freeze
				Pointer8 = 0xC9578 + 0x28, // Freeze
				Pointer9 = 0xC9578 + 0x2C, // No freeze
				Pointer10 = 0xC9578 + 0x30, // No freeze
				Pointer11 = 0xC9578 + 0x34, // No freeze
				Pointer12 = 0xC9578 + 0x38, // No freeze
				Pointer13 = 0xC9578 + 0x3C, // No freeze
				Pointer14 = 0xC9578 + 0x40, // No freeze
				Pointer15 = 0xC9578 + 0x44, // Freeze
				Value3 = 0xC9578 + 0x48,
				Pointer16 = 0xC9578 + 0x4C, // No freeze
				Pointer17 = 0xC9578 + 0x50, // No freeze
				Value4 = 0xC9578 + 0x54,
				Pointer18 = 0xC9578 + 0x58, // Freeze
				Value5 = 0xC9578 + 0x5C,

				MapTim = 0x1CF600
			}
		};
	}
}
