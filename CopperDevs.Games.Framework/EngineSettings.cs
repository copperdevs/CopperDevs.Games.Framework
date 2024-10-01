using System.Reflection;
using CopperDevs.Core.Data;
using Raylib_CSharp.Windowing;

namespace CopperDevs.Games.Framework;

public class EngineSettings
{
    public string Title { get; init; } = Assembly.GetEntryAssembly()?.GetName().Name ?? "CopperDevs.Games.Framework";
    public Vector2Int WindowSize { get; init; } = new(650, 450);
    public int TargetFps { get; init; } = 0;
    public int FixedTimeStep { get; init; } = 60;
    public ConfigFlags WindowFlags { get; init; } = ConfigFlags.Msaa4XHint | ConfigFlags.VSyncHint | ConfigFlags.ResizableWindow | ConfigFlags.AlwaysRunWindow;
}