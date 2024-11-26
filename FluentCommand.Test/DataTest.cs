using FluentCommand.Helpers;
using MineSharp.Commands;
using MineSharp.Core;
using System.Text;

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
        var blocks = _dataService.GetAllBlocks().ToArray();
        blocks.Should().NotBeEmpty();
    }

    [Fact]
    public void ParseCommand_Test()
    {
        var commandBytes = Encoding.UTF8.GetBytes("execute if @s");
        var r = CommandTree.Parse(new(commandBytes, ProtocolVersion.V_1_20_3), _dataService.MInecraftData);
    }
}
