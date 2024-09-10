using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:resource")]
internal class Resource(string registry) : BaseArgument
{
    public string Registry { get; private set; } = registry;
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return arguments[0].IsValidResourceLocation() ? new CommandParseResult(CommandTokenType.Resource, this) : new ParseError(new CommandSyntaxError());
    }
}