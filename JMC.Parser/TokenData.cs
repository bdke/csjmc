namespace JMC.Parser;

public struct TokenData(int offset, string value)
{
    public int Offset { get; set; } = offset;
    public string Value { get; set; } = value;

    public readonly override string ToString()
    {
        return $"{{Offset = {Offset}, Value = {Value}}}";
    }
}
