namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:uuid")]
internal class UUID : BaseArgument
{
    private const string UUID_ALLOWED_LETTERS = "abcdefABCDEF0123456789-";

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string value = arguments[0];
        return value.Any(v => !UUID_ALLOWED_LETTERS.Contains(v)) ? new ParseError(new CommandSyntaxError()) : new CommandParseResult(CommandTokenType.UUID, this);
    }
}