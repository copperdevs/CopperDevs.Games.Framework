namespace CopperDevs.Games.Framework.ECS;

public abstract class BaseSystem<T1, T2, T3, T4, T5> : ISystem
    where T1 : notnull, new()
    where T2 : notnull, new()
    where T3 : notnull, new()
    where T4 : notnull, new()
    where T5 : notnull, new()
{
    public abstract void Update(ref T1 componentOne, ref T2 componentTwo, ref T3 componentThree, ref T4 componentFour, ref T5 componentFive);

    void ISystem.UpdateSystem<TStreamType>(IFilter[] filters)
    {
        var stream = Game.Instance.QueryEntities<T1, T2, T3, T4, T5>(filters).Stream();

        if (typeof(TStreamType) == typeof(StreamTypes.For))
        {
            stream.For((ref T1 componentOne, ref T2 componentTwo, ref T3 componentThree, ref T4 componentFour, ref T5 componentFive) =>
                Update(ref componentOne, ref componentTwo, ref componentThree, ref componentFour, ref componentFive));
        }

        else if (typeof(TStreamType) == typeof(StreamTypes.Job))
        {
            stream.Job((ref T1 componentOne, ref T2 componentTwo, ref T3 componentThree, ref T4 componentFour, ref T5 componentFive) =>
                Update(ref componentOne, ref componentTwo, ref componentThree, ref componentFour, ref componentFive));
        }
        
        else if (typeof(TStreamType) == typeof(StreamTypes.Raw))
            throw new NotImplementedException();
    }
}