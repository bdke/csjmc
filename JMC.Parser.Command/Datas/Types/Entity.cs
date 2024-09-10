using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace JMC.Parser.Command.Datas.Types;

public class Entity : IMinecraftDbData<Entity>
{
    [Key]
    public int Id { get; set; }
    public required int EntityId { get; set; }
    public required string Version { get; set; }
    public required string TranslationKey { get; set; }
    public required string ResourceLocation { get; set; }
    public static async Task<List<Entity>> FromArticAsync(string version)
    {
        string path = "entities.json";
        string json = await ArticDataHelper.GetArticJsonAsync(version, path);
        JsonObject result = JsonSerializer.Deserialize<JsonObject>(json) ?? throw new NullReferenceException();
        Dictionary<string, JsonNode?> dict = result.ToDictionary();
        List<Entity> entities = dict.Select(v =>
        {
            string resourceLocation = v.Key;
            int id = v.Value?.AsObject()["id"].Deserialize<int>() ?? throw new NullReferenceException();
            string translationKey = v.Value?.AsObject()["translationKey"].Deserialize<string>() ?? throw new NullReferenceException();
            return new Entity()
            {
                EntityId = id,
                TranslationKey = translationKey,
                Version = version,
                ResourceLocation = resourceLocation,
            };
        }).ToList();
        return entities;
    }
}
