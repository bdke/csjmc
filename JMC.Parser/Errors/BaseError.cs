using JMC.Parser.Helpers;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;

namespace JMC.Parser.Errors;
public class BaseError
{
    public Position Position { get; set; }
    public string Message { get; private set; }

    public BaseError(string rawText, int offset, string message)
    {
        Position = rawText.ToPosition(offset);
        Message = message;
    }

    public BaseError(Position pos, string message)
    {
        Position = pos;
        Message = message;
    }

    public override string ToString()
    {
        return Message;
    }
}
