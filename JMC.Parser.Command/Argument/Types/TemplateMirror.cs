namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:template_mirror")]
internal class TemplateMirror : BaseArgument
{
    private static readonly string[] TEMPLATES = ["none", "front_back", "left_right"];

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string value = arguments[0];
        return TEMPLATES.Contains(value) ? new CommandParseResult(CommandTokenType.TemplateMirror, this) : new ParseError(new CommandSyntaxError());
    }
}