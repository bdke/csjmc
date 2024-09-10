namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:color")]
internal class Color : BaseArgument
{
    public static readonly string[] OPTIONS = [
       "reset",
        "black",
        "dark_blue",
        "dark_green",
        "dark_aqua",
        "dark_red",
        "dark_purple",
        "gold",
        "gray",
        "dark_gray",
        "blue",
        "green",
        "aqua",
        "red",
        "light_purple",
        "yellow",
        "white"
    ];

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return !OPTIONS.Contains(arguments[0]) ? new ParseError(new CommandSyntaxError()) : new CommandParseResult(CommandTokenType.Color, this);
    }
}