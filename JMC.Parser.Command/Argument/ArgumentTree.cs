using System.Text.Json;
using System.Text.Json.Nodes;

using JMC.Parser.Command.Argument.Types;
using JMC.Parser.Command.Datas;
using JMC.Parser.Command.Datas.Types;

namespace JMC.Parser.Command.Argument;

public class ArgumentTree(string rootCommand, string version)
{
    public ICollection<ArgumentNode> Nodes { get; private set; } = [];

    public string RootCommand { get; set; } = rootCommand;

    public bool Executable { get; private set; } = false;

    public string Version { get; set; } = version;

    public ArgumentTreeParseResult? Parse(string[] args)
    {
        IEnumerable<ArgumentTreeParseResult> result = Nodes.Select(v => v.Parse(args));
        return !result.Any(v => v.Result.Succeed)
            ? new()
            {
                Previous = null,
                Result = new ParseError(new CommandSyntaxError($"invalid command")),
                Next = null
            }
            : result.FirstOrDefault(v => v.Result.Succeed);
    }

    public static List<ArgumentTree> CreateFromArticJson(CommandFile comamndFile)
    {
        int versionIndex = Array.IndexOf(MinecraftDbContext.SUPPORTED_VERSION, comamndFile.Version);

        JsonObject jObj = JsonSerializer.Deserialize<JsonObject>(comamndFile.JsonText) ?? throw new JsonException();
        JsonObject commands = jObj["children"].Deserialize<JsonObject>() ?? throw new KeyNotFoundException();

        return commands.Select((v, i) => CreateFromJson(v.Key, comamndFile.Version, v.Value.Deserialize<JsonObject>() ?? throw new JsonException())).ToList();
    }

    public static ArgumentTree CreateFromJson(string command, string version, JsonObject jsonObject)
    {
        ArgumentTree tree = new(command, version);
        JsonObject? children = jsonObject["children"].Deserialize<JsonObject>() ?? null;
        if (children == null)
        {
            tree.Executable = true;
            return tree;
        }

        foreach (ArgumentNode? child in children.Select(JsonToNode))
        {
            tree.Nodes.Add(child);
        }
        return tree;
    }

    private static ArgumentNode JsonToNode(KeyValuePair<string, JsonNode?> json)
    {
        if (json.Value is not JsonObject jObj)
        {
            throw new ArgumentException($"Value should be JsonObject");
        }

        string? type = jObj["type"].Deserialize<string>();
        JsonObject? children = jObj["children"].Deserialize<JsonObject>() ?? null;
        string? parser = jObj["parser"].Deserialize<string>() ?? null;
        JsonObject? props = jObj["properties"].Deserialize<JsonObject>() ?? null;
        bool executable = jObj["executable"].Deserialize<bool?>() ?? false;

        BaseArgument? argument = null;
        ArgumentPropties argumentProperties = null!;
        if (type == "literal")
        {
            argument = new Literal(json.Key);
            argumentProperties = new()
            {
                Parser = "Literal",
                Options = [json.Key]
            };
        }
        else if (props != null && parser != null)
        {
            Type argType = ArgumentBuilder.IDENTIFIERS[parser] ?? throw new KeyNotFoundException(parser);

            JsonNode? min = props["min"] ?? null;
            JsonNode? max = props["max"] ?? null;
            JsonNode? propType = props["type"] ?? null;
            JsonNode? entityAmount = props["amount"] ?? null;
            JsonNode? registry = props["registry"] ?? null;
            argumentProperties = new()
            {
                Parser = parser,
                Min = min?.ToJsonString() ?? null,
                Max = max?.ToJsonString() ?? null,
                Amount = entityAmount.Deserialize<string>() ?? null,
                Type = propType.Deserialize<string>() ?? null,
                Registry = registry.Deserialize<string>() ?? null
            };

            switch (argType.Name)
            {
                case nameof(Int):
                    {
                        int minValue = min != null ? min.Deserialize<int>() : int.MinValue;
                        int maxValue = max != null ? max.Deserialize<int>() : int.MaxValue;
                        argument = new Int(minValue, maxValue);
                        break;
                    }
                case nameof(Long):
                    {
                        long minValue = min != null ? min.Deserialize<long>() : long.MinValue;
                        long maxValue = max != null ? max.Deserialize<long>() : long.MaxValue;
                        argument = new Long(minValue, maxValue);
                        break;
                    }
                case nameof(Types.Entity):
                    {
                        string eType = propType != null ? propType.Deserialize<string>()! : string.Empty;
                        string eAmount = entityAmount != null ? entityAmount.Deserialize<string>()! : string.Empty;
                        argument = new Types.Entity(eAmount, eType);
                        break;
                    }
                case nameof(Float):
                    {
                        float minValue = min != null ? min.Deserialize<float>() : float.MinValue;
                        float maxValue = max != null ? max.Deserialize<float>() : float.MaxValue;
                        argument = new Float(minValue, maxValue);
                        break;
                    }
                case nameof(Types.Double):
                    {
                        double minValue = min != null ? min.Deserialize<double>() : double.MinValue;
                        double maxValue = max != null ? max.Deserialize<double>() : double.MaxValue;
                        argument = new Types.Double(minValue, maxValue);
                        break;
                    }
                case nameof(Types.String):
                    {
                        argument = new Types.String(Types.String.GetStringType(propType.Deserialize<string>()!));
                        break;
                    }
                case nameof(Resource):
                    {
                        argument = new Resource(registry.Deserialize<string>()!);
                        break;
                    }
                case nameof(ResourceOrTag):
                    {
                        argument = new ResourceOrTag(registry.Deserialize<string>()!);
                        break;
                    }
                case nameof(ScoreHolder):
                    {
                        argument = new ScoreHolder(entityAmount.Deserialize<string>()!);
                        break;
                    }
                case nameof(ResourceOrTagKey):
                    {
                        argument = new ResourceOrTagKey(registry.Deserialize<string>()!);
                        break;
                    }
                case nameof(ResourceKey):
                    {
                        argument = new ResourceKey(registry.Deserialize<string>()!);
                        break;
                    }
                case nameof(Time):
                    {
                        float minValue = min != null ? min.Deserialize<float>() : float.MinValue;
                        argument = new Time(minValue);
                        break;
                    }
                default:
                    throw new NotImplementedException();
            }

        }
        else if (parser != null)
        {
            Type argType = ArgumentBuilder.IDENTIFIERS[parser] ?? throw new NullReferenceException();
            argument = Activator.CreateInstance(argType) as BaseArgument ?? throw new NullReferenceException();
        }
        ArgumentNode node = new()
        {
            Properties = argumentProperties,
            Executable = executable
        };
        IEnumerable<ArgumentNode>? childNodes = children?.Select(JsonToNode);
        if (childNodes != null)
        {
            node.Children.AddRange(childNodes);
        }

        return node;
    }

    public static BaseArgument ParserToArgument(ArgumentPropties props)
    {
        string parser = props.Parser;
        //literal
        if (parser == "Literal")
        {
            return new Literal(props.Options!);
        }

        //check parser with args
        Type argType = ArgumentBuilder.IDENTIFIERS[parser] ?? throw new KeyNotFoundException(parser);

        string? min = props.Min;
        string? max = props.Max;
        string? registry = props.Registry;
        string? propType = props.Type;
        string? entityAmount = props.Amount;

        switch (argType.Name)
        {
            case nameof(Int):
                {
                    int minValue = min != null ? int.Parse(min) : int.MinValue;
                    int maxValue = max != null ? int.Parse(max) : int.MaxValue;
                    return new Int(minValue, maxValue);
                }
            case nameof(Long):
                {
                    long minValue = min != null ? long.Parse(min) : long.MinValue;
                    long maxValue = max != null ? long.Parse(max) : long.MaxValue;
                    return new Long(minValue, maxValue);
                }
            case nameof(Types.Entity):
                {
                    string eType = propType != null ? propType! : string.Empty;
                    string eAmount = entityAmount != null ? entityAmount! : string.Empty;
                    return new Types.Entity(eType, eAmount);
                }
            case nameof(Float):
                {
                    float minValue = min != null ? float.Parse(min) : float.MinValue;
                    float maxValue = max != null ? float.Parse(max) : float.MaxValue;
                    return new Float(minValue, maxValue);
                }
            case nameof(Types.Double):
                {
                    double minValue = min != null ? double.Parse(min) : double.MinValue;
                    double maxValue = max != null ? double.Parse(max) : double.MaxValue;
                    return new Types.Double(minValue, maxValue);
                }
            case nameof(Types.String):
                return new Types.String(Types.String.GetStringType(propType!));
            case nameof(Resource):
                return new Resource(registry!);
            case nameof(ResourceOrTag):
                return new ResourceOrTag(registry!);
            case nameof(ScoreHolder):
                return new ScoreHolder(entityAmount!);
            case nameof(ResourceOrTagKey):
                return new ResourceOrTagKey(registry!);
            case nameof(ResourceKey):
                return new ResourceKey(registry!);
            case nameof(Time):
                {
                    float minValue = min != null ? float.Parse(min) : float.MinValue;
                    return new Time(minValue);
                }
            default:
                break;
        }

        //other
        return Activator.CreateInstance(argType) as BaseArgument ?? throw new InvalidCastException();
    }
}