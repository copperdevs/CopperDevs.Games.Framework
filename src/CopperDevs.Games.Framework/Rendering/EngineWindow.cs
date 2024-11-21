using CopperDevs.Core.Utility;
using CopperDevs.Games.Framework.Data;

namespace CopperDevs.Games.Framework.Rendering;

public class EngineWindow : Scope
{
    public static bool ShouldClose => WindowShouldClose();

    public static IntPtr Handle
    {
        get
        {
            unsafe
            {
                return new IntPtr(GetWindowHandle());
            }
        }
    }

    public EngineWindow(EngineSettings settings)
    {
        SetConfigFlags(settings.WindowFlags);
        InitWindow(settings.WindowSize.X, settings.WindowSize.Y, settings.Title);
        DwmCustomization();
    }

    protected override void CloseScope()
    {
        CloseWindow();
    }

    private static void DwmCustomization()
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
