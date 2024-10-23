namespace CopperDevs.Games.ECS.Systems;

public abstract class BaseSystem<T1> : BaseSystem
    where T1 : notnull, new()
{
    public abstract void Update(ref T1 component);

    protected internal override void UpdateSystem<TStreamType>(IFilter[] filters)
    {
        var stream = world.QueryEntities<T1>(filters).Stream();

        if (typeof(TStreamType) == typeof(StreamTypes.For))
        {
            stream.For((ref T1 component) =>
                Update(ref component));
        }

        else if (typeof(TStreamType) == typeof(StreamTypes.Job))
        {
            stream.Job((ref T1 component) =>
                Update(ref component));
        }
    }
}