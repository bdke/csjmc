using EmmyLua.LanguageServer.Framework.Protocol.Model;
using sly.lexer;
using System.Diagnostics.CodeAnalysis;
using LSPPosition = EmmyLua.LanguageServer.Framework.Protocol.Model.Position;

namespace JMC.Parser;

public struct Position(int line, int column)
{
    public int Line { get; set; } = line;
    public int Column { get; set; } = column;

    private static readonly Position empty = new(-1, -1);
    public static Position Empty => empty;
    public readonly bool HasValue => this != empty;

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

    public static bool operator >(Position left, Position right)
    {
        return left.Line > right.Line || (left.Line == right.Line && left.Column > right.Column);
    }

    public static bool operator <(Position left, Position right)
    {
        return left.Line < right.Line || (left.Line == right.Line && left.Column < right.Column);
    }

    public static bool operator >=(Position left, Position right)
    {
        return left.Line >= right.Line || (left.Line == right.Line && left.Column >= right.Column);
    }

    public static bool operator <=(Position left, Position right)
    {
        return left.Line <= right.Line || (left.Line == right.Line && left.Column <= right.Column);
    }

    public readonly DocumentRange Join(Position pos)
    {
        return new DocumentRange(this, pos);
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
