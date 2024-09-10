using Bertie.SNBT.Parser.NBT;

namespace JMC.Parser.Command.DataComponent;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class SNBTNameAttribute(string name) : Attribute
{
    public string Name { get; private set; } = name;
}
