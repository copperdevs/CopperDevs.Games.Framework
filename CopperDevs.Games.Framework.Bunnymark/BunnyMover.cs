using System.Numerics;
using CopperDevs.Games.Framework.ECS;
using Raylib_CSharp.Windowing;

namespace CopperDevs.Games.Framework.Bunnymark;

public class BunnyMover() : BaseSystem<Bunny>(SystemStreamType.Job)
{
    public override void Update(ref Bunny bunny)
    {
        bunny.Position.X += bunny.Speed.Y;
        bunny.Position.Y += bunny.Speed.Y;
        
        if (bunny.Position.X + Program.BunnyTexture.Width/2f > Window.GetScreenWidth() ||
            bunny.Position.X + Program.BunnyTexture.Width/2f < 0) bunny.Speed.X *= -1;
        if (bunny.Position.Y + Program.BunnyTexture.Height/2f > Window.GetScreenHeight() ||
            bunny.Position.Y + Program.BunnyTexture.Height/2f - 40 < 0) bunny.Speed.Y *= -1;
    }
}