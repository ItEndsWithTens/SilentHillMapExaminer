using BizHawk.Client.Common;
using SHME.ExternalTool.Addresses;
using System;
using System.Collections.Generic;

namespace SHME.ExternalTool
{
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
			uint harryPitch = mem.ReadU16((long)MainRam.HarryPitch);
			uint harryYaw = mem.ReadU16((long)MainRam.HarryYaw);
			uint harryRoll = mem.ReadU16((long)MainRam.HarryRoll);

			uint cameraPitch = mem.ReadU16((long)MainRam.CameraActualPitch);
			uint cameraYaw = mem.ReadU16((long)MainRam.CameraActualYaw);
			uint cameraRoll = mem.ReadU16((long)MainRam.CameraActualRoll);

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
			mem.WriteU16((long)MainRam.HarryPitch, DegreesToGameUnits(pitch));
		}
		public void SetYaw(IMemoryApi mem, float yaw)
		{
			mem.WriteU16((long)MainRam.HarryYaw, DegreesToGameUnits(yaw));
		}
		public void SetRoll(IMemoryApi mem, float roll)
		{
			mem.WriteU16((long)MainRam.HarryRoll, DegreesToGameUnits(roll));
		}
		public void SetAngles(IMemoryApi mem, float pitch, float yaw, float roll)
		{
			SetPitch(mem, pitch);
			SetYaw(mem, yaw);
			SetRoll(mem, roll);
		}

		public List<float> GetPosition(IMemoryApi mem)
		{
			float harryX = QToFloat(mem.ReadS32((long)MainRam.HarryPositionX));
			float harryY = QToFloat(mem.ReadS32((long)MainRam.HarryPositionY));
			float harryZ = QToFloat(mem.ReadS32((long)MainRam.HarryPositionZ));

			float cameraX = QToFloat(mem.ReadS32((long)MainRam.CameraPositionActualX));
			float cameraY = QToFloat(mem.ReadS32((long)MainRam.CameraPositionActualY));
			float cameraZ = QToFloat(mem.ReadS32((long)MainRam.CameraPositionActualZ));

			return new List<float>()
			{
				harryX, harryY, harryZ,
				cameraX, cameraY, cameraZ
			};
		}

		public void SetHarryX(IMemoryApi mem, float x)
		{
			mem.WriteS32((long)MainRam.HarryPositionX, FloatToQ(x));
		}
		public void SetHarryY(IMemoryApi mem, float y)
		{
			mem.WriteS32((long)MainRam.HarryPositionY, FloatToQ(y));
		}
		public void SetHarryZ(IMemoryApi mem, float z)
		{
			mem.WriteS32((long)MainRam.HarryPositionZ, FloatToQ(z));
		}
		public void SetHarryPosition(IMemoryApi mem, float x, float y, float z)
		{
			SetHarryX(mem, x);
			SetHarryY(mem, y);
			SetHarryZ(mem, z);
		}
	}
}
