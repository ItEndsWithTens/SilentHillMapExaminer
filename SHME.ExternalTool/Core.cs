using BizHawk.Client.Common;
using System;
using System.Collections.Generic;

namespace SHME.ExternalTool
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

	public enum MainRamAddresses : long
	{
		// This is relative to the entire 1024x512 VRAM area,
		// not just the onscreen frame.
		VramCroppedWidth = 0x22A64,
		VramCroppedHeight = 0x22A66,

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

		FogEnabled = 0xC4169,

		ScreenBrightness = 0xC4170,

		// 32 bit, Q24.8 format; has no effect when fog is disabled.
		DrawDistance = 0xC4178,

		FogThing1 = 0xC417c,
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
		MapChunkset = MapHeader + 0x4,
		Pointer2 = MapHeader + 0x8, // Freeze on increment (code?)
		Value1 = MapHeader + 0xC, // No freeze on increment (data?)
		Pointer3 = MapHeader + 0x10, // Freeze
		Pointer4 = MapHeader + 0x14,
		Value2 = MapHeader + 0x18, // No freeze
		Pointer5 = MapHeader + 0x1C, // No freeze
		TriggerVertexTable = MapHeader + 0x20, // Freeze
		Pointer7 = MapHeader + 0x24, // No freeze
		Pointer8 = MapHeader + 0x28, // Freeze
		Pointer9 = MapHeader + 0x2C, // No freeze
		Pointer10 = MapHeader + 0x30, // No freeze
		Pointer11 = MapHeader + 0x34, // No freeze
		Pointer12 = MapHeader + 0x38, // No freeze
		Pointer13 = MapHeader + 0x3C, // No freeze
		Pointer14 = MapHeader + 0x40, // No freeze
		Pointer15 = MapHeader + 0x44, // Freeze
		Value3 = MapHeader + 0x48,
		Pointer16 = MapHeader + 0x4C, // No freeze
		Pointer17 = MapHeader + 0x50, // No freeze
		Value4 = MapHeader + 0x54,
		Pointer18 = MapHeader + 0x58, // Freeze
		Value5 = MapHeader + 0x5C,

		MapTim = 0x1CF600
	}

	public class Core
	{
		public uint DegreesToGameUnits(float degrees)
		{
			return (uint)Utility.ScaleToRange(degrees, 0.0, 360.0, 0.0, 4096.0);
		}
		public float GameUnitsToDegrees(uint gameUnits)
		{
			// Rotations in Silent Hill have only 12 significant bits.
			uint masked = gameUnits & 0b00000000_00000000_00001111_11111111;

			return (float)Utility.ScaleToRange(masked, 0.0, 4096.0, 0.0, 360.0);
		}

		// Silent Hill appears to use the Q(20.12) fixed point number format,
		// at least for Harry's position.
		public int FloatToQ(float number)
		{
			return FloatToQ(number, 12);
		}
		public int FloatToQ(float number, int fractionalBits)
		{
			return (int)(number * Math.Pow(2.0, fractionalBits));
		}
		public float QToFloat(int q)
		{
			return QToFloat(q, 12);
		}
		public float QToFloat(int q, int fractionalBits)
		{
			return (float)((float)q * Math.Pow(2.0, -fractionalBits));
		}

		public List<float> GetAngles(IMemoryApi mem)
		{
			uint harryPitch = mem.ReadU16((long)MainRamAddresses.HarryPitch);
			uint harryYaw = mem.ReadU16((long)MainRamAddresses.HarryYaw);
			uint harryRoll = mem.ReadU16((long)MainRamAddresses.HarryRoll);

			uint cameraPitch = mem.ReadU16((long)MainRamAddresses.CameraActualPitch);
			uint cameraYaw = mem.ReadU16((long)MainRamAddresses.CameraActualYaw);
			uint cameraRoll = mem.ReadU16((long)MainRamAddresses.CameraActualRoll);

			return new List<float>()
			{
				GameUnitsToDegrees(harryPitch),
				GameUnitsToDegrees(harryYaw),
				GameUnitsToDegrees(harryRoll),

				GameUnitsToDegrees(cameraPitch),
				GameUnitsToDegrees(cameraYaw),
				GameUnitsToDegrees(cameraRoll)
			};
		}

		public void SetPitch(IMemoryApi mem, float pitch)
		{
			mem.WriteU16((long)MainRamAddresses.HarryPitch, DegreesToGameUnits(pitch));
		}
		public void SetYaw(IMemoryApi mem, float yaw)
		{
			mem.WriteU16((long)MainRamAddresses.HarryYaw, DegreesToGameUnits(yaw));
		}
		public void SetRoll(IMemoryApi mem, float roll)
		{
			mem.WriteU16((long)MainRamAddresses.HarryRoll, DegreesToGameUnits(roll));
		}
		public void SetAngles(IMemoryApi mem, float pitch, float yaw, float roll)
		{
			SetPitch(mem, pitch);
			SetYaw(mem, yaw);
			SetRoll(mem, roll);
		}

		public List<float> GetPosition(IMemoryApi mem)
		{
			float harryX = QToFloat(mem.ReadS32((long)MainRamAddresses.HarryPositionX));
			float harryY = QToFloat(mem.ReadS32((long)MainRamAddresses.HarryPositionY));
			float harryZ = QToFloat(mem.ReadS32((long)MainRamAddresses.HarryPositionZ));

			float cameraX = QToFloat(mem.ReadS32((long)MainRamAddresses.CameraPositionActualX));
			float cameraY = QToFloat(mem.ReadS32((long)MainRamAddresses.CameraPositionActualY));
			float cameraZ = QToFloat(mem.ReadS32((long)MainRamAddresses.CameraPositionActualZ));

			return new List<float>()
			{
				harryX, harryY, harryZ,
				cameraX, cameraY, cameraZ
			};
		}

		public void SetHarryX(IMemoryApi mem, float x)
		{
			mem.WriteS32((long)MainRamAddresses.HarryPositionX, FloatToQ(x));
		}
		public void SetHarryY(IMemoryApi mem, float y)
		{
			mem.WriteS32((long)MainRamAddresses.HarryPositionY, FloatToQ(y));
		}
		public void SetHarryZ(IMemoryApi mem, float z)
		{
			mem.WriteS32((long)MainRamAddresses.HarryPositionZ, FloatToQ(z));
		}
		public void SetHarryPosition(IMemoryApi mem, float x, float y, float z)
		{
			SetHarryX(mem, x);
			SetHarryY(mem, y);
			SetHarryZ(mem, z);
		}
	}
}
