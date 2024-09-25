using JMC.Parser.Helpers;
using JMC.Parser.Types;

namespace JMC.Parser;
public sealed class SyntaxBuilder : IDisposable
{
    private readonly List<BaseSyntaxType> registerSyntaxes = [];
    public List2D<BaseSyntaxType> BuiltSyntaxes { get; private set; } = [];

    public SyntaxBuilder Next(params BaseSyntaxType[] types)
    {
        List<BaseSyntaxType> tList = [.. types];
        registerSyntaxes.AddRange(tList);
        return this;
    }

    public SyntaxBuilder End()
    {
        return Next(new End());
    }

    public SyntaxBuilder Block() 
    { 
        return Next(new Block()); 
    }

    public List<BaseSyntaxType> Create()
    {
        var clone = new List<BaseSyntaxType>(registerSyntaxes);
        BuiltSyntaxes.Add(clone);
        registerSyntaxes.Clear();
        return clone;
    }

    void IDisposable.Dispose()
    {
        registerSyntaxes.Clear();
        BuiltSyntaxes.Clear();
    }
}
