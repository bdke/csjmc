namespace JMC.Parser.Types;
internal class End : BaseSyntaxType
{
    public override bool Validate(string text)
    {
        return text == ";";
    }
}
