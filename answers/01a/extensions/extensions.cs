using answers.models;

namespace answers.extensions;

public static class Extensions
{
    // This ToFriedlyString method works on DeviceType
    // Transforms its string representation into a more readable format
    // SmartLight -> Smart Light
    public static string ToFriendlyString(this DeviceType deviceType)
    {
        return string.Concat(
            deviceType.ToString().Select((c, i) => i > 0 && char.IsUpper(c) ? $" {c}" : $"{c}")
        );
    }
}
