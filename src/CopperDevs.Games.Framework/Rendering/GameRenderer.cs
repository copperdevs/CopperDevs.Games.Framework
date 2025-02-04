using CopperDevs.Games.Framework.Utility;

namespace CopperDevs.Games.Framework.Rendering;

public class GameRenderer
{
    public Action OnRender = null!;
    public Action OnUiRender = null!;

    public void RenderFrame()
    {
        ClearBackground(Color.RayWhite);
        BeginDrawing();

        OnRender?.Invoke();
        OnUiRender?.Invoke();

        EndDrawing();
    }
}