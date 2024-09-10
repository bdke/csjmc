namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("brigadier:bool")]
internal class Bool() : BaseArgument
{
    private static readonly string[] options = ["true", "false"];
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return !options.Contains(arguments[0]) ? new ParseError(new CommandSyntaxError()) : new CommandParseResult(CommandTokenType.Bool, this);
    }
}