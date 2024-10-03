using CopperDevs.Games.Framework.ECS;
using Raylib_CSharp;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Rendering;
using Raylib_CSharp.Windowing;

namespace CopperDevs.Games.Framework.Bunnymark;

public class UiRendering : Component
{
    protected override void Update()
    {
        var count = Game.Instance.QueryEntities<Bunny>().Stream().Count;

        Graphics.DrawRectangle(0, 0, Window.GetScreenWidth(), 60, Color.Black);
        Graphics.DrawText($"bunnies: {count}", 120, 30, 20, Color.Green);
        Graphics.DrawText($"batched draw calls: {1 + count / RlGl.DefaultBatchBufferElements}", 320, 30, 20, Color.Maroon);

        Graphics.DrawFPS(10, 30);
    }
}