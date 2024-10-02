using CopperDevs.Games.Framework.Data;
using CopperDevs.Games.Framework.ECS.Components;
using CopperDevs.Games.Framework.ECS.Systems;

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
            .Add(new Position())
            .Spawn(100);

        game.SpawnSystem<RandomMover, Position, SystemTypes.FrameUpdate>();
        game.SpawnSystem<RandomRenderer, Position, SystemTypes.FrameUpdate>();
    }
}