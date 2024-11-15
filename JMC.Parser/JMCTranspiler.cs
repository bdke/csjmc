namespace JMC.Parser;
public sealed class JMCTranspiler(params JMCFile[] files)
{
    public readonly ReadOnlyMemory<JMCFile> _files = files;
    public ReadOnlySpan<JMCFile> Files => _files.Span;

    private readonly List<Task> _generationTasks = [];
    private readonly CancellationTokenSource _cts = new();

    public void TranspileAllFiles()
    {
        foreach (var file in Files)
        {
            TranspileFile(file);
        }
    }

    public void TranspileFile(JMCFile file)
    {

    }

    public async Task GenerateScoreboards()
    {

    }

    public async Task GenerateFilesAsync()
    {
        await Task.WhenAll(_generationTasks);
    }

    public void CancelFileGeneration()
    {
        _cts.Cancel();
    }
}
