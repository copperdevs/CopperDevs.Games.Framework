using CopperDevs.Core.Utility;
using Raylib_CSharp;
using Raylib_CSharp.Windowing;

namespace CopperDevs.Games.Framework;

public class EngineWindow : Scope
{
    public bool ShouldClose => Window.ShouldClose();
    public IntPtr Handle => Window.GetHandle();

    public EngineWindow(EngineSettings settings)
    {
        Raylib.SetConfigFlags(settings.WindowFlags);
        Window.Init(settings.WindowSize.X, settings.WindowSize.Y, settings.Title);
    }

    public void Close()
    {
        Window.Close();
    }

    protected override void CloseScope()
    {
        Window.Close();
    }
}