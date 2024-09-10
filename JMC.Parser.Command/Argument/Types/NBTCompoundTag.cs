using Bertie.SNBT.Parser.NBT;
using Bertie.SNBT.Parser.Parsers;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:nbt_compound_tag")]
internal class NBTCompoundTag : BaseArgument
{
    public NbtCompound? NBT { get; set; }

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        NbtCompoundParser parser = new();
        NBT = parser.Parse(arguments[0]);
        return new CommandParseResult(CommandTokenType.NBTCompoundTag, this);
    }
}