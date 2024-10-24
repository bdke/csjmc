using System.Collections.Immutable;

namespace JMC.Parser;
public interface IJMCRule
{
}

internal readonly struct JMCGRule(params IJMCRule[] rules) : IJMCRule
{
    public ImmutableArray<IJMCRule> Rules { get; } = [.. rules];
}

internal readonly struct JMCRRule(IJMCRule rule, int min, int max = int.MaxValue) : IJMCRule
{
    public IJMCRule Token { get; } = rule;
    public Range AllowedRange { get; } = new(min, max);
}

internal readonly struct JMCCRule(RuleChannel ruleChannel) : IJMCRule
{
    public RuleChannel Channel { get; } = ruleChannel;
}

internal readonly struct JMCORule(params IJMCRule[] rules) : IJMCRule
{
    public ImmutableArray<IJMCRule> Rules { get; } = [.. rules];
}

internal readonly struct JMCTRule(TokenType token) : IJMCRule
{
    public TokenType Token { get; } = token;

    public static implicit operator JMCTRule(TokenType tokenType)
    {
        return new(tokenType);
    }
    public static implicit operator TokenType(JMCTRule tRule)
    {
        return tRule.Token;
    }
}

internal readonly struct JMCRule(ImmutableArray<IJMCRule> rules, RuleType ruleType, RuleChannel channel, string name) : IJMCRule
{
    public ImmutableArray<IJMCRule> SubRules { get; } = rules;
    public RuleType Type { get; } = ruleType;
    public RuleChannel Channel { get; } = channel;
    public string Name { get; } = name;
}