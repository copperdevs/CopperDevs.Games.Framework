using System.Numerics;
using System.Reflection;
using CopperDevs.Core.Data;
using CopperDevs.Games.Framework.Data;
using CopperDevs.Games.Framework.ECS;
using CopperDevs.Games.Framework.Utility;
using CopperDevs.Logger;
using fennecs;
using Raylib_CSharp.Windowing;

namespace CopperDevs.Games.Framework.Testing;

public static class Program
{
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
        using var enemySpawner = game.CreateEntity()
            .Add<Vector2>()
            .Add<Enemy>()
            .Spawn(100);

        // using var spawner = game.CreateEntity()
        //     .Add<Vector2>()
        //     .Spawn(100);

        game.QueryEntities<Vector2>().Has<Enemy>().Stream().For(static (ref Vector2 vector2) => { vector2 = new Vector2(Random.Shared.NextSingle() * 500, Random.Shared.NextSingle() * 500); });

        // game.SpawnSystem<RandomMover, Vector2, SystemTypes.FrameUpdate, StreamTypes.Job>();

        game.SpawnSystem<MouseMover, Vector2, Enemy, SystemTypes.FrameUpdate, StreamTypes.Job>();

        game.SpawnSystem<Vector2Renderer, Vector2, SystemTypes.FrameUpdate, StreamTypes.For>();

        game.AddComponent<EnemySpawner, StreamTypes.Job>();

        var count = Game.Instance.QueryEntities<Vector2>()
            .Has(typeof(Enemy))
            .Stream().Count;
        
        Log.Debug(count);
    }
}

public readonly struct Enemy;