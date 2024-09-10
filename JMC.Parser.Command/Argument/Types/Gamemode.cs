namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:gamemode")]
internal class Gamemode : BaseArgument
{
    private static readonly string[] GAMEMODES = ["survival", "creative", "adventure", "spectator"];

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string mode = arguments[0];

        return !GAMEMODES.Contains(mode) ? new ParseError(new CommandSyntaxError()) : new CommandParseResult(CommandTokenType.Gamemode, this);
    }
}