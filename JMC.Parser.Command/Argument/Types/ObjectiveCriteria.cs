
using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:objective_criteria")]
internal class ObjectiveCriteria : BaseArgument
{
    public override IParseResult Parse(params string[] arguments)
    {
        //TODO: change version
        _ = base.Parse(arguments);
        CommandSyntaxError? error = ScoreboardHelper.CheckCriteria(arguments[0], "1.20.4");
        return error == null ? new CommandParseResult(CommandTokenType.ObjectiveCriteria, this) : new ParseError(error);
    }
}