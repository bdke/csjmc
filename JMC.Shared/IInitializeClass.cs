namespace JMC.Shared;

/// <summary>
/// Indentify a class that will be Initialized when server started
/// </summary>
public interface IInitializeClass
{
    public static abstract void Init();
}