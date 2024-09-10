namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:operation")]
internal class Operation : BaseArgument
{
    private static readonly string[] OPERATORS = ["=", "+=", "-=", "*=", "/=", "%=", "><", "<", ">"];

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string op = arguments[0];
        return !OPERATORS.Contains(op) ? new ParseError(new CommandSyntaxError()) : new CommandParseResult(CommandTokenType.Operation, this);
    }
}