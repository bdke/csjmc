using Antlr4.Runtime;
using JMC.Parser.grammars;

namespace JMC.Parser;

public sealed class TokenStream(JMCLexer lexer)
{
    private readonly IEnumerable<IToken> tokens = lexer.GetAllTokens();
    private int cursor = 0;
    public int Cursor => cursor;
    public IVocabulary Vocabs => lexer.Vocabulary;

    public string GetDisplayName(int tokenType) => Vocabs.GetDisplayName(tokenType);

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
