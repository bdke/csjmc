namespace JMC.Parser.Models;

public struct SyntaxParseResult
{
    public TokenData TokenData { get; set; }
    public BaseSyntaxType SyntaxType { get; set; }
    public bool IsMatch { get; set; }
    public static readonly SyntaxParseResult INVALID = new()
    {
        TokenData = TokenData.INVALID_TOKEN,
        SyntaxType = null!,
        IsMatch = false
    };
    public static readonly SyntaxParseResult VALID_EXCCEED = new()
    {
        TokenData = TokenData.VALID_EXCEED,
        SyntaxType = null!,
        IsMatch = true
    };

    public static bool operator ==(SyntaxParseResult left, SyntaxParseResult right)
    {
        return left.TokenData == right.TokenData;
    }

    public static bool operator !=(SyntaxParseResult left, SyntaxParseResult right)
    {
        return left.TokenData != right.TokenData;
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