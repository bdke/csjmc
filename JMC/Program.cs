using JMC.Console;
using Spectre.Console.Cli;

namespace JMC;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        var app = new CommandApp();
        
        app.Configure(options =>
        {
            options.AddCommand<JMCParserCommand>("parse");
        });
        
        var result = await app.RunAsync(args);
        await DisposeSingletonsAsync();
        return result;
    }

    private static async Task DisposeSingletonsAsync()
    {
    }
}