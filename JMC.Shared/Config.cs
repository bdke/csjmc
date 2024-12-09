using MineSharp.Core.Common.Blocks;
using MineSharp.Data;

namespace JMC.Shared;

public static class Config
{
    private static bool isInitialized = false;
    private static IEnumerable<BlockInfo>? blockInfoCache;
    private static MinecraftVersion version = default!;

    public static MinecraftData MinecraftData { get; private set; } = default!;
    public static ExtendedMinecraftData ExtendedMinecraftData { get; private set; } = default!;

    public static async Task InitAsync(string minecraftVersion = "1.20.4")
    {
        if (isInitialized)
        {
            return;
        }

        isInitialized = true;
        MinecraftData = await MinecraftData.FromVersion(minecraftVersion);
        version = MinecraftData.Version;
        ExtendedMinecraftData = new()
        {
            CustomStatistics = new(await GetAllCustomStatisticAsync())
        };
    }

    private static async Task<string[]> GetAllCustomStatisticAsync()
    {
        var path = $"datas/{version}_stats";
        var content = await File.ReadAllTextAsync(path);
        return content.Split(',');
    }

    public static IEnumerable<BlockInfo> GetBlockInfos()
    {
        var blocks = Enum.GetValues<BlockType>()
            .Select(MinecraftData.Blocks.ByType)!
            .Where<BlockInfo>(v => v != null);
        return blockInfoCache ??= blocks;
    }
}