namespace JMC.Shared;
public abstract class FileDocument
{
    public required string FilePath { get; set; }
    public required string FileName { get; set; }
    public required string RawText { get; set; }
}
