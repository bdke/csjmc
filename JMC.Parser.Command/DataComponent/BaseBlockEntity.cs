namespace JMC.Parser.Command.DataComponent;
internal class BaseBlockEntity
{
    [SNBTName("id")]
    public required string Id { get; set; }
    [SNBTName("keepPacked")]
    public required bool KeepPacked { get; set; }
    [SNBTName("x")]
    public required int X { get; set; }
    [SNBTName("y")]
    public required int Y { get; set; }
    [SNBTName("z")]
    public required int Z { get; set; }
    [SNBTName("components")]
    public List<IDataComponent> DataComponents { get; set; } = [];
}
