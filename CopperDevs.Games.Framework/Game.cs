using CopperDevs.Core.Utility;
using fennecs;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Rendering;
using Random = CopperDevs.Core.Utility.Random;

namespace CopperDevs.Games.Framework;

public class Game(EngineSettings settings) : Scope
{
    private static readonly System.Random Random = new(new Guid().GetHashCode());

    public readonly World EcsWorld = new();
    public EngineWindow Window = null!;

    protected override void CloseScope()
    {
        EcsWorld.Dispose();
    }

    public void Run()
    {
        SpawnSystemManagersSystem();

        using (Window = new EngineWindow(settings))
        {
            while (!Window.ShouldClose)
            {
                Graphics.ClearBackground(Color.RayWhite);
                Graphics.BeginDrawing();

                Graphics.DrawText("hello world!", 12, 12, 24, Color.Black);

                Graphics.EndDrawing();
            }
        }
    }

    private void SpawnSystemManagersSystem()
    {
        SpawnSystemManager<FrameUpdateSystem>();

        return;

        void SpawnSystemManager<TSystemType>() where TSystemType : notnull, new()
        {
            var id = Random.Next(int.MinValue, int.MaxValue);

            var entity = EcsWorld.Spawn()
                .Add<SystemTracker>()
                .Add<TSystemType>();
            entity.Add<EntityID>(id);

            Systems.Add(id, []);
        }
    }

    private static readonly Dictionary<int, List<object>> Systems = new();

    public void SpawnSystem<TSystem, TType, TSystemType>()
        where TSystem : BaseSystem<TType>, new()
        where TType : notnull, new()
        where TSystemType : SystemType
    {
        var system = new TSystem();
        // system.Update();

        var entity = EcsWorld.Spawn().Add<SystemTracker>();
        entity.Add<EntityID>(entity.GetHashCode());

        var targetSystem = EcsWorld.Query<EntityID>()
            .Has<SystemTracker>()
            .Has<TSystemType>()
            .Stream();

        targetSystem.For((ref EntityID id) => Systems[id].Add(system));
    }

    internal readonly struct SystemTracker;

    public record SystemType;

    public sealed record FrameUpdateSystem : SystemType;
}