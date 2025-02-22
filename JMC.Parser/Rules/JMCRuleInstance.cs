using JMC.Parser.Helper;
using sly.lexer;
using sly.parser.generator;
using sly.parser.parser;
using System.Collections.Immutable;
using static JMC.Parser.Rules.RuleConstants;

namespace JMC.Parser.Rules;

[ParserRoot("program")]
public sealed partial class JMCRuleInstance
{
    public JMCFileDetail FileDetail { get; } = new();

    public static List<Token<TokenType>> LexemesPostProcess(List<Token<TokenType>> tokens)
    {
        return tokens;
    }

    [Production("program: statement*")]
    public static JMCExpression Program(List<JMCExpression> expressions)
    {
        return new()
        {
            Position = new(0, 0),
            SubExpressions = [.. expressions],
            Value = "Root"
        };
    }

    [Production("statement: class")]
    [Production("statement: variableStatement")]
    [Production("statement: function")]
    [Production("statement: funcCall")]
    [Production("statement: import")]
    [Production("statement: ifStatement")]
    [Production("statement: whileStatement")]
    [Production("statement: doWhileStatement")]
    [Production("statement: switchStatement")]
    public static JMCExpression Statement(JMCExpression exp)
    {
        return exp;
    }

    #region Import
    [Production($"importAlias: {nameof(TokenType.AsKeyword)} {nameof(TokenType.ImportContent)}")]
    public static JMCExpression ImportAlias(Token<TokenType> keyword, Token<TokenType> content)
    {
        var exp = keyword.ToExpression();
        exp.SubExpressions = [content.ToExpression()];
        return exp;
    }

    [Production($"importAlias: {nameof(TokenType.OfKeyword)} {nameof(TokenType.ImportContent)} ({COMMA} {nameof(TokenType.ImportContent)})*")]
    public static JMCExpression ImportAlias(Token<TokenType> keyword, Token<TokenType> content, List<Group<TokenType, JMCExpression>> contents)
    {
        var exp = keyword.ToExpression();
        var subExps = new JMCExpression[] { content.ToExpression() }.Concat(contents.Select(v => v.Token(0).ToExpression()));
        exp.SubExpressions = [.. subExps];
        return exp;
    }

    [Production($"importContent: {nameof(TokenType.ImportContent)} ({nameof(TokenType.ImportPathSeperator)}[d] {nameof(TokenType.ImportContent)})*")]
    public static JMCExpression ImportContent(Token<TokenType> left, List<Group<TokenType, JMCExpression>> right)
    {
        var rightExps = right.Select(v => v.Token(0).ToExpression());
        var exps = new JMCExpression[] { left.ToExpression() }.Concat(rightExps);

        return new()
        {
            SubExpressions = [.. exps],
            Value = IMPORT_PATH
        };
    }

    [Production($"import: {nameof(TokenType.ImportKeyword)} importContent? importAlias? {nameof(TokenType.EndImport)}[d]")]
    public static JMCExpression ImportExpression(Token<TokenType> keyword, ValueOption<JMCExpression> content, ValueOption<JMCExpression> alias)
    {
        var exp = content.Match(v => v, () => JMCExpression.Empty);
        ImmutableArray<JMCExpression> exps = exp.HasValue ? [exp, alias.Match(v => v, () => JMCExpression.Empty)] : [];
        var value = exps.IsDefaultOrEmpty ? string.Empty : string.Join('/', exps.Select(v => v.Value));

        return new()
        {
            Position = keyword.Position,
            SubExpressions = exps,
            TokenType = keyword.TokenID,
            Value = value
        };
    }

    [Production($"import: {nameof(TokenType.CodeKeyword)} {nameof(TokenType.ImportKeyword)} importContent? importAlias? {nameof(TokenType.EndImport)}[d]")]
    public static JMCExpression ImportExpression
        (Token<TokenType> codeKeyword, 
        Token<TokenType> importKeyword, 
        ValueOption<JMCExpression> content, 
        ValueOption<JMCExpression> alias)
    {
        var importContent = content.Match(v => v, () => JMCExpression.Empty);
        ImmutableArray<JMCExpression> splitImportContents = importContent.HasValue 
            ? [importContent, alias.Match(v => v, () => JMCExpression.Empty)] 
            : [];
        var contentValue = splitImportContents[0].SubExpressions.IsDefaultOrEmpty 
            ? string.Empty 
            : string.Join('/', splitImportContents[0].SubExpressions.Select(v => v.Value));
        var codeExp = codeKeyword.ToExpression();
        var importExp = importKeyword.ToExpression();
        importExp.Value = contentValue;
        importExp.SubExpressions = splitImportContents;
        codeExp.SubExpressions = [importExp];
        return codeExp;
    }
    #endregion

    #region Functions
    [Production($"lambdaFunction: {LPAREN} funcParams? {RPAREN} {nameof(TokenType.Arrow)}[d] block")]
    public static JMCExpression LambdaFunction(ValueOption<JMCExpression> funcParams, JMCExpression block)
    {
        JMCExpression funcParamsValue = funcParams.Match(v => v, () => JMCExpression.Empty);

        return new()
        {
            SubExpressions = [funcParamsValue, block],
            Value = LAMBDA_FUNCTION
        };
    }

    [Production($"funcParams: {IDENTIFIER} ({COMMA} {IDENTIFIER})*")]
    public static JMCExpression FuncParams(Token<TokenType> left, List<Group<TokenType, JMCExpression>> right)
    {
        IEnumerable<JMCExpression> additionalParams = right
            .Select(v => v.Token(IDENTIFIER).ToExpression());
        IEnumerable<JMCExpression> allParams = new JMCExpression[] { left.ToExpression() }.Concat(additionalParams);

        return new()
        {
            Value = FUNC_PARAMS,
            SubExpressions = [.. allParams]
        };
    }

    [Production($"funcArgs: funcArg ({COMMA} funcNameArgs)?")]
    public static JMCExpression FuncArgs(JMCExpression funcArg, ValueOption<Group<TokenType, JMCExpression>> namedArgs)
    {
        Group<TokenType, JMCExpression> nArgsValue = namedArgs.Match(v => v, () => null!);
        ImmutableArray<JMCExpression> values = nArgsValue == null ? [funcArg] : [funcArg, nArgsValue.Value(0)];

        return new()
        {
            SubExpressions = values,
            Value = ROOT_ARG
        };
    }

    [Production($"funcArgs: funcNameArgs")]
    public static JMCExpression FuncArgs(JMCExpression funcNameArgs)
    {
        return funcNameArgs;
    }

    [Production($"funcArg: value ({COMMA} value)*")]
    public static JMCExpression FuncArg(JMCExpression left, List<Group<TokenType, JMCExpression>> right)
    {
        IEnumerable<JMCExpression> values = new JMCExpression[] { left }.Concat(right.SelectMany(v => v.Items.Select(v => v.Value)));

        return new()
        {
            SubExpressions = [.. values],
            Value = NORMAL_ARG
        };
    }

    [Production($"funcNameArg: {IDENTIFIER} {COLON} value")]
    public static JMCExpression FuncNamedArg(Token<TokenType> paramName, JMCExpression value)
    {
        var exp = paramName.ToExpression();
        exp.SubExpressions = [value];
        return exp;
    }

    [Production($"funcNameArgs: funcNameArg ({COMMA} funcNameArg)*")]
    public static JMCExpression FuncNamedArgs(JMCExpression left, List<Group<TokenType, JMCExpression>> right)
    {
        IEnumerable<JMCExpression> rightValues = right.Select(v => v.Value("funcNameArg"));
        IEnumerable<JMCExpression> values = new JMCExpression[] { left }.Concat(rightValues);

        return new()
        {
            SubExpressions = [.. values],
            Value = NAMED_ARG
        };
    }

    [Production($"enclosedFuncArgs: {LPAREN} funcArgs? {RPAREN}")]
    public static JMCExpression EnclosedFuncNameAgs(ValueOption<JMCExpression> funcArgs)
    {
        return funcArgs.GetValueOrEmpty();
    }

    #endregion Functions

    #region AL

    [Production($"al: valueSign? als (operand als)*")]
    public static JMCExpression AL(ValueOption<JMCExpression> prefix, JMCExpression left, List<Group<TokenType, JMCExpression>> right)
    {
        IEnumerable<JMCExpression> subExps = right.Select(g =>
        {
            JMCExpression operand = g.Value(0);
            JMCExpression als = g.Value(1);
            operand.SubExpressions = [als];
            return operand;
        });

        JMCExpression pExp = prefix.Match(v => v, () => JMCExpression.Empty);
        pExp.SubExpressions = [left];

        IEnumerable<JMCExpression> exps = new JMCExpression[] { pExp }.Concat(subExps);

        return new()
        {
            Value = AL_ROOT,
            SubExpressions = [.. exps],
        };
    }

    [Production("als: IDENTIFIER")]
    [Production("als: variable")]
    [Production("als: unaryExp")]
    [Production("als: number")]
    [Production("als: funcCall")]

    [Production($"unaryExp: {LPAREN} al {RPAREN}")]
    public static JMCExpression Unary(JMCExpression al)
    {
        return al;
    }

    [Operand]
    [Production($"operand: {nameof(TokenType.Plus)}")]
    [Production($"operand: {nameof(TokenType.Minus)}")]
    [Production($"operand: {nameof(TokenType.Divide)}")]
    [Production($"operand: {nameof(TokenType.Multiply)}")]
    [Production($"operand: {nameof(TokenType.Remainder)}")]
    public static JMCExpression Operand(Token<TokenType> token)
    {
        return token.ToExpression();
    }
    #endregion


    #region Conditions


    [Production($"comparators: {COMPARATORS}")]
    [Production($"conditionOp: {CONDITION_OPERATORS}")]
    public static JMCExpression ConditionConstants(Token<TokenType> token)
    {
        return token.ToExpression();
    }

    [Production($"enclosedConditions: {LPAREN} conditions {RPAREN}")]
    public static JMCExpression EnclosedConditions(JMCExpression conditions)
    {
        return conditions;
    }

    [Production($"conditions: condition (conditionOp condition)*")]
    public static JMCExpression Conditions(JMCExpression condition, List<Group<TokenType, JMCExpression>> subConditions)
    {
        var root = JMCExpression.Empty;

        var subConValues = subConditions.SelectMany(v => new JMCExpression[] { v.Value(0), v.Value(1) });
        root.SubExpressions = [condition, .. subConValues];
        root.Value = "Conditions";

        return root;
    }

    [Production($"condition: value comparators value")]
    public static JMCExpression Condition(JMCExpression value, JMCExpression conditionOp, JMCExpression comparee)
    {
        var root = value;

        root.SubExpressions = [conditionOp, comparee];

        return root;
    }

    [Production($"condition: value")]
    public static JMCExpression Condition(JMCExpression value)
    {
        return value;
    }

    #endregion
}