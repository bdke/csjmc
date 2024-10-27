using JMC.Parser;
using JMC.Parser.Helper;

namespace JMC;

internal class Program
{
    private static int Main(string[] args)
    {
        string text = File.ReadAllText("test.jmc");
        var result = JMCParser.TryParse(text);
        if (result.IsError)
        {
            foreach (sly.parser.ParseError error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return 1;
        }

        result.Root.PrintTree();
        return 0;
    }
}