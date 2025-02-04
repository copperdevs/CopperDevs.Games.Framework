using System.Numerics;
using CopperDevs.Core.Utility;
using CopperDevs.Games.ECS.Systems;
using CopperDevs.Games.Framework.Data;
using Raylib_cs.BleedingEdge;

namespace CopperDevs.Games.Framework.Testing;

public class MouseMover : BaseSystem<Vector2>
{
    public override void Update(ref Vector2 component)
    {
        component += (LookAt(component, Raylib.GetMousePosition()).ToRotatedUnitVector() * (Vector2.Distance(component, Raylib.GetMousePosition()) > 64 ? 1 : -1)) * Time.DeltaTime * 32;
    }

    public static float LookAt(Vector2 position, Vector2 point)
    {
        return -MathF.Atan2(position.Y - point.Y, position.X - point.X) * (180 / MathF.PI) + 180;
    }
}
