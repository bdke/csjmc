using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:column_pos")]
internal class ColumnPos : BaseArgument
{
    public override int ArgumentsLength => 2;
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return arguments.IsValidPositions(true).Item1 ? new CommandParseResult(CommandTokenType.ColumnPos, this) : new ParseError(new CommandSyntaxError());
    }
}