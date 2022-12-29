namespace Reference;

public static class First
{
    public static bool Run()
        => "SomeStringWithUpperAndLowerCaseWords".Equals(
            "somestringwithupperandlowercasewords",
            StringComparison.OrdinalIgnoreCase);
}