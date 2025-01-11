using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace JMC.Shared.Helpers;
public static class PositionExtensions
{
    /// <summary>
    /// Convert <see cref="Position"/> to <paramref name="text"/> offset
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static int ToOffset(this Position pos, string text)
    {
        var offset = 0;
        if (text.Length == 0)
        {
            throw new InvalidOperationException();
        }
        var lines = text.Split(Environment.NewLine);
        for (var i = 0; i < pos.Line; i++)
        {
            offset += lines[i].Length + Environment.NewLine.Length;
        }
        return offset + pos.Character;
    }
}
