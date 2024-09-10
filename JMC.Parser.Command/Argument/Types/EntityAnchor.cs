namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:entity_anchor")]
internal class EntityAnchor : BaseArgument
{
    private static readonly string[] ANCHORS = ["eyes", "feet"];

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string anchor = arguments[0];
        return !ANCHORS.Contains(anchor) ? new ParseError(new CommandSyntaxError()) : new CommandParseResult(CommandTokenType.EntityAnchor, this);
    }
}