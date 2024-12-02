using FluentCommand.Arguments;
using FluentCommand.Types;
using Microsoft.VisualBasic.FileIO;
using MineSharp.Core.Common.Blocks;
using MineSharp.Core.Exceptions;
using MineSharp.Data;
using System.Text.Json;

namespace FluentCommand.Helpers;
public sealed class MinecraftDataService()
{
    public const string CACHE_DIR_NAME = "fluentCommandCache";
    public const string EXTENDED_DATA_FILE_NAME = "extendedMinecraftData.json";

    private ReadOnlyMemory<BlockInfo> blockInfoCache;
    private static MinecraftData? minecraftDataCache;
    private static ReadOnlyMemory<string> customStatsCache;

    public static ReadOnlyMemory<string> Criterias => ObjectiveCriteria.COMPOUND_CRITERIAS.AsMemory();
    public static MinecraftDataService Transient => GetDataServiceFactoryAsync().Result;

    public required MinecraftData MinecraftData { get; init; }
    public required ExtendedMinecraftData ExtendedData { get; init; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <exception cref="MineSharpException"/>
    /// <returns></returns>
    public static async Task<MinecraftDataService> GetDataServiceFactoryAsync(string version = "1.20.4")
    {
        minecraftDataCache ??= await MinecraftData.FromVersion(version);
        if (customStatsCache.IsEmpty)
        {
            customStatsCache = await GetAllCustomStatisticsAsync(version);
        }

        ExtendedMinecraftData extendedData = new()
        {
            CustomStatistics = customStatsCache,
        };
        return new()
        {
            MinecraftData = minecraftDataCache,
            ExtendedData = extendedData
        };
    }

    public ReadOnlyMemory<BlockInfo> GetAllBlocks()
    {
        if (!blockInfoCache.IsEmpty)
        {
            return blockInfoCache;
        }
        IEnumerable<BlockInfo?> blocks = Enum.GetValues<BlockType>().Select(MinecraftData.Blocks.ByType);
        return blockInfoCache = new([.. blocks]);
    }

    public static async Task<ReadOnlyMemory<string>> GetAllCustomStatisticsAsync(string version)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datas", $"{version}_stats");
        string content = await File.ReadAllTextAsync(path);
        string[] parsedResult = content.Split(',');
        return parsedResult;
    }

    public async Task CreateCacheAsync()
    {
        string tempFolder = SpecialDirectories.Temp;
        string cacheFolderPath = Path.Join(tempFolder, CACHE_DIR_NAME);
        if (!Directory.Exists(cacheFolderPath))
        {
            _ = Directory.CreateDirectory(cacheFolderPath);
        }
        string cacheFilePath = Path.Join(cacheFolderPath, EXTENDED_DATA_FILE_NAME);
        if (File.Exists(cacheFilePath))
        {
            File.Delete(cacheFilePath);
        }
        using FileStream fileStream = new(cacheFilePath, FileMode.CreateNew, FileAccess.Write);
        await JsonSerializer.SerializeAsync(fileStream, ExtendedData);
    }
}
