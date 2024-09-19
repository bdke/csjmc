namespace JMC.Mcdoc.Parser;
internal class TypedNumber : McdocSyntax
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

        NumberType? numType = Enum.IsDefined(typeof(NumberType), (int)numStr[^1]) ? (NumberType)numStr[^1] : null;
        if (numType != null)
        {
            numStr = numStr.Remove(numStr.Length - 1);
        }

        if (numType != null && int.TryParse(numStr, out _) &&
            numType is NumberType.Byte or NumberType.Short or NumberType.Long)
        {
            return true;
        }
        if (numType != null && float.TryParse(numStr, out _) && 
            numType is NumberType.Double or NumberType.Float)
        {
            return true;
        }

        return numType == null && (int.TryParse(numStr, out _) || float.TryParse(numStr, out _));
    }
}
