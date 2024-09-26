using JMC.Parser.Models;

namespace JMC.Parser.Types;
internal class Block : BaseSyntaxType, IExpandableSyntax
{
    public SyntaxTree GetTree(TokenData data)
    {
        if (!Validate(data.Value))
            return [];

        var startOffset = data.Offset + 1;
        var value = data.Value[1..^1];
        var tokenizer = new JMCTokenizer(value, startOffset);
        var parser = new JMCParser(tokenizer, JMCSyntax.GetCoreBuilder());
        return parser.Parse(out _);
    }

    public override bool Validate(string text)
    {
        return text.StartsWith('{') && text.EndsWith('}');
    }
}
