using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[RankColumn]
[MemoryDiagnoser]
// would not normally add the following, but just trying to make things faster
// as we'll use this in a mob programming session during an event
//[SimpleJob(invocationCount: 25_000_000)]
public class BenchmarkContainer<TBenchmark> where TBenchmark : IBenchmark, new()
{
    private readonly IBenchmark _benchmark = new TBenchmark();

    [GlobalSetup]
    public void GlobalSetup() => _benchmark.GlobalSetup();

    [Benchmark(Baseline = true)]
    public object Original() => _benchmark.Original();

    [Benchmark]
    public object New() => _benchmark.New();
}

public interface IBenchmark
{
    void GlobalSetup();
    
    object Original();

    object New();
}

