using System.Numerics;
using CopperDevs.Games.Framework.ECS;
using Raylib_cs.BleedingEdge;

namespace CopperDevs.Games.Framework.Testing;

public class EnemySpawner : Component
{
    protected override void Update()
    {
        if (Raylib.IsMouseButtonDown(MouseButton.Left))
        {
            using var enemySpawner = Game.Instance.CreateEntity()
                .Add<Vector2>()
                .Add<Enemy>()
                .Spawn(100);
        }
    }
}