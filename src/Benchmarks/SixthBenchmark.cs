namespace Benchmarks;

public class SixthBenchmark : IBenchmark<int>
{
    public void GlobalSetup()
    {
        // nothing to do here
    }

    public void IterationSetup()
    {
        // nothing to do here   
    }
    
    public int Original() => Starting.Sixth.Run();

    public int New() => Session.Sixth.Run();
}