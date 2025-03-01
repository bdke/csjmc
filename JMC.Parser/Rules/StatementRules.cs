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
        var block = statements.ComposeCollectionExpression(nameof(Block));
        return block;
    }

    [Production($"class: {nameof(TokenType.ClassKeyword)} IDENTIFIER {LBLOCK} [function|class]* {RBLOCK}")]
    public static JMCExpression Class(Token<TokenType> keyword, JMCExpression funcName, List<JMCExpression> expressions)
    {
        return keyword.ToExpression()
            .AddSubExpressions(funcName)
            .AddSubExpressions(expressions.ComposeCollectionExpression("FunctionOrClass"));
    }

    [Production($"variableStatement: IDENTIFIER assign value {END}")]
    [Production($"variableStatement: IDENTIFIER assign al {END}")]
    [Production($"variableStatement: variable assign value {END}")]
    [Production($"variableStatement: variable assign al {END}")]
    public static JMCExpression VariableStatement(JMCExpression variable, JMCExpression assign, JMCExpression als)
    {
        return JMCExpression.ComposeCollection(nameof(VariableStatement), variable, assign, als);
    }

    [Production($"function: {nameof(TokenType.FunctionKeyword)} IDENTIFIER {LPAREN} funcParams? {RPAREN} block")]
    public static JMCExpression FunctionStatement(
        Token<TokenType> keyword,
        JMCExpression funcName,
        ValueOption<JMCExpression> funcParams,
        JMCExpression block)
    {
        return keyword.ToExpression().AddSubExpressions(funcName, funcParams.GetValueOrEmpty(), block);
    }


    [Production($"ifStatement: {nameof(TokenType.IfKeyword)} enclosedConditions block [elseStatement|elseIfStatement]?")]
    public static JMCExpression IfStatement(
        Token<TokenType> keyword,
        JMCExpression condition,
        JMCExpression block,
        ValueOption<JMCExpression> elseExp)
    {
        return keyword.ToExpression().AddSubExpressions(condition, block, elseExp.GetValueOrEmpty());
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
        return keyword.ToExpression().AddSubExpressions(conditions, block);
    }

    [Production($"doWhileStatement: {nameof(TokenType.DoKeyword)} block {nameof(TokenType.WhileKeyword)}[d] enclosedConditions {END}")]
    public static JMCExpression DoStatement(Token<TokenType> keyword, JMCExpression block, JMCExpression conditions)
    {
        return keyword.ToExpression().AddSubExpressions(conditions, block);
    }

    [Production($"switchStatement: {nameof(TokenType.SwitchKeyword)} enclosedConditions switchBlock")]
    public static JMCExpression SwitchStatement(Token<TokenType> keywprd, JMCExpression conditions, JMCExpression block)
    {
        return keywprd.ToExpression().AddSubExpressions(conditions, block);
    }

    [Production($"switchBlock: {LBLOCK} caseBlock* defaultCaseBlock? {RBLOCK}")]
    public static JMCExpression SwitchBlock(List<JMCExpression> cases, ValueOption<JMCExpression> defaultCase)
    {
        return JMCExpression.ComposeCollection(JMCExpression.KEYWORD_EMPTY, cases).AddSubExpressions(defaultCase.GetValueOrEmpty());
    }

    [Production($"caseBlock: {nameof(TokenType.CaseKeyword)} conditions {nameof(TokenType.Colon)}[d] block")]
    public static JMCExpression CaseBlock(Token<TokenType> keyword, JMCExpression conditions, JMCExpression block)
    {
        return keyword.ToExpression().AddSubExpressions(conditions, block);
    }

    [Production($"defaultCaseBlock: {nameof(TokenType.DefaultKeyword)} {nameof(TokenType.Colon)}[d] block")]
    public static JMCExpression DefaultCaseBlock(Token<TokenType> keyword, JMCExpression block)
    {
        return keyword.ToExpression().AddSubExpressions(block);
    }
}
