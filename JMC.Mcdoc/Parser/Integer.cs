
namespace JMC.Mcdoc.Parser;
internal class Integer : McdocSyntax
{
    public override bool Parse(ReadOnlySpan<char> text, out int passedPos)
    {
        passedPos = 0;
        string numStr = string.Empty;
        char currentChar;

        do
        {
            currentChar = text[passedPos];
            numStr += currentChar;
            passedPos++;
        } while (!char.IsWhiteSpace(currentChar) && passedPos < text.Length);
        
        return int.TryParse(numStr, out _);
    }
}
