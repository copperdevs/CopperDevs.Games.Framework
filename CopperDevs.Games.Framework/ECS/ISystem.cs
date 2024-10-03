namespace CopperDevs.Games.Framework.ECS;

public interface ISystem
{
    protected internal void UpdateSystem<TStreamType>() where TStreamType : StreamType;
}