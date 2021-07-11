
  SilentHillMapExaminer
  =====================

  [![Build](https://github.com/ItEndsWithTens/SilentHillMapExaminer/actions/workflows/build.yml/badge.svg)](https://github.com/ItEndsWithTens/SilentHillMapExaminer/actions/workflows/build.yml) [![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/ItEndsWithTens/SilentHillMapExaminer?include_prereleases)](https://github.com/ItEndsWithTens/SilentHillMapExaminer/releases/tag/latest)

  A tool to help reverse engineer the level format used in the original Silent Hill. Designed ad hoc, and crudely named to reflect that, this is in its earliest stages, and should not be relied upon for much of anything.

  This is currently implemented as a [BizHawk](https://github.com/TASVideos/BizHawk) external tool; also included are the beginnings of a standalone GUI app based on [Eto.Forms](https://github.com/picoe/Eto) and [Eto.Veldrid](https://github.com/picoe/Eto.Veldrid), but that's a long way off, if it ever happens. For now the external tool is a useful, if scatterbrained, testbed for various ideas.

  Downloads are available through the badges above, or on the releases page. Just unzip into your BizHawk/ExternalTools directory and enjoy! If instead you'd like to build it yourself, read on.



  Building
  --------

  1. Check out the repo and clone the BizHawk submodule.
      - `git clone https://github.com/ItEndsWithTens/SilentHillMapExaminer`
      - `cd SilentHillMapExaminer`
      - `git submodule update --init`

  2. Build BizHawk.
      - `cd lib\BizHawk\Dist`
      - `QuickTestBuildAndPackage_Release.bat`

  3. Build SHME.
      - `cd ..\..\..`
      - `dotnet build -c:Release`

  4. Optionally, create the distribution zip file.
      - `dotnet build src\SHME.ExternalTool\SHME.ExternalTool.csproj -c:Release -t:CreateZip`

  Drill down into the artifacts directory to find the DLL, and copy it into your BizHawk\ExternalTools directory. The tool should then be available in BizHawk, provided you've loaded a disc image of Silent Hill that matches the expected hash.
  
  For easy debugging in Visual Studio, open the external tool project's properties and set them as follows:

  - Executable: `.\EmuHawk.exe`
  - Application arguments: `"relative\path\to\disc\image" --open-ext-tool-dll=SHME.ExternalTool` with maybe `--load-slot=1` tacked on the end too, once you have a save state to work with.
  - Working directory: `..\..\lib\BizHawk\output`

  You'll be up and running with a single keypress, and working on the plugin should then be vastly more convenient. Have fun!
