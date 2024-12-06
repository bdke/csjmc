using JMC.Console;
using Microsoft.Extensions.Hosting;
using Spectre.Console.Cli;

namespace JMC;

internal sealed class Program
{
    private static async Task<int> Main(string[] args)
    {
        CommandApp app = new();
        var builder = Host.CreateApplicationBuilder();
        using var host = builder.Build();

        app.Configure(options =>
        {
            var unused = options.AddCommand<JMCParserCommand>("parse");
        });

        int result = await app.RunAsync(args);
        await host.RunAsync();
        return result;
    }
}