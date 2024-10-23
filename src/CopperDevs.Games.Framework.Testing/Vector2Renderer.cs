using System.Numerics;
using CopperDevs.Games.ECS.Systems;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Rendering;

namespace CopperDevs.Games.Framework.Testing;

public class Vector2Renderer : BaseSystem<Vector2>
{
    public override void Update(ref Vector2 component)
    {
        Graphics.DrawCircleV(component, 8, Color.Red);
    }
}