using CopperDevs.Games.Framework.ECS.Components;
using CopperDevs.Games.Framework.ECS.Systems;
using Random = CopperDevs.Core.Utility.Random;

namespace CopperDevs.Games.Framework.Testing;

public class RandomMover() : BaseSystem<Position>(SystemStreamType.Job)
{
    public override void Update(ref Position component)
    {
        var circle = Random.InsideUnitCircle * 8;

        component.Value += circle;
    }
}