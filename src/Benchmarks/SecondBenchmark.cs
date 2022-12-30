namespace Benchmarks;


public class SecondBenchmark : IBenchmark<IEnumerable<int>>
{
    public void GlobalSetup()
    {
        Starting.Second.GlobalSetup();
        Session.Second.GlobalSetup();
    }
    
    public IEnumerable<int> Original() => Starting.Second.Run();

    public IEnumerable<int> New() => Session.Second.Run();
}