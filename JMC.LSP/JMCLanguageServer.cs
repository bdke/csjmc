using EmmyLua.LanguageServer.Framework.Protocol.Message.Initialize;
using EmmyLua.LanguageServer.Framework.Server;
using JMC.LSP.Handlers;
using System.Net;

namespace JMC.LSP;
public class JMCLanguageServer
{
    private readonly LanguageServer _server;

    protected JMCLanguageServer(LanguageServer server)
    {
        _server = server;
    }

    private static LanguageServer CreateStandardServer(Stream input, Stream output)
    {
        var server = LanguageServer.From(input, output);

        server.OnInitialize(OnInitialize);
        server.AddHandler(new TextDocumentHandler(server));
        server.AddHandler(new SemanticTokensHandler());

        return server;
    }

    public static async Task<JMCHttpLanguageServer> CreateHttpServerAsync(IPAddress host, int port)
    {
        var listener = new HttpListener();
        Uri uri = new($"{Uri.UriSchemeHttp}://{host}:{port}/");
        listener.Prefixes.Add(uri.ToString());

        listener.Start();
        var context = await listener.GetContextAsync();
        var input = context.Request.InputStream;
        var output = context.Response.OutputStream;

        return new JMCHttpLanguageServer(listener, CreateStandardServer(input, output));
    }

    public static Task<JMCPipeLanguageServer> CreatePipeServerAsync()
    {
        var input = Console.OpenStandardInput();
        var output = Console.OpenStandardOutput();
        var server = CreateStandardServer(input, output);
        return Task.FromResult(new JMCPipeLanguageServer(server));
    }

    private static Task OnInitialize(InitializeParams para, ServerInfo info)
    {
        info.Name = "JMC";
        info.Version = "1.0.0";
        Log.Information("Initialize");
        return Task.CompletedTask;
    }

    public async Task StartAsync()
    {
        await _server.Run();
    }
}
