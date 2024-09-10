using JMC.Parser.Command.Argument.Property;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:item_stack")]
internal class ItemStack : BaseArgument
{
    public Item? Item { get; set; }

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string itemString = arguments[0];
        Item = new Item(itemString);
        return Item.SyntaxErrors.Count != 0
            ? new ParseError(Item.SyntaxErrors.ToArray())
            : Item.IsTag ? new ParseError(new CommandSyntaxError()) : new CommandParseResult(CommandTokenType.ItemStack, this);
    }
}