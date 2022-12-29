﻿namespace Reference;

public static class Second
{
    private static int[] CollectionWithRepeatedValues = Array.Empty<int>();

    public static void GlobalSetup()
    {
        CollectionWithRepeatedValues = Enumerable.Range(0, 1000).SelectMany(i => new[] { i, i, i }).ToArray();
    }

    public static IEnumerable<int> Run()
    {
        var distinctValues = new HashSet<int>();

        foreach (var i in CollectionWithRepeatedValues)
        {
            _ = distinctValues.Add(i);
        }

        return distinctValues;
    }
}