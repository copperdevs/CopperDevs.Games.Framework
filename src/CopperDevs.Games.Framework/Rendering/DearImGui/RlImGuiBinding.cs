using System.Numerics;
using CopperDevs.Core.Data;
using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Renderer.Raylib.Bindings;
using Raylib_cs.BleedingEdge;
using ConfigFlags = CopperDevs.DearImGui.Renderer.Raylib.Bindings.ConfigFlags;
using GamepadAxis = CopperDevs.DearImGui.Renderer.Raylib.Bindings.GamepadAxis;
using GamepadButton = CopperDevs.DearImGui.Renderer.Raylib.Bindings.GamepadButton;
using KeyboardKey = CopperDevs.DearImGui.Renderer.Raylib.Bindings.KeyboardKey;
using MouseButton = CopperDevs.DearImGui.Renderer.Raylib.Bindings.MouseButton;
using MouseCursor = CopperDevs.DearImGui.Renderer.Raylib.Bindings.MouseCursor;
using Texture2D = CopperDevs.DearImGui.Renderer.Raylib.Bindings.Texture2D;
using rlTexture2D = Raylib_cs.BleedingEdge.Texture2D;
using rlKeyboardKey = Raylib_cs.BleedingEdge.KeyboardKey;
using rlMouseButton = Raylib_cs.BleedingEdge.MouseButton;
using rlConfigFlags = Raylib_cs.BleedingEdge.ConfigFlags;
using rlMouseCursor = Raylib_cs.BleedingEdge.MouseCursor;
using rlGamepadButton = Raylib_cs.BleedingEdge.GamepadButton;
using rlGamepadAxis = Raylib_cs.BleedingEdge.GamepadAxis;

namespace CopperDevs.Games.Framework.Rendering.DearImGui;

public class RlImGuiBinding : RlBinding
{
    public RlImGuiBinding()
    {
        // CopperImGui.RegisterFieldRenderer<Color, ColorFieldRenderer>();
        // CopperImGui.RegisterFieldRenderer<rlTexture2D, Texture2DFieldRenderer>();
        // CopperImGui.RegisterFieldRenderer<RenderTexture2D, RenderTexture2DFieldRenderer>();
    }
    
    public override Texture2D LoadFontTexture(IntPtr data, Vector2Int size)
    {
        unsafe
        {
            var image = new Image
            {
                Data = (void*)data,
                Width = size.X,
                Height = size.Y,
                Mipmaps = 1,
                Format = PixelFormat.UncompressedR8G8B8A8,
            };
        
            var rlTexture = Raylib.LoadTextureFromImage(image);

            return new Texture2D
            {
                Width = rlTexture.Width,
                Height = rlTexture.Height,
                Id = rlTexture.Id,
                bindingObject = rlTexture
            };
        }
    }

    public override void UnloadTexture(Texture2D texture)
    {
        Raylib.UnloadTexture((rlTexture2D)texture.bindingObject);
    }


    public override bool InputIsKeyDown(KeyboardKey key)
    {
        return Raylib.IsKeyDown((rlKeyboardKey)key);
    }

    public override bool WindowIsFocused()
    {
        return Raylib.IsWindowFocused();
    }

    public override string WindowGetClipboardText()
    {
        return Raylib.GetClipboardText_();
    }

    public override void WindowSetClipboardText(string text)
    {
        Raylib.SetClipboardText(text);
    }

    public override bool InputIsMouseButtonPressed(MouseButton button)
    {
        return Raylib.IsMouseButtonPressed((rlMouseButton)button);
    }

    public override bool InputIsMouseButtonReleased(MouseButton button)
    {
        return Raylib.IsMouseButtonReleased((rlMouseButton)button);
    }

    public override bool WindowIsFullscreen()
    {
        return Raylib.IsWindowFullscreen();
    }

    public override int WindowGetCurrentMonitor()
    {
        return Raylib.GetCurrentMonitor();
    }

    public override int WindowGetMonitorWidth(int monitor)
    {
        return Raylib.GetMonitorWidth(monitor);
    }

    public override int WindowGetMonitorHeight(int monitor)
    {
        return Raylib.GetMonitorHeight(monitor);
    }

    public override int WindowGetScreenWidth()
    {
        return Raylib.GetScreenWidth();
    }

    public override int WindowGetScreenHeight()
    {
        return Raylib.GetScreenHeight();
    }

    public override bool WindowIsState(ConfigFlags flag)
    {
        return Raylib.IsWindowState((rlConfigFlags)flag);
    }

    public override Vector2 WindowGetScaleDPI()
    {
        return Raylib.GetWindowScaleDPI();
    }

    public override float TimeGetFrameTime()
    {
        return Raylib.GetFrameTime();
    }

    public override void InputSetMousePosition(int mousePosX, int mousePosY)
    {
        Raylib.SetMousePosition(mousePosX, mousePosY);
    }

    public override int InputGetMouseX()
    {
        return Raylib.GetMouseX();
    }

    public override int InputGetMouseY()
    {
        return Raylib.GetMouseY();
    }

    public override Vector2 InputGetMouseWheelMoveV()
    {
        return Raylib.GetMouseWheelMoveV();
    }

    public override void InputHideCursor()
    {
        Raylib.HideCursor();
    }

    public override void InputShowCursor()
    {
        Raylib.ShowCursor();
    }

    public override void InputSetMouseCursor(MouseCursor value)
    {
        Raylib.SetMouseCursor((rlMouseCursor)value);
    }

    public override KeyboardKey InputGetKeyPressed()
    {
        return (KeyboardKey)Raylib.GetKeyPressed();
    }

    public override bool InputIsKeyReleased(KeyboardKey key)
    {
        return Raylib.IsKeyPressed((rlKeyboardKey)key);
    }

    public override int InputGetCharPressed()
    {
        return Raylib.GetCharPressed();
    }

    public override bool InputIsGamepadAvailable(int i)
    {
        return Raylib.IsGamepadAvailable(i);
    }

    public override bool InputIsGamepadButtonPressed(int i, GamepadButton button)
    {
        return Raylib.IsGamepadButtonPressed(i, (rlGamepadButton)button);
    }

    public override bool InputIsGamepadButtonReleased(int i, GamepadButton button)
    {
        return Raylib.IsGamepadButtonReleased(i, (rlGamepadButton)button);
    }

    public override float InputGetGamepadAxisMovement(int i, GamepadAxis axis)
    {
        return Raylib.IsGamepadButtonReleased(i, (rlGamepadButton)axis);
    }

    public override void RlGlEnableScissorTest()
    {
        Rlgl.EnableScissorTest();
    }

    public override void RlGlScissor(int scaleX, int displaySizeY, int width, int scaleY)
    {
        Rlgl.Scissor(scaleX, displaySizeY, width, scaleY);
    }

    public override void RlGlColor4F(float colorX, float colorY, float colorZ, float colorW)
    {
        Rlgl.Color4f(colorX, colorY, colorZ, colorW);
    }

    public override void RlGlTexCoord2F(float uvX, float uvY)
    {
        Rlgl.TexCoord2f(uvX, uvY);
    }

    public override void RlGlVertex2F(float posX, float posY)
    {
        Rlgl.Vertex2f(posX, posY);
    }

    public override void RlGlBegin(int p0)
    {
        Rlgl.Begin((DrawMode)p0);
    }

    public override void RlGlSetTexture(uint textureId)
    {
        Rlgl.SetTexture(textureId);
    }

    public override bool RlGlCheckRenderBatchLimit(int i)
    {
        return Rlgl.CheckRenderBatchLimit(i);
    }

    public override void RlGlEnd()
    {
        Rlgl.End();
    }

    public override void RlGlDrawRenderBatchActive()
    {
        Rlgl.DrawRenderBatchActive();
    }

    public override void RlGlDisableBackfaceCulling()
    {
        Rlgl.DisableBackfaceCulling();
    }

    public override void RlGlDisableScissorTest()
    {
        Rlgl.DisableScissorTest();
    }

    public override void RlGlEnableBackfaceCulling()
    {
        Rlgl.EnableBackfaceCulling();
    }
}