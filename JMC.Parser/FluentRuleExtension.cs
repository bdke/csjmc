namespace JMC.Parser;
internal static class FluentRuleExtension
{
    public static JMCORule Or(this IJMCRule rule, params IJMCRule[] rules)
    {
        var result = new IJMCRule[1] { rule }.Concat(rules);
        return new([.. result]);
    }

    public static JMCRRule Range(this IJMCRule rule, int min, int max = int.MaxValue)
    {
        return new(rule, min, max);
    }

    public static JMCRuleBuilder AddTokens(this JMCRuleBuilder builder, params TokenType[] tokenTypes)
    {
        foreach (var tokenType in tokenTypes)
        {
            builder.AddCondition((JMCTRule)tokenType);
        }
        return builder;
    }
}

internal static class Rule
{
    public static JMCORule Or(params IJMCRule[] rules) => new(rules);
    public static JMCCRule Channel(RuleChannel channel) => new(channel);
    public static JMCTRule Token(TokenType tokenType) => new(tokenType);
    public static JMCGRule Group(params IJMCRule[] rules) => new(rules);
}
