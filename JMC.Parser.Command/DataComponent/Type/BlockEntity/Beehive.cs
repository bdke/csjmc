namespace JMC.Parser.Command.DataComponent.Type.BlockEntity;
internal class Beehive : BaseBlockEntity
{
    public class Bee
    {
        [SNBTName("min_ticks_in_hive")]
        public int MinTicksInHive { get; set; }
        [SNBTName("TicksInHive")]
        public int TicksInHive { get; set; }
        //TODO:
    }
    [SNBTName("flower_pos")]
    public int[] FlowerPos { get; set; } = new int[3];
    //TODO:
}
