using System.Numerics;
using System.Reflection;
using CopperDevs.Core.Data;
using CopperDevs.Games.Framework.Data;
using CopperDevs.Games.Framework.ECS;
using Raylib_CSharp.Images;
using Raylib_CSharp.Textures;
using Raylib_CSharp.Windowing;

namespace CopperDevs.Games.Framework.Bunnymark;

public static class Program
{
    internal static Texture2D BunnyTexture;
    
    public static void Main()
    {
        var settings = new EngineSettings
        {
            WindowSize = new Vector2Int(800, 450),
            WindowFlags = ConfigFlags.Msaa4XHint | ConfigFlags.AlwaysRunWindow | ConfigFlags.VSyncHint
        };

        using var game = new Game(settings);
        game.OnGameStart += OnGameStart;

        game.Run();
    }

    private static void OnGameStart(Game game)
    {
        LoadBunnyImage();
        
        using var spawner = game.CreateEntity()
            .Add<Bunny>()
            .Spawn(100);

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
}