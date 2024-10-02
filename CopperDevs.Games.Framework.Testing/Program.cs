using CopperDevs.Core.Utility;
using CopperDevs.Logger;

namespace CopperDevs.Games.Framework.Testing;

public static class Program
{
    public static void Main()
    {
        var settings = new EngineSettings();

        using var game = new Game(settings);
        game.Run();

        TestMethod<Test>();

        game.EcsWorld.Spawn().Add<Test>().Add<Name>("greg");

        game.SpawnSystem<TestSystem, Test, Game.FrameUpdateSystem>();
    }

    public static void TestMethod<T>() where T : struct
    {
    }

    public readonly struct Test;
}