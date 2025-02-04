using CopperDevs.Games.Framework.ECS;

namespace CopperDevs.Games.Framework;

public partial class Game
{
    private readonly Dictionary<Type, BaseScene> scenes = new()
    {
        { typeof(DefaultScene), new DefaultScene() }
    };

    private Type currentActiveSceneType = typeof(DefaultScene);

    public void SetActiveScene<T>() where T : BaseScene, new() => SetActiveScene(typeof(T));
    internal World GetSceneWorld<T>() where T : BaseScene, new() => GetSceneWorld(typeof(T));

    public void SetActiveScene(Type type)
    {
        if (type == typeof(BaseScene))
            return;

        if (!scenes.ContainsKey(type))
            scenes.Add(type, (Activator.CreateInstance(type) as BaseScene)!);

        currentActiveSceneType = type;
    }


    internal World GetSceneWorld(Type type)
    {
        if (!scenes.ContainsKey(type))
            scenes.Add(type, (Activator.CreateInstance(type) as BaseScene)!);

        return scenes[type].world;
    }
}