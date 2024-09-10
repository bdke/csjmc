
namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:swizzle")]
internal class Swizzle : BaseArgument
{
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return !arguments[0].All(v => v is 'x' or 'y' or 'z') || arguments[0].Length > 3 ?
            new ParseError(new CommandSyntaxError()) :
            new CommandParseResult(CommandTokenType.Swizzle, this);
    }
}