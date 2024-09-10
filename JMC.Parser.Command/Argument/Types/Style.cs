using System.Text.Json;
using System.Text.Json.Nodes;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:style")]
internal class Style : BaseArgument
{
    public JsonObject? Json { get; private set; }

    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        try
        {
            Json = JsonSerializer.Deserialize<JsonObject>(arguments[0]);
        }
        catch (JsonException)
        {
            Json = null;
        }
        return Json == null ? new ParseError(new CommandSyntaxError()) : new CommandParseResult(CommandTokenType.Style, this);
    }
}