using CopperDevs.Core.Data;
using CopperDevs.Games.Framework.Data;
using CopperDevs.Games.Framework.ECS;
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

        game.Run();
        game.Dispose();
    }

    private static void OnGameStart()
    {
        LoadBunnyImage();

        game.CreateEntity().Add<Bunny>().Spawn(100).Dispose();

        game.QueryEntities<Bunny>().Stream().Job(static (ref Bunny bunny) => bunny.SetValues());

        game.SpawnSystem<BunnyMover, Bunny, SystemTypes.FrameUpdate, StreamTypes.Job>();
        game.SpawnSystem<BunnyRenderer, Bunny, SystemTypes.FrameUpdate, StreamTypes.For>();
        
        game.AddComponent<UiRendering, StreamTypes.For>();
        game.AddComponent<BunnySpawning, StreamTypes.Job>();
    }

    private static void LoadBunnyImage()
    {
        var stream = typeof(Bunny).Assembly.GetManifestResourceStream("CopperDevs.Games.Framework.Bunnymark.Resources.wabbit_alpha.png");

        using var ms = new MemoryStream();

        stream?.CopyTo(ms);

        var image = Image.LoadFromMemory(".png", ms.ToArray());

        BunnyTexture = Texture2D.LoadFromImage(image);

        image.Unload();
    }
}