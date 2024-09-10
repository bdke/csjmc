using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:rotation")]
internal class Rotation : BaseArgument
{
    public override int ArgumentsLength => 2;
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return arguments.IsValidPositions(true).Item1 ? new CommandParseResult(CommandTokenType.Rotation, this) : new ParseError(new CommandSyntaxError());
    }
}