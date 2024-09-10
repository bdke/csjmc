using System.ComponentModel.DataAnnotations;

namespace JMC.Parser.Command.Datas.Types;

public class CommandFile(string version, string jsonText) : IMinecraftDbData<CommandFile>
{
    [Key]
    public int Id { get; set; }
    public string Version { get; set; } = version;
    public string JsonText { get; set; } = jsonText;
    public static async Task<List<CommandFile>> FromArticAsync(string version)
    {
        string json = await ArticDataHelper.GetArticJsonAsync(version, "commands.json");
        return [new(version, json)];
    }
}
