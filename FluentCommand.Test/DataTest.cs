using FluentCommand.Helpers;

namespace FluentCommand.Test;
public class DataTest
{
    private readonly MinecraftDataService _dataService;
    public DataTest()
    {
        _dataService = MinecraftDataService.GetDataServiceFactoryAsync().Result;
    }

    [Fact]
    public void GetData_Test()
    {
        MineSharp.Core.Common.Blocks.BlockInfo[] blocks = _dataService.GetAllBlocks().ToArray();

        _ = blocks.Should().NotBeEmpty();
    }
}
