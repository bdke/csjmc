using JMC.Parser.Helper;
using JMC.Parser.Rules;
using System.Collections.Immutable;

namespace JMC.Parser;
public sealed class JMCRuleBuilder
{
    private List<IJMCRule> _currentRuleConditiion = [];
    private RuleType? currentType = null;
    private RuleChannel channel = RuleChannel.None;
    private readonly List<JMCRule> _builtRules = [];

    public static ImmutableArray<JMCRule> DefaultRules { get; } = CreateDefaultBuilder().Build();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="NullReferenceException" />
    public static JMCRuleBuilder CreateDefaultBuilder()
    {
        JMCRuleBuilder builder = new();

        var valueChannel = Rule.Channel(RuleChannel.Value);
        var statementChannel = Rule.Channel(RuleChannel.Statement);
        var argChannel = Rule.Channel(RuleChannel.Arg);

        _ = builder
            .SetChannel(RuleChannel.Value)
            .SetType(RuleType.String)
            .AddTokens(TokenType.String)
            .Create("string");

        _ = builder
            .SetChannel(RuleChannel.Value)
            .SetType(RuleType.Number)
            .AddCondition(Rule.Or(Rule.Token(TokenType.Int), Rule.Token(TokenType.Double)))
            .Create("number");

        _ = builder
            .SetChannel(RuleChannel.Value)
            .SetType(RuleType.List)
            .AddCondition((JMCTRule)TokenType.ListStart, valueChannel.Range(0), (JMCTRule)TokenType.ListEnd)
            .Create("list");

        _ = builder
            .SetChannel(RuleChannel.Value)
            .SetType(RuleType.Variable)
            .AddTokens(TokenType.DollarSign, TokenType.Identifier)
            .Create("variable");

        var block = builder
            .SetType(RuleType.Block)
            .AddCondition((JMCTRule)TokenType.BlockStart, statementChannel.Range(0), (JMCTRule)TokenType.BlockEnd)
            .Create("block");

        var lambdaFunction = builder
            .SetType(RuleType.Function)
            .AddTokens(TokenType.ParenStart, TokenType.ParenEnd, TokenType.Arrow)
            .AddCondition(block)
            .Create("lambdaFunction");

        var arg = builder
            .SetChannel(RuleChannel.Arg)
            .SetType(RuleType.UnNamedArg)
            .AddCondition(valueChannel.Or(lambdaFunction))
            .Create("arg");

        var namedArg = builder
            .SetChannel(RuleChannel.Arg)
            .SetType(RuleType.NamedArg)
            .AddTokens(TokenType.Identifier, TokenType.Colon)
            .AddCondition(valueChannel)
            .Create("namedArg");

        var args = builder
            .SetType(RuleType.Args)
            .AddCondition(argChannel.Range(0))
            .AddCondition(Rule.Group(Rule.Token(TokenType.Comma), argChannel).Range(0))
            .Create("args");

        var funcCall = builder
            .SetChannel(RuleChannel.Statement)
            .SetType(RuleType.FunctionCall)
            .AddTokens(TokenType.Identifier)
            .AddTokens(TokenType.ParenStart)
            .AddCondition(args)
            .AddTokens(TokenType.ParenEnd)
            .End("funcCall");



        return builder;
    }

    /// <summary>
    /// Set rule type
    /// </summary>
    /// <param name="ruleType"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public JMCRuleBuilder SetType(RuleType ruleType)
    {
        currentType = ruleType;
        return this;
    }

    /// <summary>
    /// Set rule channel
    /// </summary>
    /// <param name="channel"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public JMCRuleBuilder SetChannel(RuleChannel channel)
    {
        this.channel = channel;
        return this;
    }

    /// <summary>
    /// Add condition to rule
    /// </summary>
    /// <param name="rules"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public JMCRuleBuilder AddCondition(params IJMCRule[] rules)
    {
        if (_currentRuleConditiion.Count > 0)
        {
            _currentRuleConditiion.AddRange(rules);
            return this;
        }

        _currentRuleConditiion = [.. rules];
        return this;
    }

    public IJMCRule End(string name)
    {
        AddCondition((JMCTRule)TokenType.End);
        return Create(name);
    }

    /// <summary>
    /// Create new rule
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="NullReferenceException"></exception>
    public JMCRule Create(string name)
    {
        if (_builtRules.Any(v => v.Name == name))
        {
            throw new InvalidOperationException($"'{name}' already exists");
        }

        RuleType type = currentType ?? throw new NullReferenceException("rule is not created");

        var rule = new JMCRule([.. _currentRuleConditiion], type, channel, name);
        _builtRules.Add(rule);

        _currentRuleConditiion.Clear();
        currentType = null;

        return rule;
    }

    /// <summary>
    /// Build to get all rules
    /// </summary>
    /// <returns></returns>
    public ImmutableArray<JMCRule> Build()
    {
        return [.. _builtRules];
    }
}
