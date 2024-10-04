namespace CopperDevs.Games.Framework.ECS;

public abstract class BaseSystem<T1, T2, T3, T4>(StreamType streamType) : ISystem
    where T1 : notnull, new()
    where T2 : notnull, new()
    where T3 : notnull, new()
    where T4 : notnull, new()
{
    public abstract void Update(ref T1 componentOne, ref T2 componentTwo, ref T3 componentThree, ref T4 componentFour);

    void ISystem.UpdateSystem<TStreamType>(IFilter[] filters)
    {
        var stream = Game.Instance.QueryEntities<T1, T2, T3, T4>(filters).Stream();

        if (typeof(TStreamType) == typeof(StreamTypes.For))
        {
            stream.For((ref T1 componentOne, ref T2 componentTwo, ref T3 componentThree, ref T4 componentFour) =>
                Update(ref componentOne, ref componentTwo, ref componentThree, ref componentFour));
        }

        else if (typeof(TStreamType) == typeof(StreamTypes.Job))
        {
            stream.Job((ref T1 componentOne, ref T2 componentTwo, ref T3 componentThree, ref T4 componentFour) =>
                Update(ref componentOne, ref componentTwo, ref componentThree, ref componentFour));
        }

        else if (typeof(TStreamType) == typeof(StreamTypes.Raw))
        {
            stream.Raw((componentsOne, componentsTwo, componentsThree, componentsFour) =>
            {
                var spanOne = componentsOne.Span;
                var spanTwo = componentsTwo.Span;
                var spanThree = componentsThree.Span;
                var spanFour = componentsFour.Span;

                var minLength = Math.Min(Math.Min(spanOne.Length, spanTwo.Length), Math.Min(spanThree.Length, spanFour.Length));

                for (var i = 0; i < minLength; i++)
                {
                    Update(ref spanOne[i], ref spanTwo[i], ref spanThree[i], ref spanFour[i]);
                }
            });
        }
    }
}