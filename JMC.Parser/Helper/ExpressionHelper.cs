using sly.lexer;
using Spectre.Console;

namespace JMC.Parser.Helper;
public static class ExpressionHelper
{
    public static JMCExpression ToExpression(this Token<TokenType> token)
    {
        return new()
        {
            Position = token.Position,
            TokenType = token.TokenID,
            Value = token.Value,
        };
    }

    public static IEnumerable<JMCExpression> ToExpressions(this IEnumerable<Token<TokenType>> tokens)
    {
        return tokens.Select(v => v.ToExpression());
    }

    public static Tree GetConsoleTree(this JMCExpression token)
    {
        Tree root = new(token.Value?.ToString() ?? string.Empty);
        string position = token.HasValue ? string.Empty : $" [red]{token.Position}[/]";
        foreach (JMCExpression exp in token.SubExpressions)
        {
            string type = exp.TokenType != null ? $"[green]{exp.TokenType}[/] " : string.Empty;
            TreeNode node = root.AddNode($"{type}[aqua]{exp.Value}[/]{position}");
            exp.ConvertToConsoleTree(ref node);
        }
        return root;
    }

    private static void ConvertToConsoleTree(this JMCExpression token, ref TreeNode node)
    {
        if (token.SubExpressions.IsDefaultOrEmpty)
        {
            return;
        }

        foreach (JMCExpression exp in token.SubExpressions)
        {
            string type = exp.TokenType != null ? $"[green]{exp.TokenType}[/] " : string.Empty;
            string position = exp.HasValue ? string.Empty : $" [red]{exp.Position}[/]";
            TreeNode subNode = node.AddNode($"{type}[aqua]{exp.Value}[/]{position}");
            exp.ConvertToConsoleTree(ref subNode);
        }
    }
}
