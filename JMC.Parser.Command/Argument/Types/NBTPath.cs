using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:nbt_path")]
internal class NBTPath : BaseArgument
{
    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);

        if (!arguments[0].IsBracketValid())
        {
            return new ParseError(new CommandSyntaxError());
        }

        return new CommandParseResult(CommandTokenType.NBTPath, this);
    }
}