using System.ComponentModel;
using System.Reflection;

namespace JMC.Shared.Helpers;
public static class EnumExtensions
{
    public static string GetEnumDescription<T>(this T value) where T : struct, Enum
    {
        var attrs = value.GetType().GetCustomAttributes();

        DescriptionAttribute attr = value.GetType().GetCustomAttribute<DescriptionAttribute>() ?? throw new NullReferenceException();
        return attr.Description;
    }

    public static string[] GetAllDescriptionValues<T>() where T : struct, Enum
    {
        T[] values = Enum.GetValues<T>();
        return values.Select(v => v.GetEnumDescription()).ToArray();
    }
}