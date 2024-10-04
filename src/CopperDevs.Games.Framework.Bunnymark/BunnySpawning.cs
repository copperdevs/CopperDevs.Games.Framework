using CopperDevs.Games.Framework.ECS;
using Raylib_CSharp.Interact;

namespace CopperDevs.Games.Framework.Bunnymark;

public class BunnySpawning : Component
{
    protected override void Update()
    {
        if (Input.IsMouseButtonDown(MouseButton.Left))
        {
            // spawn bunnies
            Game.Instance.CreateEntity()
                .Add<Bunny>()
                .Add<NewBunny>()
                .Spawn(100)
                .Dispose();

            // get all new bunnies
            var query = Game.Instance.QueryEntities<Bunny>().Has<NewBunny>();

            // set default values with mouse position
            query.Stream().Job(static (ref Bunny bunny) => bunny.SetDefaultValues(Input.GetMousePosition()));

            // remove new bunny component from all created bunnies
            query.Compile().Remove<NewBunny>();
        }
    }
}