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
        char currentChar = text[passedPos];
        passedPos++;
        while (currentChar != '\n' && passedPos < text.Length)
        {
            currentChar = text[passedPos++];
        }

        return true;
    }
}
