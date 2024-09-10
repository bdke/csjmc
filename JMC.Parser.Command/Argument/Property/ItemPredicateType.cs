using JMC.Parser.Command.Datas;

namespace JMC.Parser.Command.Argument.Property;

public sealed class ItemPredicateType
{
    public required string? Namespace { get; set; }
    public required string Type { get; set; }
    public required bool IsTag { get; set; }

    public static ItemPredicateType? CreateFromString(string rawString, out List<BaseError> errors)
    {
        errors = [];

        if (rawString == "*")
        {
            return new() { IsTag = false, Namespace = null, Type = "*" };
        }

        bool isTag = rawString.StartsWith('#');
        string[] splitString = rawString.Split(':');

        string? @namespace = splitString.Length == 2 ? splitString[0] : null;
        string type = splitString.Length == 2 ? splitString[1] : splitString[0];
        string value = isTag ? type[1..] : type;

        using MinecraftDbContext database = MinecraftDbContext.Instance;
        if (!database.ItemLookUp.Contains(value))
        {
            errors.Add(new ValueError());
        }

        return new()
        {
            Namespace = @namespace,
            IsTag = isTag,
            Type = value,
        };
    }
}
