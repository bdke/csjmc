using FluentCommand.Types;
using HtmlAgilityPack;
using Microsoft.VisualBasic.FileIO;
using MineSharp.Core.Common.Blocks;
using MineSharp.Core.Exceptions;
using MineSharp.Data;
using System.Text.Json;

namespace FluentCommand.Helpers;
public sealed class MinecraftDataService() : IAsyncDisposable
{
    public const string CACHE_DIR_NAME = "fluentCommandCache";
    public const string EXTENDED_DATA_FILE_NAME = "extendedMinecraftData.json";
    public const string WIKI_BASE_PATH = "https://minecraft.wiki";
    public const string WIKI_CUSTOM_STATS_XPATH = "/html/body/div[3]/div[3]/div[5]/div[1]/table[2]/tbody/tr/td[3]";

    private ReadOnlyMemory<BlockInfo> blockInfoCache;

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
        MinecraftData data = await MinecraftData.FromVersion(version);
        ReadOnlyMemory<string> customStats = await GetCustomStatisticsAsync();
        ExtendedMinecraftData extendedData = new()
        {
            CustomStatistics = customStats
        };
        MinecraftDataService dataService = new()
        {
            MinecraftData = data,
            ExtendedData = extendedData
        };
        return dataService;
    }

    private static async Task<ReadOnlyMemory<string>> GetCustomStatisticsAsync()
    {
        using HttpClient client = CreateWikiClient();
        using var response = await client.GetAsync("/w/Statistics");
        response.EnsureSuccessStatusCode();
        using var rStream = await response.Content.ReadAsStreamAsync();
        HtmlDocument doc = new();
        doc.Load(rStream);
        HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(WIKI_CUSTOM_STATS_XPATH);
        string[] stats = nodes.Select(v => v.InnerText).ToArray();
        return new(stats);
    }

    private static HttpClient CreateWikiClient()
    {
        HttpClient client = new()
        {
            BaseAddress = new Uri(WIKI_BASE_PATH)
        };
        client.DefaultRequestHeaders.UserAgent.ParseAdd(@"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:132.0) Gecko/20100101 Firefox/132.0");
        client.DefaultRequestHeaders.Accept.ParseAdd(@"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
        client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(@"zh-TW,zh;q=0.8,en-US;q=0.5,en;q=0.3");
        client.DefaultRequestHeaders.AcceptEncoding.ParseAdd(@"gzip, deflate, br, zstd");
        client.DefaultRequestHeaders.Connection.ParseAdd("keep-alive");
        return client;
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

    public async ValueTask DisposeAsync()
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
