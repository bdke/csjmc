using sly.lexer;
using System.Collections.Immutable;

namespace JMC.Parser.Helper;
public static class ExpressionHelper
{
    public static JMCExpression ToExpression(this Token<TokenType> token) => new()
    {
        Position = token.Position,
        TokenType = token.TokenID,
        Value = token.Value,
    };

    private static void PrintTree(this JMCExpression token, string indent, bool last)
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
        Console.WriteLine($"{token.TokenType} {token.Value}");
        ImmutableArray<JMCExpression> subRules = token.SubExpressions;
        if (subRules.IsDefaultOrEmpty)
            return;

        for (int i = 0; i < subRules.Length; i++)
        {
            subRules[i].PrintTree(indent, i == subRules.Length - 1);
        }
    }

    public static void PrintTree(this JMCExpression token)
    {
        token.PrintTree(string.Empty, false);
    }
}
