using FluentCommand.Helpers;
using JMC.Console;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace JMC;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        var app = new CommandApp();
        var services = await ConfigureServicesAsync();
        
        app.Configure(options =>
        {
            options.AddCommand<JMCParserCommand>("parse");
        });

        return await app.RunAsync(args);
    }

    public static async ValueTask<IServiceProvider> ConfigureServicesAsync()
    {
        var services = new ServiceCollection();
        var dataService = await MinecraftDataService.GetDataServiceFactoryAsync();
        services.AddSingleton(dataService);
        return services.BuildServiceProvider();
    }
}