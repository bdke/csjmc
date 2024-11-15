using System.Text.Json.Serialization;

namespace JMC.Parser.Datas;

internal sealed class PackMcmeta
{
    [JsonPropertyName("pack")]
    public required PackData Pack { get; set; }
    internal sealed class PackData
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; } = null;
        [JsonPropertyName("pack_format")]
        public int PackFormat { get; set; }
    }

}
