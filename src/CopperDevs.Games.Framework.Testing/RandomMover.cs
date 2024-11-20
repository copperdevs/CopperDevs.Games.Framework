using System.Numerics;
using CopperDevs.Core.Utility;
using CopperDevs.Games.ECS.Systems;
using CopperDevs.Games.Framework.Data;
using Raylib_cs.BleedingEdge;
using Random = CopperDevs.Core.Utility.Random;

namespace CopperDevs.Games.Framework.Testing;

public class RandomMover : BaseSystem<Vector2>
{
    public override void Update(ref Vector2 component)
    {
        var circle = MathUtil.Normalized(new Vector2(Random.Range(-128, 128), Random.Range(-128, 128))) * 128 * Time.DeltaTime;
        
        component += circle;

        if (component.X < 0)
            component.X = Raylib.GetScreenWidth() - 32;

        if (component.Y < 0)
            component.Y = Raylib.GetScreenHeight() - 32;

        if (component.X > Raylib.GetScreenWidth())
            component.X = 32;

        if (component.Y > Raylib.GetScreenHeight())
            component.Y = 32;

        if (component.Y is float.NaN)
            component.Y = 0;
        
        if (component.X is float.NaN)
            component.X = 0;
    }
}