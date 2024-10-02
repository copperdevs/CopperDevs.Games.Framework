namespace CopperDevs.Games.Framework.ECS.Systems;

public abstract class BaseSystem<T1>(SystemStreamType streamType) : ISystem where T1 : notnull, new()
{
    public abstract void Update(ref T1 component);

    void ISystem.UpdateSystem()
    {
        var stream = Game.EcsWorld.Query<T1>().Stream();

        switch (streamType)
        {
            case SystemStreamType.For:
                stream.For((ref T1 component) => Update(ref component));
                break;
            case SystemStreamType.Job:
                stream.Job((ref T1 component) => Update(ref component));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(streamType), streamType, null);
        }
    }
}