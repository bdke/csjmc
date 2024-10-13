using Antlr4.Runtime;
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
        var tokenStream = new CommonTokenStream(lexer);
        foreach (var token in lexer.GetAllTokens())
        {
            Console.WriteLine($"{token.Type} {JMCLexer.DefaultVocabulary.GetSymbolicName(token.Type),-15} '{token.Text}' {token.Line} {token.Column}");
        }
        Console.WriteLine($"Used {watch.ElapsedMilliseconds} ms");
        return 0;
    }
}