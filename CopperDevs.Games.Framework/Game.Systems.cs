using CopperDevs.Games.Framework.ECS.Components;
using CopperDevs.Games.Framework.ECS.Systems;
using fennecs;

namespace CopperDevs.Games.Framework;

public partial class Game
{
    internal static readonly World EcsWorld = new();

    private void UpdateSystems()
    {
        var stream = EcsWorld
            .Query<SystemHolder>()
            .Has<FrameUpdateSystem>()
            .Stream();

        stream.For(static (ref SystemHolder holder) => holder.system.UpdateSystem());
    }

    public void SpawnSystem<TSystem, TType, TSystemType>()
        where TSystem : BaseSystem<TType>, ISystem, new()
        where TType : notnull, new()
        where TSystemType : SystemType, new()
    {
        var system = new TSystem();

        CreateEntity()
            .Add<TSystemType>()
            .Add(new SystemHolder(system))
            .Spawn().Dispose();
    }

    public EntitySpawner CreateEntity() => EcsWorld.Entity();
}