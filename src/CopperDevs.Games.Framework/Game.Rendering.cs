﻿using CopperDevs.Games.Framework.ECS;
using CopperDevs.Games.Framework.Rendering;
using CopperDevs.Games.Framework.Rendering.DearImGui;

namespace CopperDevs.Games.Framework;

public partial class Game
{
    private EngineWindow window = null!;
    private readonly GameRenderer gameRenderer;
    private ImGuiRendering imGuiRendering = null!;

    public void Run()
    {
        using (window = new EngineWindow(settings))
        {
            OnGameStart?.Invoke();

            QueryEntities<ComponentHolder>().Stream().Job(static (ref ComponentHolder holder) => holder.Start());

            imGuiRendering = new ImGuiRendering();

            while (!EngineWindow.ShouldClose)
            {
                gameRenderer.RenderFrame();
            }
        }
    }

    private void BaseRendering()
    {

    }

    private void UiRendering()
    {
        imGuiRendering?.Render();
    }
}
