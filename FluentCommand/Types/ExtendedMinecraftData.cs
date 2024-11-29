namespace FluentCommand.Types;
public readonly struct ExtendedMinecraftData
{
    public readonly required ReadOnlyMemory<string> CustomStatistics { get; init; }
}
