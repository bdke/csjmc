using System.Collections.Immutable;

namespace JMC.Parser;
public sealed class RuleBuilder
{
    private readonly List<Rule> rules = [];
    private ImmutableArray<Rule>? builtRules;

    public ImmutableArray<Rule> Rules => builtRules ?? throw new InvalidOperationException("Rules it not built");

    public Rule Create()
    {
        var rule = new Rule();
        rules.Add(rule);
        return rule;
    }

    public void Build()
    {
        builtRules = [.. rules];
    }

    public static RuleBuilder GetDefaultBuilder()
    {
        var builder = new RuleBuilder();

        var root = builder.Create();

        return builder;
    }
}
