using CopperDevs.Games.ECS.Systems;
using CopperDevs.Games.Framework.Data;
using Raylib_cs.BleedingEdge;

namespace CopperDevs.Games.Framework.Bunnymark;

public class BunnyMover : BaseSystem<Bunny>
{
    public override void Update(ref Bunny bunny)
    {
        // move bunny based off of speed
        bunny.Position.X += bunny.Speed.X * Time.DeltaTime;
        bunny.Position.Y += bunny.Speed.Y * Time.DeltaTime;

        // invert speed when the side of the screen is hit
        if (bunny.Position.X + Program.BunnyTexture.Width / 2f > Raylib.GetScreenWidth() || bunny.Position.X + Program.BunnyTexture.Width / 2f < 0)
            bunny.Speed.X *= -1;
        if (bunny.Position.Y + Program.BunnyTexture.Height / 2f > Raylib.GetScreenHeight() || bunny.Position.Y + Program.BunnyTexture.Height / 2f - 40 < 0)
            bunny.Speed.Y *= -1;
    }
}
