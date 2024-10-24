using sly.lexer;
using System.Collections.Immutable;
using System.Runtime.InteropServices;

namespace JMC.Parser;

public sealed class JMCParser(TokenChannels<TokenType> tokenChannels, ImmutableArray<IJMCRule> rules)
{
    private readonly ReadOnlyMemory<Token<TokenType>> _mainTokens = new([.. tokenChannels.GetChannel(0).Tokens]);
    private readonly ReadOnlyMemory<IJMCRule> _rules = rules.AsMemory();

    private int pointer = 0;
    private readonly JMCToken _rootToken = new()
    {
        RuleType = RuleType.Root,
        Position = new(0, 0)
    };

    public void Parse()
    {
        var statements = 
    }
}
