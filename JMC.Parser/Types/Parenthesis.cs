namespace JMC.Parser.Types;
public class Parenthesis : BaseSyntaxType
{
    public override bool Validate(string text)
    {
        return text.StartsWith('(') && text.EndsWith(')');
    }
}
