using JMC.Parser.Models;

namespace JMC.Parser.Types;
public class ValueOperation : BaseSyntaxType
{
    public override bool Validate(string text)
    {
        JMCTokenizer tokenizer = new(text);
        IEnumerable<TokenData> tokens = tokenizer.Tokenize();
        return tokens.Count() > 2;
    }
}
