using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace JMC.Parser.Rules;
public interface IJMCRule
{
}

/// <summary>
/// Group a set of <see cref="IJMCRule"/>
/// </summary>
/// <param name="rules"></param>
internal readonly struct JMCGRule(params IJMCRule[] rules) : IJMCRule
{
    public ImmutableArray<IJMCRule> Rules { get; } = [.. rules];
}

/// <summary>
/// Set value range of <see cref="IJMCRule"/>
/// </summary>
/// <param name="rule"></param>
/// <param name="min"></param>
/// <param name="max"></param>
internal readonly struct JMCRRule(IJMCRule rule, int min, int max = int.MaxValue) : IJMCRule
{
    public IJMCRule Rule { get; } = rule;
    public Range AllowedRange { get; } = new(min, max);

    public bool IsValid(int index)
    {
        return AllowedRange.Start.Value <= index && AllowedRange.End.Value >= index; 
    }
}

/// <summary>
/// Set valid <see cref="RuleChannel"/> rule
/// </summary>
/// <param name="ruleChannel"></param>
internal readonly struct JMCCRule(RuleChannel ruleChannel) : IJMCRule
{
    public RuleChannel Channel { get; } = ruleChannel;
}

/// <summary>
/// Set valid <see cref="IJMCRule"/>s
/// </summary>
/// <param name="rules"></param>
internal readonly struct JMCORule(params IJMCRule[] rules) : IJMCRule
{
    public ImmutableArray<IJMCRule> Rules { get; } = [.. rules];
}

/// <summary>
/// Set valid <see cref="TokenType"/>
/// </summary>
/// <param name="token"></param>
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

    public static bool operator ==(JMCTRule left, JMCTRule right) 
    {
        return left.Equals(right);
    }

    public static bool operator !=(JMCTRule left, JMCTRule right)
    {
        return !left.Equals(right);
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is not JMCTRule rule)
            return false;
        return Token == rule.Token;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

/// <summary>
/// Root of every rule
/// </summary>
/// <param name="rules"></param>
/// <param name="ruleType"></param>
/// <param name="channel"></param>
/// <param name="name"></param>
public readonly struct JMCRule(ImmutableArray<IJMCRule> rules, RuleType ruleType, RuleChannel channel, string name) : IJMCRule
{
    public ImmutableArray<IJMCRule> SubRules { get; } = rules;
    public RuleType Type { get; } = ruleType;
    public RuleChannel Channel { get; } = channel;
    public string Name { get; } = name;
}