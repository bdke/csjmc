namespace JMC.Parser.Models;
public class SyntaxTree : List<SyntaxNode>
{
    public void PrintPretty()
    {
        foreach (SyntaxNode node in this)
        {
            node.PrintPretty("", true);
        }
    }

    /// <summary>
    /// Add a child from a statement
    /// </summary>
    /// <param name="statement"></param>
    /// <returns>Root of the statement</returns>
    public SyntaxNode AddFromStatement(StatementParseResult statement)
    {
        Span<SyntaxParseResult> syntaxes = statement.IndividualResults.AsSpan();
        ref SyntaxParseResult opCode = ref syntaxes[0];
        SyntaxNode root = new(opCode);
        for (int i = 1; i < syntaxes.Length; i++)
        {
            ref SyntaxParseResult syntax = ref syntaxes[i];
            if (syntax == SyntaxParseResult.VALID_EXCCEED)
            {
                continue;
            }

            SyntaxNode node = new(syntax);
            root.Add(node);

            _ = node.TryExpand();
        }
        Add(root);
        return root;
    }

    public void ExpandAll()
    {
        foreach (SyntaxNode node in this)
        {
            node.TryExpand();
        }
    }
}
