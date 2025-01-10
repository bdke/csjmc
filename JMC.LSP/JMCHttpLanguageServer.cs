using EmmyLua.LanguageServer.Framework.Server;
using System.Net;

namespace JMC.LSP;
public sealed class JMCHttpLanguageServer(HttpListener listener, LanguageServer server) : JMCLanguageServer(server), IDisposable
{
    private readonly HttpListener _listener = listener;
    public void Dispose()
    {
        _listener.Close();
    }
}
