using CopperDevs.Games.ECS.Utility;

namespace CopperDevs.Games.ECS;

public record struct HasFilter<TTargetType> : IFilter
    where TTargetType : notnull, new()
{
    public TQueryBuilder FilterQuery<TQueryBuilder>(TQueryBuilder queryBuilder)
        where TQueryBuilder : class
        => queryBuilder.Has(typeof(TTargetType));
}

public record struct NotFilter<TTargetType> : IFilter
    where TTargetType : notnull, new()
{
    public TQueryBuilder FilterQuery<TQueryBuilder>(TQueryBuilder queryBuilder)
        where TQueryBuilder : class
        => queryBuilder.Not(typeof(TTargetType));
}

public record struct AnyFilter<TTargetType> : IFilter
    where TTargetType : notnull, new()
{
    public TQueryBuilder FilterQuery<TQueryBuilder>(TQueryBuilder queryBuilder)
        where TQueryBuilder : class
        => queryBuilder.Any(typeof(TTargetType));
}

public interface IFilter
{
    public TQueryBuilder FilterQuery<TQueryBuilder>(TQueryBuilder queryBuilder) where TQueryBuilder : class;
}