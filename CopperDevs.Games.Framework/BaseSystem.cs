namespace CopperDevs.Games.Framework;

public abstract class BaseSystem<T> where T : struct
{
    public abstract void Update(ref T component);
}