using EmmyLua.LanguageServer.Framework.Protocol.Model;
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
}
