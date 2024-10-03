using System.Numerics;
using CopperDevs.Games.Framework.Data;
using CopperDevs.Games.Framework.ECS;

namespace CopperDevs.Games.Framework.Testing;

public static class Program
{
    private static Game game = null!;
    
    public static void Main()
    {
        var settings = new EngineSettings();

        game = new Game(settings);
        game.OnGameStart += OnGameStart;

        game.Run();
        game.Dispose();
    }

    private static void OnGameStart()
    {
        using var spawner = game.CreateEntity()
            .Add<Vector2>()
            .Spawn(100);

        game.QueryEntities<Vector2>().Stream().For(static (ref Vector2 vector2) => { vector2 = new Vector2(Random.Shared.NextSingle() * 250, Random.Shared.NextSingle() * 250); });

        game.SpawnSystem<RandomMover, Vector2, SystemTypes.FrameUpdate, StreamTypes.Job>();
        game.SpawnSystem<RandomRenderer, Vector2, SystemTypes.FrameUpdate, StreamTypes.For>();
    }
}