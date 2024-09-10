namespace JMC.Parser.Test.Commands.TestCases
{
    internal static class ComplexTestCases
    {
        public static IEnumerable<string> ComponentInvalidDatas => [];

        public static IEnumerable<string> ComponentValidDatas
        {
            get
            {
                yield return """{amogus:"test"}""";
                yield return """{amogus:test}""";
                yield return """{"amogus":test}""";
                yield return "0.1";
                yield return @"""amogus""";
            }
        }

        public static IEnumerable<string> NBTCompoundInvalidDatas => [];
        public static IEnumerable<string> NBTCompoundValidDatas => ["""{amogus:"test"}""", """{amogus:test}""", """{"amogus":test}"""];

        public static IEnumerable<string> ObjectiveCriteriaValidDatas => ["teamkill.black", "custom:bell_ring", "dummy", "minecraft.custom:open_chest", "minecraft:air", "killed:minecraft.zombie"];
        public static IEnumerable<string> ObjectiveCriteriaInvalidDatas => ["amogus:test", "innersoth", "minecraft.used:minecraft.amogus"];

        public static IEnumerable<string> ResourceLocationValidDatas => ["foo", "foo:bar", "012"];
        public static IEnumerable<string> ResourceLocationInvalidDatas => ["minecraft:@amogus", "#skeletons", "#minecraft:skeletons"];

        public static IEnumerable<string> ResourceTagLocationValidDatas => ["foo", "foo:bar", "012", "#skeletons", "#minecraft:skeletons"];
        public static IEnumerable<string> ResourceTagLocationInvalidDatas => ["minecraft:@amogus"];
    }
}
