using FluentCommand.Arguments;

namespace FluentCommand;

public sealed class Scoreboard() : BaseCommand("scoreboard")
{
    public static string AddObjective(string objName, string criteria, string? displayName)
    {
        var s = new Scoreboard();
        return s.Keyword("objectives")
            .Keyword("add")
            .Argument(new Objective(objName))
            .Build();
    }
}
