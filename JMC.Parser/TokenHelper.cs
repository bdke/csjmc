using sly.lexer;

namespace JMC.Parser;
public static class TokenHelper
{
    public static Position ToPosition(this LexerPosition lexerPosition)
    {
        return new()
        {
            Line = lexerPosition.Line,
            Column = lexerPosition.Column,
        };
    }

    private static void PrintTree(this JMCToken token, string indent, bool last)
    {
        Console.Write(indent);
        if (last)
        {
            Console.Write("\\-");
            indent += "  ";
        }
        else
        {
            Console.Write("|-");
            indent += "| ";
        }
        Console.WriteLine($"{token.RuleType} {token.Value}");
        System.Collections.Immutable.ImmutableArray<JMCToken> subRules = token.SubRules;
        for (int i = 0; i < subRules.Length; i++)
        {
            subRules[i].PrintTree(indent, i == subRules.Length - 1);
        }
    }

    public static void PrintTree(this JMCToken token)
    {
        PrintTree(token, string.Empty, false);
    }
}
