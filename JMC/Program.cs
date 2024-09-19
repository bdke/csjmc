using JMC.Mcdoc.Parser;
using JMC.Parser.Command.Datas;

namespace JMC;

internal class Program
{
    private static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Run();
        }
        else if (args[0] == "db")
        {
        }
        return 0;
    }

    public static void Run()
    {
        var c = new TypedNumber();
        var result = c.Parse("-456.5b", out var passedPos);
    }
}