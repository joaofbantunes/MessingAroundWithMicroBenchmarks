namespace Benchmarks;


public class SecondBenchmark : IBenchmark<IReadOnlyCollection<int>>
{
    public void GlobalSetup()
    {
        Starting.Second.GlobalSetup();
        Session.Second.GlobalSetup();
    }
    
    public IReadOnlyCollection<int> Original() => Starting.Second.Run();

    public IReadOnlyCollection<int> New() => Session.Second.Run();
}