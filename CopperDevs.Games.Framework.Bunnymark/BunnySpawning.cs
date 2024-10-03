using CopperDevs.Games.Framework.ECS;
using Raylib_CSharp.Interact;

namespace CopperDevs.Games.Framework.Bunnymark;

public class BunnySpawning : Component
{
    protected override void Update()
    {
        if (Input.IsMouseButtonDown(MouseButton.Left))
        {
            for (var i = 0; i < 100; i++)
            {
                var bunny = new Bunny();

                bunny.SetValues(Input.GetMousePosition());

                Game.Instance.CreateEntity().Add(bunny).Spawn().Dispose();
            }
        }
    }
}