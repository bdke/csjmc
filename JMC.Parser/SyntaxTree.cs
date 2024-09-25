namespace JMC.Parser;
public class SyntaxTree : List<SyntaxNode>
{
    public void PrintPretty()
    {
        foreach (SyntaxNode node in this)
        {
            node.PrintPretty("", true);
        }
    }
}
