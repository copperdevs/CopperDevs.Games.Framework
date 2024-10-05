namespace CopperDevs.Games.Framework.Data;

public static class Time
{
    public static float TotalTime => (float)rlTime.GetTime();
    public static float DeltaTime => rlTime.GetFrameTime();
}