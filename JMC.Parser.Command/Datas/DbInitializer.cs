using JMC.Parser.Command.Datas.Types;

namespace JMC.Parser.Command.Datas;

internal static class DbInitializer
{
    public static async Task SeedAsync(this MinecraftDbContext context, string[] versions)
    {
        foreach (string version in versions)
        {
            List<Block> blocks = await Block.FromArticAsync(version);
            List<Item> items = await Item.FromArticAsync(version);
            List<Particle> particles = await Particle.FromArticAsync(version);
            List<CommandFile> commands = await CommandFile.FromArticAsync(version);
            List<Entity> entities = await Entity.FromArticAsync(version);
            List<BlockPropety> blockProps = await BlockPropety.FromArticAsync(version);

            await context.AddRangeAsync(blocks);
            await context.AddRangeAsync(items);
            await context.AddRangeAsync(particles);
            await context.AddRangeAsync(commands);
            await context.AddRangeAsync(entities);
            await context.AddRangeAsync(blockProps);
        }
        _ = await context.SaveChangesAsync();
    }

    public static void Seed(this MinecraftDbContext context, string[] versions)
    {
        _ = Task.Run(async () => await SeedAsync(context, versions));
    }
}