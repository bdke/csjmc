using EmmyLua.LanguageServer.Framework.Protocol.JsonRpc;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Initialize;
using EmmyLua.LanguageServer.Framework.Server;
using JMC.LSP.Handlers;
using JMC.LSP.Types;
using System.Net;
using System.Text.Json;

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
        LanguageServer server = LanguageServer.From(input, output);

        server.OnInitialize(OnInitialize);
        LanguageServer unused1 = server.AddHandler(new TextDocumentHandler(server));
        LanguageServer unused = server.AddHandler(new SemanticTokensHandler());
        LanguageServer unused4 = server.AddHandler(new CompletionHandler());
        LanguageServer unused3 = server.AddHandler(new DocumentDiagnosticHandler(server));
        LanguageServer unused2 = server.AddHandler(new WorkspaceDiagnosticHandler());
        server.RegisterAllRequestMethods();

        return server;
    }

    public static async Task<JMCHttpLanguageServer> CreateHttpServerAsync(IPAddress host, int port)
    {
        HttpListener listener = new();
        Uri uri = new($"{Uri.UriSchemeHttp}://{host}:{port}/");
        listener.Prefixes.Add(uri.ToString());

        listener.Start();
        HttpListenerContext context = await listener.GetContextAsync();
        Stream input = context.Request.InputStream;
        Stream output = context.Response.OutputStream;

        return new JMCHttpLanguageServer(listener, CreateStandardServer(input, output));
    }

    public static Task<JMCPipeLanguageServer> CreatePipeServerAsync()
    {
        Stream input = Console.OpenStandardInput();
        Stream output = Console.OpenStandardOutput();
        LanguageServer server = CreateStandardServer(input, output);
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
