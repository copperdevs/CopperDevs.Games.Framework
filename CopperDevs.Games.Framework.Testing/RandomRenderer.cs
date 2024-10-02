using System.Numerics;
using CopperDevs.Games.Framework.ECS;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Rendering;

namespace CopperDevs.Games.Framework.Testing;

public class RandomRenderer() : BaseSystem<Vector2>(SystemStreamType.For)
{
    public override void Update(ref Vector2 component)
    {
        Graphics.DrawCircleV(component, 8, Color.Red);
    }
}