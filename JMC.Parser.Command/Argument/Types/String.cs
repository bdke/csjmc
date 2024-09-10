using JMC.Parser.Command.Argument.Helper;

namespace JMC.Parser.Command.Argument.Types;

public enum StringType
{
    Word, Phrase, Greedy
}

[ArgumentIdentifier("brigadier:string")]
internal class String(StringType stringType) : BaseArgument
{
    public static StringType GetStringType(string type)
    {
        return type switch
        {
            "word" => StringType.Word,
            "phrase" => StringType.Phrase,
            "greedy" => StringType.Greedy,
            _ => throw new InvalidDataException()
        };
    }

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string argString = arguments[0];
        switch (stringType)
        {
            case StringType.Word:
                if (argString.Contains(' '))
                {
                    return new ParseError(new CommandSyntaxError());
                }
                return new CommandParseResult(CommandTokenType.Word, this);
            case StringType.Phrase:
                if (!argString.IsValidString() || argString.Contains(' '))
                {
                    return new ParseError(new CommandSyntaxError());
                }
                return new CommandParseResult(CommandTokenType.Phrase, this);
            case StringType.Greedy:
                return new CommandParseResult(CommandTokenType.Greedy, this);
            default:
                throw new NotImplementedException();
        }
    }
}