namespace Benchmarks;


public class FirstBenchmark : IBenchmark
{

    public void Original()
    {
        var x = 1 + 4;
    }

    public void New()
    {
        var x = 1 + 5;
    }
}