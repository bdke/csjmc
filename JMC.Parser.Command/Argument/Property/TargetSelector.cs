using JMC.Parser.Command.Argument.Helper;

using static JMC.Parser.Command.Argument.Helper.TargetParser;

namespace JMC.Parser.Command.Argument.Property;

internal class TargetSelector
{
    public record SelectorPropety(int KeyEndPos, string Key, int ValueEndPos, string Value);

    private string Value { get; }
    public SelectorType Type { get; }
    public IEnumerable<SelectorPropety> Propeties { get; }

    public TargetSelector(SelectorType type, string value)
    {
        Value = value;
        Type = type;
        Propeties = GetPropeties();
    }

    public bool IsSingle()
    {
        return Type is not SelectorType.All and not SelectorType.AllEntities ||
            Propeties.FirstOrDefault(v => v.Key is "amount" && v.Value is "1") != null;
    }

    public bool IsPlayers()
    {
        return Type is not SelectorType.AllEntities ||
            (Type is SelectorType.AllEntities && Propeties.FirstOrDefault(v => v.Key is "type" && v.Value is "players" or "minecraft:players") != null);
    }


    private IEnumerable<SelectorPropety> GetPropeties()
    {
        string tempKey = string.Empty;
        int tempKeyEndPos = -1;
        string tempValue = string.Empty;
        for (int i = 0; i < Value.Length; i++)
        {
            char currentValue = Value[i];

            bool isParsingNBT = currentValue == '{';

            if (!isParsingNBT && currentValue is '[' or ' ')
            {
                continue;
            }

            if (!isParsingNBT && currentValue == '=')
            {
                tempKey = tempValue.TrimStart().TrimEnd();
                tempKeyEndPos = i - 1;
                tempValue = string.Empty;
                continue;
            }
            if (isParsingNBT)
            {
                (int, string) nbtResult = Value[i..].ParseNBT();
                i += nbtResult.Item1;
                yield return new(tempKeyEndPos, tempKey, i, nbtResult.Item2);
                tempValue = string.Empty;
                continue;
            }
            else if (currentValue is ',' or ']')
            {
                yield return new(tempKeyEndPos, tempKey, i, tempValue.TrimStart().TrimEnd());
                tempValue = string.Empty;
                continue;
            }

            tempValue += currentValue;
        }
    }
}