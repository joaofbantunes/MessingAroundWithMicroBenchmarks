namespace Reference;

public static class First
{
    // doesn't allocate a new string every time
    public static bool Run()
        => "SomeStringWithUpperAndLowerCaseWords".Equals(
            "somestringwithupperandlowercasewords",
            StringComparison.OrdinalIgnoreCase);
}