using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:resource_or_tag_key")]
internal class ResourceOrTagKey(string registry) : BaseArgument
{
    public string Registry { get; private set; } = registry;
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return arguments[0].IsValidResourceLocation(true) ? new CommandParseResult(CommandTokenType.ResourceOrTagKey, this) : new ParseError(new CommandSyntaxError());
    }
}