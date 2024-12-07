using JMC.Shared;
using JMC.Shared.Helpers;
using System.Collections.Immutable;

namespace FluentCommand.Arguments;
internal sealed class ObjectiveCriteria(string criteria) : BaseArgument
{

    private const string CUSTOM_CRITERIA_WORD = "custom";

    public override string Value => criteria;

    internal override bool IsValidValue => CheckValue(Value);

    public static readonly ImmutableArray<string> SINGLE_CRITERIAS = ["dummy", "trigger", "deathCount", "playerKillCount", "totalKillCount", "health", "xp", "level", "food", "air", "armor"];
    public static readonly ImmutableArray<string> COMPOUND_CRITERIAS = ["custom", "mined", "broken", "crafted", "used", "picked_up", "dropped", "killed", "killed_by"];

    public static bool CheckValue(string value)
    {
        if (SINGLE_CRITERIAS.Contains(value))
        {
            return true;
        }
        string[] compound = value.Split(':');
        if (compound.Length == 1)
        {
            string[] kvPair = compound[0].Split('.');
            if (kvPair.Length != 2)
            {
                return false;
            }

            string key = kvPair[0];
            string v = kvPair[1];
            if (key is not "teamkill" and not "killedByTeam")
            {
                return false;
            }

            string[] validColors = EnumExtensions.GetAllDescriptionValues<CommandColor>();
            return validColors.Contains(v);
        }
        else if (compound.Length > 2)
        {
            return false;
        }

        string[] clKey = compound[0].Split('.');
        string[] clValue = compound[1].Split('.');
        string cKey = clKey.Length > 1 ? clKey[1] : clKey[0];
        string cValue = clValue.Length > 1 ? clValue[1] : clValue[0];
        if (cKey == CUSTOM_CRITERIA_WORD && !_customStats.Contains(cValue))
        {
            return false;
        }
        else if (cKey == string.Empty || cValue == string.Empty)
        {
            return false;
        }
        else if (!COMPOUND_CRITERIAS.Contains(cKey))
        {
            return false;
        }
        return true;
    }
}
