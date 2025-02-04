namespace CopperDevs.Games.Framework.ECS;

public sealed class DefaultScene : BaseScene;

public abstract class BaseScene
{
    internal World world = new();
}

