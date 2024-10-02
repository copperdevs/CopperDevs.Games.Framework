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

    public Action<Game> OnGameStart = null!;

    public Game(EngineSettings settings)
    {
        RaylibLogger.Initialize();

        this.settings = settings;

        GameRenderer = new GameRenderer();
        GameRenderer.OnRender += UpdateSystems;
        GameRenderer.OnRender += BaseRendering;
        GameRenderer.OnUiRender += UiRendering;
    }

    protected override void CloseScope()
    {
        EcsWorld.Dispose();
        ImGuiRendering.Dispose();
    }
}