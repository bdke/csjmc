namespace JMC.Mcdoc.Parser;
internal class DocComment : McdocSyntax
{
    public override bool Parse(ReadOnlySpan<char> text, out int passedPos)
    {
        passedPos = 0;
        if (!text.StartsWith("///"))
        {
            return false;
        }
        using StringReader reader = new(new(text));
        int read = reader.Read();
        passedPos++;
        while (read > -1 && read != '\n')
        {
            read = reader.Read();
            passedPos++;
        }
        return true;
    }
}
