namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:float_range")]
internal class FloatRange : BaseArgument
{

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string range = arguments[0];
        string[] splited = range.Split("..");
        switch (splited.Length)
        {
            case 1 when !float.TryParse(splited[0], out _):
                return new ParseError(new CommandSyntaxError());
            case 2 when !float.TryParse(splited[0], out _) && !float.TryParse(splited[1], out _):
                return new ParseError(new CommandSyntaxError());
            default:
                break;
        }

        return new CommandParseResult(CommandTokenType.FloatRange, this);
    }
}