using CopperDevs.Games.ECS;
using CopperDevs.Games.Framework.ECS;
using Raylib_cs.BleedingEdge;

namespace CopperDevs.Games.Framework.Bunnymark;

public class BunnySpawning : Component
{
    private const int BunnyChangeCount = 100;

    protected override void Update()
    {
        if (!Raylib.IsMouseButtonDown(MouseButton.Left))
            return;

        // spawn bunnies
        Game.Instance.CreateEntity()
            .Add<Bunny>()
            .Add<NewBunny>()
            .Spawn(BunnyChangeCount)
            .Dispose();

        // get all new bunnies
        var query = Game.Instance.QueryEntities<Bunny>(new HasFilter<NewBunny>());

        // set default values with mouse position
        query.Stream().Job(static (ref Bunny bunny) => bunny.SetDefaultValues(Raylib.GetMousePosition()));

        // remove new bunny component from all created bunnies
        query.Compile().Remove<NewBunny>();
    }
}
