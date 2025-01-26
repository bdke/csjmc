using sly.lexer;
using sly.parser.parser;
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

    public static JMCExpression GetValueOrEmpty(this ValueOption<JMCExpression> valueOption) => valueOption.Match(v => v, () => JMCExpression.Empty);
    public static Group<T1, T2>? GetValueOrNull<T1, T2>(this ValueOption<Group<T1, T2>> valueOption) where T1 : struct => 
        valueOption.Match(v => v, () => null!);

    public static IEnumerable<JMCExpression> ToExpressions(this IEnumerable<Token<TokenType>> tokens)
    {
        return tokens.Select(v => v.ToExpression());
    }

    public static Tree GetConsoleTree(this JMCExpression token)
    {
        Tree root = new(token.Value?.ToString() ?? string.Empty);
        
        foreach (JMCExpression exp in token.SubExpressions)
        {
            TreeNode node = root.AddNode(exp.GenerateTreeInfo());
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
            TreeNode subNode = node.AddNode(exp.GenerateTreeInfo());
            exp.ConvertToConsoleTree(ref subNode);
        }
    }

    private static string GenerateTreeInfo(this JMCExpression exp)
    {
        string type = exp.TokenType != null ? $"[green]{exp.TokenType}[/] " : string.Empty;
        string position = exp.Position.HasValue ? $"[red]{exp.Position}[/] " : string.Empty;
        string value = exp.Value != null ? $"[aqua]{exp.Value}[/] " : string.Empty;
        string collection = exp.IsCollection ? $"[yellow]Collection[/]" : string.Empty;
        string empty = !exp.HasValue ? $"[yellow]Empty[/]" : string.Empty;
        return $"{type}{value}{position}{collection}{empty}";
    }
}
