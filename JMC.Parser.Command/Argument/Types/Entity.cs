using JMC.Parser.Command.Argument.Property;

using static JMC.Parser.Command.Argument.Helper.TargetParser;


namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:entity")]
internal class Entity : BaseArgument
{
    private readonly string amount;
    private readonly string type;

    public Entity(string amount, string type)
    {
        this.amount = amount;
        this.type = type;

        if (amount is not "single" and not "multiple")
        {
            throw new ArgumentException($"{nameof(amount)} must be 'single' or 'multiple'");
        }
        if (type is not "players" and not "entities")
        {
            throw new ArgumentException($"{nameof(type)} must be 'players' or 'entities'");
        }
    }
    public TargetSelector? Selector { get; set; }
    private bool IsSingle => amount == "single";
    private bool IsPlayers => type == "players";


    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string selector = arguments[0];
        if (!selector.StartsWith('@'))
        {
            return new CommandParseResult(CommandTokenType.Entity, this);
        }

        Selector = ParseSelector(selector, out CommandSyntaxError? error);
        if (error != null)
        {
            return new ParseError(error);
        }

        if ((IsSingle && !Selector!.IsSingle()) || (IsPlayers && !Selector!.IsPlayers()))
        {
            return new ParseError(new CommandSyntaxError());
        }

        return new CommandParseResult(CommandTokenType.Entity, this);
    }
}