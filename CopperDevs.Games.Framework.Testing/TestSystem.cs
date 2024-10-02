using CopperDevs.Games.Framework.ECS.Components;
using CopperDevs.Games.Framework.ECS.Systems;

namespace CopperDevs.Games.Framework.Testing;

public class TestSystem() : BaseSystem<Position>(SystemStreamType.Job)
{
    public override void Update(ref Position component)
    {
        
    }
}