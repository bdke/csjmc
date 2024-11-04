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
            return await ParseJMCFileAsync(settings.FilePath) ? 1 : 0;
        }
        InvalidDataException error = new(settings.FilePath);
        AnsiConsole.WriteException(error);
        return 1;
    }

    private static async Task<bool> ParseJMCFileAsync(string filePath)
    {
        string content = await File.ReadAllTextAsync(filePath);
        JMCParser.ParseResult result = JMCParser.TryParse(content);

        if (!result.IsError)
        {
            //print tree
            Tree tree = result.Root.GetConsoleTree();
            AnsiConsole.Write(tree);
            return true;
        }

        //print errors
        IEnumerable<SyntaxErrorException> errors = result.Errors.Select(v => new SyntaxErrorException(v.ErrorMessage));
        AggregateException rootError = new(errors);
        AnsiConsole.WriteException(rootError);

        sly.lexer.LexicalError? lexError = JMCParser.TryGenerateTokens(content, out sly.lexer.TokenChannels<TokenType>? channels);
        IEnumerable<string> tokens = channels.GetChannel(0).Tokens
                .Select(v => v?.ToString() ?? string.Empty)
                .Where(v => !string.IsNullOrEmpty(v));
        string values = string.Join(Environment.NewLine, tokens);
        if (lexError != null)
        {
            AnsiConsole.WriteException(new InvalidProgramException(lexError.ErrorMessage));
            return false;
        }
        AnsiConsole.WriteLine(values);
        return false;
    }
}
