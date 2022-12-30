namespace Benchmarks;


public class ThirdBenchmark : IBenchmark
{
    public void GlobalSetup()
    {
        Starting.Third.GlobalSetup();
        Session.Third.GlobalSetup();
    }
    
    public object Original() => Starting.Third.Run();

    public object New() => Session.Third.Run();
}