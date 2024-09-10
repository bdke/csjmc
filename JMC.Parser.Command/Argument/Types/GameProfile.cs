using JMC.Parser.Command.Argument.Property;

using static JMC.Parser.Command.Argument.Helper.TargetParser;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:game_profile")]
internal class GameProfile : BaseArgument
{
    public TargetSelector? Selector { get; private set; }
    public bool IsUUID { get; private set; } = false;

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string arg = arguments[0];
        if (arg.StartsWith('@'))
        {
            Selector = ParseSelector(arg, out CommandSyntaxError? error);
            if (error != null)
            {
                return new ParseError(error);
            }
        }
        IsUUID = arg.Contains('-');
        return new CommandParseResult(CommandTokenType.GameProfile, this);
    }
}