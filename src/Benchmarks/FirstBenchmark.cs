namespace Benchmarks;

public class FirstBenchmark : IBenchmark<bool>
{
    public void GlobalSetup()
    {
        // nothing to do here   
    }

    public void IterationSetup()
    {
        // nothing to do here   
    }
    
    public bool Original() => Starting.First.Run();

    public bool New() => Session.First.Run();
}