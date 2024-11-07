using sly.lexer;
using Spectre.Console;

namespace JMC.Parser.Helper;
public static class ExpressionHelper
{
    public static JMCExpression ToExpression(this Token<TokenType> token) => new()
    {
        Position = token.Position,
        TokenType = token.TokenID,
        Value = token.Value,
    };

    public static IEnumerable<JMCExpression> ToExpressions(this IEnumerable<Token<TokenType>> tokens) => tokens.Select(v => v.ToExpression());

    public static Tree GetConsoleTree(this JMCExpression token)
    {
        var root = new Tree(token.Value?.ToString() ?? string.Empty);
        var position = token.HasValue ? string.Empty : $" [red]{token.Position}[/]";
        foreach (var exp in token.SubExpressions)
        {
            var node = root.AddNode($"[green]{exp.TokenType}[/] [aqua]{exp.Value}[/]{position}");
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

        foreach (var exp in token.SubExpressions)
        {
            var position = exp.HasValue ? string.Empty : $" [red]{exp.Position}[/]";
            var subNode = node.AddNode($"[green]{exp.TokenType}[/] [aqua]{exp.Value}[/]{position}");
            exp.ConvertToConsoleTree(ref subNode);
        }
    }
}
