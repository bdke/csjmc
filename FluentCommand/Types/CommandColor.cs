using System.ComponentModel;

namespace FluentCommand.Types;
public enum CommandColor
{
    [Description("black")]
    Black,
    [Description("dark_blue")]
    DarkBlue,
    [Description("dark_green")]
    DarkGreen,
    [Description("dark_aqua")]
    DarkAqua,
    [Description("dark_red")]
    DarkRed,
    [Description("dark_purple")]
    DarkPurple,
    [Description("gold")]
    Gold,
    [Description("gray")]
    Gray,
    [Description("dark_gray")]
    DarkGray,
    [Description("blue")]
    Blue,
    [Description("green")]
    Green,
    [Description("aqua")]
    Aqua,
    [Description("red")]
    Red,
    [Description("light_purple")]
    LightPurple,
    [Description("yellow")]
    Yellow,
    [Description("white")]
    White
}
