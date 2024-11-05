using FluentAssertions;

namespace JMC.Parser.Test;
internal static class ParseResultCheckingExtensions
{
    public static void ShouldNotBeError(this JMCParser.ParseResult parseResult)
    {
        parseResult.IsError.Should().BeFalse();
    }

    public static void ShouldBeError(this JMCParser.ParseResult parseResult)
    {
        parseResult.IsError.Should().BeTrue();
    }

    public static void ShouldHaveValue(this JMCExpression exp)
    {
        exp.Value.Should().NotBeNull();
    }

    public static void ShouldHaveValue(this JMCExpression exp, object obj)
    {
        exp.Value.Should().BeEquivalentTo(obj);
    }

    public static void ShouldNotHaveValue(this JMCExpression exp)
    {
        exp.Value.Should().BeNull();
    }

    public static void ShouldNotHaveTokenType(this JMCExpression exp)
    {
        exp.TokenType.Should().BeNull();
    }

    public static void ShouldHaveTokenType(this JMCExpression exp)
    {
        exp.TokenType.Should().NotBeNull();
    }

    public static void ShouldHaveTokenType(this JMCExpression exp, TokenType type)
    {
        exp.TokenType.Should().Be(type);
    }
}
