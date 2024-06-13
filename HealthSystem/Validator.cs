namespace HealthSystem.Tools;

public static class IntValidator
{
    public static int? Validate(string value)
    {
        bool success = int.TryParse(value, out int number);
        return success ? number : null;
    }
}
