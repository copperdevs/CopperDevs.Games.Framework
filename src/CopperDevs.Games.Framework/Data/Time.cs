using Raylib_cs.BleedingEdge;

namespace CopperDevs.Games.Framework.Data;

public static class Time
{
    public static float TotalTime => (float)Raylib.GetTime();
    public static float DeltaTime => Raylib.GetFrameTime();
}