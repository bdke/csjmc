using JMC.Parser;
using sly.lexer;
using sly.parser.generator;

namespace JMC;

internal class Program
{
    private static int Main(string[] args)
    {
        var text = File.ReadAllText("test.jmc");
        var lexerBuiltResult = LexerBuilder.BuildLexer<TokenType>();
        if (lexerBuiltResult.IsError)
        {
            var errors = lexerBuiltResult.Errors;
            errors.ForEach((e) => Console.WriteLine(e.Message));
            return 1;
        }
        var lexer = lexerBuiltResult.Result;
        
        var parserBuilder = new ParserBuilder<TokenType, JMCToken>();
        var parserBuiltResult = parserBuilder.BuildParser(new JMCParser(), ParserType.EBNF_LL_RECURSIVE_DESCENT, "program", ParserBuilderAction, lexer.LexerPostProcess);
        if (parserBuiltResult.IsError)
        {
            var errors = parserBuiltResult.Errors;
            errors.ForEach((e) => Console.WriteLine(e.Message));
            return 1;
        }
        var parser = parserBuiltResult.Result;
        return 0;
    }

    private static void ParserBuilderAction(TokenType tokenType, LexemeAttribute attr, GenericLexer<TokenType> lexer)
    {
    }
}