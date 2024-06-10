using System;

namespace SHME.ExternalTool
{
#pragma warning disable IDE0055
	[Flags]
	public enum CameraState
	{
		None =      0x000,
		LockPitch = 0x001,
		LockYaw =   0x002,
		Unknown1 =  0x004,
		Unknown2 =  0x008,
		Unknown3 =  0x010,
		Chase =     0x080,
		Cutscene =  0x100,
		Unknown4 =  0x200,
		Unknown5 =  0x400
	}
#pragma warning restore IDE0055
}
