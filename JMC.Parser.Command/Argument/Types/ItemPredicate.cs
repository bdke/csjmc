using JMC.Parser.Command.Argument.Property;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:item_predicate")]
internal class ItemPredicate : BaseArgument
{
    public Item? Item { get; set; }

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string itemString = arguments[0];
        Item = new Item(itemString);
        return Item.SyntaxErrors.Count != 0 ? new ParseError(Item.SyntaxErrors.ToArray()) : new CommandParseResult(CommandTokenType.ItemPredicate, this);
    }
}