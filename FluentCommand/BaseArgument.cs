namespace FluentCommand;
public abstract class BaseArgument()
{
    public abstract string Value { get; }
    internal abstract bool IsValidValue { get; }
}
