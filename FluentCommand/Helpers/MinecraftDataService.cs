using MineSharp.Core.Common.Blocks;
using MineSharp.Data;

namespace FluentCommand.Helpers;
public static class MinecraftDataExtensions
{
    public static ReadOnlyMemory<BlockInfo> GetAllBlocks(this MinecraftData data)
    {
        IEnumerable<BlockInfo?> blocks = Enum.GetValues<BlockType>().Select(data.Blocks.ByType);
        return new([.. blocks]);
    }

    public static async Task<ReadOnlyMemory<string>> GetAllCustomStatisticsAsync(this MinecraftData data)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datas", $"{data.Version}_stats");
        string content = await File.ReadAllTextAsync(path);
        string[] parsedResult = content.Split(',');
        return parsedResult;
    }
}
