namespace JMC.Mcdoc.Parser;
internal class Comment : McdocSyntax
{
    public override bool Parse(ReadOnlySpan<char> text, out int passedPos)
    {
        passedPos = 0;
        if (!text.StartsWith("//") || text.StartsWith("///"))
        {
            return false;
        }
        using StringReader reader = new(new(text));
        int currentChar = reader.Read();
        passedPos++;
        while (currentChar is not (-1) and not '\n')
        {
            currentChar = reader.Read();
            passedPos++;
        }

        return true;
    }
}
