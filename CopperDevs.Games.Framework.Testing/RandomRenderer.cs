using CopperDevs.Games.Framework.ECS.Components;
using CopperDevs.Games.Framework.ECS.Systems;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Rendering;
using Random = CopperDevs.Core.Utility.Random;

namespace CopperDevs.Games.Framework.Testing;

public class RandomRenderer() : BaseSystem<Position>(SystemStreamType.For)
{
    public override void Update(ref Position component)
    {
        // var circle = Random.InsideUnitCircle * 8;

        // component.Value += circle;

        Graphics.DrawCircleV(component.Value, 8, Color.Red);
    }
}