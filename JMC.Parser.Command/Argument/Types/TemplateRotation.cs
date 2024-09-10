namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:template_rotation")]
internal class TemplateRotation : BaseArgument
{
    private static readonly string[] TEMPLATES = ["none", "clockwise_90", "counterclockwise_90", "180"];
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string value = arguments[0];
        return TEMPLATES.Contains(value) ? new CommandParseResult(CommandTokenType.TemplateMirror, this) : new ParseError(new CommandSyntaxError());
    }
}