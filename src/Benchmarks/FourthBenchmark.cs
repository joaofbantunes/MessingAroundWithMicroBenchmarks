namespace Benchmarks;


public class FourthBenchmark : IBenchmark<int>
{
    public void GlobalSetup()
    {
        Starting.Fourth.GlobalSetup();
        Session.Fourth.GlobalSetup();
    }
    
    public int Original() => Starting.Fourth.Run();

    public int New() => Session.Fourth.Run();
}