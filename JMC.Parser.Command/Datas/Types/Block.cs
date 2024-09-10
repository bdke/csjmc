using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace JMC.Parser.Command.Datas.Types;

public class Block : IMinecraftDbData<Block>
{
    [Key]
    public int Id { get; set; }
    public required int BlockId { get; set; }
    public required string ResourceLocation { get; set; }
    public required string TranslationKey { get; set; }
    public required string Version { get; set; }
    public required string[] PropetiesDictKey { get; set; }

    public static async Task<List<Block>> FromArticAsync(string version)
    {
        string path = "blocks.json";
        string json = await ArticDataHelper.GetArticJsonAsync(version, path);
        JsonObject result = JsonSerializer.Deserialize<JsonObject>(json) ?? throw new NullReferenceException();
        Dictionary<string, JsonNode?> dict = result.ToDictionary();
        List<Block> blocks = dict.Select(v =>
        {
            string resourceLocation = v.Key;
            int id = v.Value?.AsObject()["id"].Deserialize<int>() ?? throw new NullReferenceException();
            string translationKey = v.Value?.AsObject()["translationKey"].Deserialize<string>() ?? throw new NullReferenceException();
            string[] propKeys = v.Value?.AsObject()["properties"].Deserialize<string[]>() ?? throw new NullReferenceException();
            return new Block()
            {
                BlockId = id,
                TranslationKey = translationKey,
                ResourceLocation = resourceLocation,
                Version = version,
                PropetiesDictKey = propKeys
            };
        }).ToList();
        return blocks;
    }
}