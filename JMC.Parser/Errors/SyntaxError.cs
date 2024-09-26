using OmniSharp.Extensions.LanguageServer.Protocol.Models;

namespace JMC.Parser.Errors;
public class SyntaxError(Position pos, string expected) :
    BaseError(pos, GenerateMessage(pos, expected))
{
    private static string GenerateMessage(Position pos, string expected)
    {
        return $"Syntax Error At {pos}: {expected}.";
    }
}
