namespace JMC.Parser.Command.DataComponent.Types.Item;
internal class DisplayProperty
{
    public class DisplayData
    {
        public required string Name { get; set; }
        public required string[] Lore { get; set; }
    }
    [SNBTName("display")]
    public required DisplayData DisplayPropeties { get; set; }
    public required int HideFlags { get; set; }
    public required int CustomModelData { get; set; }

}
