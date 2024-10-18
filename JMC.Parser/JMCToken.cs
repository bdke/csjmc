namespace JMC.Parser;
public struct JMCToken(TokenType tokenType, object value, Position position)
{
    public TokenType TokenType { get; set; } = tokenType;
    public object Value { get; set; } = value;
    public Position Position { get; set; } = position;
}

public struct Position(int line, int column)
{
    public int Line { get; set; } = line;
    public int Column { get; set; } = column;
}
