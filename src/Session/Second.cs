namespace Session;

public static class Second
{
    private static int[] _collectionWithRepeatedValues = Array.Empty<int>();

    public static void GlobalSetup()
    {
        _collectionWithRepeatedValues = Enumerable.Range(0, 1000).SelectMany(i => new[] { i, i, i }).ToArray();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static IReadOnlyCollection<int> Run()
    {
        // HashSet is ~O(1) when checking existence
        var distinctValues = new HashSet<int>();

        foreach (var i in _collectionWithRepeatedValues)
        {
            _ = distinctValues.Add(i);
        }

        return distinctValues;
    }
}