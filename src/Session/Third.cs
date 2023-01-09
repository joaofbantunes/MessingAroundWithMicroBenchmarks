namespace Session;

public static class Third
{
    private static int[] _collection = Array.Empty<int>();

    public static void GlobalSetup()
    {
        _collection = Enumerable.Range(0, 100_000_000).Select(_ => 1).ToArray();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Run()
    {
        var sum = 0;
        
        for (var i = 0; i < _collection.Length; ++i)
        {
            sum += _collection[i];
        }

        return sum;
    }
}