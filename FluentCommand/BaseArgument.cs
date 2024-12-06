namespace FluentCommand;
public abstract class BaseArgument()
{

    public abstract string Value { get; }
    internal abstract bool IsValidValue { get; }

    //TODO
    protected static readonly string[] _customStats = [];
}
