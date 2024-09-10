using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:vec3")]
internal class Vec3 : BaseArgument
{
    public override int ArgumentsLength => 3;

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        return arguments.IsValidPositions().Item1 ? new CommandParseResult(CommandTokenType.Vec3, this) : new ParseError(new CommandSyntaxError());
    }
}