namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:team")]
internal class Team : BaseArgument
{
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string value = arguments[0];
        return !value.All(v => char.IsLetterOrDigit(v) || v is '-' or '+' or '.' or '_')
            ? new ParseError(new CommandSyntaxError())
            : new CommandParseResult(CommandTokenType.Team, this);
    }
}