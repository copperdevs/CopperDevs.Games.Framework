using CopperDevs.Games.ECS.Utility;
using fennecs;

namespace CopperDevs.Games.ECS;

public partial class World : SafeDisposable
{
    private FennecsWorld ecsWorld = new();
    
    public EntitySpawner CreateEntity() => ecsWorld.Entity();
    
    public override void DisposeResources()
    {
        ecsWorld.Dispose();
    }
}