using JMC.Parser;
using JMC.Parser.Helper;
using Serilog;
using Serilog.Sinks.Spectre;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Data;

namespace JMC.Console;

public sealed class JMCParserCommand : AsyncCommand<JMCParserCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandArgument(0, "<file>")]
        public string FilePath { get; set; } = string.Empty;
    }

    public override ValidationResult Validate(CommandContext context, Settings settings)
    {
        return settings.FilePath.EndsWith(".jmc") || settings.FilePath == "jmcconfig.json"
            ? ValidationResult.Success()
            : ValidationResult.Error($"Unknown file type {settings.FilePath}");
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Spectre(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
            .WriteTo.File("Log", Serilog.Events.LogEventLevel.Debug, rollingInterval: RollingInterval.Day)
            .WriteTo.File("DetailedLog", Serilog.Events.LogEventLevel.Verbose, rollingInterval: RollingInterval.Hour)
            .CreateLogger();

        if (settings.FilePath.EndsWith(".jmc"))
        {
            var content = await File.ReadAllTextAsync(settings.FilePath);
            var result = JMCParser.TryParse(content);
            if (result.IsError)
            {
                var errors = result.Errors.Select(v => new SyntaxErrorException(v.ErrorMessage));
                var rootError = new AggregateException(errors);
                AnsiConsole.WriteException(rootError);

                var lexError = JMCParser.TryGenerateTokens(content, out var channels);
                var tokens = channels.GetChannel(0).Tokens
                    .Select(v => v?.ToString() ?? string.Empty)
                    .Where(v => !string.IsNullOrEmpty(v));
                var values = string.Join(Environment.NewLine, tokens);
                if (lexError != null)
                    AnsiConsole.WriteException(new InvalidProgramException(lexError.ErrorMessage));
                AnsiConsole.WriteLine(values);
                return 1;
            }
            var tree = result.Root.GetConsoleTree();
            AnsiConsole.Write(tree);
        }

        return 0;
    }
}
