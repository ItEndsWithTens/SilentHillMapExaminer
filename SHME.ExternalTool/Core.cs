using BizHawk.Client.Common;
using System;
using System.Collections.Generic;

namespace SHME.ExternalTool
{
	public enum MainRamAddresses
	{
		// For whatever reason, a yaw of 0 corresponds to Bachman Road
		// going north, which is what most of us would consider the +Y
		// axis. Typical approaches instead line up 0 with +X.
		HarryPositionY = 0xBA024,
		HarryPositionZ = 0xBA028,
		HarryPositionX = 0xBA02C,

		HarryPitch = 0xBA030,
		HarryYaw = 0xBA032, // Mirrored at 0xBA036
		HarryRoll = 0xBA034,

		HarryPositionZTwo = 0xBA040,

		HarryParalyzed = 0xBA150,

		CameraPositionY = 0xB9D14,
		CameraPositionZ = 0xB9D24,
		CameraPositionX = 0xB9D28,

		CameraPitch = 0xB9D88,
		CameraYaw = 0xB9D8A,
		CameraRoll = 0xB9D8C
	}

	public class Core
	{
		public float RotationSliceDegrees = 360.0f / 4096.0f;

		// TODO: See if these are in fact also Q format numbers, like the
		// position stuff.
		public uint DegreesToGameUnits(float degrees)
		{
			float mod = degrees % 360.0f;

			return (uint)((4096.0f - (mod / RotationSliceDegrees)) % 4096.0f);
		}

		public float GameUnitsToDegrees(uint gameUnits)
		{
			float mod = gameUnits % 4096.0f;

			return (360.0f - (mod * RotationSliceDegrees)) % 360.0f;
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

			float cameraX = QToFloat(mem.ReadS32((long)MainRamAddresses.CameraPositionX));
			float cameraY = QToFloat(mem.ReadS32((long)MainRamAddresses.CameraPositionY));
			float cameraZ = QToFloat(mem.ReadS32((long)MainRamAddresses.CameraPositionZ));

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
