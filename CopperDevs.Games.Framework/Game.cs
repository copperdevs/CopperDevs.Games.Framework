using CopperDevs.Core.Utility;
using CopperDevs.Games.Framework.Data;
using CopperDevs.Games.Framework.Rendering;
using CopperDevs.Games.Framework.Utility;

namespace CopperDevs.Games.Framework;

public partial class Game : Scope
{
    private readonly EngineSettings settings;

    public Action<Game> OnGameStart = null!;

    public Game(EngineSettings settings)
    {
        RaylibLogger.Initialize();

        this.settings = settings;

        GameRenderer = new GameRenderer();
        GameRenderer.OnRender += BaseRendering;
        GameRenderer.OnUiRender += UiRendering;
    }

    protected override void CloseScope()
    {
        EcsWorld.Dispose();
        ImGuiRendering.Dispose();
    }

    public void Run()
    {
        SystemsRun();

        OnGameStart?.Invoke(this);

        RenderingRun();
    }
}