namespace JMC.Mcdoc.Parser;
internal class Comments : McdocSyntax
{
    public override bool Parse(ReadOnlySpan<char> text, out int passedPos)
    {
        Comment comment = new();
        bool parseResult = comment.Parse(text, out passedPos);
        while (parseResult)
        {
            parseResult = comment.Parse(text, out int pos);
            passedPos += pos;
        }
        return true;
    }
}
