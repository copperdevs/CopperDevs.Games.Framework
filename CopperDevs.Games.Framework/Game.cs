using CopperDevs.Core.Utility;
using fennecs;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Rendering;

namespace CopperDevs.Games.Framework;

public class Game(EngineSettings settings) : Scope
{
    public readonly World EcsWorld = new();
    public EngineWindow Window = null!;

    protected override void CloseScope()
    {
        EcsWorld.Dispose();
    }

    public void Run()
    {
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

    public void SpawnSystem<TSystem, TType>() 
        where TType : struct 
        where TSystem : BaseSystem<TType>, new()
    {
        var system = new TSystem();
        // system.Update();

        var entity = EcsWorld.Spawn().Add<SystemTracker>();
        entity.Add<EntityID>(entity.GetHashCode());
    }
    internal readonly struct SystemTracker;
}