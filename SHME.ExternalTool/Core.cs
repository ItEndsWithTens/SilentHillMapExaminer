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
	// direction of the given axis.
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
		// Hmm...could these conceivable be the translation parts of
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

		CameraPitch = 0xB9D88,
		CameraYaw = 0xB9D8A,
		CameraRoll = 0xB9D8C,

		HarryPositionZ = 0xBA024,
		HarryPositionY = 0xBA028,
		HarryPositionX = 0xBA02C,

		Thing1 = 0xBA0F8, // Harry position Z, but lags behind 0xBA028? Catches up eventually.

		HarryPitch = 0xBA030,
		HarryYaw = 0xBA032, // Mirrored at 0xBA036
		HarryRoll = 0xBA034,

		HarryPositionZTwo = 0xBA040,

		HarryParalyzed = 0xBA150,

		SomeRandomTim = 0x1CF600 // Could be the map? Need to see.
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
		public int FloatToQ(float f)
		{
			return (int)(f * Math.Pow(2.0, 12.0));
		}
		public float QToFloat(int q)
		{
			return (float)((float)q * Math.Pow(2.0, -12.0));
		}

		public List<float> GetAngles(IMemoryApi mem)
		{
			uint harryPitch = mem.ReadU16((long)MainRamAddresses.HarryPitch);
			uint harryYaw = mem.ReadU16((long)MainRamAddresses.HarryYaw);
			uint harryRoll = mem.ReadU16((long)MainRamAddresses.HarryRoll);

			uint cameraPitch = mem.ReadU16((long)MainRamAddresses.CameraPitch);
			uint cameraYaw = mem.ReadU16((long)MainRamAddresses.CameraYaw);
			uint cameraRoll = mem.ReadU16((long)MainRamAddresses.CameraRoll);

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
