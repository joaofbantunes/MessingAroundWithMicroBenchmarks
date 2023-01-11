namespace Reference;

public static class Fourth
{
    // probably unexpected for most devs, using interfaces, can have performance impacts
    // more info here https://github.com/dotnet/runtime/issues/7291
    private static int[] _collection = Array.Empty<int>();

    public static void GlobalSetup()
    {
        _collection = Enumerable.Range(0, 1_000_000).Select(_ => 1).ToArray();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Run()
    {
        var sum = 0;

        foreach (var value in _collection)
        {
            sum += value;
        }

        return sum;
    }
}