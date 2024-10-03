using CopperDevs.Logger;

namespace CopperDevs.Games.Framework.ECS;

public abstract class BaseSystem<T1> : ISystem
    where T1 : notnull, new()
{
    public abstract void Update(ref T1 component);

    void ISystem.UpdateSystem<TStreamType>()
    {
        var stream = Game.Instance.QueryEntities<T1>().Stream();

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