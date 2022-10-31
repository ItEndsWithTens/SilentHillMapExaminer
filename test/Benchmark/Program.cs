using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

class Program
{
	static void Main(string[] args)
	{
		ManualConfig config = ManualConfig.Create(DefaultConfig.Instance)
			.AddJob(Job.Default
				.WithRuntime(ClrRuntime.Net48)
				.AsDefault())
			.AddDiagnoser(MemoryDiagnoser.Default)
			.WithOption(ConfigOptions.JoinSummary, true)
			.WithOrderer(new DefaultOrderer(
				SummaryOrderPolicy.Declared,
				MethodOrderPolicy.Declared));

		BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
	}
}
