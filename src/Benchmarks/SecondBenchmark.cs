namespace Benchmarks;


public class SecondBenchmark : IBenchmark
{
    public void GlobalSetup()
    {
        Starting.Second.GlobalSetup();
        Session.Second.GlobalSetup();
    }
    
    public object Original() => Starting.Second.Run();

    public object New() => Session.Second.Run();
}