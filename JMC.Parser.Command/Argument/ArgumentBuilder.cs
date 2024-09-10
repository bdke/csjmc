using System.Reflection;

using JMC.Parser.Command.Datas;

namespace JMC.Parser.Command.Argument;

public class ArgumentBuilder
{
    public static readonly Dictionary<string, Type> IDENTIFIERS = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(type => type.GetCustomAttributes(typeof(ArgumentIdentifierAttribute), true).Length > 0)
        .Select(v =>
        {
            string attribute = v.GetAttributeValue<ArgumentIdentifierAttribute, string>(v => v.Identifier) ?? throw new ArgumentNullException(v.Name);
            return new KeyValuePair<string, Type>(attribute, v);
        })
        .ToDictionary();

    /// <summary>
    /// Builder commands from <see cref="MinecraftDbContext.CommandFiles"/>
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public static IEnumerable<ArgumentTree> BuildFromDatabase(string version)
    {
        using MinecraftDbContext database = MinecraftDbContext.Instance;
        Datas.Types.CommandFile result = database.CommandFiles.Where(v => v.Version == version).FirstOrDefault() ?? throw new KeyNotFoundException();
        List<ArgumentTree> data = ArgumentTree.CreateFromArticJson(result);
        foreach (ArgumentTree command in data)
        {
            yield return command;
        }
    }
}