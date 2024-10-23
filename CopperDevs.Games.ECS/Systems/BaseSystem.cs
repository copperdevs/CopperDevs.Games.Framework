namespace CopperDevs.Games.ECS.Systems;

public abstract class BaseSystem
{
    protected internal World world;
    protected internal abstract void UpdateSystem<TStreamType>(IFilter[] filters) where TStreamType : StreamType;

    protected internal void SetWorld(World targetWorld) => world = targetWorld;
}