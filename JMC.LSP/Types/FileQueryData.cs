using JMC.Parser;
using System.Text.Json.Serialization;

namespace JMC.LSP.Types;
internal class FileQueryData
{
    [JsonPropertyName("uri"), JsonRequired]
    public required string Uri { get; set; }
    [JsonPropertyName("pos")]
    public QueryPosition? Position { get; set; }

    public class QueryPosition
    {
        [JsonPropertyName("line")]
        public required int Line { get; set; }
        [JsonPropertyName("column")]
        public required int Column { get; set; }
    }
}
