namespace Starting;

public static class Fourth
{
    private static IEnumerable<int> _collection = Array.Empty<int>();

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