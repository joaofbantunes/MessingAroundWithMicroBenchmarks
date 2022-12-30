namespace Reference;

public static class Fifth
{

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Run()
    {
        var sum = 0;

        for (var i = 0; i < 50_000_000; i++)
        {
            // passing the parameter explicitly, removing the closure allocation,
            // means we don't allocate something new on every iteration 
            sum += FuncInvoker(static (first, second) => first * second, i);
        }

        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int FuncInvoker(Func<int, int, int> func, int someValue)
        => func(123456, someValue);
}