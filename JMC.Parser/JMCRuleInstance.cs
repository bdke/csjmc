using JMC.Parser.Helper;
using sly.lexer;
using sly.parser.generator;
using sly.parser.parser;
using System.Collections.Immutable;

namespace JMC.Parser;

[ParserRoot("program")]
public sealed class JMCRuleInstance
{
    private const string END = $"{nameof(TokenType.End)}[d]";
    private const string IDENTIFIER = nameof(TokenType.Identifier);
    private const string DOT = $"{nameof(TokenType.Dot)}[d]";
    private const string LPAREN = $"{nameof(TokenType.ParenStart)}[d]";
    private const string RPAREN = $"{nameof(TokenType.ParenEnd)}[d]";
    private const string LBLOCK = $"{nameof(TokenType.BlockStart)}[d]";
    private const string LBLOCK_KEEP = $"{nameof(TokenType.BlockStart)}";
    private const string RBLOCK = $"{nameof(TokenType.BlockEnd)}[d]";
    private const string COMMA = $"{nameof(TokenType.Comma)}[d]";

    private const string STRING_VALUE = $"{nameof(TokenType.StringValue)}";
    private const string STRING_START = $"{STRING_START_KEEP}[d]";
    private const string STRING_START_KEEP = $"{nameof(TokenType.StartQuote)}";
    private const string STRING_END = $"{nameof(TokenType.EndQuote)}[d]";

    private const string COLON = $"{nameof(TokenType.Colon)}[d]";

    private const string NORMAL_ARG = "NormalArg";
    private const string NAMED_ARG = "NamedArg";
    private const string ROOT_ARG = "RootArg";

    private readonly JMCFileDetail fileDetail = new();
    public JMCFileDetail FileDetail => fileDetail;

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
    [Production("statement: commandBlock")]
    public static JMCExpression Statement(JMCExpression exp)
    {
        return exp;
    }

    #region Statements
    [Production($"block: {nameof(TokenType.BlockStart)} statement* {RBLOCK}")]
    public static JMCExpression Block(Token<TokenType> lBlock, List<JMCExpression> statements)
    {
        return new()
        {
            Position = lBlock.Position,
            SubExpressions = [.. statements],
            Value = "Block"
        };
    }

    [Production($"class: {nameof(TokenType.ClassKeyword)} namespace {LBLOCK} [function|class]* {RBLOCK}")]
    public static JMCExpression Class(Token<TokenType> keyword, JMCExpression funcName, List<JMCExpression> expressions)
    {
        return expressions.Count == 0
            ? JMCExpression.Empty
            : new()
            {
                Position = keyword.Position,
                SubExpressions = [.. expressions],
                TokenType = keyword.TokenID,
                Value = funcName.Value
            };
    }

    [Production($"variableStatement: IDENTIFIER assign STRING {END}")]
    [Production($"variableStatement: variable assign al {END}")]
    [Production($"variableStatement: variable cmdAssign command")]
    public static JMCExpression VariableStatement(JMCExpression variable, JMCExpression assign, JMCExpression als)
    {
        return new()
        {
            Position = variable.Position,
            TokenType = variable.TokenType,
            SubExpressions = [assign, als],
            Value = variable.Value
        };
    }

    [Production($"function: {nameof(TokenType.FunctionKeyword)}[d] namespace {LPAREN} funcParams? {RPAREN} block")]
    public static JMCExpression FunctionStatement(JMCExpression funcName, ValueOption<JMCExpression> funcParams, JMCExpression block)
    {
        return new()
        {
            Position = funcName.Position,
            SubExpressions = [funcParams.Match(v => v, () => JMCExpression.Empty), block],
            TokenType = TokenType.FunctionKeyword,
            Value = funcName.Value,
        };
    }

    [Production($"funcCall: namespace {LPAREN} funcArgs? {RPAREN} {END}")]
    public static JMCExpression FunctionCallStatement(JMCExpression funcName, ValueOption<JMCExpression> funcArgs)
    {
        return new()
        {
            Position = funcName.Position,
            SubExpressions = [funcArgs.Match(v => v, () => JMCExpression.Empty)],
            Value = funcName.Value,
            TokenType = funcName.TokenType
        };
    }

    [Production($"commandBlock: {nameof(TokenType.CommandKeyword)}[d] {nameof(TokenType.BlockStart)} command* {RBLOCK}")]
    public static JMCExpression CommadBlock(Token<TokenType> token, List<JMCExpression> commands)
    {
        return new()
        {
            Position = token.Position,
            Value = "CommandBlock",
            SubExpressions = [.. commands]
        };
    }

    #endregion

    #region Functions
    [Production($"lambdaFunction: {LPAREN} funcParams? {RPAREN} {nameof(TokenType.Arrow)}[d] block")]
    public static JMCExpression LambdaFunction(ValueOption<JMCExpression> funcParams, JMCExpression block)
    {
        JMCExpression funcParamsValue = funcParams.Match(v => v, () => JMCExpression.Empty);

        return new()
        {
            Position = funcParamsValue.Position,
            SubExpressions = [funcParamsValue, block],
            Value = "LambdaFunction"
        };
    }

    [Production($"namespace: {IDENTIFIER} ({DOT} {IDENTIFIER})*")]
    public static JMCExpression Namespace(Token<TokenType> left, List<Group<TokenType, JMCExpression>> right)
    {
        string value = string.Join('.', right.Select(v => v.Token(IDENTIFIER).Value));
        value = !string.IsNullOrEmpty(value) ? $"{left.Value}.{value}" : left.Value;

        return new()
        {
            Position = left.Position,
            Value = value,
            TokenType = TokenType.Namespace
        };
    }

    [Production($"funcParams: {IDENTIFIER} ({COMMA} {IDENTIFIER})*")]
    public static JMCExpression FuncParams(Token<TokenType> left, List<Group<TokenType, JMCExpression>> right)
    {
        IEnumerable<JMCExpression> allParams = right
            .Select(v => v.Token(IDENTIFIER))
            .Concat([left])
            .Select(v => new JMCExpression()
            {
                Position = v.Position,
                TokenType = v.TokenID,
                Value = v.Value,
            });

        return new()
        {
            Position = left.Position,
            Value = left.Value,
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
            Position = funcArg.Position,
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
            Position = left.Position,
            SubExpressions = [.. values],
            Value = NORMAL_ARG
        };
    }

    [Production($"funcNameArg: {IDENTIFIER} {nameof(TokenType.Colon)}[d] value")]
    public static JMCExpression FuncNamedArg(Token<TokenType> paramName, JMCExpression value)
    {
        return new()
        {
            Position = paramName.Position,
            SubExpressions = [value],
            Value = paramName.Value
        };
    }

    [Production($"funcNameArgs: funcNameArg ({COMMA} funcNameArg)*")]
    public static JMCExpression FuncNamedArgs(JMCExpression left, List<Group<TokenType, JMCExpression>> right)
    {
        IEnumerable<JMCExpression> rightValues = right.Select(v => v.Value("funcNameArg"));
        IEnumerable<JMCExpression> values = new JMCExpression[] { left }.Concat(rightValues);

        return new()
        {
            Position = left.Position,
            SubExpressions = [.. values],
            Value = NAMED_ARG
        };
    }

    #endregion Functions

    #region AL
    [Production($"al: als (operand als)*")]
    public static JMCExpression AL(JMCExpression left, List<Group<TokenType, JMCExpression>> right)
    {
        IEnumerable<JMCExpression> subRules = right.Select(g =>
        {
            JMCExpression operand = g.Value("operand");
            JMCExpression als = g.Value("als");
            return new JMCExpression()
            {
                Position = operand.Position,
                Value = operand.Value,
                SubExpressions = [als],
                TokenType = operand.TokenType
            };
        });
        return new()
        {
            Position = left.Position,
            Value = left.Value,
            SubExpressions = [.. subRules],
            TokenType = left.TokenType
        };
    }

    [Production("als: number")]
    [Production("als: variable")]
    [Production("als: unaryExp")]
    [Production("als: IDENTIFIER")]
    public static JMCExpression ALS(JMCExpression als)
    {
        return als;
    }

    [Production($"unaryExp: [{nameof(TokenType.Plus)}|{nameof(TokenType.Minus)}]? {LPAREN} al {RPAREN}")]
    public static JMCExpression Unary(Token<TokenType> prefix, JMCExpression als)
    {
        return !prefix.IsEmpty ? new()
        {
            Position = prefix.Position,
            SubExpressions = [als],
            Value = prefix.Value,
            TokenType = prefix.TokenID
        } : als;
    }

    [Operand]
    [Production($"operand: {nameof(TokenType.Plus)}")]
    [Production($"operand: {nameof(TokenType.Minus)}")]
    [Production($"operand: {nameof(TokenType.Divide)}")]
    [Production($"operand: {nameof(TokenType.Multiply)}")]
    [Production($"operand: {nameof(TokenType.Remainder)}")]
    public static JMCExpression Operand(Token<TokenType> token)
    {
        return new()
        {
            Position = token.Position,
            TokenType = token.TokenID,
            Value = token.Value
        };
    }
    #endregion

    #region Commands
    [Production($"command: cmdKeyword cmdArg* {END}")]
    public static JMCExpression Command(JMCExpression root, List<JMCExpression> args)
    {
        root.SubExpressions = [.. args];

        return root;
    }

    [Production("cmdArg: vec2")]
    [Production("cmdArg: vec3")]
    [Production("cmdArg: cmdKeyword")]
    [Production("cmdArg: selector")]
    public static JMCExpression CommandArgument(JMCExpression exp) => exp;

    [Production($"posI: valueSign? number")]
    public static JMCExpression PosI(ValueOption<JMCExpression> sign, JMCExpression exp)
    {
        JMCExpression value = sign.Match(v => v, () => JMCExpression.Empty);
        exp.SubExpressions = [value];
        return value;
    }
    [Production($"posF: '^' valueSign? number")]
    [Production($"posR: '~' valueSign? number")]
    public static JMCExpression PosFR(Token<TokenType> s, ValueOption<JMCExpression> sign, JMCExpression i)
    {
        JMCExpression exp = s.ToExpression();
        JMCExpression signValue = sign.Match(v => v, () => JMCExpression.Empty);

        i.SubExpressions = [signValue];

        exp.Value = $"{s.Value}{signValue.Value}{i.Value}";
        exp.SubExpressions = [i];

        return exp;
    }

    [Production($"vec2: posI posI")]
    [Production($"vec2: posR posR")]
    [Production($"vec2: posF posF")]
    public static JMCExpression Vec2(JMCExpression e1, JMCExpression e2)
    {
        return new()
        {
            Position = e1.Position,
            SubExpressions = [e1, e2],
            Value = $"{e1.Value} {e2.Value}"
        };
    }

    [Production($"vec3: posI posI posI")]
    [Production($"vec3: posR posR posR")]
    [Production($"vec3: posF posF posF")]
    public static JMCExpression Vec3(JMCExpression e1, JMCExpression e2, JMCExpression e3)
    {
        return new()
        {
            Position = e1.Position,
            SubExpressions = [e1, e2, e3],
            Value = $"{e1.Value} {e2.Value} {e3.Value}"
        };
    }

    [Production($"quotedProps: {nameof(TokenType.ListStart)}[d] properties? {nameof(TokenType.ListEnd)}[d]")]
    public static JMCExpression QuotedProperties(ValueOption<JMCExpression> props) => props.Match(v => v, () => JMCExpression.Empty);

    [Production($"properties: property ({COMMA} property)*")]
    public static JMCExpression Properties(JMCExpression left, List<Group<TokenType, JMCExpression>> right)
    {
        var rValues = right.Select(v => v.Value(0));
        ImmutableArray<JMCExpression> values = [left, .. rValues];

        return new()
        {
            Position = left.Position,
            SubExpressions = values,
            Value = "Properties"
        };
    }

    [Production($"property: {IDENTIFIER} {nameof(TokenType.Assign)}[d] cmdValue")]
    public static JMCExpression Property(Token<TokenType> key, JMCExpression value)
    {
        var exp = key.ToExpression();
        exp.SubExpressions = [value];
        return exp;
    }

    [Production($"cmdValue: bool")]
    [Production($"cmdValue: number")]
    public static JMCExpression CommandValue(JMCExpression exp) => exp;

    [Production($"cmdValue: {IDENTIFIER}")]
    public static JMCExpression CommandValue(Token<TokenType> token) => token.ToExpression();

    [Production($"cmdKeyword: {IDENTIFIER}")]
    public static JMCExpression CommandKeyword(Token<TokenType> token) => token.ToExpression();

    [Production($"jsonValue: jsonObject")]
    [Production($"jsonValue: jsonList")]
    [Production($"jsonValue: bool")]
    [Production($"jsonValue: number")]
    [Production($"jsonValue: STRING")]
    public static JMCExpression JsonValue(JMCExpression exp) => exp;

    [Production($"jsonObject: {LBLOCK_KEEP} ([STRING|IDENTIFIER] {COLON} jsonValue)* {RBLOCK}")]
    public static JMCExpression JsonObject(Token<TokenType> lBlock, List<Group<TokenType, JMCExpression>> values)
    {
        var exps = values.Select(v => new JMCExpression()
        {
            Position = v.Value(0).Position,
            Value = v.Value(0).Value,
            SubExpressions = [v.Value(1)]
        }).ToImmutableArray();

        return new()
        {
            Position = lBlock.Position,
            SubExpressions = exps,
            Value = "JsonObject"
        };
    }

    [Production($"jsonList: {nameof(TokenType.ListStart)} jsonValue* {nameof(TokenType.ListEnd)}[d]")]
    public static JMCExpression JsonList(Token<TokenType> token, List<JMCExpression> values)
    {
        return new()
        {
            Position = token.Position,
            SubExpressions = [.. values],
            Value = "JsonList"
        };
    }

    #endregion

    #region values
    [Production($"assign: [" +
        $"{nameof(TokenType.Assign)}|{nameof(TokenType.CompareAssign)}|{nameof(TokenType.DivideAssign)}|" +
        $"{nameof(TokenType.MinusAssign)}|{nameof(TokenType.MultiplyAssign)}|{nameof(TokenType.NullColesleAssign)}|" +
        $"{nameof(TokenType.PlusAssign)}|{nameof(TokenType.RemainderAssign)}" +
        $"]")]
    public static JMCExpression Assign(Token<TokenType> token)
    {
        return new()
        {
            Position = token.Position,
            TokenType = token.TokenID,
            Value = token.Value
        };
    }

    [Production($"cmdAssign: {nameof(TokenType.Assign)}")]
    [Production($"cmdAssign: {nameof(TokenType.BooleanAssign)}")]
    public static JMCExpression CommandAssign(Token<TokenType> token) => token.ToExpression();

    [Production($"number: [{nameof(TokenType.Int)}|{nameof(TokenType.Double)}]")]
    public static JMCExpression Number(Token<TokenType> number)
    {
        return new()
        {
            Position = number.Position,
            TokenType = number.TokenID,
            Value = number.TokenID == TokenType.Int ? number.IntValue : number.DoubleValue,
        };
    }

    [Production($"bool: [{nameof(TokenType.True)}|{nameof(TokenType.False)}]")]
    public static JMCExpression Bool(Token<TokenType> b)
    {
        return new()
        {
            Position = b.Position,
            TokenType = b.TokenID,
            Value = b.Value
        };
    }

    [Production($"variable: {nameof(TokenType.DollarSign)} {IDENTIFIER}")]
    public JMCExpression Variable(Token<TokenType> dollarSign, Token<TokenType> identifier)
    {
        string value = identifier.Value;

        _ = fileDetail.Variables.Add(value);

        return new()
        {
            Position = dollarSign.Position,
            TokenType = dollarSign.TokenID,
            Value = value
        };
    }

    [Production($"variable: {nameof(TokenType.DollarSign)} {LBLOCK} {IDENTIFIER}* {RBLOCK}")]
    public static JMCExpression Variable(Token<TokenType> dollarSign, List<Token<TokenType>> identifiers)
    {
        var exps = identifiers.Select(v => v.ToExpression());
        return new()
        {
            Position = dollarSign.Position,
            TokenType = dollarSign.TokenID,
            Value = string.Join(",", identifiers.Select(v => v.Value))
        };
    }

    [Production($"defaultString: {STRING_START_KEEP} {STRING_VALUE}* {STRING_END}")]
    public static JMCExpression DefaultString(Token<TokenType> start, List<Token<TokenType>> strValues)
    {
        var exp = start.ToExpression();
        var values = strValues.Select(v => v.ToExpression());
        exp.SubExpressions = [.. values];
        return exp;
    }

    [Production($"STRING: defaultString")]
    public static JMCExpression NormalString(JMCExpression exp) => exp;

    [Production($"STRING: {nameof(TokenType.Deref)} defaultString")]
    public static JMCExpression ColorString(Token<TokenType> token, JMCExpression strExp)
    {
        var exp = token.ToExpression();
        exp.SubExpressions = [strExp];
        return exp;
    }

    [Production($"valueSign: {nameof(TokenType.Plus)}")]
    [Production($"valueSign: {nameof(TokenType.Minus)}")]
    public static JMCExpression ValueSign(Token<TokenType> value)
    {
        return value.ToExpression();
    }

    [Production("value: lambdaFunction")]
    [Production("value: number")]
    [Production("value: variable")]
    [Production("value: STRING")]
    public static JMCExpression Value(JMCExpression expression)
    {
        return expression;
    }

    [Production($"selector: {nameof(TokenType.SelectorSelf)} quotedProps?")]
    [Production($"selector: {nameof(TokenType.SelectorAllPlayers)} quotedProps?")]
    [Production($"selector: {nameof(TokenType.SelectorAllEntities)} quotedProps?")]
    [Production($"selector: {nameof(TokenType.SelectorNearest)} quotedProps?")]
    [Production($"selector: {nameof(TokenType.SelectorRandomPlayer)} quotedProps?")]
    public static JMCExpression Selector(Token<TokenType> start, ValueOption<JMCExpression> properties)
    {
        var exp = start.ToExpression();
        exp.SubExpressions = [properties.Match(v => v, () => JMCExpression.Empty)];
        return exp;
    }

    [Production($"IDENTIFIER: {IDENTIFIER}")]
    public static JMCExpression Identifier(Token<TokenType> token) => token.ToExpression();

    #endregion
}