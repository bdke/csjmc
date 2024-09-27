using JMC.Parser;

namespace JMC;

internal class Program
{
    private static int Main(string[] args)
    {
        var text = File.ReadAllText("test.jmc");
        var t = new JMCTokenizer(text);
        using var builder = JMCSyntax.GetCoreBuilder();
        using var parser = new JMCParser(t, builder);
        var tree = parser.Parse(out var errors);

        t = new JMCTokenizer(text);
        var tokens = t.Tokenize();
        Console.WriteLine(string.Join('\n', tokens));
        tree.PrintPretty();
        Console.WriteLine(string.Join('\n', errors));
        return 0;
    }
}