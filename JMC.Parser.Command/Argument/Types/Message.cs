using JMC.Parser.Command.Argument.Property;

using static JMC.Parser.Command.Argument.Helper.TargetParser;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:message")]
internal class Message : BaseArgument
{
    public List<TargetSelector> Selectors { get; private set; } = [];

    public override IParseResult Parse(params string[] arguments)
    {
        foreach (string? arg in arguments.Where(arg => arg.StartsWith('@') && arg.Length > 1))
        {
            TargetSelector? selector = ParseSelector(arg, out CommandSyntaxError? error);
            if (error != null)
            {
                return new ParseError(error);
            }
            Selectors.Add(selector!);
        }
        return new CommandParseResult(CommandTokenType.Message, this);
    }
}