using System.ComponentModel.DataAnnotations;

namespace JMC.Parser.Command.Argument;

public class ArgumentPropties()
{
    public required string Parser { get; set; }
    public string? Min { get; set; }
    public string? Max { get; set; }
    public string? Registry { get; set; }
    public string? Type { get; set; }
    public string? Amount { get; set; }
    public string[]? Options { get; set; }
    [Key]
    public int Id { get; set; }
}