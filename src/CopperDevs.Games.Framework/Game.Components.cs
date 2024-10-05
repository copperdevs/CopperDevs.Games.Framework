using CopperDevs.Games.Framework.ECS;

namespace CopperDevs.Games.Framework;

public partial class Game
{
    public void AddComponent<TComponent, TStreamType>()
        where TComponent : Component, new()
        where TStreamType : StreamType, new()
    {
        CreateEntity()
            .Add(new ComponentHolder(new TComponent()))
            .Add<TStreamType>()
            .Spawn()
            .Dispose();
    }

    private void UpdateComponents()
    {
        UpdateComponents<StreamTypes.For>();
        UpdateComponents<StreamTypes.Job>();
    }

    private void UpdateComponents<TStreamType>() where TStreamType : StreamType, new()
    {
        var stream = QueryEntities<ComponentHolder>()
            .Has<TStreamType>()
            .Stream();

        if (typeof(TStreamType) == typeof(StreamTypes.For))
            stream.For(static (ref ComponentHolder holder) => holder.Update());

        else if (typeof(TStreamType) == typeof(StreamTypes.Job))
            stream.Job(static (ref ComponentHolder holder) => holder.Update());
    }
}