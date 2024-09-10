using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace JMC.Parser.Command.Datas.Types;

public class Item : IMinecraftDbData<Item>
{
    [Key]
    public int Id { get; set; }
    public required int ItemId { get; set; }
    public required string ResourceLocation { get; set; }
    public required string Version { get; set; }

    public static async Task<List<Item>> FromArticAsync(string version)
    {
        string path = "particles.json";
        string json = await ArticDataHelper.GetArticJsonAsync(version, path);
        JsonObject result = JsonSerializer.Deserialize<JsonObject>(json) ?? throw new NullReferenceException();
        Dictionary<string, JsonNode?> dict = result.ToDictionary();
        List<Item> items = dict.Select(v =>
        {
            string resourceLocation = v.Key;
            int id = v.Value?.AsObject()["id"].Deserialize<int>() ?? throw new NullReferenceException();
            return new Item()
            {
                ItemId = id,
                ResourceLocation = resourceLocation,
                Version = version,
            };
        }).ToList();
        return items;
    }
}