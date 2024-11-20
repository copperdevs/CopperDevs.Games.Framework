using CopperDevs.Games.ECS.Systems;
using Raylib_cs.BleedingEdge;

namespace CopperDevs.Games.Framework.Bunnymark;

public class BunnyRenderer : BaseSystem<Bunny>
{
    public override void Update(ref Bunny bunny)
    {
        Raylib.DrawTexture(Program.BunnyTexture, (int)bunny.Position.X, (int)bunny.Position.Y, bunny.Color);
    }
}
