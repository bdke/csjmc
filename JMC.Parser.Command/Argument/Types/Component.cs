using Bertie.SNBT.Parser.NBT;
using Bertie.SNBT.Parser.Parsers;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:component")]
internal class Component : BaseArgument
{
    public override IParseResult Parse(params string[] arguments)
    {
        NbtTagParser parser = new();
        NbtTag tag = parser.Parse(arguments[0]);
        return tag.TryAs<NbtCompound>(out _) || tag.TryAs<NbtPrimitive<string>>(out _) || tag.TryAs<NbtArray>(out _)
            ? new CommandParseResult(CommandTokenType.Component, this)
            : new ParseError(new CommandSyntaxError());
    }
}