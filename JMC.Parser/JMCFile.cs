namespace JMC.Parser;
public readonly struct JMCFile(string filePath, JMCExpression root, JMCFileDetail detail)
{
    public readonly string FilePath => Path.GetFullPath(filePath);
    public readonly JMCExpression Root => root;
    public readonly JMCFileDetail Detail => detail;

    public readonly string FileName => Path.GetFileName(FilePath);
    public readonly string FileNameWithOutExtension => Path.GetFileNameWithoutExtension(FilePath);
}
