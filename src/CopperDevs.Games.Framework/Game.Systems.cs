using CopperDevs.Games.Framework.ECS;
using fennecs;

namespace CopperDevs.Games.Framework;

public partial class Game
{
    private readonly World ecsWorld = new();

    public EntitySpawner CreateEntity() => ecsWorld.Entity();

    private void UpdateSystems()
    {
        UpdateSystem<SystemTypes.FrameUpdate, StreamTypes.For>();
        UpdateSystem<SystemTypes.FrameUpdate, StreamTypes.Job>();
        UpdateSystem<SystemTypes.FrameUpdate, StreamTypes.Raw>();
    }

    private void UpdateSystem<TSystemType, TStreamType>()
        where TSystemType : SystemType
        where TStreamType : StreamType
    {
        var stream = QueryEntities<SystemHolder>()
            .Has<TSystemType>()
            .Has<TStreamType>()
            .Stream();

        stream.For(static (ref SystemHolder holder) => { holder.System.UpdateSystem<TStreamType>(holder.Filters); });
    }

    private void SpawnSystemEntity<TSystemType, TStreamType>(ISystem system, IFilter[] filters)
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new()
    {
        CreateEntity()
            .Add<TSystemType>()
            .Add<TStreamType>()
            .Add(new SystemHolder(system, filters))
            .Spawn()
            .Dispose();
    }

    public void SpawnSystem<TSystem, TType1, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1>, ISystem, new()
        where TType1 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        SpawnSystemEntity<TSystemType, TStreamType>(new TSystem(), filters);

    public void SpawnSystem<TSystem, TType1, TType2, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1, TType2>, ISystem, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        SpawnSystemEntity<TSystemType, TStreamType>(new TSystem(), filters);

    public void SpawnSystem<TSystem, TType1, TType2, TType3, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1, TType2, TType3>, ISystem, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TType3 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        SpawnSystemEntity<TSystemType, TStreamType>(new TSystem(), filters);

    public void SpawnSystem<TSystem, TType1, TType2, TType3, TType4, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1, TType2, TType3, TType4>, ISystem, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TType3 : notnull, new()
        where TType4 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        SpawnSystemEntity<TSystemType, TStreamType>(new TSystem(), filters);

    public void SpawnSystem<TSystem, TType1, TType2, TType3, TType4, TType5, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1, TType2, TType3, TType4, TType5>, ISystem, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TType3 : notnull, new()
        where TType4 : notnull, new()
        where TType5 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        SpawnSystemEntity<TSystemType, TStreamType>(new TSystem(), filters);

    public QueryBuilder<C1> QueryEntities<C1>()
        where C1 : notnull =>
        ecsWorld.Query<C1>();

    public QueryBuilder<C1, C2> QueryEntities<C1, C2>()
        where C1 : notnull
        where C2 : notnull =>
        ecsWorld.Query<C1, C2>();

    public QueryBuilder<C1, C2, C3> QueryEntities<C1, C2, C3>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        ecsWorld.Query<C1, C2, C3>();

    public QueryBuilder<C1, C2, C3, C4> QueryEntities<C1, C2, C3, C4>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        ecsWorld.Query<C1, C2, C3, C4>();

    public QueryBuilder<C1, C2, C3, C4, C5> QueryEntities<C1, C2, C3, C4, C5>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        ecsWorld.Query<C1, C2, C3, C4, C5>();

    public QueryBuilder<C1> QueryEntities<C1>(params IFilter[] filters)
        where C1 : notnull =>
        filters.Aggregate(QueryEntities<C1>(), (current, filter) => filter.FilterQuery(current));

    public QueryBuilder<C1, C2> QueryEntities<C1, C2>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull =>
        filters.Aggregate(ecsWorld.Query<C1, C2>(), (current, filter) => filter.FilterQuery(current));

    public QueryBuilder<C1, C2, C3> QueryEntities<C1, C2, C3>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        filters.Aggregate(ecsWorld.Query<C1, C2, C3>(), (current, filter) => filter.FilterQuery(current));

    public QueryBuilder<C1, C2, C3, C4> QueryEntities<C1, C2, C3, C4>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        filters.Aggregate(ecsWorld.Query<C1, C2, C3, C4>(), (current, filter) => filter.FilterQuery(current));

    public QueryBuilder<C1, C2, C3, C4, C5> QueryEntities<C1, C2, C3, C4, C5>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        filters.Aggregate(ecsWorld.Query<C1, C2, C3, C4, C5>(), (current, filter) => filter.FilterQuery(current));
}