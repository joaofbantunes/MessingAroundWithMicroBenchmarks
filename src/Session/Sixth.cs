namespace Session;

public static class Sixth
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Run() => CalculatorInvoker(new Multiplier());

    // using generics avoids boxing the struct
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int CalculatorInvoker<TCalculateSomething>(TCalculateSomething calculator) where TCalculateSomething : ICalculateSomething
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