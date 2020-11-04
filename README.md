
  SilentHillMapExaminer
  =====================

  A tool to help reverse engineer the level format used in the original Silent Hill. Designed ad hoc, and crudely named to reflect that, this is in its earliest stages, and should not be relied upon for much of anything.

  This is currently implemented as a [BizHawk](https://github.com/TASVideos/BizHawk) external tool; also included are the beginnings of a standalone GUI app based on [Eto.Forms](https://github.com/picoe/Eto) and [Eto.Veldrid](https://github.com/picoe/Eto.Veldrid), but that's a long way off, if it ever happens. For now the external tool is a useful, if scatterbrained, testbed for various ideas.

  CI builds are on the todo list. Check out the repo, clone the BizHawk submodule, then do ```dotnet build -c Release``` and you should be good to go! Drill down into the artifacts directory to find the resulting DLL.