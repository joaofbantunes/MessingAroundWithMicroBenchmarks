namespace Benchmarks;


public class ThirdBenchmark : IBenchmark<int>
{
    public void GlobalSetup()
    {
        Starting.Third.GlobalSetup();
        Session.Third.GlobalSetup();
    }
    
    public int Original() => Starting.Third.Run();

    public int New() => Session.Third.Run();
}