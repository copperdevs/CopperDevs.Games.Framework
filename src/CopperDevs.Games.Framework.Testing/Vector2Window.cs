using System.Numerics;
using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Rendering;

namespace CopperDevs.Games.Framework.Testing;

[Window("Vector2 Values", WindowOpen = true)]
public class Vector2Window : BaseWindow
{
    private static int index;
    
    public override void WindowUpdate()
    {
        var stream = Game.Instance.QueryEntities<Vector2>().Stream();

        CopperImGui.Text(stream.Count);
        
        index = 0;
        
        stream.For(static (ref Vector2 vector) =>
        {
            index++;
            
            CopperImGui.DragValue(index.ToString(), ref vector);
        });
    }
}