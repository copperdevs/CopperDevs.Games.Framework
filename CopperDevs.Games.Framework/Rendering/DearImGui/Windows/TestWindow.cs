using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Attributes;
using CopperDevs.DearImGui.Rendering;

namespace CopperDevs.Games.Framework.Rendering.DearImGui.Windows;

[Window("Test Window")]
public class TestWindow : BaseWindow
{
    public override void WindowUpdate()
    {
        CopperImGui.Text("hello world!");
    }
}