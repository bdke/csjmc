using JMC.Parser.Rules;
using sly.lexer;
using System.Collections.Immutable;

namespace JMC.Parser;

public sealed class JMCParser(TokenChannels<TokenType> tokenChannels, ImmutableArray<JMCRule> rules)
{
    private readonly ReadOnlyMemory<Token<TokenType>> _mainTokens = new([.. tokenChannels.GetChannel(0).Tokens]);
    private readonly ReadOnlyMemory<JMCRule> _rules = rules.AsMemory();
    private ReadOnlySpan<JMCRule> StatementRules => GetRules(RuleChannel.Statement);

    private int pointer = 0;
    private readonly JMCToken _rootToken = new()
    {
        RuleType = RuleType.Root,
        Position = new(0, 0)
    };

    public JMCToken Parse()
    {
        for (; pointer < _mainTokens.Length; pointer++)
        {
            JMCRule? matchedRule = null;
            JMCToken[] subRules = [];
            ReadOnlySpan<JMCRule> statements = StatementRules;
            foreach (JMCRule rule in statements)
            {
                if (TryParse(rule, out subRules))
                {
                    matchedRule = rule;
                    break;
                }
            }
            if (!matchedRule.HasValue)
            {
                continue;
            }
            pointer--;
            JMCRule ruleValue = matchedRule.Value;
            pointer += ruleValue.SubRules.Length;

        }

        return _rootToken;
    }

    private bool TryParse(JMCRule rule, out JMCToken[] jmcTokens)
    {
        jmcTokens = [];
        ImmutableArray<IJMCRule> subRules = rule.SubRules;
        int length = subRules.Length;
        ReadOnlySpan<Token<TokenType>> tokens = GetTokens(length);
        if (tokens.IsEmpty)
        {
            return false;
        }
        for (int i = 0; i < length; i++)
        {
            IJMCRule subRule = subRules[i];
            Token<TokenType> token = tokens[i];
            if (!TryParse(subRule, token.TokenID, out jmcTokens))
            {
                return false;
            }
        }

        return true;
    }

    private bool TryParse(JMCCRule cRule, TokenType tokenType, out JMCToken[] tokens)
    {
        tokens = [];
        ReadOnlySpan<JMCRule> rules = GetRules(cRule.Channel);

        foreach (JMCRule rule in rules)
        {
            if (TryParse(rule, tokenType, out tokens))
            {
                return true;
            }
        }

        return false;
    }

    private bool TryParse(JMCRRule rRule, TokenType tokenType, out JMCToken[] tokens)
    {
        List<JMCToken> list = [];
        int matchedCount = 0;

        while (TryParse(rRule.Rule, tokenType, out tokens))
        {
            matchedCount++;
            list.AddRange(tokens);
        }

        tokens = [.. list];
        return rRule.IsValid(matchedCount);
    }

    internal bool TryParse(IJMCRule rule, TokenType tokenType, out JMCToken[] token)
    {
        token = [];
        JMCToken[] tokens = [];
        return rule switch
        {
            JMCRule root => TryParse(root, out tokens),
            JMCCRule c => TryParse(c, tokenType, out token),
            JMCTRule t => t == tokenType,
            JMCORule o => o.Rules.Any(v => TryParse(v, tokenType, out tokens)),
            JMCGRule g => g.Rules.All(v => TryParse(v, tokenType, out tokens)),
            JMCRRule r => TryParse(r, tokenType, out tokens),
            _ => throw new NotImplementedException(),
        };
    }

    private ReadOnlySpan<JMCRule> GetRules(RuleChannel channel)
    {
        ReadOnlySpan<JMCRule> rules = _rules.Span;
        List<JMCRule> list = [];
        foreach (JMCRule rule in rules)
        {
            if (rule.Channel != channel)
            {
                continue;
            }
            list.Add(rule);
        }
        return new([.. list]);
    }

    private ReadOnlySpan<Token<TokenType>> GetTokens(int length)
    {
        try
        {
            return _mainTokens.Slice(pointer, length).Span;
        }
        catch (ArgumentOutOfRangeException)
        {
            return [];
        }
    }
}
