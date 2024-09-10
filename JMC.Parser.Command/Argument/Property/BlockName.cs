using JMC.Parser.Command.Datas;

namespace JMC.Parser.Command.Argument.Property;

public class BlockName
{
    public BlockName(string str)
    {
        RawString = str;
        IsTag = str.StartsWith('#');
        string[] splitColon = str.Split(':');
        Namespace = splitColon.Length > 1 ? splitColon[0] : "minecraft";
        BlockValue = splitColon.Length > 1 ? splitColon[1] : splitColon[0];
        BlockValue = IsTag ? BlockValue[1..] : BlockValue;
    }

    public string RawString { get; private set; }
    public string Namespace { get; private set; }
    public string BlockValue { get; private set; }
    public bool IsTag { get; private set; } = false;

    public static bool Exists(string blockName)
    {
        using MinecraftDbContext database = MinecraftDbContext.Instance;
        return database.BlockLookUp.Contains($"minecraft:{blockName}");
    }
}