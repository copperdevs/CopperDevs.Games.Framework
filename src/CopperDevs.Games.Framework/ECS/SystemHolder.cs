namespace CopperDevs.Games.Framework.ECS;

internal record struct SystemHolder(ISystem System, IFilter[] Filters);