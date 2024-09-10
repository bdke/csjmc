using JMC.Shared;

namespace JMC.Parser.JMC;

public class CommandStatement(string rawString) : Statement, IInitializeClass
{
    public static void Init()
    {
    }
}