using Antlr4.Runtime;
using JMC.Parser;
using JMC.Parser.grammars;
using System.Diagnostics;

namespace JMC;

internal class Program
{
    private static int Main(string[] args)
    {
        var text = File.ReadAllText("test.jmc");
        var watch = Stopwatch.StartNew();
        var inputStream = new AntlrInputStream(text);
        var lexer = new JMCLexer(inputStream);
        var commonTokenStream = new CommonTokenStream(lexer);
        var parser = new JMCParser(commonTokenStream)
        {
            BuildParseTree = true
        };
        parser.AddErrorListener(new JMCErrorListener());
        var entry = parser.program();
        var visitor = new JMCVisitor();
        visitor.Visit(entry);
        watch.Stop();
        foreach (var token in commonTokenStream.GetTokens())
        {
            Console.WriteLine($"{JMCLexer.DefaultVocabulary.GetSymbolicName(token.Type),-15} '{token.Text}' {token.Line} {token.Column}");
        }
        Console.WriteLine(entry.ToStringTree(parser));
        Console.WriteLine($"Used {watch.ElapsedMilliseconds} ms");
        return 0;
    }
}