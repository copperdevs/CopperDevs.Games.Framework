using System.Numerics;
using Raylib_CSharp;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Windowing;

namespace CopperDevs.Games.Framework.Bunnymark;

public struct Bunny
{
    public Vector2 Position;

    public Vector2 Speed;

    public Color Color;

    public void SetDefaultValues()
    {
        Raylib.SetRandomSeed((uint)(Random.Shared.Next(int.MinValue, int.MaxValue) - int.MinValue));
        SetDefaultValues(new Vector2(Raylib.GetRandomValue(0, Window.GetScreenWidth()), Raylib.GetRandomValue(0, Window.GetScreenHeight())));
    }

    public void SetDefaultValues(Vector2 position)
    {
        Position = position;

        Raylib.SetRandomSeed((uint)(Random.Shared.Next(int.MinValue, int.MaxValue) - int.MinValue));
        Speed = new Vector2(Raylib.GetRandomValue(-250, 250), Raylib.GetRandomValue(-250, 250));

        Raylib.SetRandomSeed((uint)(Random.Shared.Next(int.MinValue, int.MaxValue) - int.MinValue));
        Color = new Color(
            (byte)Raylib.GetRandomValue(50, 240),
            (byte)Raylib.GetRandomValue(80, 240),
            (byte)Raylib.GetRandomValue(100, 240),
            255);
    }
}