﻿using System.Numerics;
using CopperDevs.Core.Data;
using CopperDevs.Games.ECS;
using CopperDevs.Games.ECS.Systems;
using CopperDevs.Games.Framework.Data;
using CopperDevs.Logger;
using Raylib_cs.BleedingEdge;

namespace CopperDevs.Games.Framework.Testing;

public static class Program
{
    private static Game game = null!;
    public static void Main()
    {
        var settings = new EngineSettings
        {
            WindowSize = new Vector2Int(800, 450),
            WindowFlags = ConfigFlags.Msaa4XHint | ConfigFlags.WindowAlwaysRun | ConfigFlags.VSyncHint | ConfigFlags.WindowResizable
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

        game.For<Vector2>(static (ref Vector2 vector2) => { vector2 = new Vector2(Random.Shared.NextSingle() * 500, Random.Shared.NextSingle() * 500); }, new HasFilter<Enemy>());

        game.SpawnSystem<MouseMover, Vector2, SystemTypes.FrameUpdate, StreamTypes.Job>(new HasFilter<Enemy>());

        game.SpawnSystem<Vector2Renderer, Vector2, SystemTypes.FrameUpdate, StreamTypes.For>();

        game.AddComponent<EnemySpawner, StreamTypes.Job>();

        var count = game.Stream<Vector2>(new HasFilter<Enemy>()).Count;

        Log.Debug(count);
    }
}

public readonly struct Enemy;
