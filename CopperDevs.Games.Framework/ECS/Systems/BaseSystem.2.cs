﻿namespace CopperDevs.Games.Framework.ECS.Systems;

public abstract class BaseSystem<T1, T2>(SystemStreamType streamType) : ISystem
    where T1 : notnull, new()
    where T2 : notnull, new()
{
    public abstract void Update(ref T1 componentOne, ref T2 componentTwo);

    void ISystem.UpdateSystem()
    {
        var stream = Game.EcsWorld.Query<T1, T2>().Stream();

        switch (streamType)
        {
            case SystemStreamType.For:
                stream.For((ref T1 componentOne, ref T2 componentTwo) =>
                    Update(ref componentOne, ref componentTwo));
                break;
            case SystemStreamType.Job:
                stream.Job((ref T1 componentOne, ref T2 componentTwo) =>
                    Update(ref componentOne, ref componentTwo));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(streamType), streamType, null);
        }
    }
}