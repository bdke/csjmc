using JMC.Parser.Error;

namespace JMC.Parser.Rules;
public sealed class TokenRule() : BaseRule("Token")
{
    public override IEnumerable<SyntaxNode> Parse(ref List<SyntaxError> errors)
    {
        throw new NotImplementedException();
    }
}
