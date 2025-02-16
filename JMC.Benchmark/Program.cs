using sly.parser;
using sly.parser.generator;

namespace JMC.Benchmark;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = new ParserBuilder<TokenType, string>();
        var buildResult = builder.BuildParser(new Rule(), ParserType.EBNF_LL_RECURSIVE_DESCENT, rootRule: "program");
        if (buildResult.IsError)
        {
            buildResult.Errors.ForEach(error => Console.WriteLine(error.Message));
            return;
        }
        var parser = buildResult.Result;
        var parseResult = parser.Parse("test = test; test =");
        if (parseResult.IsError)
        {
            parseResult.Errors.ForEach(error => Console.WriteLine(error.ErrorMessage));
            return;
        }
        Console.WriteLine(parseResult.Result);
    }
}
