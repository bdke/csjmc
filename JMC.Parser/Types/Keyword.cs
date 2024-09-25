namespace JMC.Parser.Types;
public class Keyword(string word) : BaseSyntaxType
{
    public override bool Validate(string text)
    {
        return text == word;
    }
}
