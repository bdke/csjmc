using FluentAssertions;

using JMC.Parser.Command.Argument.Helper;

using Xunit;

namespace JMC.Parser.Test.Commands
{
    [Collection("Helper")]
    public class HelperTests : IClassFixture<DatabaseFixture>
    {
        [Fact]
        public void CommandValueParser_Tests()
        {
            //block Names
            _ = CommandValueParser.ParseBlock("#stone", out _).BlockName.IsTag.Should().BeTrue();
            _ = CommandValueParser.ParseBlock("stone", out _).BlockName.IsTag.Should().BeFalse();
            _ = CommandValueParser.ParseBlock("stone", out _).BlockName.Namespace.Should().Be("minecraft");
            _ = CommandValueParser.ParseBlock("minecraft:stone", out _).BlockName.Namespace.Should().Be("minecraft");
            _ = CommandValueParser.ParseBlock("amogus:stone", out _).BlockName.Namespace.Should().Be("amogus");
            _ = CommandValueParser.ParseBlock("minecraft:stone", out _).BlockName.BlockValue.Should().Be("stone");
            _ = CommandValueParser.ParseBlock("amogus:red", out List<Shared.BaseError>? errors);
            _ = errors.Should().BeEmpty();
            _ = CommandValueParser.ParseBlock("red", out errors);
            _ = errors.Should().NotBeEmpty();

            //block properties
            _ = CommandValueParser.ParseBlock("barrel[facing=down]", out _).BlockPropety?.Properties.ElementAt(0)
                .Should()
                .BeEquivalentTo(new KeyValuePair<string, string>("facing", "down"));

            _ = CommandValueParser.ParseBlock("barrel[facing=amogus]", out errors).BlockPropety?.Properties.ElementAt(0);
            _ = errors.Should().NotBeEmpty();

            _ = CommandValueParser.ParseBlock("barrel[amogus=amogus]", out errors).BlockPropety?.Properties.ElementAt(0);
            _ = errors.Should().NotBeEmpty();

            _ = CommandValueParser.ParseBlock("barrel[facing=down , open=true]", out _).BlockPropety?.Properties
                .Should()
                .HaveCount(2);

            _ = CommandValueParser.ParseBlock("barrel[age=0]", out errors);
            _ = errors.Should().NotBeEmpty();
        }
    }
}
