using Bertie.SNBT.Parser.NBT;
using Bertie.SNBT.Parser.Parsers;

using JMC.Parser.Command.Argument.Property;

namespace JMC.Parser.Command.Argument.Helper;

public static class CommandValueParser
{
    public record BlockInfo(BlockName BlockName, BlockPropety? BlockPropety, NbtCompound? Nbt);
    public static BlockInfo ParseBlock(string blockString, out List<BaseError> errors)
    {
        Span<char> blockStringSpan = stackalloc char[blockString.Length];
        blockString.AsSpan().CopyTo(blockStringSpan);
        errors = [];

        string blockValueString = string.Empty;
        int i = 0;
        //parse blockname
        for (; i < blockStringSpan.Length; i++)
        {
            ref char currentChar = ref blockStringSpan[i];
            if (currentChar is '[' or '{')
            {
                break;
            }
            if (char.IsWhiteSpace(currentChar))
            {
                continue;
            }

            blockValueString += currentChar;
        }
        BlockName blockName = new(blockValueString);
        if (!BlockName.Exists(blockName.BlockValue) && blockName.Namespace == "minecraft")
        {
            errors.Add(new ValueError());
        }

        string stateValue = string.Empty;
        //parse state
        for (; i < blockStringSpan.Length; i++)
        {
            ref char currentChar = ref blockStringSpan[i];
            if (currentChar is '{')
            {
                break;
            }
            if (i + 1 == blockString.Length && currentChar is not ']')
            {
                errors.Add(new CommandSyntaxError());
            }

            stateValue += currentChar;
        }
        BlockPropety? blockPropety = stateValue == string.Empty ? null : new(stateValue);
        if (blockPropety != null && !blockPropety.Properties.All(v => BlockPropety.CheckValidity(blockName.BlockValue, v)))
        {
            errors.Add(new ValueError());
        }

        if (i == blockString.Length)
        {
            return new(blockName, blockPropety, null);
        }

        //parse snbt
        string snbtString = blockString[i..];
        NbtTagParser parser = new();
        NbtCompound? nbt = null;
        int pos = 0;
        try
        {
            nbt = parser.Parse(snbtString, ref pos).As<NbtCompound>();
        }
        catch (ArgumentException)
        {
            errors.Add(new CommandSyntaxError());
        }

        return new(blockName, blockPropety, nbt);
    }

    public record ItemPredicateInfo(ItemPredicateType ItemType, ItemPredicateTest[] Tests);
    public static ItemPredicateInfo ParseItemPredicate(string predicateString)
    {
        Span<char> stringSpan = stackalloc char[predicateString.Length];
        predicateString.AsSpan().CopyTo(stringSpan);

        string typeString = string.Empty;
        int i = 0;
        for (; i < stringSpan.Length; i++)
        {
            ref char currentChar = ref stringSpan[i];

            if (currentChar is '[')
            {
                break;
            }

            typeString += currentChar;
        }

        string testsString = stringSpan[i..].ToString() ?? string.Empty;

        ItemPredicateType type = ItemPredicateType.CreateFromString(typeString, out _) ?? throw new NullReferenceException();
        IEnumerable<ItemPredicateTest> tests = ItemPredicateTest.CreateArrayFromString(predicateString, out _);
        return new(type, tests.ToArray());
    }
}