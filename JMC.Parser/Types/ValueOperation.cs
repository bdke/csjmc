using JMC.Parser.Models;

namespace JMC.Parser.Types;
public class ValueOperation : BaseSyntaxType, IExpandableSyntax
{
    private bool isNumber = false;
    private bool isParenthesis = false;
    private bool isOperation = false;
    private string text = string.Empty;
    public SyntaxTree GetTree(TokenData data)
    {
        var tokenizer = new JMCTokenizer(text, data.Offset);
        using var parser = new JMCParser(tokenizer, JMCSyntax.GetCoreBuilder());
        var tree = parser.Parse(out var errors);
        return tree;
    }

    public override bool Validate(string text)
    {
        isNumber = int.TryParse(text, out _);
        isParenthesis = text.StartsWith('(') && text.EndsWith(')');
        isOperation = text.Split(Operator.VALID_OPERATORS.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length > 1;
        this.text = text;
        return isNumber || isParenthesis || isOperation;
    }
}
