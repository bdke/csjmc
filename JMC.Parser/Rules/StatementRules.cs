using JMC.Parser.Helper;
using sly.lexer;
using sly.parser.generator;
using sly.parser.parser;
using static JMC.Parser.Rules.RuleConstants;

namespace JMC.Parser.Rules;

public partial class JMCRuleInstance
{
    [Production($"block: {nameof(TokenType.BlockStart)} statement* {RBLOCK}")]
    public static JMCExpression Block(Token<TokenType> lBlock, List<JMCExpression> statements)
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
    [Production($"variableStatement: variable assign array {END}")]
    public static JMCExpression VariableStatement(JMCExpression variable, JMCExpression assign, JMCExpression als)
    {
        variable.SubExpressions = [assign, als];
        return variable;
    }

    [Production($"function: {nameof(TokenType.FunctionKeyword)}[d] namespace {LPAREN} funcParams? {RPAREN} block")]
    public static JMCExpression FunctionStatement(
        JMCExpression funcName,
        ValueOption<JMCExpression> funcParams,
        JMCExpression block)
    {
        return new()
        {
            Position = funcName.Position,
            SubExpressions = [funcParams.Match(v => v, () => JMCExpression.Empty), block],
            TokenType = TokenType.FunctionKeyword,
            Value = funcName.Value,
        };
    }

    [Production($"funcCall: namespace enclosedFuncArgs subFuncCall? {END}")]
    public static JMCExpression FunctionCallStatement(JMCExpression funcName, JMCExpression funcArgs, ValueOption<JMCExpression> subFuncCall)
    {
        funcName.SubExpressions = [funcArgs, subFuncCall.GetValueOrEmpty()];
        return funcName;
    }

    [Production($"ifStatement: {nameof(TokenType.IfKeyword)} enclosedConditions block [elseStatement|elseIfStatement]?")]
    public static JMCExpression IfStatement(
        Token<TokenType> keyword,
        JMCExpression condition,
        JMCExpression block,
        ValueOption<JMCExpression> exp)
    {
        JMCExpression root = keyword.ToExpression();
        JMCExpression bElse = exp.GetValueOrEmpty();
        root.SubExpressions = [condition, block, bElse];

        return root;
    }

    [Production($"elseStatement: {nameof(TokenType.ElseKeyword)}[d] block")]
    [Production($"elseIfStatement: {nameof(TokenType.ElseKeyword)}[d] ifStatement")]
    public static JMCExpression ElseIfStatement(JMCExpression exp)
    {
        return exp;
    }

    [Production($"whileStatement: {nameof(TokenType.WhileKeyword)} enclosedConditions block")]
    public static JMCExpression WhileStatement(Token<TokenType> keyword, JMCExpression conditions, JMCExpression block)
    {
        JMCExpression root = keyword.ToExpression();

        root.SubExpressions = [conditions, block];

        return root;
    }

    [Production($"doWhileStatement: {nameof(TokenType.DoKeyword)} block {nameof(TokenType.WhileKeyword)}[d] enclosedConditions {END}")]
    public static JMCExpression DoStatement(Token<TokenType> keyword, JMCExpression block, JMCExpression conditions)
    {
        JMCExpression root = keyword.ToExpression();

        root.SubExpressions = [conditions, block];

        return root;
    }

    [Production($"switchStatement: {nameof(TokenType.SwitchKeyword)} enclosedConditions switchBlock")]
    public static JMCExpression SwitchStatement(Token<TokenType> keywprd, JMCExpression conditions, JMCExpression block)
    {
        JMCExpression root = keywprd.ToExpression();
        root.SubExpressions = [conditions, block];
        return root;
    }

    [Production($"switchBlock: {LBLOCK} caseBlock* defaultCaseBlock? {RBLOCK}")]
    public static JMCExpression SwitchBlock(List<JMCExpression> cases, ValueOption<JMCExpression> defaultCase)
    {
        JMCExpression root = JMCExpression.Empty;

        root.SubExpressions = [.. cases, defaultCase.GetValueOrEmpty()];

        return root;
    }

    [Production($"caseBlock: {nameof(TokenType.CaseKeyword)} conditions {nameof(TokenType.Colon)}[d] block")]
    public static JMCExpression CaseBlock(Token<TokenType> keyword, JMCExpression conditions, JMCExpression block)
    {
        var root = keyword.ToExpression();

        root.SubExpressions = [conditions, block];

        return root;
    }

    [Production($"defaultCaseBlock: {nameof(TokenType.DefaultKeyword)} {nameof(TokenType.Colon)}[d] block")]
    public static JMCExpression DefaultCaseBlock(Token<TokenType> keyword, JMCExpression block)
    {
        var root = keyword.ToExpression();

        root.SubExpressions = [block];

        return root;
    }
}
