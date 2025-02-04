using CopperDevs.Core.Utility;
using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Renderer.Raylib;

namespace CopperDevs.Games.Framework.Rendering.DearImGui;

public class ImGuiRendering : Scope
{
    public ImGuiRendering() => CopperImGui.Setup<RlImGuiRenderer<RlImGuiBinding>>();

#pragma warning disable CA1822
    public void Render() => CopperImGui.Render();
#pragma warning restore CA1822

    protected override void CloseScope() => CopperImGui.Shutdown();
}
