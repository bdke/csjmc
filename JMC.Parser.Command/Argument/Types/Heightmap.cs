namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:heightmap")]
internal class Heightmap : BaseArgument
{
    public static readonly string[] HEIGHTMAP = ["world_surface", "motion_blocking", "motion_blocking_no_leaves", "ocean_floor"];

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string mode = arguments[0];

        return !HEIGHTMAP.Contains(mode) ? new ParseError(new CommandSyntaxError()) : new CommandParseResult(CommandTokenType.Heightmap, this);
    }
}