namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:time")]
internal class Time(float min) : BaseArgument
{
    public float Min { get; private set; } = min;
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string value = arguments[0];

        if (value.Count(char.IsLetter) > 1)
        {
            return new ParseError(new CommandSyntaxError());
        }
        else if (!char.IsDigit(value.Last()) && !float.TryParse(value[..^1], out float v))
        {
            return new ParseError(new CommandSyntaxError());
        }
        else if (!"std".Contains(value.Last()) && !char.IsDigit(value.Last()))
        {
            return new ParseError(new CommandSyntaxError());
        }
        else if (!float.TryParse(value[..^1], out v))
        {
            return new ParseError(new CommandSyntaxError());
        }
        else if (v < Min)
        {
            return new ParseError(new CommandSyntaxError());
        }
        return new CommandParseResult(CommandTokenType.Time, this);
    }
}