namespace Benchmarks;


public class FirstBenchmark : IBenchmark
{

    public object Original() => 1 + 4;

    public object New() => 1 + 5;
}