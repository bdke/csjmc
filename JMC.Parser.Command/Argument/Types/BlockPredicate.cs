using JMC.Parser.Command.Argument.Helper;

using static JMC.Parser.Command.Argument.Helper.CommandValueParser;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:block_predicate")]
internal class BlockPredicate : BaseArgument
{
    public CommandValueParser.BlockInfo? State { get; private set; }
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        State = ParseBlock(arguments[0], out List<BaseError>? errors);

        return errors.Count == 0 ? new CommandParseResult(CommandTokenType.BlockPredicate, this) : new ParseError(new CommandSyntaxError());
    }
}