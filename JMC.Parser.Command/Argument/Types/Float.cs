namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("brigadier:float")]
internal class Float : BaseArgument
{
    private readonly float max;
    private readonly float min;

    public Float(float max = float.MaxValue, float min = float.MinValue)
    {
        this.max = max;
        this.min = min;
    }

    public Float()
    {
        max = float.MaxValue;
        min = float.MinValue;
    }

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return !float.TryParse(arguments[0], out float result) || result > max || result < min
            ? new ParseError(new CommandSyntaxError())
            : new CommandParseResult(CommandTokenType.Float, this);
    }
}