using JMC.Parser.Rules;
using sly.lexer;
using System.Collections.Immutable;

namespace JMC.Parser;
public struct JMCToken()
{
    public required RuleType RuleType { get; set; }
    public object? Value { get; set; } = null;
    public required Position Position { get; set; }
    public ImmutableArray<JMCToken> SubRules { get; set; } = [];
    public TokenType? TokenType { get; set; } = null;
}

public struct Position(int line, int column)
{
    public int Line { get; set; } = line;
    public int Column { get; set; } = column;

    public static implicit operator LexerPosition(Position pos)
    {
        return new(-1, pos.Line, pos.Column);
    }


    public static implicit operator Position(LexerPosition pos)
    {
        return new(pos.Line, pos.Column);
    }
}
