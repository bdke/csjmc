namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:dimension")]
internal class Dimension : BaseArgument
{
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return new CommandParseResult(CommandTokenType.Dimension, this);
    }
}