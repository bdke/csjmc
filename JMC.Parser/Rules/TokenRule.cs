using JMC.Parser.Error;

namespace JMC.Parser.Rules;
public sealed class TokenRule(int tokenType) : BaseRule("Token")
{
    public override IEnumerable<SyntaxNode> Parse(ref TokenStream stream, ref List<SyntaxError> errors)
    {
        var token = stream.Read();
        if (token.Type != tokenType)
        {
            errors.Add(new(false, stream.GetDisplayName(token.Type), token.Line - 1, token.Column));
        }
        return [new SyntaxNode(this)];
    }
}
