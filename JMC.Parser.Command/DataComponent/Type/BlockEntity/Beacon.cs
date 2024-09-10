namespace JMC.Parser.Command.DataComponent.Type.BlockEntity;
internal class Beacon : BaseBlockEntity
{
    public string? CustomName { get; set; }
    public string? Lock { get; set; }
    [SNBTName("primary_effect")]
    public string? PrimaryEffect { get; set; }
    [SNBTName("secondary_effect")]
    public string? SecondaryEffect { get; set; }
}
