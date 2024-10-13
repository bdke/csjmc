namespace JMC.Parser;
public sealed class SyntaxTree(BaseRule rootRule)
{
    public SyntaxNode RootNode { get; private set; } = new(rootRule);
}
