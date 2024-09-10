namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("Literal")]
internal class Literal(params string[] options) : BaseArgument
{
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return !options.Contains(arguments[0]) ? new ParseError(new CommandSyntaxError()) : new CommandParseResult(CommandTokenType.Word, this);
    }
}