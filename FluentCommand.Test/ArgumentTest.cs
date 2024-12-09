using FluentCommand.Arguments;
using JMC.Shared;

namespace FluentCommand.Test;
public class ArgumentTest() : ConfigTest()
{
    [Theory]
    [InlineData("xp")]
    [InlineData("teamkill.dark_red")]
    [InlineData("custom:clean_banner")]
    public void ValidObjectiveCriteria_Test(string argument)
    {
        var arg = new ObjectiveCriteria(argument);

        ObjectiveCriteria.CheckValue(arg.Value).Should().BeTrue();
    }
}
