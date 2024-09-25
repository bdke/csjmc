using System.Collections;
using System.Xml.Linq;

namespace JMC.Parser;

public class SyntaxNode(TokenData data) : List<SyntaxNode>
{
    public TokenData Data => data;

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
        Console.WriteLine(Data);

        for (int i = 0; i < this.Count; i++)
            this[i].PrintPretty(indent, i == this.Count - 1);
    }
}
