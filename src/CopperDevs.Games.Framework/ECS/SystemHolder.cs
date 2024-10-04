namespace CopperDevs.Games.Framework.ECS;

public record struct SystemHolder(ISystem system, List<IFilter> filters);