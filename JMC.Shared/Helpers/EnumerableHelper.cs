namespace JMC.Shared.Helpers;
public static class EnumerableHelper
{
    /// <summary>
    /// Remove all null values of <paramref name="enumerable"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <exception cref="ArgumentException"/>
    /// <returns></returns>
    public static IEnumerable<T> FilterNullValues<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.Where(static x => x != null);
    }
}
