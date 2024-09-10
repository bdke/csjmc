using JMC.Parser.Command.Argument.Helper;
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
        MinecraftDbContext.Init();
        _ = CommandValueParser.ParseBlock("barrel[facing=down]", out _);
        _ = CommandValueParser.ParseBlock("barrel[facing=down]", out _);
    }
}