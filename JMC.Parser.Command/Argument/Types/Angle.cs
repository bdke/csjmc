using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:angle")]
internal class Angle : BaseArgument
{
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return !arguments[0].IsValidPosition() ? new ParseError(new CommandSyntaxError()) : new CommandParseResult(CommandTokenType.Angle, this);
    }
}