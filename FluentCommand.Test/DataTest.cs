using JMC.Shared;

namespace FluentCommand.Test;
public class DataTest
{
    [Fact]
    public void GetData_Test()
    {
        Config.InitAsync().Wait();
        var blocks = Config.GetBlockInfos();

        _ = blocks.Should().NotBeEmpty();
    }
}
