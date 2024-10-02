using CopperDevs.Games.Framework.Data;
using CopperDevs.Games.Framework.ECS.Components;

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
        game.SpawnSystem<TestSystem, Position, FrameUpdateSystem>();
    }
}