using CopperDevs.Games.Framework.ECS;
using fennecs;

namespace CopperDevs.Games.Framework;

public partial class Game
{
    public static readonly World EcsWorld = new();

    public EntitySpawner CreateEntity() => EcsWorld.Entity();

    private void UpdateSystems()
    {
        UpdateSystem<SystemTypes.FrameUpdate>();
    }

    private void UpdateSystem<TSystemType>() where TSystemType : SystemType
    {
        var stream = EcsWorld
            .Query<SystemHolder>()
            .Has<TSystemType>()
            .Stream();

        stream.For((ref SystemHolder holder) => holder.system.UpdateSystem());
    }

    private void SpawnSystemEntity<TSystemType>(ISystem system) where TSystemType : SystemType, new()
    {
        CreateEntity()
            .Add<TSystemType>()
            .Add(new SystemHolder(system))
            .Spawn().Dispose();
    }

    public void SpawnSystem<TSystem, TType1, TSystemType>()
        where TSystem : BaseSystem<TType1>, ISystem, new()
        where TType1 : notnull, new()
        where TSystemType : SystemType, new()
    {
        SpawnSystemEntity<TSystemType>(new TSystem());
    }

    public void SpawnSystem<TSystem, TType1, TType2, TSystemType>()
        where TSystem : BaseSystem<TType1, TType2>, ISystem, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TSystemType : SystemType, new()
    {
        SpawnSystemEntity<TSystemType>(new TSystem());
    }

    public void SpawnSystem<TSystem, TType1, TType2, TType3, TSystemType>()
        where TSystem : BaseSystem<TType1, TType2, TType3>, ISystem, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TType3 : notnull, new()
        where TSystemType : SystemType, new()
    {
        SpawnSystemEntity<TSystemType>(new TSystem());
    }

    public void SpawnSystem<TSystem, TType1, TType2, TType3, TType4, TSystemType>()
        where TSystem : BaseSystem<TType1, TType2, TType3, TType4>, ISystem, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TType3 : notnull, new()
        where TType4 : notnull, new()
        where TSystemType : SystemType, new()
    {
        SpawnSystemEntity<TSystemType>(new TSystem());
    }

    public void SpawnSystem<TSystem, TType1, TType2, TType3, TType4, TType5, TSystemType>()
        where TSystem : BaseSystem<TType1, TType2, TType3, TType4, TType5>, ISystem, new()
        where TType1 : notnull, new()
        where TType2 : notnull, new()
        where TType3 : notnull, new()
        where TType4 : notnull, new()
        where TType5 : notnull, new()
        where TSystemType : SystemType, new()
    {
        SpawnSystemEntity<TSystemType>(new TSystem());
    }
}