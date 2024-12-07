using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMC.Shared;
public readonly struct ExtendedMinecraftData
{
    public readonly required ReadOnlyMemory<string> CustomStatistics { get; init; }
}
