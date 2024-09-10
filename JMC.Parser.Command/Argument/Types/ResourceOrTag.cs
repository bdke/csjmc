using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:resource_or_tag")]
internal class ResourceOrTag(string registry) : BaseArgument
{
    public string Registry { get; private set; } = registry;
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return arguments[0].IsValidResourceLocation(true) ? new CommandParseResult(CommandTokenType.ResourceOrTag, this) : new ParseError(new CommandSyntaxError());
    }
}