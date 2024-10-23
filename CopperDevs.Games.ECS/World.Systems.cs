using CopperDevs.Games.ECS.Systems;

namespace CopperDevs.Games.ECS;

public partial class World
{
    public void UpdateSystem<TSystemType, TStreamType>()
        where TSystemType : SystemType
        where TStreamType : StreamType
    {
        var stream = QueryEntities<SystemHolder>()
            .Has<TSystemType>()
            .Has<TStreamType>()
            .Stream();

        stream.For(static (ref SystemHolder holder) => { holder.BaseSystem.UpdateSystem<TStreamType>(holder.Filters); });
    }

    private void SpawnSystemEntity<TSystemType, TStreamType>(BaseSystem baseSystem, IFilter[] filters)
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new()
    {
        baseSystem.SetWorld(this);

        CreateEntity()
            .Add<TSystemType>()
            .Add<TStreamType>()
            .Add(new SystemHolder(baseSystem, filters))
            .Spawn()
            .Dispose();
    }

    public void SpawnSystem<TSystem, TType1, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1>, new()
        where TType1 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        SpawnSystemEntity<TSystemType, TStreamType>(new TSystem(), filters);

    public void SpawnSystem<TSystem, TType1, TType2, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1, TType2>, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        SpawnSystemEntity<TSystemType, TStreamType>(new TSystem(), filters);

    public void SpawnSystem<TSystem, TType1, TType2, TType3, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1, TType2, TType3>, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TType3 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        SpawnSystemEntity<TSystemType, TStreamType>(new TSystem(), filters);

    public void SpawnSystem<TSystem, TType1, TType2, TType3, TType4, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1, TType2, TType3, TType4>, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TType3 : notnull, new()
        where TType4 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        SpawnSystemEntity<TSystemType, TStreamType>(new TSystem(), filters);

    public void SpawnSystem<TSystem, TType1, TType2, TType3, TType4, TType5, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1, TType2, TType3, TType4, TType5>, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TType3 : notnull, new()
        where TType4 : notnull, new()
        where TType5 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        SpawnSystemEntity<TSystemType, TStreamType>(new TSystem(), filters);
}