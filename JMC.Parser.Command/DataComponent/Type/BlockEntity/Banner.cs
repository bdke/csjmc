namespace JMC.Parser.Command.DataComponent.Type.BlockEntity;
internal class Banner : BaseBlockEntity
{
    public class Pattern
    {
        public class BannerPattern
        {
            [SNBTName("asset_id")]
            public required string AssetId { get; set; }
            [SNBTName("translation_key")]
            public required string TranslationKey { get; set; }
        }
        [SNBTName("color")]
        public required string Color { get; set; }
        [SNBTName("pattern")]
        public required BannerPattern[] Patterns { get; set; }
        public string CustomName { get; set; } = string.Empty;
    }
    public string? CustomName { get; set; }
    public required Pattern[] Patterns { get; set; }
}
