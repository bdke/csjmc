using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace JMC.LSP;
public sealed class LSPServices
{
    public static LSPServices Instance { get; private set; } = default!;
    private readonly ServiceProvider _serviceProvider;
    public static IMemoryCache MemoryCache => Instance._serviceProvider.GetService<IMemoryCache>() ?? throw new NullReferenceException();
    public LSPServices(ServiceProvider serviceProvider)
    {
        Instance = this;
        _serviceProvider = serviceProvider;
    }

    public static T GetService<T>()
    {
        return Instance._serviceProvider.GetService<T>() ?? throw new NullReferenceException();
    }
}
