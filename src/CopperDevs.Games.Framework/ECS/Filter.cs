namespace CopperDevs.Games.Framework.ECS;

public class Filter<TTargetType, TFilterType> : IFilter
    where TTargetType : notnull, new()
    where TFilterType : FilterType
{
}

public interface IFilter;