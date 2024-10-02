using CopperDevs.Games.Framework.Rendering;
using CopperDevs.Games.Framework.Rendering.DearImGui;
using Raylib_CSharp;
using Raylib_CSharp.Rendering;

namespace CopperDevs.Games.Framework;

public partial class Game
{
    private EngineWindow Window = null!;
    private readonly GameRenderer GameRenderer;
    private ImGuiRendering ImGuiRendering = null!;

    private void RenderingRun()
    {
        using (Window = new EngineWindow(settings))
        {
            ImGuiRendering = new ImGuiRendering();
            
            while (!Window.ShouldClose)
            {
                GameRenderer.RenderFrame();
            }
        }
    }

    private void BaseRendering()
    {
        Graphics.DrawFPS(24, 24);
    }

    private void UiRendering()
    {
        ImGuiRendering?.Render();
    }
}