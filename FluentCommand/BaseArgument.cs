
using JMC.Shared;

namespace FluentCommand;
public abstract class BaseArgument()
{
    public abstract string Value { get; }
    internal abstract bool IsValidValue { get; }

    protected static readonly string[] _customStats = Config.ExtendedMinecraftData.CustomStatistics.ToArray();
}
