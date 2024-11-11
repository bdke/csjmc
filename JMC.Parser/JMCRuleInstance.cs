using JMC.Parser.Helper;
using sly.lexer;
using sly.parser.generator;
using sly.parser.parser;
using System.Collections.Immutable;
using System.Text.Json;

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
    private const string LLIST = $"{LLIST_KEEP}[d]";
    private const string LLIST_KEEP = nameof(TokenType.ListStart);
    private const string RLIST = $"{nameof(TokenType.ListEnd)}[d]";
    private const string RBLOCK = $"{nameof(TokenType.BlockEnd)}[d]";
    private const string COMMA = $"{nameof(TokenType.Comma)}[d]";

    private const string STRING_VALUE = $"{nameof(TokenType.StringValue)}";
    private const string STRING_START = $"{STRING_START_KEEP}[d]";
    private const string STRING_START_KEEP = $"{nameof(TokenType.StartQuote)}";
    private const string STRING_END = $"{nameof(TokenType.EndQuote)}[d]";

    private const string COLON = $"{nameof(TokenType.Colon)}[d]";

    internal const string NORMAL_ARG = "NormalArg";
    internal const string NAMED_ARG = "NamedArg";
    internal const string ROOT_ARG = "RootArg";

    internal const string BLOCK = "Block";
    internal const string IMPORT_PATH = "ImportPath";

    internal const string LAMBDA_FUNCTION = "LambdaFunction";
    internal const string FUNC_PARAMS = "FuncParams";

    internal const string AL_ROOT = "AL";

    internal const string VEC2_COLLECTION = "Vec2";
    internal const string VEC3_COLLECTION = "Vec3";
    internal const string COMMAND_PROPERTIES = "Properties";

    internal const string COMMAND_JSON_OBJECT = "JsonObject";
    internal const string COMMAND_JSON_LIST = "JsonList";

    internal const string VALUE_STRING = "String";
    internal const string F_STRING_EXPRESSION = "FStringExpression";
    internal const string F_STRING = "FString";
    internal const string COLOR_STRING = "ColorString";
    internal const string COLOR_TAG = "ColorTag";

    internal const string ARRAY_ELEMS = "ArrayElems";
    internal const string ARRAY = "Array";

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
    [Production("statement: commandBlock")]
    [Production("statement: commandLine")]
    [Production("statement: import")]
    public static JMCExpression Statement(JMCExpression exp)
    {
        return exp;
    }

    #region Statements
    [Production($"block: {nameof(TokenType.BlockStart)} statement* {RBLOCK}")]
    public JMCExpression Block(Token<TokenType> lBlock, List<JMCExpression> statements)
    {
        return new()
        {
            Position = lBlock.Position,
            SubExpressions = [.. statements],
            Value = BLOCK
        };
    }

    [Production($"class: {nameof(TokenType.ClassKeyword)} namespace {LBLOCK} [function|class]* {RBLOCK}")]
    public static JMCExpression Class(Token<TokenType> keyword, JMCExpression funcName, List<JMCExpression> expressions)
    {
        return new()
        {
            Position = keyword.Position,
            SubExpressions = [.. expressions],
            TokenType = keyword.TokenID,
            Value = funcName.Value
        };
    }

    [Production($"variableStatement: IDENTIFIER assign value {END}")]
    [Production($"variableStatement: variable assign al {END}")]
    [Production($"variableStatement: variable cmdAssign command")]
    public static JMCExpression VariableStatement(JMCExpression variable, JMCExpression assign, JMCExpression als)
    {
        variable.SubExpressions = [assign, als];
        return variable;
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
        funcName.SubExpressions = [funcArgs.Match(v => v, () => JMCExpression.Empty)];
        return funcName;
    }

    [Production($"commandBlock: {nameof(TokenType.CommandKeyword)} {LBLOCK} command* {RBLOCK}")]
    public static JMCExpression CommadBlock(Token<TokenType> keyword, List<JMCExpression> commands)
    {
        JMCExpression exp = keyword.ToExpression();
        exp.SubExpressions = [.. commands];
        return exp;
    }

    [Production($"commandLine: {nameof(TokenType.CommandKeyword)}[d] {COLON} command")]
    public static JMCExpression CommandLine(JMCExpression cmd)
    {
        return cmd;
    }

    [Production($"commandFunction: {nameof(TokenType.CommandKeyword)} {nameof(TokenType.FunctionKeyword)}[d] namespace {LBLOCK} command* {RBLOCK}")]
    public static JMCExpression CommandFunction(Token<TokenType> keyword, JMCExpression ns, List<JMCExpression> commands)
    {
        ns.SubExpressions = [.. commands];
        ns.TokenType = keyword.TokenID;
        return ns;
    }

    #endregion

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
    public static JMCExpression ImportExpression(Token<TokenType> codeKeyword, Token<TokenType> importKeyword, ValueOption<JMCExpression> content, ValueOption<JMCExpression> alias)
    {
        var exp = content.Match(v => v, () => JMCExpression.Empty);
        ImmutableArray<JMCExpression> exps = exp.HasValue ? [exp, alias.Match(v => v, () => JMCExpression.Empty)] : [];
        var value = exps[0].SubExpressions.IsDefaultOrEmpty ? string.Empty : string.Join('/', exps[0].SubExpressions.Select(v => v.Value));
        var codeExp = codeKeyword.ToExpression();
        var importExp = importKeyword.ToExpression();
        importExp.Value = value;
        importExp.SubExpressions = exps;
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

    [Production($"namespace: {IDENTIFIER} ({DOT} {IDENTIFIER})*")]
    public static JMCExpression Namespace(Token<TokenType> left, List<Group<TokenType, JMCExpression>> right)
    {
        IEnumerable<JMCExpression> rightValues = right.Select(v => v.Token(IDENTIFIER).ToExpression());
        IEnumerable<JMCExpression> values = new JMCExpression[] { left.ToExpression() }.Concat(rightValues);

        string value = string.Join('.', rightValues.Select(v => v.Value));
        value = !string.IsNullOrEmpty(value) ? $"{left.Value}.{value}" : left.Value;

        return new()
        {
            Position = left.Position,
            Value = value,
            SubExpressions = [.. rightValues]
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

    [Production($"funcNameArg: {IDENTIFIER} {nameof(TokenType.Colon)}[d] value")]
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

    #endregion Functions

    #region AL

    [Production($"al: valueSign? als (operand als)*")]
    public static JMCExpression AL(ValueOption<JMCExpression> prefix, JMCExpression left, List<Group<TokenType, JMCExpression>> right)
    {
        IEnumerable<JMCExpression> subExps = right.Select(g =>
        {
            JMCExpression operand = g.Value("operand");
            JMCExpression als = g.Value("als");
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

    [Production("als: number")]
    [Production("als: variable")]
    [Production("als: unaryExp")]
    [Production("als: IDENTIFIER")]
    public static JMCExpression ALS(JMCExpression als)
    {
        return als;
    }

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
    public static JMCExpression CommandArgument(JMCExpression exp)
    {
        return exp;
    }

    [Production($"posI: valueSign? number")]
    public static JMCExpression PosI(ValueOption<JMCExpression> sign, JMCExpression exp)
    {
        exp.SubExpressions = [sign.GetValueOrEmpty()];
        return exp;
    }
    [Production($"posF: '^' valueSign? number")]
    [Production($"posR: '~' valueSign? number")]
    public static JMCExpression PosFR(Token<TokenType> s, ValueOption<JMCExpression> sign, JMCExpression i)
    {
        JMCExpression exp = s.ToExpression();
        JMCExpression signValue = sign.GetValueOrEmpty();

        signValue.SubExpressions = [i];

        exp.Value = $"{s.Value}{signValue.Value}{i.Value}";
        exp.SubExpressions = [signValue];

        return exp;
    }

    [Production($"vec2: posI posI")]
    [Production($"vec2: posR posR")]
    [Production($"vec2: posF posF")]
    public static JMCExpression Vec2(JMCExpression e1, JMCExpression e2)
    {
        return new()
        {
            SubExpressions = [e1, e2],
            Value = VEC2_COLLECTION
        };
    }

    [Production($"vec3: posI posI posI")]
    [Production($"vec3: posR posR posR")]
    [Production($"vec3: posF posF posF")]
    public static JMCExpression Vec3(JMCExpression e1, JMCExpression e2, JMCExpression e3)
    {
        return new()
        {
            SubExpressions = [e1, e2, e3],
            Value = VEC3_COLLECTION
        };
    }

    [Production($"quotedProps: {nameof(TokenType.ListStart)}[d] properties? {nameof(TokenType.ListEnd)}[d]")]
    public static JMCExpression QuotedProperties(ValueOption<JMCExpression> props)
    {
        return props.GetValueOrEmpty();
    }

    [Production($"properties: property ({COMMA} property)*")]
    public static JMCExpression Properties(JMCExpression left, List<Group<TokenType, JMCExpression>> right)
    {
        IEnumerable<JMCExpression> rValues = right.Select(v => v.Value(0));
        ImmutableArray<JMCExpression> values = [left, .. rValues];

        return new()
        {
            SubExpressions = values,
            Value = COMMAND_PROPERTIES
        };
    }

    [Production($"property: {IDENTIFIER} {nameof(TokenType.Assign)}[d] cmdValue")]
    public static JMCExpression Property(Token<TokenType> key, JMCExpression value)
    {
        JMCExpression exp = key.ToExpression();
        exp.SubExpressions = [value];
        return exp;
    }

    [Production($"cmdValue: bool")]
    [Production($"cmdValue: number")]
    public static JMCExpression CommandValue(JMCExpression exp)
    {
        return exp;
    }

    [Production($"cmdValue: {IDENTIFIER}")]
    public static JMCExpression CommandValue(Token<TokenType> token)
    {
        return token.ToExpression();
    }

    [Production($"cmdKeyword: {IDENTIFIER}")]
    public static JMCExpression CommandKeyword(Token<TokenType> token)
    {
        return token.ToExpression();
    }

    [Production($"jsonValue: jsonObject")]
    [Production($"jsonValue: jsonList")]
    [Production($"jsonValue: bool")]
    [Production($"jsonValue: number")]
    [Production($"jsonValue: STRING")]
    public static JMCExpression JsonValue(JMCExpression exp)
    {
        return exp;
    }

    [Production($"jsonObject: {LBLOCK} ([STRING|IDENTIFIER] {COLON} jsonValue)* {RBLOCK}")]
    public static JMCExpression JsonObject(List<Group<TokenType, JMCExpression>> values)
    {
        ImmutableArray<JMCExpression> exps = values.Select(v => new JMCExpression()
        {
            Position = v.Value(0).Position,
            Value = v.Value(0).Value,
            SubExpressions = [v.Value(1)]
        }).ToImmutableArray();

        return new()
        {
            SubExpressions = exps,
            Value = COMMAND_JSON_OBJECT
        };
    }

    [Production($"jsonList: {LLIST} jsonValue* {RLIST}")]
    public static JMCExpression JsonList(List<JMCExpression> values)
    {
        return new()
        {
            SubExpressions = [.. values],
            Value = COMMAND_JSON_LIST
        };
    }

    #endregion

    #region Values
    [Production($"assign: [" +
        $"{nameof(TokenType.Assign)}|{nameof(TokenType.CompareAssign)}|{nameof(TokenType.DivideAssign)}|" +
        $"{nameof(TokenType.MinusAssign)}|{nameof(TokenType.MultiplyAssign)}|{nameof(TokenType.NullColesleAssign)}|" +
        $"{nameof(TokenType.PlusAssign)}|{nameof(TokenType.RemainderAssign)}" +
        $"]")]
    public static JMCExpression Assign(Token<TokenType> token)
    {
        return token.ToExpression();
    }

    [Production($"cmdAssign: {nameof(TokenType.Assign)}")]
    [Production($"cmdAssign: {nameof(TokenType.BooleanAssign)}")]
    public static JMCExpression CommandAssign(Token<TokenType> token)
    {
        return token.ToExpression();
    }

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
        return b.ToExpression();
    }

    [Production($"variable: {nameof(TokenType.DollarSign)} {IDENTIFIER}")]
    public JMCExpression Variable(Token<TokenType> dollarSign, Token<TokenType> identifier)
    {
        string value = $"${identifier.Value}";

        _ = FileDetail.ScoreboardVariables.Add(value);

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
        IEnumerable<JMCExpression> exps = identifiers.Select(v => v.ToExpression());
        return new()
        {
            Position = dollarSign.Position,
            TokenType = dollarSign.TokenID,
            Value = string.Join(",", identifiers.Select(v => v.Value)),
            SubExpressions = [.. exps]
        };
    }

    [Production($"defaultString: {STRING_START_KEEP} {STRING_VALUE}* {STRING_END}")]
    public static JMCExpression DefaultString(Token<TokenType> start, List<Token<TokenType>> strValues)
    {
        ImmutableArray<JMCExpression> exps = [.. strValues.ToExpressions()];
        return new()
        {
            Position = start.Position,
            Value = VALUE_STRING,
            SubExpressions = exps
        };
    }

    [Production($"fStringExpression: {nameof(TokenType.FStringBracketStart)}[d] al {nameof(TokenType.FStringBracketEnd)}[d]")]
    public static JMCExpression FStringExpression(JMCExpression al)
    {
        return new()
        {
            Value = F_STRING_EXPRESSION,
            SubExpressions = [al]
        };
    }

    [Production($"fStringExpression: {nameof(TokenType.FStringContent)}")]
    public static JMCExpression FStringExpression(Token<TokenType> token)
    {
        return token.ToExpression();
    }

    [Production($"fString: {nameof(TokenType.StartFString)}[d] fStringExpression* {nameof(TokenType.EndFString)}[d]")]
    public static JMCExpression FString(List<JMCExpression> contents)
    {
        return new()
        {
            Value = F_STRING,
            SubExpressions = [.. contents]
        };
    }

    [Production($"colorStringValue: {nameof(TokenType.ColorStringContent)}")]
    public static JMCExpression ColorStringValue(Token<TokenType> token)
    {
        return token.ToExpression();
    }

    [Production($"colorStringValue: {nameof(TokenType.ColoStringTagStart)}[d] [{nameof(TokenType.ColorStringTagValue)}|{nameof(TokenType.ColorStringTagEndValue)}] {nameof(TokenType.ColoStringTagEnd)}[d]")]
    public static JMCExpression ColorStringTagValue(Token<TokenType> value)
    {
        return new()
        {
            Value = COLOR_TAG,
            SubExpressions = [value.ToExpression()]
        };
    }

    [Production($"colorString: {nameof(TokenType.StartColorString)}[d] colorStringValue* {nameof(TokenType.EndColorString)}[d]")]
    public static JMCExpression ColorString(List<JMCExpression> values)
    {
        return new()
        {
            Value = COLOR_STRING,
            SubExpressions = [.. values]
        };
    }

    [Production($"arrayElem: value ({COMMA} value)*")]
    public static JMCExpression ArrayElement(JMCExpression left, List<Group<TokenType, JMCExpression>> right)
    {
        var rightValues = right.Select(v => v.Value(0));
        ImmutableArray<JMCExpression> exps = [left, .. right.Select(v => v.Value(0))];

        return new()
        {
            Value = ARRAY_ELEMS,
            SubExpressions = exps
        };
    }

    [Production($"array: {LLIST} arrayElem? {RLIST}")]
    public static JMCExpression ArrayExpressions(ValueOption<JMCExpression> elem)
    {
        return new()
        {
            SubExpressions = elem.GetValueOrEmpty().SubExpressions,
            Value = ARRAY
        };
    }

    [Production($"STRING: fString")]
    [Production($"STRING: colorString")]
    [Production($"STRING: defaultString")]
    public static JMCExpression NormalString(JMCExpression exp)
    {
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
    [Production("value: array")]
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
        JMCExpression exp = start.ToExpression();
        exp.SubExpressions = [properties.GetValueOrEmpty()];
        return exp;
    }

    [Production($"IDENTIFIER: {IDENTIFIER}")]
    public static JMCExpression Identifier(Token<TokenType> token)
    {
        return token.ToExpression();
    }

    #endregion
}