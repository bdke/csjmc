using sly.lexer;
using System.Diagnostics.CodeAnalysis;
using LSPPosition = OmniSharp.Extensions.LanguageServer.Protocol.Models.Position;

namespace JMC.Parser;

public struct Position(int line, int column)
{
    public int Line { get; set; } = line;
    public int Column { get; set; } = column;

    public static Position Empty => new(-1, -1);
    public readonly bool HasValue => this != Empty;

    public static implicit operator LexerPosition(Position position) => new(-1, position.Line, position.Column);
    public static implicit operator Position(LexerPosition position) => new(position.Line, position.Column);

    public static implicit operator LSPPosition(Position position) => new(position.Line, position.Column);
    public static implicit operator Position(LSPPosition position) => new(position.Line, position.Character);

    public static bool operator ==(Position left, Position right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Position left, Position right)
    {
        return !left.Equals(right);
    }

    public readonly override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is not Position pos)
            return false;
        return pos.Line == Line && pos.Column == Column;
    }

    public readonly override string ToString()
    {
        return $"Line={Line}, Column={Column}";
    }

    public readonly override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
