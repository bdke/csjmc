namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:objective")]
internal class Objective : BaseArgument
{
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return !arguments[0].All(v => char.IsLetterOrDigit(v) || "-+._".Contains(v)) && arguments[0] != "*"
            ? new ParseError(new CommandSyntaxError())
            : new CommandParseResult(CommandTokenType.Objective, this);
    }
}