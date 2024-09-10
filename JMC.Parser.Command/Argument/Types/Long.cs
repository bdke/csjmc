namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("brigadier:long")]
internal class Long : BaseArgument
{
    private readonly long max;
    private readonly long min;

    public Long(long max = long.MaxValue, long min = long.MinValue)
    {
        this.max = max;
        this.min = min;
    }

    public Long()
    {
        max = long.MaxValue;
        min = long.MinValue;
    }

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return !long.TryParse(arguments[0], out long result) || result > max || result < min
            ? new ParseError(new CommandSyntaxError())
            : new CommandParseResult(CommandTokenType.Long, this);
    }
}