using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace JMC.Parser.Command.Datas.Types;

public class BlockPropety : IMinecraftDbData<BlockPropety>
{
    [Key]
    public int Id { get; set; }
    public required string Version { get; set; }
    public required string DictKey { get; set; }
    public required string Key { get; set; }
    public required string[] Values { get; set; }

    public static async Task<List<BlockPropety>> FromArticAsync(string version)
    {
        string path = "block_properties.json";
        string json = await ArticDataHelper.GetArticJsonAsync(version, path);
        JsonObject result = JsonSerializer.Deserialize<JsonObject>(json) ?? throw new NullReferenceException();
        Dictionary<string, JsonNode?> dict = result.ToDictionary();
        List<BlockPropety> entities = dict.Select(v =>
        {
            string dictKey = v.Key;
            string[] values = v.Value?.AsObject()["values"].Deserialize<object[]>()?.Select(v => v.ToString()!).ToArray() ?? throw new NullReferenceException();
            string key = v.Value?.AsObject()["key"].Deserialize<string>() ?? throw new NullReferenceException();
            return new BlockPropety()
            {
                Key = key,
                Values = values,
                Version = version,
                DictKey = dictKey,
            };
        }).ToList();
        return entities;
    }
}
