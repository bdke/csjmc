using JMC.Parser.Command.Datas;

namespace JMC.Parser.Command.Argument.Helper;

internal static class ScoreboardHelper
{
    public static readonly string[] TEAM_COLORS = ["black", "dark_blue", "dark_green", "dark_aqua", "dark_red", "dark_purple", "gold", "gray", "dark_gray", "blue", "green", "aqua", "red", "light_purple", "yellow", "white"];
    public static readonly Dictionary<string, bool> SINGLE_CRITERIA = new()
    {
        ["dummy"] = true,
        ["trigger"] = true,
        ["deathCount"] = true,
        ["playerKillCount"] = true,
        ["totalKillCount"] = true,
        ["health"] = false,
        ["xp"] = false,
        ["level"] = false,
        ["food"] = false,
        ["air"] = false,
        ["armor"] = false
    };
    public static readonly string[] COMPOUND_CRITERIA = ["teamKill", "killedByTeam"];
    public static readonly string[] STATISTICS = ["custom", "mined", "broken", "crafted", "used", "picked_up", "dropped", "killed", "killed_by"];
    public static readonly string[] CUSTOM_STATISTICS = ["animals_bred", "clean_armor", "clean_banner", "open_barrel", "bell_ring", "eat_cake_slice", "fill_cauldron", "open_chest", "damage_absorbed", "damage_blocked_by_shield", "damage_dealt", "damage_dealt_absorbed", "damage_dealt_resisted", "damage_resisted", "damage_taken", "inspect_dispenser", "climb_one_cm", "crouch_one_cm", "fall_one_cm", "fly_one_cm", "sprint_one_cm", "swim_one_cm", "walk_one_cm", "walk_on_water_one_cm", "walk_under_water_one_cm", "boat_one_cm", "aviate_one_cm", "horse_one_cm", "minecart_one_cm", "pig_one_cm", "strider_one_cm", "inspect_dropper", "open_enderchest", "fish_caught", "leave_game", "inspect_hopper", "interact_with_anvil", "interact_with_beacon", "interact_with_blast_furnace", "interact_with_brewingstand", "interact_with_campfire", "interact_with_cartography_table", "interact_with_crafting_table", "interact_with_furnace", "interact_with_grindstone", "interact_with_lectern", "interact_with_loom", "interact_with_smithing_table", "interact_with_smoker", "interact_with_stonecutter", "drop", "enchant_item", "jump", "mob_kills", "play_record", "play_noteblock", "tune_noteblock", "deaths", "pot_flower", "player_kills", "raid_trigger", "raid_win", "clean_shulker_box", "open_shulker_box", "sneak_time", "talked_to_villager", "target_hit", "play_time", "time_since_death", "time_since_rest", "total_world_time", "sleep_in_bed", "traded_with_villager", "trigger_trapped_chest", "use_cauldron",];

    public static IEnumerable<string> ScoreboardDisplaySlots
    {
        get
        {
            yield return "list";
            yield return "sidebar";
            yield return "below_name";
            foreach (string color in TEAM_COLORS)
            {
                yield return $"sidebar.team.{color}";
            }
        }
    }

    public static IEnumerable<string> AllCompoundCriteria
    {
        get
        {
            foreach (string color in TEAM_COLORS)
            {
                yield return $"teamkill.{color}";
                yield return $"killedByTeam.{color}";
            }
        }
    }

    //TODO: optimization, this is slow
    /// <summary>
    /// 
    /// </summary>
    /// <param name="criteria"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static CommandSyntaxError? CheckCriteria(string criteria, string version)
    {
        //remove unnessary namespaces
        criteria = string.Join("", criteria.Split(["minecraft.", "minecraft:"], StringSplitOptions.None));
        string[] args = criteria.Split(':');
        using MinecraftDbContext database = MinecraftDbContext.Instance;
        ILookup<string, Datas.Types.Block> blocks = database.BlockLookUp;
        ILookup<string, Datas.Types.Item> items = database.ItemLookUp;
        ILookup<string, Datas.Types.Entity> entities = database.EntityLookUp;

        if (args.Length == 1)
        {
            if (!SINGLE_CRITERIA.ContainsKey(args[0]) && !AllCompoundCriteria.Contains(args[0]))
            {
                return new CommandSyntaxError($"invalid criteria: {args[0]}");
            }

            return null;
        }

        if (!STATISTICS.Contains(args[0]))
        {
            return new CommandSyntaxError($"invalid stattype: {args[0]}");
        }

        string statName = args[1];
        switch (args[0])
        {
            case "custom" when !CUSTOM_STATISTICS.Contains(statName):
            case "mined" or "broken" or "crafted" or "used" or "picked_up" or "dropped" when !blocks.Contains($"minecraft:{args[1]}"):
            case "broken" or "crafted" or "used" or "picked_up" or "dropped" when !items.Contains($"minecraft:{args[1]}"):
            case "killed" or "killed_by" when !entities.Contains($"minecraft:{args[1]}"):
                return new CommandSyntaxError($"invalid statname for {args[0]}: {args[1]}");
        }


        return null;
    }
}