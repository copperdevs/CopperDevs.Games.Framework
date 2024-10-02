using CopperDevs.Games.Framework.ECS.Systems;
using fennecs;

namespace CopperDevs.Games.Framework;

public partial class Game
{
    internal static readonly World EcsWorld = new();
    
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

    public void SpawnSystem<TSystem, TType, TSystemType>()
        where TSystem : BaseSystem<TType>, ISystem, new()
        where TType : notnull, new()
        where TSystemType : SystemType, new()
    {
        SpawnSystemEntity<TSystemType>(new TSystem());
    }

}