namespace JMC.Parser.Models;

public struct TokenData(int offset, string value)
{
    public int Offset { get; set; } = offset;
    public string Value { get; set; } = value;
    public static readonly TokenData INVALID_TOKEN = new(-1, string.Empty);
    public static readonly TokenData VALID_EXCEED = new(-2, string.Empty);
    public override readonly string ToString()
    {
        return $"{{Offset = {Offset}, Value = {Value?.Replace(Environment.NewLine, "\\n")}}}";
    }

    public static bool operator ==(TokenData left, TokenData right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(TokenData left, TokenData right)
    {
        return !left.Equals(right);
    }

    public override readonly bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override readonly int GetHashCode()
    {
        return base.GetHashCode();
    }
}
