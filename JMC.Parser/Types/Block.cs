namespace JMC.Parser.Types;
internal class Block : BaseSyntaxType
{
    public override bool Validate(string text)
    {
        return text.StartsWith('{') && text.EndsWith('}');
    }
}
