namespace Session;

public static class First
{
    public static bool Run()
        => "SomeStringWithUpperAndLowerCaseWords".ToLower().Equals("somestringwithupperandlowercasewords");
}