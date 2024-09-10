using JMC.Parser.Command.Datas.Types;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JMC.Parser.Command.Datas;

public class MinecraftDbContextFactory : IDbContextFactory<MinecraftDbContext>
{
    public MinecraftDbContext CreateDbContext()
    {
        MinecraftDbContext db = new();
        if (db.Database.EnsureCreated())
        {
            db.Seed(MinecraftDbContext.SUPPORTED_VERSION);
        }
        db.ChangeVersion(MinecraftDbContext.SUPPORTED_VERSION[0]);
        return db;
    }
}

public class MinecraftDbContext : DbContext, IInitializeClass
{
    public static readonly string[] SUPPORTED_VERSION = ["1.20.4"];
    public static readonly MinecraftDbContextFactory Factory = new();
    public static MinecraftDbContext Instance { get; private set; } = Factory.CreateDbContext();

    public string UsingVersion { get; private set; } = null!;
    public DbSet<Block> Blocks { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Particle> Particles { get; set; }
    public DbSet<CommandFile> CommandFiles { get; set; }
    public DbSet<Entity> Entities { get; set; }
    public DbSet<BlockPropety> BlockPropeties { get; set; }
    public string DbPath { get; private set; } = string.Empty;

    /// <summary>
    /// Key is <see cref="Block.ResourceLocation"/>
    /// </summary>
    public ILookup<string, Block> BlockLookUp { get; private set; } = null!;
    /// <summary>
    /// Key is <see cref="Item.ResourceLocation"/>
    /// </summary>
    public ILookup<string, Item> ItemLookUp { get; private set; } = null!;
    /// <summary>
    /// Key is <see cref="Entity.ResourceLocation"/>
    /// </summary>
    public ILookup<string, Entity> EntityLookUp { get; private set; } = null!;
    /// <summary>
    /// Key is <see cref="Particle.ResourceLocation"/>
    /// </summary>
    public ILookup<string, Particle> ParticlesLookUp { get; private set; } = null!;
    /// <summary>
    /// Key is <see cref="BlockPropety.Key"/>
    /// </summary>
    public ILookup<string, BlockPropety> BlockPropetiesLookUp { get; private set; } = null!;

    public MinecraftDbContext()
    {
        Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "minecraft.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder.UseSqlite($"Data Source={DbPath}");
        _ = optionsBuilder.EnableSensitiveDataLogging();

        ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        _ = optionsBuilder.UseLoggerFactory(factory);
    }

    public void ChangeVersion(string version)
    {
        UsingVersion = version;
        BlockLookUp = Blocks.WithVersion(version).ToLookup(v => v.ResourceLocation, v => v);
        ItemLookUp = Items.WithVersion(version).ToLookup(v => v.ResourceLocation, v => v);
        EntityLookUp = Entities.WithVersion(version).ToLookup(v => v.ResourceLocation, v => v);
        ParticlesLookUp = Particles.WithVersion(version).ToLookup(v => v.ResourceLocation, v => v);
        BlockPropetiesLookUp = BlockPropeties.WithVersion(version).ToLookup(v => v.Key, v => v);
    }

    public static void Init()
    {
        new MinecraftDbContextFactory().CreateDbContext().Dispose();
    }
}