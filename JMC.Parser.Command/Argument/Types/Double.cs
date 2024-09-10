namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("brigadier:double")]
internal class Double : BaseArgument
{
    private readonly double max;
    private readonly double min;

    public Double(double max = double.MaxValue, double min = double.MinValue)
    {
        this.max = max;
        this.min = min;
    }

    public Double()
    {
        max = double.MaxValue;
        min = double.MinValue;
    }

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return !double.TryParse(arguments[0], out double result) || result > max || result < min
            ? new ParseError(new CommandSyntaxError())
            : new CommandParseResult(CommandTokenType.Double, this);
    }
}