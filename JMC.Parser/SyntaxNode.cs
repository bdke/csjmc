namespace JMC.Parser;
public sealed class SyntaxNode(BaseRule rule)
{
    public List<SyntaxNode> Children { get; private set; } = [];
    public BaseRule SyntaxRule => rule;
}
