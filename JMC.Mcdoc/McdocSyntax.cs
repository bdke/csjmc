namespace JMC.Mcdoc;
internal abstract class McdocSyntax
{
    public abstract bool Parse(ReadOnlySpan<char> text, out int passedPos);

}