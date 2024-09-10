namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:function")]
internal class MinecraftFunction : BaseArgument
{
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        //TODO: parse this
        return new CommandParseResult(CommandTokenType.Function, this);
    }
}