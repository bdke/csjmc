using System.ComponentModel;
using System.Reflection;

namespace FluentCommand.Helpers;
public static class EnumExtensions
{
    public static string GetEnumDescription(this Enum value)
    {
        DescriptionAttribute attr = value.GetType().GetCustomAttribute<DescriptionAttribute>() ?? throw new NullReferenceException();
        return attr.Description;
    }

    public static string[] GetAllDescriptionValues<T>() where T : struct, Enum
    {
        T[] values = Enum.GetValues<T>();
        return values.Select(v => v.GetEnumDescription()).ToArray();
    }
}