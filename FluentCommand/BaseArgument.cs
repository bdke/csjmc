using FluentCommand.Helpers;

namespace FluentCommand;
public abstract class BaseArgument()
{
    public abstract string Value { get; }
    internal abstract bool IsValidValue { get; }

    protected static readonly string[] _customStats = MinecraftDataService.Transient.ExtendedData.CustomStatistics.ToArray();
}
