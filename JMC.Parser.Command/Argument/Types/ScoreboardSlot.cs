using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:scoreboard_slot")]
internal class ScoreboardSlot : BaseArgument
{
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return ScoreboardHelper.ScoreboardDisplaySlots.Contains(arguments[0]) ? new CommandParseResult(CommandTokenType.ScoreboardSlot, this) : new ParseError(new CommandSyntaxError());
    }
}