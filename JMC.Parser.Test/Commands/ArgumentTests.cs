using JMC.Parser.Command.Argument;
using JMC.Parser.Command.Argument.Types;
using JMC.Parser.JMC;
using JMC.Parser.Test.Commands.TestCases;

using Xunit;

namespace JMC.Parser.Test.Commands
{
    [Collection("Argument")]
    public class ArgumentTests : IClassFixture<DatabaseFixture>
    {
        public record ArgumentTestCaseData(BaseArgument Argument, string Input, bool Succeed);

        #region Simple Tests
        public static PositionTestDatas AngleTestDatas => new(new Angle());
        public static PositionTestDatas BlockPosTestDatas => new(new BlockPos());
        public static ArgumentTestData BoolTestDatas => new(new Bool(), ["true", "false"], ["amogus"]);
        public static ArgumentTestData ColorTestDatas => new(new Color(), Color.OPTIONS, ["amogus"]);
        public static PositionTestDatas ColumnPosTestDatas => new(new ColumnPos(), true);
        public static ArgumentTestData ComponentTestDatas => new(new Component(), ComplexTestCases.ComponentValidDatas, ComplexTestCases.ComponentInvalidDatas);
        public static ResourceLocationTestDatas DimensionTestDatas => new(new Dimension(), true);
        public static ArgumentTestData DoubleTestDatas => new(new Command.Argument.Types.Double(), ["0.5", "-0.5", "-.5", ".5", "1234.5", "333"], ["amogus"]);
        public static ArgumentTestData EntitySinglePlayersTestDatas =>
            new(new Entity("single", "players"), ["@s", "@a[amount=1]", "@e[amount=1, type=players]", "@s[name=amogus]", "@p"], ["@a", "@"]);
        public static ArgumentTestData EntitySingleEntitiesTestDatas =>
            new(new Entity("single", "entities"), ["@s", "@a[amount=1]", "@e[amount=1]", "@s[name=amogus]", "@p", "@e[amount=1, type=players]"], ["@e", "@"]);
        public static ArgumentTestData EntityMultiplePlayersTestDatas =>
            new(new Entity("single", "players"), ["@s", "@a[amount=1]", "@e[amount=1, type=players]", "@s[name=amogus]", "@p"], ["@e", "@"]);
        public static ArgumentTestData EntityMultipleEntitiesTestDatas =>
            new(new Entity("single", "entities"), ["@s", "@a[amount=1]", "@e[amount=1]", "@s[name=amogus]", "@p"], ["@e", "@"]);
        public static ArgumentTestData EntityAnchorTestDatas => new(new EntityAnchor(), ["eyes", "feet"], ["amogus"]);
        public static ArgumentTestData FloatRangeTestDatas => new(new FloatRange(), ["0..5.2", "0", "-5.4", "-100.76..", "..100"], [".."]);
        public static ArgumentTestData GameProfileTestDatas => new(new GameProfile(), ["Player", "0123", "dd12be42-52a9-4a91-a8a1-11c01849e498", "@e"], ["@"]);
        public static ArgumentTestData GamemodeTestDatas => new(new Gamemode(), ["survival", "creative", "adventure", "spectator"], ["amogus"]);
        public static ArgumentTestData HeightmapTestDatas => new(new Heightmap(), Heightmap.HEIGHTMAP, ["amogus"]);
        public static ArgumentTestData IntRangeTestDatas => new(new IntRange(), ["0..5", "0", "-5", "-100..", "..100"], ["..", "1.5.."]);
        public static ArgumentTestData ItemSlotTestDatas => new(new ItemSlot(), ["container.5", "12", "weapon"], ["weapon.1", "weapon.amogus", "amogus", "12.2"]);
        public static ArgumentTestData MessageTestDatas => new(new Message(), ["when @s[name= red] is sus", "red is 'not' sus", "when @ is sus"], []);
        public static ArgumentTestData NBTCompoundTagDatas => new(new NBTCompoundTag(), ComplexTestCases.NBTCompoundValidDatas, ComplexTestCases.NBTCompoundInvalidDatas);
        public static ArgumentTestData NBTPathTestDatas => new(new NBTPath(), ["foo", "foo.bar", "foo[0]", "[0]", "[]", "{foo:bar}", "foo.bar[0].\"A [crazy name]\".baz."], ["amogus.[0"]);
        public static ArgumentTestData NBTTagTestDatas => new(new NBTTag(), ["0", "0b", "0l", "0.0", "\"foo\"", "{foo:bar}"], []);
        public static ArgumentTestData ObjectiveTestDatas => new(new Objective(), ["foo", "*", "123", "_"], ["amogus@innersoth"]);
        public static ArgumentTestData ObjectiveCriteriaTestDatas => new(new ObjectiveCriteria(), ComplexTestCases.ObjectiveCriteriaValidDatas, ComplexTestCases.ObjectiveCriteriaInvalidDatas);
        public static ArgumentTestData OperationTestDatas => new(new Operation(), ["=", "+=", "*=", "/=", "%=", "><", ">", "<"], ["--"]);
        public static ArgumentTestData ParticlesTestDatas => new(new Particle(), ["dust 0.1 0.2 0.3 1", "bubble_pop", "minecraft:bubble_pop"], ["amogus is sus"]);
        public static ArgumentTestData ResourceTestDatas => new(new Resource(string.Empty), ComplexTestCases.ResourceLocationValidDatas, ComplexTestCases.ResourceLocationInvalidDatas);
        public static ArgumentTestData ResourceKeyTestDatas => new(new ResourceKey(string.Empty), ComplexTestCases.ResourceLocationValidDatas, ComplexTestCases.ResourceLocationInvalidDatas);
        public static ArgumentTestData ResourceLocationTestDatas => new(new ResourceLocation(), ComplexTestCases.ResourceLocationValidDatas, ComplexTestCases.ResourceLocationInvalidDatas);
        public static ArgumentTestData ResourceOrTagTestDatas => new(new ResourceOrTag(string.Empty), ComplexTestCases.ResourceTagLocationValidDatas, ComplexTestCases.ResourceTagLocationInvalidDatas);
        public static ArgumentTestData ResourceOrTagKeyTestDatas => new(new ResourceOrTagKey(string.Empty), ComplexTestCases.ResourceTagLocationValidDatas, ComplexTestCases.ResourceTagLocationInvalidDatas);
        public static ArgumentTestData RotationTestDatas => new(new Rotation(), ["0 0", "~ ~", "~-5 ~-5"], ["~ 0", "^ ^", "^ 0", "0 ~"]);
        public static ArgumentTestData ScoreHolderSingleTestDatas => new(new ScoreHolder("single"), ["@s", "Player", "0123"], ["@e", "@@", "*"]);
        public static ArgumentTestData ScoreHolderMultipleTestDatas => new(new ScoreHolder("multiple"), ["@e", "*", "Player", "0123"], ["@@"]);
        public static ArgumentTestData ScoreboardSlotTestDatas => new(new ScoreboardSlot(), ["sidebar", "sidebar.team.black", "list", "below_name"], ["amogus"]);
        public static ArgumentTestData StyleTestDatas => new(new Style(), ["""{"bold":true}"""], ["""{bold:true}"""]);
        public static ArgumentTestData SwizzleTestDatas => new(new Swizzle(), ["x", "xz", "zyx", "yxz", "yz"], ["amogus"]);
        public static ArgumentTestData TeamTestDatas => new(new Team(), ["foo", "123", "sussy_baka", "red.is.sus"], ["@amogus"]);
        public static ArgumentTestData TemplateMirrorTestDatas => new(new TemplateMirror(), ["none", "front_back", "left_right"], ["amogus"]);
        public static ArgumentTestData TemplateRotationTestDatas => new(new TemplateRotation(), ["none", "clockwise_90", "counterclockwise_90", "180"], ["amogus"]);
        public static ArgumentTestData TimeTestDatas => new(new Time(0f), [".5d", "5s", "1.2t", "10"], ["-1", "amogus"]);
        public static ArgumentTestData UUIDTestDatas => new(new UUID(), ["dd12be42-52a9-4a91-a8a1-11c01849e498"], ["amogus"]);
        public static ArgumentTestData Vec2TestDatas => new(new Vec2(), ["0 0", "~ ~", "^ ^", "0.1 -0.5", "~.5 ~1.8"], ["^ ~"]);
        public static ArgumentTestData Vec3TestDatas => new(new Vec3(), ["0 0 0", "~ ~ ~", "^1 ^ ^-5", "0.1 -0.5 .9", "~.5 ~1.8 ~-5"], ["^ ~ 0.5", ".5 .5"]);
        #endregion

        #region Complex Tests
        public static ArgumentTestData BlockPredicateTests => new(new BlockPredicate(), ["stone", "minecraft:stone", "#stone", "barrel[facing=down]"], ["test"]);
        public static ArgumentTestData BlockStateTests => new(new BlockState(), ["stone", "minecraft:stone", "barrel[facing=down]"], ["test", "#stone"]);
        #endregion


        //TODO: Function, Item Predicate, Item Stack

        private static void TestArgument(ArgumentTestCaseData testData)
        {
            BaseArgument parser = testData.Argument;
            string[] splitArguments = JMCParser
                .SplitArguments(testData.Input)
                .ToDictionary()
                .Select(v => v.Value)
                .ToArray();

            bool result;
            try
            {
                result = parser.Parse(splitArguments).Succeed;
            }
            catch (ArgumentException)
            {
                result = false;
            }

            Assert.Equivalent(testData.Succeed, result);
        }

        [Theory]
        [MemberData(nameof(AngleTestDatas))]
        public void Angle_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(BlockPosTestDatas))]
        public void BlockPos_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(ColorTestDatas))]
        public void Color_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(ColumnPosTestDatas))]
        public void ColumnPos_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(ComponentTestDatas))]
        public void Component_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(EntityMultipleEntitiesTestDatas))]
        [MemberData(nameof(EntityMultiplePlayersTestDatas))]
        [MemberData(nameof(EntitySingleEntitiesTestDatas))]
        [MemberData(nameof(EntitySinglePlayersTestDatas))]
        public void Entity_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(EntityAnchorTestDatas))]
        public void EntityAnchor_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(FloatRangeTestDatas))]
        public void FloatRange_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(GameProfileTestDatas))]
        public void GameProfile_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(GamemodeTestDatas))]
        public void Gamemode_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(HeightmapTestDatas))]
        public void Heightmap_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(IntRangeTestDatas))]
        public void IntRange_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(ItemSlotTestDatas))]
        public void ItemSlot_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(MessageTestDatas))]
        public void Message_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(NBTCompoundTagDatas))]
        public void NBTCompoundTag_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(NBTPathTestDatas))]
        public void NBTPath_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(NBTTagTestDatas))]
        public void NBTTag_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(ObjectiveTestDatas))]
        public void Objective_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(ObjectiveCriteriaTestDatas))]
        public void ObjectiveCriteria_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(OperationTestDatas))]
        public void Operation_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(ParticlesTestDatas))]
        public void Particles_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(ResourceKeyTestDatas))]
        [MemberData(nameof(ResourceTestDatas))]
        [MemberData(nameof(ResourceLocationTestDatas))]
        public void ResourceLocation_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }


        [Theory]
        [MemberData(nameof(ResourceKeyTestDatas))]
        [MemberData(nameof(ResourceOrTagKeyTestDatas))]
        public void ResourceTagLocation_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(RotationTestDatas))]
        public void Rotation_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(ScoreHolderSingleTestDatas))]
        [MemberData(nameof(ScoreHolderMultipleTestDatas))]
        public void ScoreHolder_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(ScoreboardSlotTestDatas))]
        public void ScorebiardSlot_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(StyleTestDatas))]
        public void Style_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(SwizzleTestDatas))]
        public void Swizzle_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(TeamTestDatas))]
        public void Team_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(TemplateMirrorTestDatas))]
        public void TemplateMirror_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(TimeTestDatas))]
        public void Time_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(UUIDTestDatas))]
        public void UUID_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(Vec2TestDatas))]
        public void Vec2_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(Vec3TestDatas))]
        public void Vec3_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(BlockPredicateTests))]
        public void BlockPredicate_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }

        [Theory]
        [MemberData(nameof(BlockStateTests))]
        public void BlockState_Tests(ArgumentTestCaseData testData)
        {
            TestArgument(testData);
        }
    }
}
