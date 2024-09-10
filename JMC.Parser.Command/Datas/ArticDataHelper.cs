using System.Net.NetworkInformation;

namespace JMC.Parser.Command.Datas;

internal static class ArticDataHelper
{
    public static bool CheckForInternetConnection()
    {
        using Ping ping = new();
        PingReply reply = ping.Send("www.google.com");
        return reply != null && reply.Status == IPStatus.Success;
    }

    public static async Task<string> GetArticJsonAsync(string version, params string[] path)
    {
        path = path.Select(v => $"{version.Replace('.', '_')}_{v}").ToArray();
        string pathUri = Path.Combine(path);
        UriBuilder uriBuilder = new(@$"https://raw.githubusercontent.com/Articdive/ArticData/{version}/");
        uriBuilder.Path += pathUri;

        HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync(uriBuilder.Uri);
        _ = response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
}