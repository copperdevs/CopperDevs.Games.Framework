using System.Numerics;
using Raylib_CSharp;
using Raylib_CSharp.Colors;

namespace CopperDevs.Games.Framework.Bunnymark;

public struct Bunny(Vector2 position)
{
    public Vector2 Position = position;

    public Vector2 Speed = new(Raylib.GetRandomValue(-250, 250), Raylib.GetRandomValue(-250, 250));

    public Color Color = new(
        (byte)Raylib.GetRandomValue(50, 240),
        (byte)Raylib.GetRandomValue(80, 240),
        (byte)Raylib.GetRandomValue(100, 240),
        255);
}