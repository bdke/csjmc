using MineSharp.Core.Common.Blocks;
using MineSharp.Data;

namespace FluentCommand.Helpers;
public sealed class MinecraftDataService(MinecraftData data)
{
    private ReadOnlyMemory<BlockInfo> blockInfoCache;

    private readonly MinecraftData _data = data;
    public MinecraftData MinecraftData => _data;

    public static async Task<MinecraftDataService> GetDataServiceFactoryAsync(string version = "1.20.4")
    {
        MinecraftData data = await MinecraftData.FromVersion(version);
        MinecraftDataService dataService = new(data);
        return dataService;
    }

    public ReadOnlyMemory<BlockInfo> GetAllBlocks()
    {
        if (!blockInfoCache.IsEmpty)
        {
            return blockInfoCache;
        }
        IEnumerable<BlockInfo?> blocks = Enum.GetValues<BlockType>().Select(_data.Blocks.ByType);
        return blockInfoCache = new([.. blocks]);
    }
}
