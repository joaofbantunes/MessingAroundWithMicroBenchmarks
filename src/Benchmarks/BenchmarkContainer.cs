using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks;

[RankColumn]
[MemoryDiagnoser]
// would not normally add the following, but just trying to make things faster
// as we'll use this in a mob programming session during an event
//[SimpleJob(invocationCount: 25_000_000)]
public class BenchmarkContainer<TBenchmark, TReturn> where TBenchmark : IBenchmark<TReturn>, new()
{
    private readonly TBenchmark _benchmark = new TBenchmark();

    [GlobalSetup]
    public void GlobalSetup() => _benchmark.GlobalSetup();
    
    [IterationSetup]
    public void IterationSetup() => _benchmark.IterationSetup();

    [Benchmark(Baseline = true)]
    public TReturn Original() => _benchmark.Original();

    [Benchmark]
    public TReturn New() => _benchmark.New();
}

public interface IBenchmark<TReturn>
{
    void GlobalSetup();

    void IterationSetup();
    
    TReturn Original();

    TReturn New();
}

