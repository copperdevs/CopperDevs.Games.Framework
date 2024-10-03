namespace CopperDevs.Games.Framework.ECS;

public readonly record struct ComponentHolder(Component Component)
{
    public void Start() => Component.Start();
    public void Update() => Component.Update();
    public void Stop() => Component.Stop();
}