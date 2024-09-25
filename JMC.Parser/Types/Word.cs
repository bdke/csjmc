namespace JMC.Parser.Types;
public class Word : BaseSyntaxType
{
    public override bool Validate(string text)
    {
        return text.All(v => v is '_' or '.' || char.IsLetterOrDigit(v));
    }
}
