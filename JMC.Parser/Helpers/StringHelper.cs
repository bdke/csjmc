using OmniSharp.Extensions.LanguageServer.Protocol.Models;

namespace JMC.Parser.Helpers;
internal static class StringHelper
{
    /// <summary>
    /// Document offset to <see cref="Position"/>
    /// </summary>
    /// <param name="value">document content</param>
    /// <param name="offset"></param>
    /// <returns>Zero-Based <see cref="Position"/></returns>
    public static Position ToPosition(this string value, int offset)
    {
        var currentOffset = offset;
        var newLine = Environment.NewLine;
        var lines = value.Split(newLine).AsSpan();
        for (int i = 0; i < lines.Length; i++)
        {
            ref var line = ref lines[i];
            var len = line.Length + newLine.Length;
            if (currentOffset < len)
            {
                return new Position(i, currentOffset);
            }

            currentOffset -= len;
        }
        throw new IndexOutOfRangeException();
    }
    
}