namespace JMC.Parser.Command.Argument.Property;

internal class Item
{
    public string ResourceLocation { get; set; }
    public string ItemId { get; set; }
    public ItemDataTag DataTag { get; set; }
    public List<CommandSyntaxError> SyntaxErrors { get; set; } = [];
    public bool IsTag;

    public Item(string rawString)
    {
        if (rawString.Count(v => v is '{') != rawString.Count(v => v is '}'))
        {
            SyntaxErrors.Add(new());
        }

        IsTag = rawString.StartsWith('#');

        string itemString = string.Empty;
        int i = 0;
        for (; i < rawString.Length; i++)
        {
            char s = rawString[i];
            if (s != '{')
            {
                itemString += s;
            }
            else
            {
                break;
            }
        }
        string dataTagString = rawString[i..];

        string[] splitItemString = itemString.Split(":");
        ResourceLocation = splitItemString.Length == 1 ? "minecraft" : splitItemString[0];
        ItemId = splitItemString[^1];
        DataTag = new(dataTagString);
    }

    public Item(string itemId, ItemDataTag dataTag, string resourceLocation = "minecraft")
    {
        ResourceLocation = resourceLocation;
        ItemId = itemId;
        DataTag = dataTag;
    }
}