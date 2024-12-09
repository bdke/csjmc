using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMC.Shared;
public abstract class ConfigTest
{
    public string Version { get; init; } = "1.20.4";
    public ConfigTest()
    {
        Config.Init(Version);
    }
}
