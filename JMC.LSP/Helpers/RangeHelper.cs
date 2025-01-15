using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace JMC.LSP.Helpers;
internal static class RangeHelper
{
    public static bool Contains(this DocumentRange range, Parser.Position pos)
    {
        Parser.Position end = range.End;
        return !end.HasValue ? range.Start <= pos : range.Start <= pos && range.End > pos;
    }
}
