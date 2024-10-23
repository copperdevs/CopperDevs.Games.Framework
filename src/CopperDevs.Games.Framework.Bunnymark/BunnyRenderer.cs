using CopperDevs.Games.ECS.Systems;
using Raylib_CSharp.Rendering;

namespace CopperDevs.Games.Framework.Bunnymark;

public class BunnyRenderer : BaseSystem<Bunny>
{
    public override void Update(ref Bunny bunny)
    {
        Graphics.DrawTexture(Program.BunnyTexture, (int)bunny.Position.X, (int)bunny.Position.Y, bunny.Color);
    }
}