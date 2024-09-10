using JMC.Parser.Command.Argument.Property;

using static JMC.Parser.Command.Argument.Helper.TargetParser;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:score_holder")]
internal class ScoreHolder(string amount) : BaseArgument
{
    private static CommandParseResult Result { get; set; } = null!;
    public string Amount { get; private set; } = amount;
    public TargetSelector? Selector { get; private set; }

    public override IParseResult Parse(params string[] arguments)
    {
        Result = new(CommandTokenType.ScoreHolder, this);
        _ = base.Parse(arguments);
        string target = arguments[0];
        if (target.StartsWith('@'))
        {
            Selector = ParseSelector(target, out CommandSyntaxError? error);
            if (error != null)
            {
                return new ParseError(error);
            }

            return !Selector!.IsSingle() && Amount == "single"
                ? new ParseError(new CommandSyntaxError())
                : Result;
        }
        else if (target == "*" && Amount == "single")
        {
            return new ParseError(new CommandSyntaxError());
        }
        else if (target == "*")
        {
            return Result;
        }

        return target.Any(v => !char.IsLetterOrDigit(v)) ? new ParseError(new CommandSyntaxError()) : Result;
    }
}