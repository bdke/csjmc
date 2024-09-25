using FluentAssertions;

namespace JMC.Parser.Test;

[Trait("Category", "Tokenizing")]
public class TokenizerTest
{
    public static IEnumerable<object[]> TokenSplitTestData = [
        ["if (test)\r\n{test;}\r\n", new string[] {"if", "(test)", "{test;}"}],
        ["execute as is sus", new string[] {"execute", "as", "is", "sus"}]
    ];

    [Theory(DisplayName = "Token Split Test")]
    [MemberData(nameof(TokenSplitTestData))]
    public void TokenSplitTest_Test(string input, string[] expected)
    {
        var parser = new JMCTokenizer(input);
        var tokens = parser.Tokenize();
        tokens.Select(v => v.Value).Should().BeEquivalentTo(expected);
    }
}
