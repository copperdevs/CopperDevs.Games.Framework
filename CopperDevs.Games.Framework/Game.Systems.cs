using CopperDevs.Games.Framework.ECS.Components;
using CopperDevs.Games.Framework.ECS.Systems;
using fennecs;

namespace CopperDevs.Games.Framework;

public partial class Game
{
    internal static readonly World EcsWorld = new();
    private readonly SystemsManager SystemsManager = new();

    private void SystemsRun()
    {
        SpawnSystemManagersSystem();
    }
    
    private void SpawnSystemManagersSystem()
    {
        SystemsManager.AddSystemType<FrameUpdateSystem>();
    }

    public void SpawnSystem<TSystem, TType, TSystemType>()
        where TSystem : BaseSystem<TType>, ISystem, new()
        where TType : notnull, new()
        where TSystemType : SystemType
    {
        BaseSystem<TType> system = new TSystem();

        SystemsManager.AddSystem<TSystem, TType, TSystemType>((TSystem)system);
    }
}