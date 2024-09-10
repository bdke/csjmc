using JMC.Parser.Command.Argument;

namespace JMC.Parser.Test.Commands.TestCases
{
    public class ResourceLocationTestDatas(BaseArgument arg, bool requireNamespace = false) :
        ArgumentTestData(arg, GetValid(requireNamespace), GetInvalid(requireNamespace))
    {
        public static IEnumerable<string> GetValid(bool requireNamespace)
        {
            IEnumerable<string> requireNamespaceDatas = ["mincraft:amogus.drip", "mincraft:amogus-drip", "mincraft:red_is_sus", "mincraft:mincraft:sussy_mojang", "test:custom", "test:69420k"];
            IEnumerable<string> normalTestDatas = ["mincraft:amogus.drip", "mincraft:amogus-drip", "mincraft:red_is_sus", "mincraft:sussy_mojang", "test:custom", "69420k"];
            return requireNamespace ? requireNamespaceDatas : normalTestDatas;
        }

        public static IEnumerable<string> GetInvalid(bool requireNamespace)
        {
            IEnumerable<string> requireNamespaceDatas = ["minecraft:@amogus_drip", "!drip==pos", "amogus_drip", "--:drip"];
            IEnumerable<string> normalTestDatas = ["@amogus_drip", "!drip==pos", "amogus_drip", "--:drip"];
            return requireNamespace ? requireNamespaceDatas : normalTestDatas;
        }
    }
}
