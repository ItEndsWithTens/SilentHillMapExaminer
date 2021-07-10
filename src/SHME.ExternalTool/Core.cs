using BizHawk.Client.Common;
using System;
using System.Collections.Generic;

namespace SHME.ExternalTool
{
	public class Core
	{
		public Rom Rom { get; set; } = new USRetail();

		public static uint DegreesToGameUnits(float degrees)
		{
			return (uint)Utility.ScaleToRange(degrees, 0.0, 360.0, 0.0, 4096.0);
		}
		public static float GameUnitsToDegrees(uint gameUnits)
		{
			// Rotations in Silent Hill have only 12 significant bits.
			uint masked = gameUnits & 0b00000000_00000000_00001111_11111111;

			return (float)Utility.ScaleToRange(masked, 0.0, 4096.0, 0.0, 360.0);
		}

		// Silent Hill appears to use the Q(20.12) fixed point number format,
		// at least for Harry's position.
		public static int FloatToQ(float f)
		{
			return FloatToQ(f, 12);
		}
		public static int FloatToQ(float f, int fractionalBits)
		{
			return (int)(f * Math.Pow(2.0, fractionalBits));
		}
		public static float QToFloat(int q)
		{
			return QToFloat(q, 12);
		}
		public static float QToFloat(int q, int fractionalBits)
		{
			return (float)((float)q * Math.Pow(2.0, -fractionalBits));
		}

		public List<float> GetAngles(IMemoryApi mem)
		{
			uint harryPitch = mem.ReadU16(Rom.Addresses.MainRam.HarryPitch);
			uint harryYaw = mem.ReadU16(Rom.Addresses.MainRam.HarryYaw);
			uint harryRoll = mem.ReadU16(Rom.Addresses.MainRam.HarryRoll);

			uint cameraPitch = mem.ReadU16(Rom.Addresses.MainRam.CameraActualPitch);
			uint cameraYaw = mem.ReadU16(Rom.Addresses.MainRam.CameraActualYaw);
			uint cameraRoll = mem.ReadU16(Rom.Addresses.MainRam.CameraActualRoll);

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
			mem.WriteU16(Rom.Addresses.MainRam.HarryPitch, DegreesToGameUnits(pitch));
		}
		public void SetYaw(IMemoryApi mem, float yaw)
		{
			mem.WriteU16(Rom.Addresses.MainRam.HarryYaw, DegreesToGameUnits(yaw));
		}
		public void SetRoll(IMemoryApi mem, float roll)
		{
			mem.WriteU16(Rom.Addresses.MainRam.HarryRoll, DegreesToGameUnits(roll));
		}
		public void SetAngles(IMemoryApi mem, float pitch, float yaw, float roll)
		{
			SetPitch(mem, pitch);
			SetYaw(mem, yaw);
			SetRoll(mem, roll);
		}

		public List<float> GetPosition(IMemoryApi mem)
		{
			float harryX = QToFloat(mem.ReadS32(Rom.Addresses.MainRam.HarryPositionX));
			float harryY = QToFloat(mem.ReadS32(Rom.Addresses.MainRam.HarryPositionY));
			float harryZ = QToFloat(mem.ReadS32(Rom.Addresses.MainRam.HarryPositionZ));

			float cameraX = QToFloat(mem.ReadS32(Rom.Addresses.MainRam.CameraPositionActualX));
			float cameraY = QToFloat(mem.ReadS32(Rom.Addresses.MainRam.CameraPositionActualY));
			float cameraZ = QToFloat(mem.ReadS32(Rom.Addresses.MainRam.CameraPositionActualZ));

			return new List<float>()
			{
				harryX, harryY, harryZ,
				cameraX, cameraY, cameraZ
			};
		}

		public void SetHarryX(IMemoryApi mem, float x)
		{
			mem.WriteS32(Rom.Addresses.MainRam.HarryPositionX, FloatToQ(x));
		}
		public void SetHarryY(IMemoryApi mem, float y)
		{
			mem.WriteS32(Rom.Addresses.MainRam.HarryPositionY, FloatToQ(y));
		}
		public void SetHarryZ(IMemoryApi mem, float z)
		{
			mem.WriteS32(Rom.Addresses.MainRam.HarryPositionZ, FloatToQ(z));
		}
		public void SetHarryPosition(IMemoryApi mem, float x, float y, float z)
		{
			SetHarryX(mem, x);
			SetHarryY(mem, y);
			SetHarryZ(mem, z);
		}
	}
}
