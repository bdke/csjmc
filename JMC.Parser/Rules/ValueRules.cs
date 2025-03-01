using JMC.Parser.Helper;
using sly.lexer;
using sly.parser.generator;
using sly.parser.parser;
using System.Collections.Immutable;
using static JMC.Parser.Rules.RuleConstants;

namespace JMC.Parser.Rules;

public partial class JMCRuleInstance
{
    private const string ASSIGN_TOKENS = $"[{nameof(TokenType.Assign)}|{nameof(TokenType.CompareAssign)}|{nameof(TokenType.DivideAssign)}|{nameof(TokenType.MinusAssign)}|{nameof(TokenType.MultiplyAssign)}|{nameof(TokenType.NullColesleAssign)}|{nameof(TokenType.PlusAssign)}|{nameof(TokenType.RemainderAssign)}]";
    [Production($"assign: {ASSIGN_TOKENS}")]
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
    public static JMCExpression Bool(Token<TokenType> token)
    {
        return token.ToExpression();
    }

    [Production($"variable: {nameof(TokenType.DollarSign)} {IDENTIFIER}")]
    public JMCExpression Variable(Token<TokenType> dollarSign, Token<TokenType> identifier)
    {
        string value = identifier.Value;
        _ = FileDetail.ScoreboardVariables.Add(value);

        return new()
        {
            Position = dollarSign.Position,
            TokenType = dollarSign.TokenID,
            Type = ValueType.Variable,
            Value = value,
            SubExpressions = [identifier.ToExpression()]
        };
    }

    [Production($"variable: {nameof(TokenType.DollarSign)} {LBLOCK} IDENTIFIER* {RBLOCK}")]
    public static JMCExpression Variable(Token<TokenType> dollarSign, List<JMCExpression> identifiers)
    {
        return new()
        {
            Position = dollarSign.Position,
            TokenType = TokenType.Identifier,
            Type = ValueType.Variable,
            Value = string.Join(",", identifiers.Select(v => v.Value)),
            SubExpressions = [.. identifiers]
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

    [Production($"BOOL: [{nameof(TokenType.True)}|{nameof(TokenType.False)}]")]
    public static JMCExpression Boolean(Token<TokenType> value)
    {
        return value.ToExpression();
    }

    [Production($"valueSign: {nameof(TokenType.Plus)}")]
    [Production($"valueSign: {nameof(TokenType.Minus)}")]
    public static JMCExpression ValueSign(Token<TokenType> value)
    {
        return value.ToExpression();
    }

    [Production("objectValue: lambdaFunction")]
    [Production("objectValue: number")]
    [Production("objectValue: variable")]
    [Production("objectValue: STRING")]
    [Production("objectValue: array")]
    [Production("objectValue: BOOL")]
    [Production("objectValue: IDENTIFIER")]
    [Production("objectValue: funcCall")]
    [Production("value: objectValue")]
    [Production("value: propertyValue")]
    public static JMCExpression Value(JMCExpression expression)
    {
        return expression;
    }

    [Production($"propertyValue: objectValue ({DOT} [funcCall|IDENTIFIER])+")]
    public static JMCExpression PropertyValue(JMCExpression left, List<Group<TokenType, JMCExpression>> right)
    {
        var root = left;

        var props = right
            .Select(v => v.Value(0))
            .ComposeCollectionExpression();
        root.SubExpressions = [..left.SubExpressions, props];

        return root;
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


    [Production($"funcCall: IDENTIFIER enclosedFuncArgs")]
    public static JMCExpression FunctionCallStatement(JMCExpression funcName, JMCExpression funcArgs)
    {
        funcName.SubExpressions = [funcArgs];
        funcName.Type = ValueType.Function;
        return funcName;
    }

    [Production($"IDENTIFIER: {IDENTIFIER}")]
    public static JMCExpression Identifier(Token<TokenType> token)
    {
        var identifier = token.ToExpression();
        identifier.Type = ValueType.Constant;
        return identifier;
    }
}
