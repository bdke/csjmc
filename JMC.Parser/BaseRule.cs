using Antlr4.Runtime;
using JMC.Parser.Error;

namespace JMC.Parser;
public abstract class BaseRule(string ruleName)
{
    public string RuleName => ruleName;
    //TODO: tokenstream
    public abstract IEnumerable<SyntaxNode> Parse(ref TokenStream stream ,ref List<SyntaxError> errors);
}
