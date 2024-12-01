using FluentCommand.Arguments;

namespace FluentCommand.Test;
public class ArgumentTest
{
    [Theory]
    [InlineData("xp")]
    public void ValidObjectiveCriteria_Test(string argument)
    {
        var arg = new ObjectiveCriteria(argument);

        arg.IsValidValue.Should().BeTrue();
    }
}
