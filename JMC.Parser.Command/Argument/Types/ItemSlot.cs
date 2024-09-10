namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:item_slot")]
internal class ItemSlot : BaseArgument
{
    private static readonly string[] SLOTS = ["armor.chest", "armor.feet", "armor.head", "armor.legs", "weapon", "weapon.mainhand", "weapon.offhand", "horse.saddle", "horse.chest", "horse.armor"];


    public override IParseResult Parse(params string[] arguments)
    {
        _ = base.Parse(arguments);
        string slot = arguments[0];
        CommandParseResult result = new(CommandTokenType.ItemSlot, this);
        if (SLOTS.Contains(slot))
        {
            return result;
        }

        if (int.TryParse(slot, out int slotIndex))
        {
            switch (slotIndex)
            {
                case >= 0 and <= 53:
                case >= 98 and <= 103:
                case 105:
                case >= 200 and <= 226:
                case >= 300 and <= 307:
                case 400:
                case 409:
                case >= 500 and <= 514:
                    return result;
            }
        }

        string[] splitString = slot.Split('.');
        if (splitString.Length <= 1)
        {
            return new ParseError(new CommandSyntaxError());
        }

        switch (splitString[0])
        {
            case "container" when int.TryParse(splitString[1], out slotIndex) && slotIndex is >= 0 and <= 53:
            case "enderchest" when int.TryParse(splitString[1], out slotIndex) && slotIndex is >= 0 and <= 26:
            case "hotbar" when int.TryParse(splitString[1], out slotIndex) && slotIndex is >= 0 and <= 8:
            case "inventory" when int.TryParse(splitString[1], out slotIndex) && slotIndex is >= 0 and <= 26:
            case "horse" when int.TryParse(splitString[1], out slotIndex) && slotIndex is >= 0 and <= 14:
            case "villager" when int.TryParse(splitString[1], out slotIndex) && slotIndex is >= 0 and <= 7:
                return result;
            default:
                return new ParseError(new CommandSyntaxError());
        }
    }
}