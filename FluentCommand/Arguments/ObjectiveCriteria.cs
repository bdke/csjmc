using System.Collections.Immutable;

namespace FluentCommand.Arguments;
internal sealed class ObjectiveCriteria(string criteria) : BaseArgument
{
    public override string Value => criteria;

    internal override bool IsValidValue => CheckValue();

    public static readonly ImmutableArray<string> SINGLE_CRITERIAS = ["dummy", "trigger", "deathCount", "playerKillCount", "totalKillCount", "health", "xp", "level", "food", "air", "armor"];

    private bool CheckValue()
    {


        return true;
    }
}
