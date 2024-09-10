using JMC.Parser.Command.Argument;

using static JMC.Parser.Command.Argument.BaseArgument;

namespace JMC.Parser.Command;

public class CommandParseResult(CommandTokenType tokenType, BaseArgument argType) : IParseResult
{
    public CommandTokenType TokenType { get; set; } = tokenType;
    bool IParseResult.Succeed { get; set; } = true;
    public BaseArgument ArgType = argType;
}