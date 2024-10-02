using System.Diagnostics;
using CopperDevs.Games.Framework.ECS.Components;
using CopperDevs.Games.Framework.ECS.Systems;
using CopperDevs.Logger;
using fennecs;

namespace CopperDevs.Games.Framework;

public partial class Game
{
    internal static readonly World EcsWorld = new();
    
    private void UpdateSystems()
    {
        // stopwatch = Stopwatch.StartNew();
        
        var stream = EcsWorld
            .Query<SystemHolder>()
            .Has<FrameUpdateSystem>()
            .Stream();

        // Log.Performance($"stream: {stopwatch.Elapsed}");
        
        stream.For((ref SystemHolder holder) => holder.system.UpdateSystem());
        
        // Log.Performance($"for: {stopwatch.Elapsed}");
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