using CopperDevs.Games.Framework.ECS.Components;

namespace CopperDevs.Games.Framework.ECS.Systems;

public class SystemsManager
{
    private readonly Dictionary<Type, List<ISystem>> Systems = new();

    public void AddSystem<TSystem, TType, TSystemType>(TSystem system)
        where TSystem : BaseSystem<TType>, ISystem, new()
        where TType : notnull, new()
        where TSystemType : SystemType
    {
        AddSystemType<TSystemType>();

        HasSystemType<TSystemType>(out var foundSystems);

        foundSystems?.Add(system);
    }

    public bool HasSystemType<T>(out List<ISystem>? systems) where T : SystemType
    {
        if (Systems.TryGetValue(typeof(T), out var foundSystems))
        {
            systems = foundSystems;
            return true;
        }

        systems = null;
        return false;
    }

    public void AddSystemType<T>() where T : SystemType
    {
        if (!HasSystemType<T>(out _))
            Systems.Add(typeof(T), []);
    }
}