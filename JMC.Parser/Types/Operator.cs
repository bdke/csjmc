using JMC.Parser.Models;

namespace JMC.Parser.Types;
public class Operator : BaseSyntaxType
{
    public const string VALID_OPERATORS = "+-*/?%><=";
    public override bool Validate(string text)
    {
        if (text.Length != 1)
            return false;
        var c = text[0];
        return VALID_OPERATORS.Contains(c);
    }
}
