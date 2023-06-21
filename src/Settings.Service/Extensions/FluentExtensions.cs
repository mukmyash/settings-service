namespace Settings.Service.Extensions;

/// <summary>
/// Расширения в стиле Fluent
/// </summary>
public static class FluentExtensions
{
    /// <summary>
    /// Проверяет значение и если проверка вернула true то выбрасывается исключение
    /// </summary>
    /// <param name="value">Проверяемое значение</param>
    /// <param name="predicat">Предикат проверки</param>
    /// <param name="createException">Функция создания ошибки</param>
    /// <typeparam name="T">Тип value</typeparam>
    /// <typeparam name="TE">Тип Exception</typeparam>
    /// <returns>Проверенное значение</returns>
    /// <exception cref="TE">Выбрасываемое исклюечние</exception>
    public static T CheckValue<T, TE>(this T value, Predicate<T> predicat, Func<T,TE> createException)
        where TE : Exception
    {
        if (predicat(value))
        {
            throw createException(value);
        }

        return value;
    }
}