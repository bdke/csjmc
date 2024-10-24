using JMC.Parser;
using sly.lexer;
using sly.parser.generator;

namespace JMC;

internal class Program
{
    private static int Main(string[] args)
    {
        var text = File.ReadAllText("test.jmc");
        var lexerBuilder = LexerBuilder.BuildLexer<TokenType>();
        if (lexerBuilder.IsError)
        {
            lexerBuilder.Errors.ForEach(Console.WriteLine);
            return 1;
        }
        var lexer = lexerBuilder.Result;
        var tokenizeResult = lexer.Tokenize(text);
        if (tokenizeResult.IsError)
        {
            Console.WriteLine(tokenizeResult.Error);
            return 1;
        }
        var tokens = tokenizeResult.Tokens;
        var parser = new JMCParser(tokens, JMCRuleBuilder.DefaultRules);

        return 0;
    }
}