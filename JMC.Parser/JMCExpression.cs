using System.Collections.Immutable;

namespace JMC.Parser;
public struct JMCExpression()
{
    public object? Value { get; set; } = null;
    public Position Position { get; set; } = Position.Empty;
    public ImmutableArray<JMCExpression> SubExpressions { get; set; } = [];
    public TokenType? TokenType { get; set; } = null;

    public static JMCExpression Empty => new() { Position = new(-1, -1), Value = "Empty" };
    public readonly bool HasValue => Position.HasValue || !SubExpressions.IsDefaultOrEmpty;
    public readonly bool IsCollection => !Position.HasValue && !SubExpressions.IsDefaultOrEmpty;
}
