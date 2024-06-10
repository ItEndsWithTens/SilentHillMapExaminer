using System;

namespace BizHawk.Client.EmuHawk;

#pragma warning disable IDE0055
// IDE0055 covers all code style formatting rules, including the removal of
// whitespace some developers use to line up values when assigning many
// variables at once. That's usually desirable, but in cases like this, i.e.
// bitfields/flags, the alignment helps make it more visually obvious which
// bits correspond to which enum members.
[Flags]
public enum PsxButtons
{
	None =     0x0000,
	Select =   0x0001,
	L3 =       0x0002,
	R3 =       0x0004,
	Start =    0x0008,
	Up =       0x0010,
	Right =    0x0020,
	Down =     0x0040,
	Left =     0x0080,
	L2 =       0x0100,
	R2 =       0x0200,
	L1 =       0x0400,
	R1 =       0x0800,
	Triangle = 0x1000,
	Circle =   0x2000,
	X =        0x4000,
	Square =   0x8000
}
#pragma warning restore IDE0055
