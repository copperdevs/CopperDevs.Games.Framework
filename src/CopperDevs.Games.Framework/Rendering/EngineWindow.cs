using CopperDevs.Core.Utility;
using CopperDevs.Games.Framework.Data;
using Raylib_cs.BleedingEdge;

namespace CopperDevs.Games.Framework.Rendering;

public class EngineWindow : Scope
{
    public bool ShouldClose => Raylib.WindowShouldClose();

    public IntPtr Handle
    {
        get
        {
            unsafe
            {
                return new IntPtr(Raylib.GetWindowHandle());
            }
        }
    }

    public EngineWindow(EngineSettings settings)
    {
        Raylib.SetConfigFlags(settings.WindowFlags);
        Raylib.InitWindow(settings.WindowSize.X, settings.WindowSize.Y, settings.Title);
        DwmCustomization();
    }

    protected override void CloseScope()
    {
        Raylib.CloseWindow();
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