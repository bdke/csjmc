using FluentAssertions;
using Xunit.Categories;

namespace JMC.Parser.Test.Syntaxes;
public sealed class JMCSyntaxTest()
{
    private const string JMCSYNTAX = "JMCSyntax";

    [Fact(DisplayName = "Class&Function")]
    [TestCase(JMCSYNTAX)]
    public void ClassFunctionSyntax_Test()
    {
        var value = "class ns { function test() {} }";
        var result = JMCParser.TryParse(value);
        var exp = result.Root.SubExpressions[0];

        result.IsError.Should().BeFalse();
        exp.SubExpressions.Should().HaveCount(1);
        exp.Value.Should().Be("ns");
        exp.TokenType.Should().Be(TokenType.ClassKeyword);

        var func = exp.SubExpressions[0];
        func.Value.Should().Be("test");

        var funcParams = func.SubExpressions[0];
        funcParams.Should().BeEquivalentTo(JMCExpression.Empty);

        var funcBlock = func.SubExpressions[1];
        funcBlock.Value.Should().Be("Block");
        funcBlock.TokenType.Should().BeNull();
        funcBlock.SubExpressions.Should().BeEmpty();
    }

    [Fact(DisplayName = "Class")]
    [TestCase(JMCSYNTAX)]
    public void ClassSyntax_Test()
    {
        var value = "class ns { }";
        var result = JMCParser.TryParse(value);
        var exp = result.Root.SubExpressions[0];

        result.IsError.Should().BeFalse();
        exp.SubExpressions.Should().BeEmpty();
        exp.Value.Should().Be("ns");
        exp.TokenType.Should().Be(TokenType.ClassKeyword);
    }

    [Fact(DisplayName = "Function")]
    [TestCase(JMCSYNTAX)]
    public void FunctionSyntax_Test()
    {
        var value = "function test(i1, i2) { $var = i1; }";
        var result = JMCParser.TryParse(value);
        var root = result.Root;

        result.IsError.Should().BeFalse();

        var func = root.SubExpressions[0];
        func.Value.Should().Be("test");

        var funcParams = func.SubExpressions[0];
        funcParams.Should().NotBeEquivalentTo(JMCExpression.Empty);
        funcParams.SubExpressions.Should().HaveCount(2);
        funcParams.SubExpressions[0].Value.Should().Be("i1");
        funcParams.SubExpressions[1].Value.Should().Be("i2");

        var funcBlock = func.SubExpressions[1];
        funcBlock.Value.Should().Be("Block");
        funcBlock.TokenType.Should().BeNull();
        funcBlock.SubExpressions.Should().HaveCount(1);

        var vassign = funcBlock.SubExpressions[0];
        vassign.TokenType.Should().Be(TokenType.DollarSign);
        vassign.Value.Should().Be("var");
        vassign.SubExpressions.Should().HaveCount(2);

        var v1 = vassign.SubExpressions[0];
        var v2 = vassign.SubExpressions[1];
        v1.TokenType.Should().Be(TokenType.Assign);
        v2.TokenType.Should().Be(TokenType.Identifier);
        v2.Value.Should().Be("i1");
    }

    [Fact(DisplayName = "AL_Parenthsis")]
    [TestCase(JMCSYNTAX)]
    public void ALParen_Test()
    {
        var paren = "$test = -(3 + 3);";
        var result = JMCParser.TryParse(paren);
        result.ShouldNotBeError();
        
        var rootVar = result.Root.SubExpressions[0];
        //TODO:
    }

    [Theory(DisplayName = "Class_Error")]
    [Bug(JMCSYNTAX)]
    [InlineData("class {}")]
    [InlineData("class ns }")]
    [InlineData("class ns {")]
    public void ClassSyntaxError_Test(string text)
    {
        var result = JMCParser.TryParse(text);
        result.ShouldNotBeError();
    }
}
