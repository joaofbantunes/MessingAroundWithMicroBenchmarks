namespace Reference;

public static class Third
{
    private static int[] _collection = Array.Empty<int>();

    public static void GlobalSetup()
    {
        _collection = Enumerable.Range(0, 1_000_000).Select(_ => 1).ToArray();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Run()
    {
        // having a local reference lets the compiler optimize away the need to do bounds check
        var localCollectionReference = _collection;
        var sum = 0;
        
        for (var i = 0; i < localCollectionReference.Length; ++i)
        {
            sum += localCollectionReference[i];
        }

        return sum;
    }
}