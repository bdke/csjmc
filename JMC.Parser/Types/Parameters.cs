using JMC.Parser.Models;

namespace JMC.Parser.Types;
internal class Parameters : BaseSyntaxType
{
    public override bool Validate(string text)
    {
        return text.StartsWith('(') && text.EndsWith(')');
    }
}
