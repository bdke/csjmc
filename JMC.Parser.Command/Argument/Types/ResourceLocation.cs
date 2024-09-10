using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:resource_location")]
internal class ResourceLocation : BaseArgument
{

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return arguments[0].IsValidResourceLocation() ? new CommandParseResult(CommandTokenType.ResourceLocation, this) : new ParseError(new CommandSyntaxError());
    }
}