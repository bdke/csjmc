namespace JMC.Parser.Command.DataComponent.Types.Item;
internal class Enchantment
{
    public class EnchantmentData
    {
        [SNBTName("id")]
        public required string Id { get; set; }
        [SNBTName("lvl")]
        public required string Level { get; set; }
    }
    public EnchantmentData[] Enchantments { get; set; } = [];
    public EnchantmentData[] StoreEnchantments { get; set; } = [];
    public int RepairCost { get; set; }
}
