namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("brigadier:integer")]
internal class Int : BaseArgument
{
    private readonly int max;
    private readonly int min;

    public Int(int max = int.MaxValue, int min = int.MinValue)
    {
        this.max = max;
        this.min = min;
    }

    public Int()
    {
        max = int.MaxValue;
        min = int.MinValue;
    }

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return !int.TryParse(arguments[0], out int result) || result > max || result < min
            ? new ParseError(new CommandSyntaxError())
            : new CommandParseResult(CommandTokenType.Int, this);
    }
}