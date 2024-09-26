using JMC.Parser.Models;

namespace JMC.Parser.Types;
public sealed class Variable : BaseSyntaxType
{
    public override bool Validate(string text)
    {
        return text.StartsWith('$') && !text.Any(char.IsWhiteSpace);
    }
}
