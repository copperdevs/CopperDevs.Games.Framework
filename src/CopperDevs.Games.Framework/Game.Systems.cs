using System.Diagnostics.CodeAnalysis;
using CopperDevs.Games.ECS;
using CopperDevs.Games.ECS.Systems;
using CopperDevs.Games.Framework.Data;
using fennecs;

namespace CopperDevs.Games.Framework;

public partial class Game
{
    private World ecsWorld => scenes[currentActiveSceneType].world;

    public EntitySpawner CreateEntity() => ecsWorld.CreateEntity();

    private const float FixedUpdateTime = 1f / 60f;
    private float fixedUpdateTimer;

    private void UpdateSystems()
    {
        ecsWorld.UpdateSystem<SystemTypes.FrameUpdate, StreamTypes.For>();
        ecsWorld.UpdateSystem<SystemTypes.FrameUpdate, StreamTypes.Job>();

        fixedUpdateTimer += Time.DeltaTime;

        if (!(fixedUpdateTimer >= FixedUpdateTime))
            return;

        fixedUpdateTimer = 0;

        ecsWorld.UpdateSystem<SystemTypes.FixedUpdate, StreamTypes.For>();
        ecsWorld.UpdateSystem<SystemTypes.FixedUpdate, StreamTypes.Job>();
    }

    public void SpawnSystem<TSystem, TType1, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1>, new()
        where TType1 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        ecsWorld.SpawnSystem<TSystem, TType1, TSystemType, TStreamType>(filters);

    public void SpawnSystem<TSystem, TType1, TType2, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1, TType2>, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        ecsWorld.SpawnSystem<TSystem, TType1, TType2, TSystemType, TStreamType>(filters);

    public void SpawnSystem<TSystem, TType1, TType2, TType3, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1, TType2, TType3>, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TType3 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        ecsWorld.SpawnSystem<TSystem, TType1, TType2, TType3, TSystemType, TStreamType>(filters);

    public void SpawnSystem<TSystem, TType1, TType2, TType3, TType4, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1, TType2, TType3, TType4>, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TType3 : notnull, new()
        where TType4 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        ecsWorld.SpawnSystem<TSystem, TType1, TType2, TType3, TType4, TSystemType, TStreamType>(filters);

    public void SpawnSystem<TSystem, TType1, TType2, TType3, TType4, TType5, TSystemType, TStreamType>(params IFilter[] filters)
        where TSystem : BaseSystem<TType1, TType2, TType3, TType4, TType5>, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TType3 : notnull, new()
        where TType4 : notnull, new()
        where TType5 : notnull, new()
        where TSystemType : SystemType, new()
        where TStreamType : StreamType, new() =>
        ecsWorld.SpawnSystem<TSystem, TType1, TType2, TType3, TType4, TType5, TSystemType, TStreamType>(filters);

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public QueryBuilder<C1> QueryEntities<C1>()
        where C1 : notnull =>
        ecsWorld.QueryEntities<C1>();

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public QueryBuilder<C1, C2> QueryEntities<C1, C2>()
        where C1 : notnull
        where C2 : notnull =>
        ecsWorld.QueryEntities<C1, C2>();

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public QueryBuilder<C1, C2, C3> QueryEntities<C1, C2, C3>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        ecsWorld.QueryEntities<C1, C2, C3>();

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public QueryBuilder<C1, C2, C3, C4> QueryEntities<C1, C2, C3, C4>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        ecsWorld.QueryEntities<C1, C2, C3, C4>();

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public QueryBuilder<C1, C2, C3, C4, C5> QueryEntities<C1, C2, C3, C4, C5>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        ecsWorld.QueryEntities<C1, C2, C3, C4, C5>();

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public QueryBuilder<C1> QueryEntities<C1>(params IFilter[] filters)
        where C1 : notnull =>
        filters.Aggregate(QueryEntities<C1>(), (current, filter) => filter.FilterQuery(current));

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public QueryBuilder<C1, C2> QueryEntities<C1, C2>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull =>
        ecsWorld.QueryEntities<C1, C2>(filters);

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public QueryBuilder<C1, C2, C3> QueryEntities<C1, C2, C3>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        ecsWorld.QueryEntities<C1, C2, C3>(filters);

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public QueryBuilder<C1, C2, C3, C4> QueryEntities<C1, C2, C3, C4>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        ecsWorld.QueryEntities<C1, C2, C3, C4>(filters);

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public QueryBuilder<C1, C2, C3, C4, C5> QueryEntities<C1, C2, C3, C4, C5>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        ecsWorld.QueryEntities<C1, C2, C3, C4, C5>(filters);
}