#!/bin/sh

# Ripped wholesale from lib/BizHawk/Assets/EmuHawkMono.sh, specifically the 2.8
# tag, with apologies to the BizHawk team. VS Code makes almost everything a
# gigantic pain; setting up for Mono debugging is no exception, and just reusing
# the existing Linux environment config (but leaving mono execution, with the
# required extra debugging parameters, to a VS Code extension) was simplest.

libpath=""
winepath=""
if [ "$(command -v lsb_release)" ]; then
	case "$(lsb_release -i | cut -c17- | tr -d "\n" | tr A-Z a-z)" in
		"arch"|"manjarolinux"|"artix") libpath="/usr/lib";;
		"fedora") libpath="/usr/lib64"; export MONO_WINFORMS_XIM_STYLE=disabled;; # see https://bugzilla.xamarin.com/show_bug.cgi?id=28047#c9
		"debian"|"linuxmint"|"ubuntu"|"pop") libpath="/usr/lib/x86_64-linux-gnu"; export MONO_WINFORMS_XIM_STYLE=disabled;; # ditto
	esac
else
	printf "Distro does not provide LSB release info API! (You've met with a terrible fate, haven't you?)\n"
fi
if [ -z "$libpath" ]; then
	printf "%s\n" "Unknown distro, assuming system-wide libraries are in /usr/lib..."
	libpath="/usr/lib"
fi
if [ -z "$winepath" ]; then winepath="$libpath/wine"; fi
export LD_LIBRARY_PATH="$PWD/dll:$PWD:$winepath:$libpath"
export BIZHAWK_INT_SYSLIB_PATH="$libpath"
