namespace JMC.Parser.Command.DataComponent.Types.Item;
internal class AttributeModifier : IDataComponent
{
    public class ModifierData
    {
        public required string AttributeName { get; set; }
        public required string Name { get; set; }
        public required string Slot { get; set; }
        public required int Operation { get; set; }
        public required string UUID { get; set; }
    }
    public required ModifierData[] AttributeModifiers { get; set; }
}
