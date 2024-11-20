

using Raylib_cs.BleedingEdge;

namespace CopperDevs.Games.Framework.Rendering;

public class GameRenderer
{
    public Action OnRender = null!;
    public Action OnUiRender = null!;
    
    public void RenderFrame()
    {
        Raylib.ClearBackground(Color.RayWhite);
        Raylib.BeginDrawing();

        OnRender?.Invoke();
        OnUiRender?.Invoke();

        Raylib.EndDrawing();
    }
}