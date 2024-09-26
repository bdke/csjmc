using JMC.Parser.Models;

namespace JMC.Parser.Types;
public class ValueOperation : BaseSyntaxType, IExpandableSyntax
{
    public SyntaxTree GetTree(TokenData data)
    {
        //TODO:
        throw new NotImplementedException();
    }

    public override bool Validate(string text)
    {
        JMCTokenizer tokenizer = new(text);
        IEnumerable<TokenData> tokens = tokenizer.Tokenize();
        return tokens.Count() > 2;
    }
}
