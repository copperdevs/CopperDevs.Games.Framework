using CopperDevs.Games.Framework.ECS;
using Raylib_cs.BleedingEdge;

namespace CopperDevs.Games.Framework.Bunnymark;

public class UiRendering : Component
{
    public const int DefaultBatchBufferElements = 8192;
    
    protected override void Update()
    {
        var count = Game.Instance.QueryEntities<Bunny>().Stream().Count;

        Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), 60, Color.Black);
        Raylib.DrawText($"bunnies: {count}", 120, 30, 20, Color.Green);
        Raylib.DrawText($"batched draw calls: {1 + count / DefaultBatchBufferElements}", 320, 30, 20, Color.Maroon);

        Raylib.DrawFPS(10, 30);
    }
}