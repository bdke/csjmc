using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace JMC.Parser;
public struct JMCExpression()
{
    public const string KEYWORD_EMPTY = "Empty";

    public object? Value { get; set; } = null;
    public Position Position { get; set; } = Position.Empty;
    public ImmutableArray<JMCExpression> SubExpressions { get; set; } = [];
    public TokenType? TokenType { get; set; } = null;

    public static JMCExpression Empty => new() { Position = new(-1, -1), Value = KEYWORD_EMPTY };
    public readonly bool HasValue => Position.HasValue || !SubExpressions.IsDefaultOrEmpty;
    public readonly bool IsCollection => 
        !Position.HasValue && !SubExpressions.IsDefaultOrEmpty;
    public readonly bool IsCollectionOrEmpty => IsCollection || !HasValue;

    public ValueType Type { get; internal set; } = ValueType.Unspecify;

    public static JMCExpression ComposeCollection(params JMCExpression[] exps)
    {
        var root = Empty;
        root.SubExpressions = [.. exps];
        return root;
    }

    public static JMCExpression ComposeCollection(IEnumerable<JMCExpression> exps)
    {
        return ComposeCollection(exps.ToArray());
    }

    public JMCExpression AddToCollection(params JMCExpression[] exps)
    {
        SubExpressions = SubExpressions.AddRange(exps);
        return this;
    }

    public JMCExpression AddToCollection(IEnumerable<JMCExpression> exps)
    {
        return AddToCollection(exps.ToArray());
    }

    public static bool operator ==(JMCExpression left, JMCExpression right)
    {
        return left.Equals(right);
    }
    public static bool operator !=(JMCExpression left, JMCExpression right)
    {
        return !left.Equals(right);
    }

    public readonly override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is not JMCExpression exp)
            return false;
        return Position == exp.Position;
    }

    public readonly override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
