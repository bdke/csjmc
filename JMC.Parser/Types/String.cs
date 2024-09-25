namespace JMC.Parser.Types;
public class String : BaseSyntaxType
{
    public override bool Validate(string text)
    {
        return text.StartsWith('"') && text.EndsWith('"');
    }
}
