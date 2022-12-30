namespace Starting;

public static class Second
{
    private static int[] _collectionWithRepeatedValues = Array.Empty<int>();

    public static void GlobalSetup()
    {
        _collectionWithRepeatedValues = Enumerable.Range(0, 1000).SelectMany(i => new[] { i, i, i }).ToArray();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static IEnumerable<int> Run()
    {
        var distinctValues = new List<int>();
        
        foreach (var i in _collectionWithRepeatedValues)
        {
            if (!distinctValues.Contains(i))
            {
                distinctValues.Add(i);
            }
        }
        
        return distinctValues;
    }
}