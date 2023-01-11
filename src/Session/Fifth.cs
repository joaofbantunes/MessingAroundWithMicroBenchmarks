namespace Session;

public static class Fifth
{

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Run()
    {
        var sum = 0;

        for (var i = 0; i < 1_000_000; i++)
        {
            sum += FuncInvoker(input => input * i);
        }

        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int FuncInvoker(Func<int, int> func)
        => func(123456);
}