using System.Numerics;
using CopperDevs.Games.Framework.Data;
using CopperDevs.Games.Framework.ECS;

namespace CopperDevs.Games.Framework.Testing;

public static class Program
{
    public static void Main()
    {
        var settings = new EngineSettings();

        using var game = new Game(settings);
        game.OnGameStart += OnGameStart;

        game.Run();
    }

    private static void OnGameStart(Game game)
    {
        using var spawner = game.CreateEntity()
            .Add<Vector2>()
            .Spawn(100);

        game.SpawnSystem<RandomMover, Vector2, SystemTypes.FrameUpdate>();
        game.SpawnSystem<RandomRenderer, Vector2, SystemTypes.FrameUpdate>();
    }
}