using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[RankColumn, MinColumn, MaxColumn]
[MemoryDiagnoser]
public class BenchmarkContainer<TBenchmark, TReturn> where TBenchmark : IBenchmark<TReturn>, new()
{
    private readonly TBenchmark _benchmark = new TBenchmark();

    [GlobalSetup]
    public void GlobalSetup() => _benchmark.GlobalSetup();
    
    [Benchmark(Baseline = true)]
    public TReturn Original() => _benchmark.Original();

    [Benchmark]
    public TReturn New() => _benchmark.New();
}

public interface IBenchmark<TReturn>
{
    void GlobalSetup();

    TReturn Original();

    TReturn New();
}