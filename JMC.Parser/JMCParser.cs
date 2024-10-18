using sly.lexer;
using sly.parser.generator;

namespace JMC.Parser;

public sealed class JMCParser
{
    [Production("program: line*")]
    public JMCToken ParseProgram(List<JMCToken> tokens)
    {
        return default;
    }

    [Prefix()]

    [Production("number: [Int | Float]")]
    public JMCToken PaseNumber(Token<TokenType> token)
    {
        return new(token.TokenID, token.IntValue, token.Position.ToPosition());
    }
}
