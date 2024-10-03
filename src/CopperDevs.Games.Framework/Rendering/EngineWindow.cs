using CopperDevs.Core.Utility;
using CopperDevs.Games.Framework.Data;
using Raylib_CSharp;
using Raylib_CSharp.Windowing;

namespace CopperDevs.Games.Framework.Rendering;

public class EngineWindow : Scope
{
    public bool ShouldClose => Window.ShouldClose();
    public IntPtr Handle => Window.GetHandle();

    public EngineWindow(EngineSettings settings)
    {
        Raylib.SetConfigFlags(settings.WindowFlags);
        Window.Init(settings.WindowSize.X, settings.WindowSize.Y, settings.Title);
        DwmCustomization();
    }

    protected override void CloseScope()
    {
        Window.Close();
    }

    private void DwmCustomization()
    {
        if (!WindowsApi.IsWindows11)
            return;
        
        // WindowsApi.OnWindowResize += OnWindowsApiWindowResize;

        WindowsApi.SetDwmImmersiveDarkMode(Handle, true);
        WindowsApi.SetDwmSystemBackdropType(Handle, WindowsApi.SystemBackdropType.Acrylic);
        WindowsApi.SetDwmWindowCornerPreference(Handle, WindowsApi.WindowCornerPreference.Default);
        
        // WindowsApi.RegisterWindow(Handle);
    }
}