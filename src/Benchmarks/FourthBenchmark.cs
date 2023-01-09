namespace Benchmarks;


public class FourthBenchmark : IBenchmark<int>
{
    public void GlobalSetup()
    {
        Starting.Fourth.GlobalSetup();
        Session.Fourth.GlobalSetup();
    }
    
    public void IterationSetup()
    {
        // nothing to do here   
    }
    
    public int Original() => Starting.Fourth.Run();

    public int New() => Session.Fourth.Run();
}