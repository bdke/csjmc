using sly.lexer;
using System.Diagnostics.CodeAnalysis;

namespace JMC.Parser;

public struct Position(int line, int column)
{
    public int Line { get; set; } = line;
    public int Column { get; set; } = column;

    public static Position Empty => new(-1, -1);
    public readonly bool HasValue => this != Empty;

    public static implicit operator LexerPosition(Position position) => new(-1, position.Line, position.Column);
    public static implicit operator Position(LexerPosition position) => new(position.Line, position.Column);

    public static bool operator ==(Position left, Position right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Position left, Position right)
    {
        return !left.Equals(right);
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is not Position pos)
            return false;
        return pos.Line == Line && pos.Column == Column;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
