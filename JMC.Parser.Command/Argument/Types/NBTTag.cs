using Bertie.SNBT.Parser.NBT;
using Bertie.SNBT.Parser.Parsers;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:nbt_tag")]
internal class NBTTag : BaseArgument
{
    public NbtTag? NBT { get; set; }

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        NbtTagParser parser = new();
        NBT = parser.Parse(arguments[0]);
        return new CommandParseResult(CommandTokenType.NBTTag, this);
    }
}