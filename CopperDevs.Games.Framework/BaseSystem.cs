namespace CopperDevs.Games.Framework;

public abstract class BaseSystem<T> where T : notnull, new()
{
    public abstract void Update(ref T component);
}