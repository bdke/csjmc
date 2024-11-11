namespace JMC.Parser;
public sealed class JMCTranspiler(IEnumerable<JMCExpression> roots, IEnumerable<JMCFileDetail> fileDetails)
{
    private readonly ReadOnlyMemory<JMCExpression> _roots = new(roots.ToArray());
    private readonly ReadOnlyMemory<JMCFileDetail> _fileDetails = new(fileDetails.ToArray());

    public ReadOnlySpan<JMCFileDetail> FileDetails => _fileDetails.Span;
    public ReadOnlySpan<JMCExpression> Roots => _roots.Span;

}
