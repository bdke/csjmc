namespace JMC.Parser.Command.Argument;

public abstract class BaseArgument
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="rawString"></param>
    /// <returns>return nothing if error</returns>
    public virtual IParseResult Parse(params string[] arguments)
    {
        return arguments.Length != ArgumentsLength
            ? throw new ArgumentException($"{nameof(arguments)} should have {ArgumentsLength} elements")
            : (IParseResult)new CommandParseResult(CommandTokenType.Unknown, this);
    }
    public virtual int ArgumentsLength => 1;

    public enum CommandTokenType
    {
        Unknown,
        Word,
        Double,
        Bool,
        Float,
        Int,
        Long,
        Phrase,
        Greedy,
        Angle,
        BlockPos,
        BlockPredicate,
        Color,
        BlockState,
        ColumnPos,
        Component,
        Dimension,
        Entity,
        EntityAnchor,
        GameProfile,
        Gamemode,
        FloatRange,
        Heightmap,
        IntRange,
        ItemPredicate,
        ItemSlot,
        ItemStack,
        Message,
        NBTCompoundTag,
        NBTTag,
        Operation,
        Particle,
        ObjectiveCriteria,
        Resource,
        ResourceKey,
        ResourceLocation,
        ResourceOrTag,
        ResourceOrTagKey,
        Rotation,
        ScoreHolder,
        ScoreboardSlot,
        Style,
        Swizzle,
        Team,
        TemplateMirror,
        Time,
        UUID,
        Vec2,
        Vec3,
        NBTPath,
        Function,
        Objective
    }
}