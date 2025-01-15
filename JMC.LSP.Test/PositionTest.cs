using EmmyLua.LanguageServer.Framework.Protocol.Model;
using JMC.LSP.Helpers;
using JMC.Shared.Helpers;

namespace JMC.LSP.Test;

public class PositionTest
{
    [Fact]
    public void PositonConvertToOffset_Test()
    {
        var text = $"idk{Environment.NewLine}idk";
        var pos = new Position(1,1);
        var targetOffset = 3 + Environment.NewLine.Length + 1;
        var actualOffset = pos.ToOffset(text);
        Assert.Equal(targetOffset, actualOffset);
    }

    [Fact]
    public void RangeContains_test()
    {
        var range = new DocumentRange(new(1, 2), new(2, 2));
        var pos1 = new Position(2,1);
        var pos2 = new Position(1,3);
        var r1 = range.Contains(pos1);
        var r2 = range.Contains(pos2);
        Assert.True(r1);
        Assert.True(r2);
    }
}
