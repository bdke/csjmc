using sly.lexer;
using sly.parser.generator;

namespace JMC.Benchmark;
public sealed class Rule
{
    [Production("program: statement*")]
    public static string Program(List<string> statements)
    {
        return string.Join(Environment.NewLine, statements);
    }

    [Production("statement: Identifier Assign[d] Identifier[d] End[d]")]
    public static string Statement(Token<TokenType> token)
    {
        return token.ToString();
    }
}
