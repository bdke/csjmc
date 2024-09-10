using System.Collections.ObjectModel;

using JMC.Parser.Command.Datas;

namespace JMC.Parser.Command.Argument.Property;

public class BlockPropety
{
    private readonly string _propetyString;
    public ReadOnlyDictionary<string, string> Properties { get; private set; }
    public BlockPropety(string str)
    {
        _propetyString = str;
        Properties = new(ToKeyValues(_propetyString));
    }

    public static bool CheckValidity(string blockValue, KeyValuePair<string, string> valuePair)
    {
        using MinecraftDbContext database = MinecraftDbContext.Instance;
        ILookup<string, Datas.Types.BlockPropety> propLookup = database.BlockPropetiesLookUp;
        ILookup<string, Datas.Types.Block> blockLookup = database.BlockLookUp;
        if (!blockLookup.Contains($"minecraft:{blockValue}"))
        {
            throw new ArgumentException(blockValue);
        }
        if (!propLookup.Contains(valuePair.Key))
        {
            return false;
        }
        Datas.Types.BlockPropety lookupResult = propLookup[valuePair.Key].First();
        Datas.Types.Block blockProps = blockLookup[$"minecraft:{blockValue}"].First();
        if (!blockProps.PropetiesDictKey.Contains(lookupResult.DictKey))
        {
            return false;
        }

        string value = valuePair.Value.ToUpperInvariant();
        return lookupResult.Values.Contains(value);
    }

    private static Dictionary<string, string> ToKeyValues(string propetyString)
    {
        Dictionary<string, string> dict = [];

        //remove brackets
        propetyString = propetyString[1..^1];

        string tempKey = string.Empty;
        string tempValue = string.Empty;
        bool isInKey = true;

        for (int i = 0; i < propetyString.Length; i++)
        {
            char currentChar = propetyString[i];

            switch (currentChar)
            {
                case '=':
                    isInKey = false;
                    continue;
                case ',':
                    isInKey = true;
                    dict.Add(tempKey, tempValue);
                    tempKey = string.Empty;
                    tempValue = string.Empty;
                    continue;
            }

            if (isInKey)
            {
                tempKey += currentChar;
            }
            else
            {
                tempValue += currentChar;
            }

            if (propetyString.Length == i + 1)
            {
                dict.Add(tempKey, tempValue);
            }
        }

        return dict;
    }
}