using CopperDevs.Core.Data;
using CopperDevs.Games.Framework.Data;
using CopperDevs.Games.Framework.ECS;
using CopperDevs.Games.Framework.Utility;
using Raylib_CSharp.Textures;
using Raylib_CSharp.Windowing;

namespace CopperDevs.Games.Framework.Bunnymark;

public static class Program
{
    internal static Texture2D BunnyTexture;
    private static Game game = null!;

    public static void Main()
    {
        var settings = new EngineSettings
        {
            WindowSize = new Vector2Int(800, 450),
            WindowFlags = ConfigFlags.Msaa4XHint | ConfigFlags.AlwaysRunWindow | ConfigFlags.VSyncHint | ConfigFlags.ResizableWindow
        };

        game = new Game(settings);

        game.OnGameStart += OnGameStart;

        game.Run();
        game.Dispose();
    }

    private static void OnGameStart()
    {
        // loads bunny texture from the embedded resources
        BunnyTexture = typeof(Bunny).Assembly.LoadTexture("CopperDevs.Games.Framework.Bunnymark.Resources.wabbit_alpha.png");

        // creates 100 initial bunnies
        game.CreateEntity().Add<Bunny>().Spawn(100).Dispose();

        // sets random default values for the initial bunnies
        game.QueryEntities<Bunny>().Stream().Job(static (ref Bunny bunny) => bunny.SetDefaultValues());

        // adds a system for moving each bunny, and a system to render all bunnies
        game.SpawnSystem<BunnyMover, Bunny, SystemTypes.FrameUpdate, StreamTypes.Job>();
        game.SpawnSystem<BunnyRenderer, Bunny, SystemTypes.FrameUpdate, StreamTypes.For>();

        game.AddComponent<UiRendering, StreamTypes.For>(); // simple ui to show how many bunnies, the games fps, and the batched draw calls 
        game.AddComponent<BunnySpawning, StreamTypes.Job>(); // spawn more bunnies on held left click
    }
}