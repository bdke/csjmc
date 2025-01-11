using JMC.LSP;
using JMC.Shared;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Json;
using Serilog.Sinks.Spectre;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics;
using System.Net;

namespace JMC.Console;
public sealed class JMCServerCommand : AsyncCommand<JMCServerCommand.Settings>
{
    private LSPServices lspServices = default!;
    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
#if DEBUG
        while (!Debugger.IsAttached)
        {
            Debugger.Launch();
            await Task.Delay(100);
        }
#endif
        //setups
        var provider = new ServiceCollection()
            .AddMemoryCache()
            .BuildServiceProvider();
        lspServices = new(provider);
        //logging
        var domainPath = AppDomain.CurrentDomain.BaseDirectory;
        var logPath = Path.Join(domainPath, "Logs", "JMCExtension.log");
        AnsiConsole.Console = AnsiConsole.Create(new AnsiConsoleSettings()
        {
            Out = new AnsiConsoleOutput(System.Console.Error),
        });
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Async(o => o.File(logPath, rollingInterval: RollingInterval.Day))
            .WriteTo.Spectre(restrictedToMinimumLevel: LogEventLevel.Information)
            .MinimumLevel.Verbose()
            .CreateLogger();
        //handle exceptions
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

        //server
        JMCLanguageServer server = (ServerMode)settings.Mode == ServerMode.Http 
            ? await JMCLanguageServer.CreateHttpServerAsync(IPAddress.Parse(settings.Host), settings.Port)
            : await JMCLanguageServer.CreatePipeServerAsync();
        await server.StartAsync();
        return 0;
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Log.Fatal(e.ExceptionObject as Exception, "Unhandled exception during setup");
    }

    public override ValidationResult Validate(CommandContext context, Settings settings)
    {
        if (!IPAddress.TryParse(settings.Host, out _))
        {
            return ValidationResult.Error("Invalid Host");
        }
        if (!Enum.IsDefined((ServerMode)settings.Mode))
        {
            return ValidationResult.Error("Invalid Mode");
        }
        return ValidationResult.Success();
    }

    public sealed class Settings : CommandSettings
    {
        [CommandOption("-p|--port")]
        public int Port { get; set; } = 2007;
        [CommandOption("-h|--host")]
        public string Host { get; set; } = "127.0.0.1";
        [CommandOption("-m|--mode")]
        public byte Mode { get; set; } = (byte)ServerMode.Pipe;
    }

    public enum ServerMode : byte
    {
        Http = 0,
        Pipe = 2
    }
}
