using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:block_state")]
internal class BlockState : BaseArgument
{
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        CommandValueParser.BlockInfo state = CommandValueParser.ParseBlock(arguments[0], out List<BaseError>? errors);
        return state.BlockName.IsTag || errors.Count != 0 ? new ParseError(new CommandSyntaxError()) : new CommandParseResult(CommandTokenType.BlockState, this);
    }
}