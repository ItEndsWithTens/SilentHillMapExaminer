#!/bin/sh

# Ripped wholesale from lib/BizHawk/Assets/EmuHawkMono.sh, specifically the 2.9
# tag: https://github.com/TASEmulators/BizHawk/blob/ac3a8c7e5f0711b51defdb3f121d1a63c44818c3/Assets/EmuHawkMono.sh#L7-L24
#
# Apologies to the BizHawk team for that, but VS Code makes almost everything a
# gigantic pain; setting up for Mono debugging is no exception, and just reusing
# the existing Linux environment config (but leaving mono execution, with the
# required extra debugging parameters, to a VS Code extension) was simplest.

libpath=""
if [ "$(command -v lsb_release)" ]; then
	case "$(lsb_release -i | cut -c17- | tr -d "\n" | tr A-Z a-z)" in
		"arch"|"artix"|"manjarolinux") libpath="/usr/lib";;
		"fedora"|"gentoo") libpath="/usr/lib64";;
		"debian"|"linuxmint"|"pop"|"ubuntu") libpath="/usr/lib/x86_64-linux-gnu";;
	esac
else
	printf "Distro does not provide LSB release info API! (You've met with a terrible fate, haven't you?)\n"
fi
if [ -z "$libpath" ]; then
	printf "%s\n" "Unknown distro, assuming system-wide libraries are in /usr/lib..."
	libpath="/usr/lib"
fi
export LD_LIBRARY_PATH="$PWD/dll:$PWD:$libpath"
export MONO_CRASH_NOFILE=1
export MONO_WINFORMS_XIM_STYLE=disabled # see https://bugzilla.xamarin.com/show_bug.cgi?id=28047#c9
export BIZHAWK_INT_SYSLIB_PATH="$libpath"
