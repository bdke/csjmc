using JMC.Parser.Command.Datas;

namespace JMC.Parser.Command.Argument.Types;

[ArgumentIdentifier("minecraft:particle")]
internal class Particle : BaseArgument
{
    private static CommandParseResult Result { get; set; } = null!;

    public override IParseResult Parse(params string[] arguments)
    {
        Result = new(CommandTokenType.Particle, this);
        string[] configs = arguments[1..];
        string particleName = string.Join("", arguments[0].Split("minecraft:"));
        switch (particleName)
        {
            case "block" or "block_marker" or "fallingdust" when configs.Length == 1:
                return ParseBlock(configs[0]);
            case "dust" when configs.Length == 4:
                bool rResult = float.TryParse(configs[0], out float r);
                bool gResult = float.TryParse(configs[1], out float g);
                bool bResult = float.TryParse(configs[2], out float b);
                bool sizeResult = float.TryParse(configs[3], out float size);
                if (rResult && gResult && bResult && sizeResult)
                {
                    return ParseDust(r, g, b, size);
                }
                return new ParseError(new CommandSyntaxError());
            case "dust_color_transition" when configs.Length == 7:
                return ParseDustColorTransition(configs);
            case "entity_effect" when configs.Length == 4:
                return ParseEntityEffect(configs);
            case "entity_effect" when configs.Length == 1:
                return ParseEntityEffect(configs[0]);
            case "item" when configs.Length == 1:
                return ParseItem(configs[0]);
            case "vibration" when configs.Length is 5 or 6:
                return ParseVibration(configs[0], configs[1], configs[2..]);
            case "sculk_change" when configs.Length == 1:
                return ParseSculkCharge(configs[0]);
            case "shriek" when configs.Length == 1:
                return ParseShriek(configs[0]);

            case "sculk_charge" when configs.Length != 1:
            case "shriek" when configs.Length != 1:
            case "vibration" when configs.Length is not 5 or 6:
            case "block" or "block_marker" or "fallingdust" when configs.Length != 1:
            case "dust" when configs.Length != 4:
            case "dust_color_transition" when configs.Length != 7:
            case "entity_effect" when configs.Length != 4:
                return new ParseError(new CommandSyntaxError());
            default:
                {
                    using MinecraftDbContext database = MinecraftDbContext.Instance;
                    return database.ParticlesLookUp.Contains($"minecraft:{particleName}") ? Result : new ParseError(new CommandSyntaxError());
                }
        }
    }

    private static IParseResult ParseVibration(string type, string arrivalInTicks, params string[] args)
    {
        return type switch
        {
            "block" when args.Length == 3 => args.Any(v => !int.TryParse(v, out _)) || !int.TryParse(arrivalInTicks, out _) ? new ParseError(new CommandSyntaxError()) : Result,
            "entity" when args.Length == 4 => args.Any(v => !int.TryParse(v, out _)) || !int.TryParse(arrivalInTicks, out _) ? new ParseError(new CommandSyntaxError()) : Result,
            _ => throw new ArgumentException($"Invalid parameters"),
        };
    }

    private static IParseResult ParseShriek(string delay)
    {
        return !float.TryParse(delay, out _) ? new ParseError(new CommandSyntaxError()) : Result;
    }

    private static IParseResult ParseSculkCharge(string roll)
    {
        return !float.TryParse(roll, out _) ? new ParseError(new CommandSyntaxError()) : Result;
    }

    private static IParseResult ParseItem(string arg)
    {
        return arg.Split(":").First().StartsWith("air") ? new ParseError(new CommandSyntaxError()) : Result;
    }

    private static IParseResult ParseEntityEffect(string arg)
    {
        return !float.TryParse(arg, out _) ? new ParseError(new CommandSyntaxError()) : Result;
    }

    private static IParseResult ParseEntityEffect(params string[] args)
    {
        if (args.Length != 3)
        {
            return new ParseError(new CommandSyntaxError($"{nameof(args)} should have 3 elements."));
        }
        CommandSyntaxError[] errors = args.Where(arg => !float.TryParse(arg, out float value) || value is > 1 or < 0).Select(arg => new CommandSyntaxError()).ToArray();
        return errors.Length > 0 ? new ParseError(errors) : Result;
    }

    private static IParseResult ParseDustColorTransition(params string[] args)
    {
        if (args.Length != 6)
        {
            return new ParseError(new CommandSyntaxError($"{nameof(args)} should have 7 elements."));
        }

        CommandSyntaxError[] errors = args.Where(arg => !float.TryParse(arg, out float value) || value is > 1 or < 0).Select(arg => new CommandSyntaxError()).ToArray();
        return errors.Length > 0 ? new ParseError(errors) : Result;
    }

    private static IParseResult ParseDust(float r, float g, float b, float size)
    {
        return r is > 1 or < 0 || g is > 1 or < 0 || b is > 1 or < 0 || size is > 1 or < 0 ? new ParseError(new CommandSyntaxError()) : Result;
    }

    private static CommandParseResult ParseBlock(string block)
    {
        return Result;
    }
}