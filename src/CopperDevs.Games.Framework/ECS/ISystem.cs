namespace CopperDevs.Games.Framework.ECS;

public interface ISystem
{
    protected internal void UpdateSystem<TStreamType>(List<IFilter> filters) where TStreamType : StreamType;
}