namespace Settings.Service.Extensions;

/// <summary>
/// Расширения для <see cref="IEnumerable{T}"/>
/// </summary>
public static class EnumerableExtensions
{
    
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> func)
    {
        foreach (var item in source)
        {
            func(item);
            // yield return item;
        }
    }
}