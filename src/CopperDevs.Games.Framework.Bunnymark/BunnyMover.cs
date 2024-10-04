using CopperDevs.Games.Framework.ECS;
using Raylib_CSharp;
using Raylib_CSharp.Windowing;

namespace CopperDevs.Games.Framework.Bunnymark;

public class BunnyMover : BaseSystem<Bunny>
{
    public override void Update(ref Bunny bunny)
    {
        // move bunny based off of speed
        bunny.Position.X += bunny.Speed.X * Time.GetFrameTime();
        bunny.Position.Y += bunny.Speed.Y * Time.GetFrameTime();

        // invert speed when the side of the screen is hit
        if (bunny.Position.X + Program.BunnyTexture.Width / 2f > Window.GetScreenWidth() || bunny.Position.X + Program.BunnyTexture.Width / 2f < 0)
            bunny.Speed.X *= -1;
        if (bunny.Position.Y + Program.BunnyTexture.Height / 2f > Window.GetScreenHeight() || bunny.Position.Y + Program.BunnyTexture.Height / 2f - 40 < 0)
            bunny.Speed.Y *= -1;
    }
}