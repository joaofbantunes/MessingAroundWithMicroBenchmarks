namespace Session;

public static class First
{
    // doesn't allocate a new string every time
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool Run()
        => "SomeStringWithUpperAndLowerCaseWords".Equals(
            "somestringwithupperandlowercasewords",
            StringComparison.OrdinalIgnoreCase);
}