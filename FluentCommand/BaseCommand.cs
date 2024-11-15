using FluentCommand.Arguments;

namespace FluentCommand;
public abstract class BaseCommand(string rootCommand)
{
    protected List<BaseArgument> _buildingArgs = [];
    public string RootCommand => rootCommand;

    protected BaseCommand Argument(BaseArgument arg)
    {
        if (!arg.IsValidValue)
        {
            throw new InvalidOperationException($"Invalid value {arg.Value} for {arg.GetType().Name}");
        }
        _buildingArgs.Add(arg);
        return this;
    }

    protected BaseCommand Keyword(string word)
    {
        return Argument(new Keyword(word));
    }

    public string Build()
    {
        return string.Join(' ', _buildingArgs.Select(v => v.Value));
    }
}
