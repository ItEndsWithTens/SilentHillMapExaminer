
  # SilentHillMapExaminer

  [![Build](https://github.com/ItEndsWithTens/SilentHillMapExaminer/actions/workflows/build.yml/badge.svg)](https://github.com/ItEndsWithTens/SilentHillMapExaminer/actions/workflows/build.yml) [![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/ItEndsWithTens/SilentHillMapExaminer?include_prereleases)](https://github.com/ItEndsWithTens/SilentHillMapExaminer/releases/tag/latest)

  A tool to help reverse engineer the level format used in the original Silent Hill, currently implemented as a [BizHawk](https://github.com/TASVideos/BizHawk) external tool; also included are the beginnings of a standalone GUI app based on [Eto.Forms](https://github.com/picoe/Eto) and [Eto.Veldrid](https://github.com/picoe/Eto.Veldrid), but that's a long way off, if it ever happens. For now the external tool is a useful, if scatterbrained, testbed for various ideas.



  ## Requirements

  - [BizHawk 2.10 or newer](https://github.com/TASEmulators/BizHawk/releases)
  - [Silent Hill USA Original/Greatest Hits](http://redump.org/disc/137/)



  ## Installation

  Downloads are available through the badges above, or on [the releases page](https://github.com/ItEndsWithTens/SilentHillMapExaminer/releases). Just unzip into your BizHawk/ExternalTools directory and enjoy!



  ## Usage

  TODO: Proper docs for the other tabs.

  ### Save

  #### In-game saves
  The save menu can be activated almost anywhere, and this section lets you do so, optionally binding a controller button to the feature. Limitations include:

   - Saves can't be created for the title screen, end credits, or during cinematics, in other words anywhere the save screen can't be activated.
   - Upon loading one of these "Anywhere" saves, cutscenes that are part of the current map but which haven't been activated yet will be corrupted, e.g. if you make a save before chasing after Cheryl when the game begins ("Footsteps?").

  #### SaveRAM
  Having a set of save states from a variety of moments throughout a playthrough of Silent Hill facilitates reverse engineering, by making it convenient to compare and contrast different game conditions. Unfortunately those save states aren't compatible across emulator releases, and keeping this tool up to date while continuing to reverse engineer the game would require replaying Silent Hill, and recreating all the save states, for every new BizHawk release.

  There is a way to bring up the in-game save screen at any time, and creating a set of such saves does alleviate the problem somewhat, but using those saves isn't as fast as using save states. To address the burden of dealing with all this, the Save tab offers facilities to "convert" from SaveRAM to save state and vice versa.

  There are limitations:
   - A small amount of game time will pass between loading a SaveRAM save and creating the corresponding save state, or between loading a state and creating an in-game save. If the save you're attempting to convert is dependent on capturing an extremely precise point in time, this feature will likely not help you.
   - There's a danger, common to all emulators, that both SaveRAM and save states risk clobbering one another, i.e. overwriting your progress if you're not careful. As such, the conversion features are disabled by default, and must be manually enabled with a checkbox that will explicitly warn you about said danger.

  If you would benefit from these conversion features, and you're confident that you know what you're doing, enable the checkbox and have fun! Otherwise ignore that section.



  ## Development

  Be careful using C# features introduced beyond version 7.3!

  This project uses C# language version 12.0 despite running under .NET Framework 4.8, a combination which is not officially supported. Newer versions of the language introduce some features that require new types and/or an updated runtime, but there are nonetheless many purely syntactical improvements that prove exceptionally useful (e.g. [tuple type aliases](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-field-names)), and are too good to ignore.

  For more information see [Microsoft's documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version), [StackOverflow](https://stackoverflow.com/questions/56651472/does-c-sharp-8-support-the-net-framework), and [this blog post by Stuart Lang](https://stu.dev/csharp8-doing-unsupported-things/).

  ### Building

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

  4. Optionally, create the distribution zip file. Keep in mind that the ContinuousIntegrationBuild property used here strips local file path information out of the embedded debug symbols, so this step is only useful for distributable builds, not local development and debugging.
     - `dotnet build src\SHME.ExternalTool\SHME.ExternalTool.csproj -c:Release -t:CreateZip -p:ContinuousIntegrationBuild=true`

  Drill down into the artifacts directory to find the DLL, and copy it into your BizHawk\ExternalTools directory. The tool should then be available in BizHawk, provided you've loaded a disc image of Silent Hill that matches the expected hash.

  For easy debugging in Visual Studio, open the external tool project's properties and create a new Executable debug launch profile as follows:

   - Executable: `.\EmuHawk.exe`
   - Application arguments: `"relative\path\to\disc\image" --open-ext-tool-dll=SHME.ExternalTool` with maybe `--load-slot=1` tacked on the end too, once you have a save state to work with.
   - Working directory: `..\..\lib\BizHawk\output`

  You'll be up and running with a single keypress, and working on the plugin should then be vastly more convenient. Have fun!

  In event of any problems, try cleaning the solution and rebuilding just in case, and don't forget about dotnet build's `-bl` option that spits out a binary log. With one in hand, head over to https://msbuildlog.com/ and save yourself a lifetime of build debugging anguish.



  ### Testing

  For just the unit tests, run `dotnet test` from the project's top level directory, or use Visual Studio's built-in Test Explorer. If instead you want to collect code coverage information at the same time, first install the coverage collection tool:
   - `dotnet tool install --global dotnet-coverage`

  Then install Daniel Palme's [ReportGenerator](https://github.com/danielpalme/ReportGenerator):
   - `dotnet tool install --global dotnet-reportgenerator-globaltool`

  Run the tests and collect coverage data:
   - `dotnet-coverage collect dotnet test --settings CodeCoverage.runsettings --output artifacts/test/coverage.xml --output-format xml`

  Generate the human readable coverage report:
   - `reportgenerator -reports:"artifacts/test/coverage.xml" -targetdir:"artifacts/test/coveragereport" -reporttypes:Html`

  Finally, open `artifacts/test/coveragereport/index.html` and wallow in despair at the lack of code coverage.



  ### Benchmarking

  Accumulated benchmark results can be viewed [here](https://itendswithtens.github.io/PerfTrendsWithTens/SHME/bench/), with the caveat that by running on CI servers with unpredictable performance characteristics, said benchmarks are useful only as an extremely high level overview of long term trends.

  To run all included benchmarks locally:
   - `mkdir artifacts\test`
   - `cd artifacts\test`
   - `dotnet run --project ..\..\test\Benchmark\Benchmark.csproj -c Release -- -f *`

  You can also customize the filter to limit what runs, e.g. `-f *AabbBenchmarks*` to run just the axis-aligned bounding box benchmarks. Alternatively, run the project without passing through any arguments to enter an interactive benchmark selection mode:
   - `dotnet run --project ..\..\test\Benchmark\Benchmark.csproj -c Release`

  The runner will then present a list of options to choose from, along with instructions on how to proceed.

  Benchmarks will default to running on .NET Framework 4.8 (the runtime currently used by BizHawk itself), but this can be overridden with the `-r` parameter. For example, using `-r net6.0 mono` would run the benchmarks under both .NET 6 and Mono.

  Benchmark output will be saved to `artifacts\test\BenchmarkDotNet.Artifacts` by default, unless redirected with BenchmarkDotNet's `-a` parameter (added after the `--`, just like the filter).

  More information about BenchmarkDotNet can be found on [the library's website](https://benchmarkdotnet.org/). The .NET Performance repo also has some useful docs, namely those offering [an overview of the library](https://github.com/dotnet/performance/blob/main/docs/benchmarkdotnet.md) and [tips on designing microbenchmarks](https://github.com/dotnet/performance/blob/main/docs/microbenchmark-design-guidelines.md). The focus in both is on measuring the performance of the various .NET Runtimes, but a great deal of both documents applies to the use of BDN with any project.
