using CommunityToolkit.HighPerformance;
using System.Runtime.InteropServices;

namespace JMC.Parser.Helpers;
internal static class ListHelper
{
    public static Span2D<T> AsSpan2D<T>(this List<List<T>> list)
    {
        if (list.Count == 0)
        {
            return Span2D<T>.Empty;
        }

        int maxSize = list.Select(v => v.Count).Max();
        T[,] arr = new T[list.Count, maxSize];

        Span<List<T>> spanList = CollectionsMarshal.AsSpan(list);
        for (int i = 0; i < spanList.Length; i++)
        {
            Span<T> statementSpan = CollectionsMarshal.AsSpan(spanList[i]);
            for (int j = 0; j < statementSpan.Length; j++)
            {
                ref T syntax = ref statementSpan[j];
                arr[i, j] = syntax;
            }
        }

        return arr.AsSpan2D();
    }
}
