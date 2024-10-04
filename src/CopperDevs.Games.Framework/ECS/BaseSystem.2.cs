namespace CopperDevs.Games.Framework.ECS;

public abstract class BaseSystem<T1, T2> : ISystem
    where T1 : notnull, new()
    where T2 : notnull, new()
{
    public abstract void Update(ref T1 componentOne, ref T2 componentTwo);

    void ISystem.UpdateSystem<TStreamType>(IFilter[] filters)
    {
        var stream = Game.Instance.QueryEntities<T1, T2>(filters).Stream();

        if (typeof(TStreamType) == typeof(StreamTypes.For))
        {
            stream.For((ref T1 componentOne, ref T2 componentTwo) =>
                Update(ref componentOne, ref componentTwo));
        }

        else if (typeof(TStreamType) == typeof(StreamTypes.Job))
        {
            stream.Job((ref T1 componentOne, ref T2 componentTwo) =>
                Update(ref componentOne, ref componentTwo));
        }
        
        else if (typeof(TStreamType) == typeof(StreamTypes.Raw))
            throw new NotImplementedException();
    }
}