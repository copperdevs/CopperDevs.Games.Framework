using System.Numerics;
using CopperDevs.Games.Framework.ECS;
using Random = CopperDevs.Core.Utility.Random;

namespace CopperDevs.Games.Framework.Testing;

public class RandomMover() : BaseSystem<Vector2>(SystemStreamType.Job)
{
    public override void Update(ref Vector2 component)
    {
        var circle = Random.InsideUnitCircle * 8;

        component += circle;
    }
}