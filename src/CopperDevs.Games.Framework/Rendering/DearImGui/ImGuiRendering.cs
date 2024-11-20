using CopperDevs.Core.Utility;
using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Renderer.Raylib;

namespace CopperDevs.Games.Framework.Rendering.DearImGui;

public class ImGuiRendering : Scope
{
    public ImGuiRendering() => CopperImGui.Setup<RlImGuiRenderer<RlImGuiBinding>>();

    public void Render() => CopperImGui.Render();

    protected override void CloseScope() => CopperImGui.Shutdown();
}