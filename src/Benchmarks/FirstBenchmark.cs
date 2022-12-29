namespace Benchmarks;

public class FirstBenchmark : IBenchmark
{
    public void GlobalSetup()
    {
        // nothing to do here   
    }

    public object Original() => Starting.First.Run();

    public object New() => Session.First.Run();
}