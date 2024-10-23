namespace CopperDevs.Games.ECS.Systems;

internal record struct SystemHolder(BaseSystem BaseSystem, IFilter[] Filters);