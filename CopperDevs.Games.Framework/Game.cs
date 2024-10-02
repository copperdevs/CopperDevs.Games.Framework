using System.Diagnostics;
using CopperDevs.Core.Utility;
using CopperDevs.Games.Framework.Data;
using CopperDevs.Games.Framework.Rendering;
using CopperDevs.Games.Framework.Utility;

namespace CopperDevs.Games.Framework;

public partial class Game : Scope
{
    private Stopwatch stopwatch = null!;
    private readonly EngineSettings settings;

    public Action OnGameStart = null!;
    public Action OnRender = null!;
    public Action OnUiRender = null!;

    public Game(EngineSettings settings)
    {
        RaylibLogger.Initialize();

        this.settings = settings;

        GameRenderer = new GameRenderer();
        GameRenderer.OnRender += UpdateSystems;
        GameRenderer.OnRender += BaseRendering;
        GameRenderer.OnUiRender += UiRendering;
        GameRenderer.OnRender += () => OnRender?.Invoke();
        GameRenderer.OnUiRender += () => OnUiRender?.Invoke();
    }

    protected override void CloseScope()
    {
        EcsWorld.Dispose();
        ImGuiRendering.Dispose();
    }
}