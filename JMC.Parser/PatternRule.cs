namespace JMC.Parser;
public abstract class PatternRule(string ruleName) : BaseRule(ruleName)
{
    public abstract int[] TokenPattern { get; }
}
