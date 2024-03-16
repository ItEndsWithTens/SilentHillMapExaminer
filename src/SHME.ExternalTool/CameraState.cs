using System;

namespace SHME.ExternalTool
{
	[Flags]
	public enum CameraState
	{
		None = 0x0,
		LockPitch = 0x1,
		LockYaw = 0x2,
		Unknown1 = 0x10,
		Chase = 0x80,
		Cutscene = 0x100,
		Unknown2 = 0x200,
		Unknown3 = 0x400
	}
}
