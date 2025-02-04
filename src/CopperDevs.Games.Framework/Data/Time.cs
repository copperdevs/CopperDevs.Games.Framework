namespace CopperDevs.Games.Framework.Data;

public static class Time
{
    public static float TotalTime => (float)GetTime();
    public static float DeltaTime => GetFrameTime();
}
