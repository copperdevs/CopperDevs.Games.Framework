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

    #region SpawnSystem

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

    #endregion

    #region QueryEntities

    public QueryBuilder<C1> QueryEntities<C1>()
        where C1 : notnull =>
        ecsWorld.QueryEntities<C1>();

    public QueryBuilder<C1, C2> QueryEntities<C1, C2>()
        where C1 : notnull
        where C2 : notnull =>
        ecsWorld.QueryEntities<C1, C2>();

    public QueryBuilder<C1, C2, C3> QueryEntities<C1, C2, C3>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        ecsWorld.QueryEntities<C1, C2, C3>();

    public QueryBuilder<C1, C2, C3, C4> QueryEntities<C1, C2, C3, C4>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        ecsWorld.QueryEntities<C1, C2, C3, C4>();

    public QueryBuilder<C1, C2, C3, C4, C5> QueryEntities<C1, C2, C3, C4, C5>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        ecsWorld.QueryEntities<C1, C2, C3, C4, C5>();

    public QueryBuilder<C1> QueryEntities<C1>(params IFilter[] filters)
        where C1 : notnull =>
        filters.Aggregate(QueryEntities<C1>(), (current, filter) => filter.FilterQuery(current));

    public QueryBuilder<C1, C2> QueryEntities<C1, C2>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull =>
        ecsWorld.QueryEntities<C1, C2>(filters);

    public QueryBuilder<C1, C2, C3> QueryEntities<C1, C2, C3>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        ecsWorld.QueryEntities<C1, C2, C3>(filters);

    public QueryBuilder<C1, C2, C3, C4> QueryEntities<C1, C2, C3, C4>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        ecsWorld.QueryEntities<C1, C2, C3, C4>(filters);

    public QueryBuilder<C1, C2, C3, C4, C5> QueryEntities<C1, C2, C3, C4, C5>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        ecsWorld.QueryEntities<C1, C2, C3, C4, C5>(filters);

    #endregion

    #region For

    public void For<C1>(ComponentAction<C1> action)
        where C1 : notnull =>
        ecsWorld.For<C1>(action);

    public void For<C1, C2>(ComponentAction<C1, C2> action)
        where C1 : notnull
        where C2 : notnull =>
        ecsWorld.For<C1, C2>(action);

    public void For<C1, C2, C3>(ComponentAction<C1, C2, C3> action)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        ecsWorld.For<C1, C2, C3>(action);

    public void For<C1, C2, C3, C4>(ComponentAction<C1, C2, C3, C4> action)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        ecsWorld.For<C1, C2, C3, C4>(action);

    public void For<C1, C2, C3, C4, C5>(ComponentAction<C1, C2, C3, C4, C5> action)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        ecsWorld.For<C1, C2, C3, C4, C5>(action);

    public void For<C1>(ComponentAction<C1> action, params IFilter[] filters)
        where C1 : notnull =>
        ecsWorld.For<C1>(action, filters);

    public void For<C1, C2>(ComponentAction<C1, C2> action, params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull =>
        ecsWorld.For<C1, C2>(action, filters);

    public void For<C1, C2, C3>(ComponentAction<C1, C2, C3> action, params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        ecsWorld.For<C1, C2, C3>(action, filters);

    public void For<C1, C2, C3, C4>(ComponentAction<C1, C2, C3, C4> action, params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        ecsWorld.For<C1, C2, C3, C4>(action, filters);

    public void For<C1, C2, C3, C4, C5>(ComponentAction<C1, C2, C3, C4, C5> action, params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        ecsWorld.For<C1, C2, C3, C4, C5>(action, filters);

    #endregion

    #region Job

    public void Job<C1>(ComponentAction<C1> action)
        where C1 : notnull =>
        ecsWorld.Job<C1>(action);

    public void Job<C1, C2>(ComponentAction<C1, C2> action)
        where C1 : notnull
        where C2 : notnull =>
        ecsWorld.Job<C1, C2>(action);

    public void Job<C1, C2, C3>(ComponentAction<C1, C2, C3> action)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        ecsWorld.Job<C1, C2, C3>(action);

    public void Job<C1, C2, C3, C4>(ComponentAction<C1, C2, C3, C4> action)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        ecsWorld.Job<C1, C2, C3, C4>(action);

    public void Job<C1, C2, C3, C4, C5>(ComponentAction<C1, C2, C3, C4, C5> action)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        ecsWorld.Job<C1, C2, C3, C4, C5>(action);

    public void Job<C1>(ComponentAction<C1> action, params IFilter[] filters)
        where C1 : notnull =>
        ecsWorld.Job<C1>(action, filters);

    public void Job<C1, C2>(ComponentAction<C1, C2> action, params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull =>
        ecsWorld.Job<C1, C2>(action, filters);

    public void Job<C1, C2, C3>(ComponentAction<C1, C2, C3> action, params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        ecsWorld.Job<C1, C2, C3>(action, filters);

    public void Job<C1, C2, C3, C4>(ComponentAction<C1, C2, C3, C4> action, params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        ecsWorld.Job<C1, C2, C3, C4>(action, filters);

    public void Job<C1, C2, C3, C4, C5>(ComponentAction<C1, C2, C3, C4, C5> action, params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        ecsWorld.Job<C1, C2, C3, C4, C5>(action, filters);

    #endregion

    #region Stream

    public Stream<C1> Stream<C1>()
        where C1 : notnull =>
        ecsWorld.Stream<C1>();

    public Stream<C1, C2> Stream<C1, C2>()
        where C1 : notnull
        where C2 : notnull =>
        ecsWorld.Stream<C1, C2>();

    public Stream<C1, C2, C3> Stream<C1, C2, C3>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        ecsWorld.Stream<C1, C2, C3>();

    public Stream<C1, C2, C3, C4> Stream<C1, C2, C3, C4>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        ecsWorld.Stream<C1, C2, C3, C4>();

    public Stream<C1, C2, C3, C4, C5> Stream<C1, C2, C3, C4, C5>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        ecsWorld.Stream<C1, C2, C3, C4, C5>();

    public Stream<C1> Stream<C1>(params IFilter[] filters)
        where C1 : notnull =>
        ecsWorld.Stream<C1>(filters);

    public Stream<C1, C2> Stream<C1, C2>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull =>
        ecsWorld.Stream<C1, C2>(filters);

    public Stream<C1, C2, C3> Stream<C1, C2, C3>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        ecsWorld.Stream<C1, C2, C3>(filters);

    public Stream<C1, C2, C3, C4> Stream<C1, C2, C3, C4>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        ecsWorld.Stream<C1, C2, C3, C4>(filters);

    public Stream<C1, C2, C3, C4, C5> Stream<C1, C2, C3, C4, C5>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        ecsWorld.Stream<C1, C2, C3, C4, C5>(filters);

    #endregion

    #region Count

    public int Count<C1>()
        where C1 : notnull =>
        Stream<C1>().Count;

    public int Count<C1, C2>()
        where C1 : notnull
        where C2 : notnull =>
        Stream<C1, C2>().Count;

    public int Count<C1, C2, C3>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        Stream<C1, C2, C3>().Count;

    public int Count<C1, C2, C3, C4>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        Stream<C1, C2, C3, C4>().Count;

    public int Count<C1, C2, C3, C4, C5>()
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        Stream<C1, C2, C3, C4, C5>().Count;

    public int Count<C1>(params IFilter[] filters)
        where C1 : notnull =>
        Stream<C1>(filters).Count;

    public int Count<C1, C2>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull =>
        Stream<C1, C2>(filters).Count;

    public int Count<C1, C2, C3>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull =>
        Stream<C1, C2, C3>(filters).Count;

    public int Count<C1, C2, C3, C4>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull =>
        Stream<C1, C2, C3, C4>(filters).Count;

    public int Count<C1, C2, C3, C4, C5>(params IFilter[] filters)
        where C1 : notnull
        where C2 : notnull
        where C3 : notnull
        where C4 : notnull
        where C5 : notnull =>
        Stream<C1, C2, C3, C4, C5>(filters).Count;

    #endregion
}
