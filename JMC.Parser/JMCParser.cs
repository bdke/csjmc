using sly.buildresult;
using sly.lexer;
using sly.parser;
using sly.parser.generator;
using System.Collections.Immutable;

namespace JMC.Parser;

public static class JMCParser
{
    private static Parser<TokenType, JMCExpression> Parser => CreateParser();
    private static readonly ILexer<TokenType> lexer = CreateLexer();

    private static Parser<TokenType, JMCExpression> CreateParser()
    {
        ParserBuilder<TokenType, JMCExpression> parserBuilder = new();
        BuildResult<Parser<TokenType, JMCExpression>> parserBuildResult = parserBuilder.BuildParser(new JMCRuleInstance(), ParserType.EBNF_LL_RECURSIVE_DESCENT, lexerPostProcess: JMCRuleInstance.LexemesPostProcess);
        if (parserBuildResult.IsError)
        {
            IEnumerable<InvalidProgramException> errors = parserBuildResult.Errors.Select(e => new InvalidProgramException(e.Message));
            throw new AggregateException("Initializtion Errors Occured", errors);
        }
        return parserBuildResult.Result;
    }

    private static ILexer<TokenType> CreateLexer()
    {
        BuildResult<ILexer<TokenType>> lexerBuiltResult = LexerBuilder.BuildLexer<TokenType>();
        if (lexerBuiltResult.IsError)
        {
            IEnumerable<InvalidProgramException> errors = lexerBuiltResult.Errors.Select(e => new InvalidProgramException(e.Message));
            throw new AggregateException("Initializtion Errors Occured", errors);
        }
        return lexerBuiltResult.Result;
    }

    public static LexicalError? TryGenerateTokens(string text, out TokenChannels<TokenType> tokens)
    {
        var lexResult = lexer.Tokenize(text);
        if (lexResult.IsError)
        {
            tokens = [];
            return lexResult.Error;
        }
        tokens = lexResult.Tokens;
        return null;
    }

    public static ParseResult TryParse(string text)
    {
        var parser = Parser;
        ParseResult<TokenType, JMCExpression> parseResult = parser.Parse(text);
        if (parseResult.IsError)
        {
            return new(parseResult.Errors, JMCExpression.Empty, null);
        }
        var instance = parser.Instance;
        if (instance is not JMCRuleInstance r)
        {
            throw new TypeAccessException($"{instance.GetType().Name} is not valid parser instance");
        }

        return new([], parseResult.Result, r);
    }

    public readonly struct ParseResult(IEnumerable<ParseError> errors, JMCExpression root, JMCRuleInstance? instance)
    {
        public readonly ImmutableArray<ParseError> Errors = [.. errors];
        public readonly JMCExpression Root = root;
        public readonly JMCRuleInstance? Instance = instance;

        public bool IsError => Instance == null;
    }
}
