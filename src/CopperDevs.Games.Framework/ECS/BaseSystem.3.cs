namespace CopperDevs.Games.Framework.ECS;

public abstract class BaseSystem<T1, T2, T3> : ISystem
    where T1 : notnull, new()
    where T2 : notnull, new()
    where T3 : notnull, new()
{
    public abstract void Update(ref T1 componentOne, ref T2 componentTwo, ref T3 componentThree);

    void ISystem.UpdateSystem<TStreamType>(IFilter[] filters)
    {
        var stream = Game.Instance.QueryEntities<T1, T2, T3>(filters).Stream();

        if (typeof(TStreamType) == typeof(StreamTypes.For))
        {
            stream.For((ref T1 componentOne, ref T2 componentTwo, ref T3 componentThree) =>
                Update(ref componentOne, ref componentTwo, ref componentThree));
        }

        else if (typeof(TStreamType) == typeof(StreamTypes.Job))
        {
            stream.Job((ref T1 componentOne, ref T2 componentTwo, ref T3 componentThree) =>
                Update(ref componentOne, ref componentTwo, ref componentThree));
        }
    }
}