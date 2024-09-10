using JMC.Parser.Command.Argument.Property;

namespace JMC.Parser.Command.Argument.Helper;

internal static class TargetParser
{
    public enum SelectorType
    {
        Nearest = 'p',
        Random = 'r',
        All = 'a',
        AllEntities = 'e',
        Executer = 's'
    }

    public static TargetSelector? ParseSelector(string value, out CommandSyntaxError? syntaxError)
    {
        syntaxError = null;
        if (value.Length < 2 || (value.Length > 1 && !"parse".Contains(value[1])))
        {
            syntaxError = new();
            return null;
        }

        SelectorType selectorType = (SelectorType)value[1];
        string propsString = value[2..] ?? string.Empty;
        TargetSelector selector = new(selectorType, propsString);

        return selector;
    }
}