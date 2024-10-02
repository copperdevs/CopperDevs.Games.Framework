namespace CopperDevs.Games.Framework.ECS.Systems;

public record struct SystemHolder(ISystem system)
{
    public ISystem system { get; set; } = system;
}
