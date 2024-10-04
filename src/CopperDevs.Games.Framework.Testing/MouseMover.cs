using System.Numerics;
using CopperDevs.Core.Utility;
using CopperDevs.Games.Framework.ECS;
using CopperDevs.Logger;
using Raylib_CSharp;
using Raylib_CSharp.Interact;
using Random = CopperDevs.Core.Utility.Random;

namespace CopperDevs.Games.Framework.Testing;

public class MouseMover : BaseSystem<Vector2>
{
    public override void Update(ref Vector2 component)
    {
        component += (LookAt(component, Input.GetMousePosition()).ToRotatedUnitVector() * (Vector2.Distance(component, Input.GetMousePosition()) > 64 ? 1 : -1)) * Time.GetFrameTime() * 32;
    }

    public float LookAt(Vector2 position, Vector2 point)
    {
        return -MathF.Atan2(position.Y - point.Y, position.X - point.X) * (180 / MathF.PI) + 180;
    }
}