﻿using System.Numerics;
using CopperDevs.Games.Framework.ECS;
using CopperDevs.Logger;
using Raylib_CSharp.Rendering;
using Raylib_CSharp.Textures;

namespace CopperDevs.Games.Framework.Bunnymark;

public class BunnyRenderer() : BaseSystem<Bunny>(SystemStreamType.For)
{
    public override void Update(ref Bunny bunny)
    {
        Graphics.DrawTexture(Program.BunnyTexture, (int)bunny.Position.X, (int)bunny.Position.Y, bunny.Color);
    }
}