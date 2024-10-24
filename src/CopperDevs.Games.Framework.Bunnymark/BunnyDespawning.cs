using CopperDevs.Games.Framework.ECS;
using Raylib_CSharp.Interact;

namespace CopperDevs.Games.Framework.Bunnymark;

public class BunnyDespawning : Component
{
    private const int BunnyChangeCount = 100;

    protected override void Update()
    {
        if (!Input.IsMouseButtonDown(MouseButton.Right)) 
            return;
        
        // get all bunnies and compile them
        var query = Game.Instance.QueryEntities<Bunny>().Compile();

        // take the first 100 and run them through a for each loop
        query.Take(BunnyChangeCount).ToList().ForEach(bunny =>
        {
            bunny.Remove<Bunny>();
            bunny.Despawn();
        });
    }
}