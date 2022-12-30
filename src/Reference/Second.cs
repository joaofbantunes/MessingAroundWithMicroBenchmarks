namespace Reference;

public static class Second
{
    private static int[] _collectionWithRepeatedValues = Array.Empty<int>();

    public static void GlobalSetup()
    {
        _collectionWithRepeatedValues = Enumerable.Range(0, 1000).SelectMany(i => new[] { i, i, i }).ToArray();
    }

    // HashSet is ~O(1) when checking existance
    public static IEnumerable<int> Run()
    {
        var distinctValues = new HashSet<int>();

        foreach (var i in _collectionWithRepeatedValues)
        {
            _ = distinctValues.Add(i);
        }

        return distinctValues;
    }
}