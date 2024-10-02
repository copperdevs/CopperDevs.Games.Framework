namespace CopperDevs.Games.Framework.ECS.Systems;

public abstract class BaseSystem<T1, T2, T3, T4>(SystemStreamType streamType) : ISystem
    where T1 : notnull, new()
    where T2 : notnull, new()
    where T3 : notnull, new()
    where T4 : notnull, new()
{
    public abstract void Update(ref T1 componentOne, ref T2 componentTwo, ref T3 componentThree, ref T4 componentFour);

    void ISystem.UpdateSystem()
    {
        var stream = Game.EcsWorld.Query<T1, T2, T3, T4>().Stream();

        switch (streamType)
        {
            case SystemStreamType.For:
                stream.For((ref T1 componentOne, ref T2 componentTwo, ref T3 componentThree, ref T4 componentFour) => 
                    Update(ref componentOne, ref componentTwo, ref componentThree, ref componentFour));
                break;
            case SystemStreamType.Job:
                stream.Job((ref T1 componentOne, ref T2 componentTwo, ref T3 componentThree, ref T4 componentFour) => 
                    Update(ref componentOne, ref componentTwo, ref componentThree, ref componentFour));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(streamType), streamType, null);
        }
    }
}