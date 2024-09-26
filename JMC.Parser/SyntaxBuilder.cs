using JMC.Parser.Helpers;
using JMC.Parser.Models;
using JMC.Parser.Types;

namespace JMC.Parser;
public sealed class SyntaxBuilder : IDisposable
{
    private readonly List<BaseSyntaxType> buildingStatement = [];
    public List2D<BaseSyntaxType> Statements { get; private set; } = [];

    public SyntaxBuilder Next(params BaseSyntaxType[] types)
    {
        List<BaseSyntaxType> tList = [.. types];
        buildingStatement.AddRange(tList);
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
        var clone = new List<BaseSyntaxType>(buildingStatement);
        Statements.Add(clone);
        buildingStatement.Clear();
        return clone;
    }

    public List2D<BaseSyntaxType> Build()
    {
        Statements.RemoveAll(v => v == null);
        return Statements;
    }

    void IDisposable.Dispose()
    {
        buildingStatement.Clear();
        Statements.Clear();
    }
}
