using fennecs;

namespace CopperDevs.Games.Framework.Utility;

public static class Extensions
{
    public static TQueryBuilder Has<TQueryBuilder>(this TQueryBuilder queryBuilder, Type type)
        where TQueryBuilder : class
    {
        var queryBuilderType = queryBuilder.GetType();

        var method = queryBuilderType.GetMethod("Has", [typeof(Match)]);

        var genericMethod = method?.MakeGenericMethod(type);

        genericMethod?.Invoke(queryBuilder, [default(Match)]);

        return queryBuilder;
    }
}