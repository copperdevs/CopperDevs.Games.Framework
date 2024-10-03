using System.Numerics;
using CopperDevs.Games.Framework.ECS;
using Raylib_CSharp.Interact;

namespace CopperDevs.Games.Framework.Testing;

public class EnemySpawner : Component
{
    protected override void Update()
    {
        if (Input.IsMouseButtonDown(MouseButton.Left))
        {
            using var enemySpawner = Game.Instance.CreateEntity()
                .Add<Vector2>()
                .Add<Enemy>()
                .Spawn(100);
        }
    }
}