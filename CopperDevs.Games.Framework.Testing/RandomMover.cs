using System.Numerics;
using CopperDevs.Core.Utility;
using CopperDevs.Games.Framework.ECS;
using CopperDevs.Logger;
using Raylib_CSharp;
using Raylib_CSharp.Windowing;
using Random = CopperDevs.Core.Utility.Random;

namespace CopperDevs.Games.Framework.Testing;

public class RandomMover() : BaseSystem<Vector2>(SystemStreamType.Job)
{
    public override void Update(ref Vector2 component)
    {
        var circle = MathUtil.Normalized(new Vector2(Random.Range(-128, 128), Random.Range(-128, 128))) * 128 * Time.GetFrameTime();
        
        component += circle;

        if (component.X < 0)
            component.X = Window.GetScreenWidth() - 32;

        if (component.Y < 0)
            component.Y = Window.GetScreenHeight() - 32;

        if (component.X > Window.GetScreenWidth())
            component.X = 32;

        if (component.Y > Window.GetScreenHeight())
            component.Y = 32;

        if (component.Y is float.NaN)
            component.Y = 0;
        
        if (component.X is float.NaN)
            component.X = 0;
        
        Log.Debug(component);
    }
}