using System.Numerics;
using CopperDevs.Core.Data;
using CopperDevs.Games.Framework.Data;
using CopperDevs.Games.Framework.ECS;
using CopperDevs.Logger;
using Raylib_CSharp;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Images;
using Raylib_CSharp.Interact;
using Raylib_CSharp.Rendering;
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
        game.OnRender += GameRender;

        game.Run();
        game.Dispose();
    }

    private static void OnGameStart()
    {
        LoadBunnyImage();

        game.CreateEntity().Add<Bunny>().Spawn(100).Dispose();

        Game.EcsWorld.Query<Bunny>().Stream().For(static (ref Bunny bunny) => bunny.SetValues());

        game.SpawnSystem<BunnyMover, Bunny, SystemTypes.FrameUpdate>();
        game.SpawnSystem<BunnyRenderer, Bunny, SystemTypes.FrameUpdate>();
    }

    private static void LoadBunnyImage()
    {
        var stream = typeof(Bunny).Assembly.GetManifestResourceStream("CopperDevs.Games.Framework.Bunnymark.Resources.wabbit_alpha.png");

        using var ms = new MemoryStream();

        stream?.CopyTo(ms);

        BunnyTexture = Texture2D.LoadFromImage(Image.LoadFromMemory(".png", ms.ToArray()));
    }

    private static void GameRender()
    {
        var count = Game.EcsWorld.Query<Bunny>().Stream().Count;

        Graphics.DrawRectangle(0, 0, Window.GetScreenWidth(), 60, Color.Black);
        Graphics.DrawText($"bunnies: {count}", 120, 30, 20, Color.Green);
        Graphics.DrawText($"batched draw calls: {1 + Game.EcsWorld.Query<Bunny>().Stream().Count / RlGl.DefaultBatchBufferElements}", 320, 30, 20, Color.Maroon);

        Graphics.DrawFPS(10, 30);

        if (Input.IsMouseButtonDown(MouseButton.Left))
        {
            for (var i = 0; i < 100; i++)
            {
                var bunny = new Bunny();

                bunny.SetValues(Input.GetMousePosition());

                game.CreateEntity().Add(bunny).Spawn().Dispose();
            }
        }
    }
}