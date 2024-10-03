using CopperDevs.Core.Utility;

namespace CopperDevs.Games.Framework.ECS;

public abstract class Component
{
    protected internal virtual void Start()
    {
    }

    protected internal virtual void Update()
    {
    }

    protected internal virtual void Stop()
    {
    }
}