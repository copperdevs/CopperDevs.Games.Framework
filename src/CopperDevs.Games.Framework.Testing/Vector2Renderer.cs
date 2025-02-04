using System.Numerics;
using CopperDevs.Games.ECS.Systems;
using Raylib_cs.BleedingEdge;

namespace CopperDevs.Games.Framework.Testing;

public class Vector2Renderer : BaseSystem<Vector2>
{
    public override void Update(ref Vector2 component)
    {
        Raylib.DrawCircleV(component, 8, Color.Red);
    }
}