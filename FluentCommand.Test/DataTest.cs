using JMC.Shared;

namespace FluentCommand.Test;
public class DataTest() : ConfigTest()
{
    [Fact]
    public void GetData_Test()
    {
        var blocks = Config.GetBlockInfos();

        _ = blocks.Should().NotBeEmpty();
    }
}
