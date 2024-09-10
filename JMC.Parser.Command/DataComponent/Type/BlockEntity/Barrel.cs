namespace JMC.Parser.Command.DataComponent.Type.BlockEntity;
internal class Barrel : BaseBlockEntity
{
    public class ContainerItem
    {
        public required sbyte Slot { get; set; }
        [SNBTName("id")]
        public required string Id { get; set; }
        [SNBTName("count")]
        public int Count { get; set; } = 1;
        [SNBTName("components")]
        public List<IDataComponent> DataComponents { get; set; } = [];
    }
    public string CustomName { get; set; } = string.Empty;
    public string? Lock { get; set; } = null;
    public string? LootTable { get; set; } = null;
    public long? LootTableSeed { get; set; } = null;
}
