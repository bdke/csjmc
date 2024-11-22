using MineSharp.Data;

namespace FluentCommand.Helpers;
internal sealed class DataService(MinecraftData data)
{
    private readonly MinecraftData _data = data;

    public static async Task<DataService> DataServiceFactory()
    {
        MinecraftData data = await MinecraftData.FromVersion("1.20.4");
        DataService dataService = new(data);
        return dataService;
    }
}
