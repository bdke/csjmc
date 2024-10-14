using Antlr4.Runtime;

namespace JMC.Parser;

public sealed class TokenStream(IEnumerable<IToken> tokens)
{
    private readonly IEnumerable<IToken> tokens = tokens;
    private int cursor = 0;
    public int Cursor => cursor;

    public IToken Read()
    {
        var token = tokens.ElementAt(cursor);
        cursor++;
        return token;
    }

    public IEnumerable<IToken> Read(int length)
    {
        if (length == 0)
            throw new ArgumentOutOfRangeException(nameof(length), length, "length must be larger than 0");

        var result = tokens.Skip(cursor).Take(length);
        cursor += length;
        return result;
    }
}
