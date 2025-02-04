using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CopperDevs.Logger;

namespace CopperDevs.Games.Framework.Utility;

public static class RaylibLogger
{
    internal static bool HideLogs = false;

    public static void Initialize()
    {
        unsafe
        {
            SetTraceLogCallback(&RayLibLog);
            SetTraceLogLevel(TraceLogLevel.All);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe void RayLibLog(TraceLogLevel logLevel, sbyte* rawText, IntPtr args)
    {
        if (HideLogs)
            return;

        var text = Marshal.PtrToStringUTF8((IntPtr)rawText) ?? string.Empty; ;

        switch (logLevel)
        {
            case TraceLogLevel.All:
                RaylibLogInfo(text);
                break;
            case TraceLogLevel.Trace:
                RaylibLogTrace(text);
                break;
            case TraceLogLevel.Debug:
                RaylibLogDebug(text);
                break;
            case TraceLogLevel.Info:
                RaylibLogInfo(text);
                break;
            case TraceLogLevel.Warning:
                RaylibLogWarning(text);
                break;
            case TraceLogLevel.Error:
                RaylibLogError(text);
                break;
            case TraceLogLevel.Fatal:
                RaylibLogFatal(text);
                break;
            case TraceLogLevel.None:
                RaylibLogDebug(text);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
        }
    }

    private static void RaylibLogInfo(object message)
    {
        var color = AnsiColors.GetColor(AnsiColors.Names.Cyan);
        Log.Info($"{AnsiColors.Black}{AnsiColors.WhiteBackground} Raylib {AnsiColors.Reset}{color} {message}{AnsiColors.Black}");
    }

    private static void RaylibLogTrace(object message)
    {
        var color = AnsiColors.GetColor(AnsiColors.Names.LightBlue);
        Log.Trace($"{AnsiColors.Black}{AnsiColors.WhiteBackground} Raylib {AnsiColors.Reset}{color} {message}{AnsiColors.Black}");
    }

    private static void RaylibLogDebug(object message)
    {
        var color = AnsiColors.GetColor(AnsiColors.Names.Gray);
        Log.Debug($"{AnsiColors.Black}{AnsiColors.WhiteBackground} Raylib {AnsiColors.Reset}{color} {message}{AnsiColors.Black}");
    }

    private static void RaylibLogWarning(object message)
    {
        var color = AnsiColors.GetColor(AnsiColors.Names.BrightYellow);
        Log.Warning($"{AnsiColors.Black}{AnsiColors.WhiteBackground} Raylib {AnsiColors.Reset}{color} {message}{AnsiColors.Black}");
    }

    private static void RaylibLogError(object message)
    {
        var color = AnsiColors.GetColor(AnsiColors.Names.Red);
        Log.Error($"{AnsiColors.Black}{AnsiColors.WhiteBackground} Raylib {AnsiColors.Reset}{color} {message}{AnsiColors.Black}");
    }

    private static void RaylibLogFatal(object message)
    {
        var color = AnsiColors.GetColor(AnsiColors.Names.DarkRed);
        Log.Fatal($"{AnsiColors.Black}{AnsiColors.WhiteBackground} Raylib {AnsiColors.Reset}{color} {message}{AnsiColors.Black}");
    }
}
