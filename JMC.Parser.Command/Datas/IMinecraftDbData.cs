using System.ComponentModel.DataAnnotations;

namespace JMC.Parser.Command.Datas;

internal interface IMinecraftDbData<T>
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Version { get; set; }

    public static abstract Task<List<T>> FromArticAsync(string version);
}