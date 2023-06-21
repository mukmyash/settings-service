namespace Settings.Service.Test.Extensions;

/// <summary>
/// расширения для <see cref="ICollection{T}"/>
/// </summary>
public static class CollectionExtensions
{
    private static Random randomizer = new Random((int)DateTime.Now.Ticks);
    public static T GetRandomElement<T>(this IList<T> source)
    {
        return source[randomizer.Next() % source.Count];
    }
}