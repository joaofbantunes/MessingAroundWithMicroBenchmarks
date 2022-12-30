namespace Benchmarks;


public class SecondBenchmark : IBenchmark<IEnumerable<int>>
{
    public void GlobalSetup()
    {
        Starting.Second.GlobalSetup();
        Session.Second.GlobalSetup();
    }
    
    public void IterationSetup()
    {
        // nothing to do here   
    }
    
    public IEnumerable<int> Original() => Starting.Second.Run();

    public IEnumerable<int> New() => Session.Second.Run();
}