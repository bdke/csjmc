using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:block_pos")]
internal class BlockPos : BaseArgument
{
    public override int ArgumentsLength => 3;
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        (bool, bool[]) posResult = arguments.IsValidPositions();
        return posResult.Item1 ? new CommandParseResult(CommandTokenType.BlockPos, this) : new ParseError(new CommandSyntaxError());
    }
}