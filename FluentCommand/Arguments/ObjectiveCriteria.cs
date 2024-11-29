using FluentCommand.Helpers;
using FluentCommand.Types;
using System.Collections.Immutable;

namespace FluentCommand.Arguments;
internal sealed class ObjectiveCriteria(string criteria) : BaseArgument
{
    public override string Value => criteria;

    internal override bool IsValidValue => CheckValue(Value);

    public static readonly ImmutableArray<string> SINGLE_CRITERIAS = ["dummy", "trigger", "deathCount", "playerKillCount", "totalKillCount", "health", "xp", "level", "food", "air", "armor"];

    public static bool CheckValue(string value)
    {
        if (SINGLE_CRITERIAS.Contains(value))
        {
            return true;
        }
        var compound = value.Split(':');
        if (compound.Length == 1)
        {
            var kvPair = compound[0].Split('.');
            if (kvPair.Length != 2)
            {
                return false;
            }

            var key = kvPair[0];
            var v = kvPair[1];

            if (key is not "teamkill" and not "killedByTeam")
            {
                return false;
            }

            var validColors = EnumExtensions.GetAllDescriptionValues<CommandColor>();
            if (!validColors.Contains(v))
            {
                return false;
            }

            return true;
        }
        else if (compound.Length > 2)
        {
            return false;
        }

        var clKey = compound[0].Split('.');
        var clValue = compound[1].Split('.');
        var cKey = clKey.Length > 1 ? clKey[1] : clKey[0];
        var cValue = clValue.Length > 1 ? clValue[1] : clValue[0];


        return false;
    }
}
