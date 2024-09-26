namespace JMC.Parser.Models;

public class SyntaxNode(SyntaxParseResult syntaxParseResult) : List<SyntaxNode>
{
    public SyntaxParseResult Syntax { get; init; } = syntaxParseResult;

    public bool TryExpand()
    {
        if (Syntax.SyntaxType is IExpandableSyntax expandable)
        {
            SyntaxTree result = expandable.GetTree(Syntax.TokenData);
            AddRange(result);
            foreach (SyntaxNode node in this)
            {
                _ = node.TryExpand();
            }
            return true;
        }
        return false;
    }

    public void PrintPretty(string indent, bool last)
    {
        Console.Write(indent);
        if (last)
        {
            Console.Write("\\-");
            indent += "  ";
        }
        else
        {
            Console.Write("|-");
            indent += "| ";
        }
        Console.WriteLine($"{Syntax.TokenData} - {Syntax.SyntaxType?.GetType().Name ?? "Invalid"} - Matched: {Syntax.IsMatch}");

        for (int i = 0; i < Count; i++)
        {
            this[i].PrintPretty(indent, i == Count - 1);
        }
    }
}
