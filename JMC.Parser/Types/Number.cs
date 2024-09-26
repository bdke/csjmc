using JMC.Parser.Models;

namespace JMC.Parser.Types;
public sealed class Number : BaseSyntaxType
{
    public override bool Validate(string text)
    {
        return int.TryParse(text, out _);
    }
}
