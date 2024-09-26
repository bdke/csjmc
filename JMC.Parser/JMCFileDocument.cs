using JMC.Parser.Models;
using JMC.Shared;

namespace JMC.Parser;
public class JMCFileDocument : FileDocument
{
    public required SyntaxTree SyntaxTree { get; set; }
}
