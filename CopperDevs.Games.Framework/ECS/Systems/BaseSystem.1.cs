namespace CopperDevs.Games.Framework.ECS.Systems;

public abstract class BaseSystem<T>(SystemStreamType streamType) : ISystem where T : notnull, new()
{
    public abstract void Update(ref T component);

    void ISystem.UpdateSystem()
    {
        var stream = Game.EcsWorld.Query<T>().Stream();

        switch (streamType)
        {
            case SystemStreamType.For:
                stream.For((ref T component) => Update(ref component));
                break;
            case SystemStreamType.Job:
                stream.Job((ref T component) => Update(ref component));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(streamType), streamType, null);
        }
    }
}