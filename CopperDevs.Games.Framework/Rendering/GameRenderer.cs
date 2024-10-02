using Raylib_CSharp.Colors;
using Raylib_CSharp.Rendering;

namespace CopperDevs.Games.Framework.Rendering;

public class GameRenderer
{
    public Action OnRender = null!;
    public Action OnUiRender = null!;
    
    public void RenderFrame()
    {
        Graphics.ClearBackground(Color.RayWhite);
        Graphics.BeginDrawing();

        Graphics.DrawText("hello world!", 12, 12, 24, Color.Black);
        OnRender?.Invoke();

        Graphics.EndDrawing();
        
        OnUiRender?.Invoke();
    }
}