using Microsoft.EntityFrameworkCore;

namespace JMC.Parser.Command.Datas;

internal static class DbHelper
{
    public static IEnumerable<T> WithVersion<T>(this DbSet<T> dbSet, string version) where T : class, IMinecraftDbData<T>
    {
        ILookup<string, T> lookup = dbSet.ToLookup(v => v.Version, v => v);
        IEnumerable<T> result = lookup[version];
        return result;
    }
}
