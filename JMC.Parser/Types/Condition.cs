namespace JMC.Parser.Types;
public class Condition : BaseSyntaxType
{
    public override bool Validate(string text)
    {
        return text.StartsWith('(') && text.EndsWith(')');
    }
}
