using JMC.Parser.Error;

namespace JMC.Parser.Rules;
public sealed class SubRule(BaseRule rule) : BaseRule(rule.RuleName)
{
    public override IEnumerable<SyntaxNode> Parse(ref TokenStream stream, ref List<SyntaxError> errors)
    {
        return rule.Parse(ref stream, ref errors);
    }
}
