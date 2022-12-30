namespace Starting;

public static class Fourth
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Run() => CalculatorInvoker(new Multiplier());

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int CalculatorInvoker(ICalculateSomething calculator)
        => calculator.Calculate(123456, 654321);
}

public interface ICalculateSomething
{
    int Calculate(int first, int second);
}

public struct Multiplier : ICalculateSomething
{
    public int Calculate(int first, int second) => first * second;
}