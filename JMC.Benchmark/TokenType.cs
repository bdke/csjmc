using sly.lexer;

namespace JMC.Benchmark;
public enum TokenType
{
    EOF,
    [Sugar("=")]
    Assign,
    [Sugar(";")]
    End,
    [AlphaNumDashId]
    Identifier
}
