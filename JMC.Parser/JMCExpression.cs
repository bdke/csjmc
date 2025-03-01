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
    public ValueType Type { get; internal set; } = ValueType.Unspecify;
    public string Description { get; internal set; } = string.Empty;

    public static JMCExpression Empty => new() { Position = new(-1, -1), Description = KEYWORD_EMPTY };
    public readonly bool HasValue => Position.HasValue || !SubExpressions.IsDefaultOrEmpty;
    public readonly bool IsCollection => Type == ValueType.Collection;
    public readonly bool IsCollectionOrEmpty => IsCollection || !HasValue;

    public static JMCExpression ComposeCollection(string collectionName = KEYWORD_EMPTY, params JMCExpression[] exps)
    {
        var root = Empty;
        root.SubExpressions = [.. exps];
        root.Type = ValueType.Collection;
        root.Description = collectionName;
        return root;
    }

    public static JMCExpression ComposeCollection(string collectionName, IEnumerable<JMCExpression> exps)
    {
        return ComposeCollection(collectionName, exps.ToArray());
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
