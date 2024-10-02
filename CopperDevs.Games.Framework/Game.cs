using CopperDevs.Core.Utility;
using CopperDevs.Games.Framework.Data;
using CopperDevs.Games.Framework.ECS.Components;
using CopperDevs.Games.Framework.ECS.Systems;
using CopperDevs.Games.Framework.Rendering;
using fennecs;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Rendering;

namespace CopperDevs.Games.Framework;

public class Game(EngineSettings settings) : Scope
{
    internal static readonly World EcsWorld = new();
    private EngineWindow Window = null!;
    private readonly SystemsManager SystemsManager = new();

    public Action<Game> OnGameStart = null!;

    protected override void CloseScope()
    {
        EcsWorld.Dispose();
    }

    public void Run()
    {
        SpawnSystemManagersSystem();

        OnGameStart?.Invoke(this);

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
        SystemsManager.AddSystemType<FrameUpdateSystem>();
    }

    public void SpawnSystem<TSystem, TType, TSystemType>()
        where TSystem : BaseSystem<TType>, ISystem, new()
        where TType : notnull, new()
        where TSystemType : SystemType
    {
        BaseSystem<TType> system = new TSystem();

        SystemsManager.AddSystem<TSystem, TType, TSystemType>((TSystem)system);
    }
}