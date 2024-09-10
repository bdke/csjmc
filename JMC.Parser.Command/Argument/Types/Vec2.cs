using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:vec2")]
internal class Vec2 : BaseArgument
{
    public override int ArgumentsLength => 2;

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return arguments.IsValidPositions().Item1 ? new CommandParseResult(CommandTokenType.Vec2, this) : new ParseError(new CommandSyntaxError());
    }
}