using JMC.Parser;
using JMC.Parser.Types;

namespace JMC;

internal class Program
{
    private static int Main(string[] args)
    {
        var t = new JMCTokenizer(File.ReadAllText("test.jmc"));
        var datas = t.Tokenize();
        Console.WriteLine(string.Join('\n', datas));
        using var builder = Register();
        var parser = new JMCParser(builder);
        var tree = parser.Parse(datas);
        tree.PrintPretty();
        return 0;
    }

    public static SyntaxBuilder Register()
    {
        var builder = new SyntaxBuilder();

        builder
            .Next(new Keyword("import"))
            .Next(new Parser.Types.String())
            .End()
            .Create();
        builder
            .Next(new Keyword("if"))
            .Next(new Condition())
            .Block()
            .Create();
        builder
            .Next(new Keyword("function"))
            .Next(new Word())
            .Next(new Parenthesis())
            .Block()
            .Create();

        return builder;
    }
}