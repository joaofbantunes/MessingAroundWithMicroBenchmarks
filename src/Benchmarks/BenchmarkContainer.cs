using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[RankColumn]
[MemoryDiagnoser]
public class BenchmarkContainer<TBenchmark> where TBenchmark : IBenchmark, new()
{
    private readonly IBenchmark _benchmark;

    public BenchmarkContainer()
    {
        _benchmark = new TBenchmark();
    }

    [Benchmark(Baseline = true)]
    public object Original() => _benchmark.Original();

    [Benchmark]
    public object New() => _benchmark.New();
}

public interface IBenchmark
{
    object Original();

    object New();
}

