namespace Session;

public static class First
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool Run()
        => "SomeStringWithUpperAndLowerCaseWords".ToLower().Equals("somestringwithupperandlowercasewords");
}