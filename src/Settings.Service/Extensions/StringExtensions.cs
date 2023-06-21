namespace Settings.Service.Extensions;

/// <summary>
/// Расширения для <see cref="string"/>
/// </summary>
public static class StringExtensions
{
    public static bool IsNullOrWhiteSpace(this string? value)
        => string.IsNullOrWhiteSpace(value);

    public static string CheckFolderName(this string? value, string fullPath)
        => value.CheckValue(v => v.IsNullOrWhiteSpace(),
            _ => new ArgumentNullException($"Не удалось определить название папки в пути {fullPath}"))!;
}