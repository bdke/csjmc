namespace JMC.Shared;
public abstract class FileDocument(string rawText)
{
    public required string FilePath { get; set; }
    public required string FileName { get; set; }
    public string RawText { get; set; } = rawText;
}
