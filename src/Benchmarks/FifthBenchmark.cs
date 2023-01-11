namespace Benchmarks;

public class FifthBenchmark : IBenchmark<int>
{
    public void GlobalSetup()
    {
        // nothing to do here   
    }

    public int Original() => Starting.Fifth.Run();

    public int New() => Session.Fifth.Run();
}