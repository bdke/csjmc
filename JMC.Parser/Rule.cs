using System.Collections.Immutable;

namespace JMC.Parser;
public sealed class Rule
{
    private readonly List<BaseRule> rules = [];

    private ImmutableArray<BaseRule>? builtArray;

    public ImmutableArray<BaseRule> Rules => builtArray ?? throw new InvalidOperationException("The rule is not built");

    public Rule Add(params BaseRule[] subRules)
    {
        rules.AddRange(subRules);
        return this;
    }

    public void Build()
    {
        builtArray = [.. rules];
    }
}
