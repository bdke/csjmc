
namespace JMC.Mcdoc.Parser;
internal class DocComments : McdocSyntax
{
    public override bool Parse(ReadOnlySpan<char> text, out int passedPos)
    {
        DocComment docComment = new();
        bool parseResult = docComment.Parse(text, out passedPos);
        while (parseResult)
        {
            parseResult = docComment.Parse(text, out int pos);
            passedPos += pos;
        }
        return true;
    }
}
